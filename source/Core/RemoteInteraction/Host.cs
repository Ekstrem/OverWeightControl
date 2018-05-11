using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.Server;
using OverWeightControl.Core.Settings;

namespace OverWeightControl.Core.RemoteInteraction
{
    public class Host : IDisposable
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private ServiceHost _host;

        public Host(
            IConsoleService console,
            ISettingsStorage settings)
        {
            _console = console;
            _settings = settings;
            HostStorageCommitment();
        }

        ~Host()
        {
            Dispose();
        }

        public void Dispose()
        {
            _host.Close();
            _host = null;
        }

        public bool HostStorageCommitment()
        {
            try
            {
                var binding = GetBinding();
                var uri = GetAddress(binding);
                _host = new ServiceHost(typeof(RecivingFiles), uri);
                _host.AddServiceEndpoint(
                    typeof(IRemoteInteraction),
                    binding,
                    uri);

                AddServiceMetadata();
                
                return true;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return false;
            }
        }

        private void AddServiceMetadata()
        {
            if (bool.TryParse(_settings.Key(ArgsKeyList.IsDebugMode), out bool isDebug)
                && isDebug)
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = new Uri($"http://localhost:{_settings.Key(ArgsKeyList.Port)}/mex");
                _host.Description.Behaviors.Add(smb);
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
                return new Uri($"{uriBuilder.Scheme}://{uriBuilder.Host}/{uriBuilder.Path}");
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
                binding.TransferMode = TransferMode.StreamedRequest;

                return binding;
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return null;
            }
        }
    }
}
