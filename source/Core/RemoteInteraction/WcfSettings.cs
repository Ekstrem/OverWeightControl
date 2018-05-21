using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Settings;

namespace OverWeightControl.Core.RemoteInteraction
{
    internal static class WcfSettings
    {
        /// <summary>
        /// Получить адрес.
        /// </summary>
        /// <returns>Адрес сервиса.</returns>
        /// <exception cref="KeyNotFoundException">
        /// В DI-контейнере не были найдены настройки соединения.
        /// <c>MachineUrl</c> или <c>TcpPort</c>
        /// </exception>
        internal static Uri GetAddress(
            Binding binding,
            ISettingsStorage settings,
            IConsoleService console)
        {
            try
            {
                var uriBuilder = new UriBuilder(
                    scheme: binding.Scheme,
                    host: settings.Key(ArgsKeyList.ServerName),
                    port: int.Parse(settings.Key(ArgsKeyList.Port)),
                    pathValue: $"{typeof(IRemoteInteraction).Name}.svc");
                return new Uri($"{uriBuilder.Scheme}://{uriBuilder.Host}:{uriBuilder.Port}/{uriBuilder.Path}");
            }
            catch (Exception e)
            {
                console?.AddException(e);
                return null;
            }
        }

        internal static Binding GetBinding(
            ISettingsStorage settings,
            IConsoleService console)
        {
            string bindingName = settings?.Key(ArgsKeyList.Binding) ?? "Net";
            switch (bindingName)
            {
                case "Net":
                    return GetNetBinding(console);
                case "Custom":
                    return GetCustomBinding(settings, console);
                default:
                    return GetNetBinding(console);
            }
        }

        private static Binding GetNetBinding(IConsoleService console)
        {
            try
            {
                var binding = Activator.CreateInstance<NetTcpBinding>();
                binding.Security.Mode = SecurityMode.None;
                binding.TransferMode = TransferMode.StreamedRequest;
                binding.MaxBufferSize = Int32.MaxValue;
                binding.MaxReceivedMessageSize = Int32.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;

                return binding;
            }
            catch (Exception e)
            {
                console?.AddException(e);
                return null;
            }
        }

        private static Binding GetCustomBinding(
            ISettingsStorage settings,
            IConsoleService console)
        {
            var tcpBinding = GetNetBinding(console);
            try
            {
                var binding = (CustomBinding)Activator.CreateInstance(
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
                console?.AddException(e);
                return tcpBinding;
            }
        }

        private static void AddServiceMetadata(
            ISettingsStorage settings,
            IConsoleService console,
            ServiceHost host)
        {
            try
            {
                if (bool.TryParse(settings.Key(ArgsKeyList.IsDebugMode), out bool isDebug)
                    && isDebug)
                {
                    var smb = new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true,
                        HttpGetUrl =
                            new Uri(
                                $"http://{settings.Key(ArgsKeyList.ServerName)}:{settings.Key(ArgsKeyList.Port)}/mex")
                    };

                    host.Description.Behaviors.Add(smb);
                }
            }
            catch (Exception e)
            {
                console?.AddException(e);
                console?.AddEvent("MEX does not activated.", ConsoleMessageType.Information);
            }
        }

    }
}