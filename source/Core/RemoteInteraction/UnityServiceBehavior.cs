using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Unity;
using Unity.Interception.Utilities;

namespace OverWeightControl.Core.RemoteInteraction
{
    /// <summary>
    /// Перезагрузка поведения службы.
    /// </summary>
    internal class UnityServiceBehavior : IServiceBehavior
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="UnityServiceBehavior"/>
        /// </summary>
        /// <param name="container">DI контейнер.</param>
        /// <exception cref="ArgumentNullException">
        /// <see cref="container"/> равно <c>null</c>.
        /// </exception>
        public UnityServiceBehavior(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Provides the ability to inspect the service host and
        /// the service description to confirm that the service can run successfully.
        /// </summary>
        /// <param name="serviceDescription">Информация о сервисе.</param>
        /// <param name="serviceHostBase">Хостинг сервиса.</param>
        public void Validate(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        /// Provides the ability to pass custom data to binding elements
        /// to support the contract implementation.
        /// </summary>
        /// <param name="serviceDescription">Информация о сервисе.</param>
        /// <param name="serviceHostBase">Хостинг сервиса.</param>
        /// <param name="endpoints">Конечные точки сервиса.</param>
        /// <param name="bindingParameters">Параметры привязки.</param>
        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Provides the ability to change run-time property values
        /// or insert custom extension objects such as error handlers,
        /// message or parameter interceptors, security extensions,
        /// and other custom extension objects.
        /// </summary>
        /// <param name="serviceDescription">Информация о сервисе.</param>
        /// <param name="serviceHostBase">Хостинг сервиса.</param>
        /// <exception cref="ArgumentNullException">
        /// Один из аргументов является <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// У сервиса нет ни одного публичного метода.
        /// </exception>
        public void ApplyDispatchBehavior(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
            var serviceType = serviceDescription.ServiceType;
            var methods = serviceType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.DeclaringType == serviceType).ToArray();
            if (methods.Length == 0)
            {
                throw new InvalidOperationException(
                    "Service does not have any public methods!");
            }

            OverrideInstanceProvider(serviceDescription, serviceHostBase);
        }

        /// <summary>
        /// Каждому прослушивателю конечной точки предоставляет <c>InstanceProvider</c>
        /// <see cref="UnityInstanceProvider"/> со логикой внедрения зависимостей.
        /// </summary>
        /// <param name="serviceDescription">Экземпляр <see cref="ServiceDescription"/>.</param>
        /// <param name="serviceHostBase">Экземпляр <see cref="ServiceHostBase"/></param>
        private void OverrideInstanceProvider(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase)
        {
            serviceHostBase.ChannelDispatchers
                .OfType<ChannelDispatcher>()
                .ForEach(cd => ConfigureChannelDispatcher(serviceDescription, cd));
        }

        private void ConfigureChannelDispatcher(
            ServiceDescription serviceDescription, ChannelDispatcher dispatcher)
        {
            dispatcher.Endpoints.ForEach(endpoint =>
            {
                endpoint.DispatchRuntime.InstanceProvider =
                    new UnityInstanceProvider(_container, serviceDescription.ServiceType);
                endpoint.DispatchRuntime.ConcurrencyMode = ConcurrencyMode.Multiple;
            });
        }
    }
}