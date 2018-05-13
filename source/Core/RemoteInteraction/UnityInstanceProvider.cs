using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Unity;

namespace OverWeightControl.Core.RemoteInteraction
{
    /// <summary>
    /// Управление созданием объектов служб.
    /// </summary>
    internal class UnityInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;
        private readonly IUnityContainer _container;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="UnityInstanceProvider"/>
        /// </summary>
        /// <param name="container">DI контейнер.</param>
        /// <param name="serviceType">Тип сервиса.</param>
        /// <exception cref="ArgumentNullException">
        /// Один из параметров равен <c>null</c>.
        /// </exception>
        public UnityInstanceProvider(IUnityContainer container, Type serviceType)
        {
            _serviceType = serviceType;
            _container = container;
        }

        /// <summary>
        /// Создаёт экземпляр службы.
        /// </summary>
        /// <param name="instanceContext">Класс соединяющий экземпляр и среду выполнения.</param>
        /// <returns>Экземпляр службы.</returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Создаёт экземпляр службы.
        /// </summary>
        /// <param name="instanceContext">Класс соединяющий экземпляр и среду выполнения.</param>
        /// <param name="message">Сообщение SOAP.</param>
        /// <returns>Экземпляр службы.</returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return ((IUnityContainer) _container).Resolve(_serviceType);
        }

        /// <summary>
        /// Освобождение экземпляра.
        /// </summary>
        /// <param name="instanceContext">Класс соединяющий экземпляр и среду выполнения.</param>
        /// <param name="instance">Экземпляр службы.</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            (instance as IDisposable).Dispose();
        }
    }
}