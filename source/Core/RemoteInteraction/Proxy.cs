﻿using System;
 using System.Collections.Generic;
 using System.ServiceModel;
using System.ServiceModel.Channels;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;

namespace OverWeightControl.Core.RemoteInteraction
{
    public class Proxy : IDisposable
    {
        private readonly IConsoleService _console;
        private readonly ISettingsStorage _settings;
        private ChannelFactory<IRemoteInteraction> _factory;

        #region LifeTime

        public Proxy(
            IConsoleService console,
            ISettingsStorage settings)
        {
            _console = console;
            _settings = settings;
        }

        ~Proxy() { Dispose(); }

        public void Dispose()
        {
            _factory.Close();
        }

        #endregion

        public CommunicationState State => _factory.State;

        public IRemoteInteraction RemoteStorage()
        {
            try
            {
                var binding = GetBinding();
                var address = new EndpointAddress(GetAddress(binding).AbsoluteUri);
                _factory = new ChannelFactory<IRemoteInteraction>(binding, address);
                return  _factory.CreateChannel();
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return null;
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
