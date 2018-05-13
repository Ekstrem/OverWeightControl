using System;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer;
using OverWeightControl.Core.Settings;

namespace OverWeightControl.Core.RemoteInteraction.Test
{
    public static class Class1
    {
        public static void Main(params string[] args)
        {
            IConsoleService console = new DefaultConsoleService();
            ISettingsStorage settings = new DefaultSettingsStorage(console);

            var h = new Host(console, settings);
            var p = new Proxy(console,settings);
            var proxy = p.RemoteStorage();

            //proxy.SendFile(Guid.Empty, new FileTransferInfo());
            var res = proxy.Ping();
            System.Console.WriteLine(res);
            

            System.Console.ReadKey();
            h.Dispose();
            p.Dispose();
        }
    }
}
