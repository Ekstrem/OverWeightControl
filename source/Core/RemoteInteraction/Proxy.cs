﻿using System;
 using System.ServiceModel;
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
                var binding = WcfSettings.GetBinding(
                    settings: _settings,
                    console: _console);
                var address = new EndpointAddress(
                    WcfSettings.GetAddress(
                        binding: binding,
                        settings: _settings,
                        console: _console)
                        .AbsoluteUri);
                _factory = new ChannelFactory<IRemoteInteraction>(binding, address);
                return  _factory.CreateChannel();
            }
            catch (Exception e)
            {
                _console?.AddException(e);
                return null;
            }
        }
    }
}
