using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.Server;
using OverWeightControl.Core.Settings;
using Unity;
using Unity.Attributes;
using Unity.Interception.Utilities;

namespace OverWeightControl.Core.RemoteInteraction
{
    public class Host : IDisposable
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private readonly IUnityContainer _container;
        private ServiceHost _host;

        #region LifeTime

        [InjectionConstructor]
        public Host(
            IConsoleService console,
            ISettingsStorage settings,
            IUnityContainer container)
        {
            _console = console;
            _settings = settings;
            _container = container;

            FindAndHost()
                .ForEach(e => HostService(e.Value, e.Key));
        }

        ~Host()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_host != null)
            {
                if (_host.State != CommunicationState.Faulted)
                    _host.Close();
                _host = null;
            }
        }

        #endregion

        public CommunicationState State => _host.State;

        public bool HostService(Type service, Type implamentation)
        {
            try
            {
                var binding = WcfSettings.GetBinding(
                    settings: _settings,
                    console: _console);
                var uri = WcfSettings.GetAddress<IRemoteInteraction>(
                    binding: binding,
                    settings: _settings,
                    console: _console);
                _host = new ServiceHost(implamentation, uri);
                _host.AddServiceEndpoint(
                    implementedContract: service,
                    binding: binding,
                    address: uri);

                // AddServiceMetadata();

                _host.Description.Behaviors.Add(_container.Resolve<UnityServiceBehavior>());

                _host.Open();

                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }

        private IDictionary<Type, Type> FindAndHost()
        {
            // get service contracts
            var services = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(TryGetTypes)
                .Where(f => f.IsInterface
                            && f.Namespace != null
                            && f.Namespace.StartsWith("OverWeightControl.")
                            && f.IsDefined(typeof(ServiceContractAttribute), false));
            // get service realization
            var result = new Dictionary<Type, Type>();
            foreach (var service in services)
            {
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(TryGetTypes)
                    .Where(f => f.IsClass
                                && f.Namespace != null
                                && f.Namespace.StartsWith("OverWeightControl.")
                                && f.GetInterfaces().Contains(service))
                    .ForEach(e => result.Add(e, service));
            }

            return result;
        }

        private Type[] TryGetTypes(Assembly asm)
        {
            try
            {
                return asm.GetTypes();
            }
            catch (Exception ex)
            {
                return new Type[] { };
            }
        }
    }
}
