using System;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer;
using OverWeightControl.Core.FileTransfer.Server;
using OverWeightControl.Core.Settings;
using Unity;

namespace OverWeightControl.Core.RemoteInteraction.Test
{
    public static class Class1
    {
        public static void Main(params string[] args)
        {
            IConsoleService console = new DefaultConsoleService();
            ISettingsStorage settings = new DefaultSettingsStorage(console);
            IUnityContainer container = new UnityContainer();
            container
                .RegisterType<IConsoleService, DefaultConsoleService>()
                .RegisterType<ISettingsStorage, DefaultSettingsStorage>()
                .RegisterType<IRemoteInteraction, RecivingFiles>();

            var h = container.Resolve<Host>();
            var p = container.Resolve<Proxy>();
            var proxy = p.RemoteStorage<IRemoteInteraction>();

            var res = proxy.Ping();
            System.Console.WriteLine(res);
            
            proxy.SendFile(Guid.Empty, new FileTransferInfo());

            System.Console.ReadKey();
            h.Dispose();
            p.Dispose();
        }
    }
}
