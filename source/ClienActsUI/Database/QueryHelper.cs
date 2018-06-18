using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace OverWeightControl.Clients.ActsUI.Database
{
    public static class QueryHelper
    {
        public static IEnumerable<T> ApplyOrder<T>(
            this IEnumerable<T> source,
            string property,
            string methodName)
        {
            try
            {
                return source.AsQueryable().ApplyOrder(property, methodName).AsEnumerable();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IQueryable<T> ApplyOrder<T>(
            this IQueryable<T> source,
            string property,
            string methodName)
        {
            try
            {
                //Создаем аргумент лямбда выражения. в данном случае мы формируем лямбду x => x.property, а значит аргумент будет один
                var arg = Expression.Parameter(typeof(T), "x");
                //Начинаем построение дерева выражения. x => x. Возвращаем переданный аргумент без изменений
                Expression expr = arg;

                //Второй и последний шаг построения дерева выражения. Обращаемся к свойству property. x => x.property
                expr = Expression.Property(expr, property);

                //Создаем из дерева выражений лямбду, привязываем к ней аргумент
                var lambda = Expression.Lambda(expr, arg);

                //Находим в классе Queryable метод с именем methodName. Магия поиска и создания шаблонного метода чуть ниже
                var method = typeof(Queryable).GetGenericMethod(
                    methodName,
                    //Типы аргументов шаблона метода
                    new[] { typeof(T), expr.Type },
                    //Типы параметров метода
                    new[] { source.GetType(), lambda.GetType() }
                );
                //Выполняем метод, передавая ему неявный параметр this и лямбду. 
                //Т.е. выполняем source.OrderBy(x => x.property);
                return (IOrderedQueryable<T>)method.Invoke(null, new object[] { source, lambda });
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IQueryable<T> Where<T>(
            IQueryable<T> source,
            string columnName,
            string filterValue)
        {
            try
            {
                ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
                Expression property = Expression.Property(parameter, columnName);
                Expression constant = Expression.Constant(filterValue);
                Expression equality = Expression.Equal(property, constant);
                Expression<Func<T, bool>> predicate =
                    Expression.Lambda<Func<T, bool>>(equality, parameter);
                Func<T, bool> compiled = predicate.Compile();
                return (IQueryable<T>)source.Where(compiled);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static MethodInfo GetGenericMethod(
            this Type type,
            string name,
            Type[] genericTypeArgs,
            Type[] paramTypes)
        {
            return type.GetMethods(BindingFlags.NonPublic 
                                   | BindingFlags.Public 
                                   | BindingFlags.Instance 
                                   | BindingFlags.Static)
                .Where(f => f.IsGenericMethod 
                            && f.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                .Select(abstractGenericMethod => new {abstractGenericMethod, pa = abstractGenericMethod.GetParameters()})
                .Where(@t => @t.pa.Length == paramTypes.Length)
                .Select(@t => @t.abstractGenericMethod.MakeGenericMethod(genericTypeArgs))
                //.Where(f => f.GetParameters().Select(p => p.ParameterType).SequenceEqual(paramTypes, new TestAssignable()))
                .FirstOrDefault();
        }

        private class TestAssignable : IEqualityComparer<Type>
        {
            public bool Equals(Type x, Type y)
            {
                //Если тип значение типа y может использовано в качестве значения типа x, то нас это устраивает
                return x.IsAssignableFrom(y);
            }

            public int GetHashCode(Type obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}