using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Builder;
using Unity.Events;
using Unity.Extension;
using Unity.Interception.Utilities;

namespace OverWeightControl.Core.Unity
{
    public class DecoratorContainerExtension
        : UnityContainerExtension
    {
        private Dictionary<Type, Queue<Type>> _typeStacks;
        private static HashSet<Type> _allowedDecorators;

        public DecoratorContainerExtension(params Type[] decorators)
            : base()
        {
            _typeStacks = new Dictionary<Type, Queue<Type>>();
            _allowedDecorators = new HashSet<Type>();

            foreach (var decorator in decorators)
            {
                _allowedDecorators.Add(decorator);
            }
        }

        protected override void Initialize()
        {
            Context.Registering += AddRegistration;

            Context.Strategies.Add(
                new DecoratorBuildStrategy(_typeStacks),
                UnityBuildStage.PreCreation
            );
        }

        private void AddRegistration(
            object sender,
            RegisterEventArgs e)
        {
            var type = e.TypeFrom;
            var b = e.TypeTo.GetInterfaces()
                .Any(f => _allowedDecorators.Contains(f));
            if (!b)
            {
                return;
            }

            Queue<Type> stack = null;
            if (!_typeStacks.ContainsKey(type))
            {
                stack = new Queue<Type>();
                _typeStacks.Add(type, stack);
            }
            else
            {
                stack = _typeStacks[type];
            }

            stack.Enqueue(e.TypeTo);
        }

        public static void AllowType<T>() => _allowedDecorators.Add(typeof(T));
    }

}
