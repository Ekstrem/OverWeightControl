using System;
using System.ServiceModel;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.Server;
using OverWeightControl.Core.Settings;
using Unity;

namespace OverWeightControl.Core.RemoteInteraction
{
    public class Host : IDisposable
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private readonly IUnityContainer _container;
        private ServiceHost _host;

        #region LifeTime

        public Host(
            IConsoleService console,
            ISettingsStorage settings,
            IUnityContainer container)
        {
            _console = console;
            _settings = settings;
            _container = container;
            HostStorageCommitment();
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

        public bool HostStorageCommitment()
        {
            try
            {
                var binding = WcfSettings.GetBinding(
                    settings: _settings,
                    console: _console);
                var uri = WcfSettings.GetAddress(
                    binding: binding,
                    settings: _settings,
                    console: _console);
                _host = new ServiceHost(typeof(RecivingFiles), uri);
                _host.AddServiceEndpoint(
                    typeof(IRemoteInteraction),
                    binding,
                    uri);

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
    }
}
