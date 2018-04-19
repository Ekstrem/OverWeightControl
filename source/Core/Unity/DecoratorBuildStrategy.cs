using System;
using System.Collections.Generic;
using Unity.Builder;
using Unity.Builder.Strategy;
using Unity.Resolution;

namespace OverWeightControl.Core.Unity
{
    public class DecoratorBuildStrategy : BuilderStrategy
    {
        private readonly Dictionary<Type, List<Type>> _typeStacks;

        public DecoratorBuildStrategy(
            Dictionary<Type, List<Type>> typeStacks)
        {
            _typeStacks = typeStacks;
        }

        public override void PreBuildUp(IBuilderContext context)
        {
            var key = context.OriginalBuildKey;

            if (!(key.Type.IsInterface
                && _typeStacks.ContainsKey(key.Type))
                || context.GetOverriddenResolver(key.Type) != null)
            {
                return;
            }

            
            var stack = new Queue<Type>(_typeStacks[key.Type]);

            object value = null;
            while (stack.Count != 0)
            {
                var t = stack.Dequeue();
                value = context.NewBuildUp(t, key.Name);
                var overrides = new DependencyOverride(
                    key.Type, value);
                context.AddResolverOverrides(overrides);
            }

            /*stack.ForEach(t =>
                {
                    value = context.NewBuildUp(t, key.Name);
                    var overrides = new DependencyOverride(
                        key.Type, value);
                    context.AddResolverOverrides(overrides);
                }
            );*/

            context.Existing = value;
            context.BuildComplete = true;
        }
    }

}
