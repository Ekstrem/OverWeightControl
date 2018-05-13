using System.ServiceModel;
using Unity;

namespace OverWeightControl.Core.RemoteInteraction
{
    public class UnityServiceHost : ServiceHost
    {
        private readonly IUnityContainer _container;

        public UnityServiceHost( IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        ///   Вызывается в процессе перехода объекта связи в состояние открытия.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add(_container.Resolve<UnityServiceBehavior>());
            base.OnOpening();
        }
    }
}