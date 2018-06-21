using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace OverWeightControl.Clients.ActsUI.Tools
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
                return source
                    .AsQueryable()
                    .ApplyOrder(property, methodName)
                    .AsEnumerable();
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
            this IQueryable<T> source,
            string columnName,
            string filterValue,
            string operation)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                Expression column = Expression.Property(parameter, columnName);

                var constant = Expression.Constant(filterValue.ToLower());
                Expression[] methodArgs = {constant};

                var toStringCall = Expression.Call(column, "ToString", Type.EmptyTypes);
                var toLowerCall = Expression.Call(toStringCall, "ToLower", Type.EmptyTypes);
                MethodInfo method = typeof(string).GetMethod(operation, new[] {typeof(string)});
                Expression predicateCall = Expression.Call(toLowerCall, method, methodArgs);
                var lambda = Expression.Lambda<Func<T, bool>>(predicateCall, parameter);

                return source.Where(lambda);

                // return source.Provider.CreateQuery<T>(lambda);

                /*'(.Lambda #Lambda1<System.Func`2[OverWeightControl.Common.Model.Act,System.Boolean]>)

                    .Lambda #Lambda1<System.Func`2[OverWeightControl.Common.Model.Act,System.Boolean]>(OverWeightControl.Common.Model.Act $f)
                {
                    .Call(.Call(.Call($f.PpvkNumber).ToString()).ToLower()).Contains("1")
                }*/
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> source,
            string columnName,
            string filterValue,
            string operation)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                Expression column = Expression.Property(parameter, columnName);

                var constant = Expression.Constant(filterValue.ToLower());
                Expression[] methodArgs = { constant };

                var toStringCall = Expression.Call(column, "ToString", Type.EmptyTypes);
                var toLowerCall = Expression.Call(toStringCall, "ToLower", Type.EmptyTypes);
                MethodInfo method = typeof(string).GetMethod(operation, new[] { typeof(string) });
                Expression predicateCall = Expression.Call(toLowerCall, method, methodArgs);
                var lambda = Expression.Lambda<Func<T, bool>>(predicateCall, parameter);

                return source.Where(lambda.Compile());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> source,
            IDictionary<ColumnInfo, SearchingTerm> terms)
        {
            if (terms == null)
                return source;

            return terms.Keys.Aggregate(
                    source, 
                    (current, term) => current.Where(term.Description, terms[term].SearchingData, terms[term].Mode.Mode.ToString()));
        }

        private static MethodInfo GetGenericMethod(
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