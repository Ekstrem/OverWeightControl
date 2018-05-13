using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Unity;

namespace OverWeightControl.Core.RemoteInteraction
{
    /// <summary>
    /// Фабрика создания <see cref="ServiceHost"/>.
    /// Предназначен для активации в IIS окружении.
    /// </summary>
    /// <remarks>
    /// Класс не требуется для работы библиотеки,
    /// но рекомендуется его реализация.
    /// </remarks>
    internal class UnityServiceHostFactory : ServiceHostFactory
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="UnityServiceHostFactory"/>
        /// </summary>
        /// <param name="container">DI контейнер.</param>
        /// <remarks>
        /// Активации в IIS может и не случится,
        /// т.к. это не конструктор по умолчанию.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// <see cref="container"/> равен <c>null</c>.
        /// </exception>
        public UnityServiceHostFactory(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Перезагрузка фабричного метода.
        /// </summary>
        /// <param name="serviceType">Тип сервиса.</param>
        /// <param name="baseAddresses">Адрес конечной точки.</param>
        /// <returns>Хостер службы.</returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            // veu: возможно что-то придётся добавить что бы стартанула такая фабрика.
            return (ServiceHost) _container.Resolve<ServiceHostBase>();
        }
    }
}