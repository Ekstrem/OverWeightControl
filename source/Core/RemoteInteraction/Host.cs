using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
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
                var binding = GetBinding();
                var uri = GetAddress(binding);
                _host = new ServiceHost(typeof(RecivingFiles), uri);
                _host.Opening += _host_Opening;
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

        private void _host_Opening(object sender, EventArgs e)
        {
            return;
            /* Description.Behaviors.Add(_container.RestrictedResolve<UnityServiceBehavior>());

            base.OnOpening(); */
        }

        private void AddServiceMetadata()
        {
            try
            {
                if (bool.TryParse(_settings.Key(ArgsKeyList.IsDebugMode), out bool isDebug)
                    && isDebug)
                {
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.HttpGetUrl =
                        new Uri(
                            $"http://{_settings.Key(ArgsKeyList.ServerName)}:{_settings.Key(ArgsKeyList.Port)}/mex");
                    _host.Description.Behaviors.Add(smb);
                }
            }
            catch (Exception e)
            {
                _console.AddException(e);
                _console.AddEvent("MEX does not activated.", ConsoleMessageType.Information);
            }
        }

        /// <summary>
        /// Получить адрес.
        /// </summary>
        /// <returns>Адрес сервиса.</returns>
        /// <exception cref="KeyNotFoundException">
        /// В DI-контейнере не были найдены настройки соединения.
        /// <c>MachineUrl</c> или <c>TcpPort</c>
        /// </exception>
        private Uri GetAddress(Binding binding)
        {
            try
            {
                var uriBuilder = new UriBuilder(
                    scheme: binding.Scheme,
                    host: _settings.Key(ArgsKeyList.ServerName),
                    port: int.Parse(_settings.Key(ArgsKeyList.Port)),
                    pathValue: $"{typeof(IRemoteInteraction).Name}.svc");
                return new Uri($"{uriBuilder.Scheme}://{uriBuilder.Host}:{uriBuilder.Port}/{uriBuilder.Path}");
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return null;
            }
        }

        private Binding GetBinding()
        {
            try
            {
                var binding = Activator.CreateInstance<NetTcpBinding>();
                binding.Security.Mode = SecurityMode.None;
                binding.TransferMode = TransferMode.StreamedRequest;
                binding.MaxBufferSize = int.MaxValue;
                binding.MaxReceivedMessageSize = int.MaxValue;

                return binding;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return null;
            }
        }

        private Binding GetCustomBinding()
        {
            var tcpBinding = GetBinding();
            try
            {
                var binding = (CustomBinding) Activator.CreateInstance(
                    typeof(CustomBinding), tcpBinding);
                var rbe = new ReliableSessionBindingElement();
                binding.Elements.Add(rbe);
                var bme = Activator.CreateInstance<BinaryMessageEncodingBindingElement>();
                bme.CompressionFormat = CompressionFormat.GZip;
                binding.Elements.Add(bme);
                var tf = Activator.CreateInstance<TransactionFlowBindingElement>();
                binding.Elements.Add(tf);

                return binding;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                return tcpBinding;
            }
        }
    }
}
