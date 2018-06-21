using System;
using System.Collections.Concurrent;
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
        private IDictionary<Type, ServiceHost> _hosts;

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

            _hosts = new ConcurrentDictionary<Type, ServiceHost>();
            FindAndHost()
                .ForEach(e => HostService(e.Value, e.Key));
        }

        ~Host()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_hosts != null)
            {
                _hosts
                    .Where(f => f.Value.State != CommunicationState.Faulted)
                    .ForEach(e => e.Value.Close());
                _hosts.Clear();
            }
        }

        #endregion

        public CommunicationState State => _hosts.FirstOrDefault().Value.State;

        public bool HostService(Type service, Type implamentation)
        {
            try
            {
                if (_hosts == null || _hosts.ContainsKey(service))
                    return false;

                var binding = WcfSettings.GetBinding(
                    settings: _settings,
                    console: _console);
                var uri = WcfSettings.GetAddress(
                    type: service,
                    binding: binding,
                    settings: _settings,
                    console: _console);
                var host = new ServiceHost(implamentation, uri);
                host.AddServiceEndpoint(
                    implementedContract: service,
                    binding: binding,
                    address: uri);

                // AddServiceMetadata();

                host.Description.Behaviors.Add(_container.Resolve<UnityServiceBehavior>());

                host.Open();

                _hosts.Add(service, host);

                _console.AddEvent($"{implamentation} hosted.");

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
                _console.AddException(ex);
                return new Type[] { };
            }
        }
    }
}
