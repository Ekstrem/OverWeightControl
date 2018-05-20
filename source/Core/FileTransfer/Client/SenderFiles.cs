using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.RemoteInteraction;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.Client
{
    public class SenderFiles : WorkFlowDecoratorBase
    {
        private IRemoteInteraction _proxy;

        #region Lifetime

        [InjectionConstructor]
        public SenderFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console,
            Proxy proxy)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(SenderFiles)} ready.");
            _proxy = proxy.RemoteStorage();
        }

        ~SenderFiles()
        {
            Dispose();
        }

        /// <summary>
        ///   Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public override void Dispose()
        {
            _console.AddEvent($"{nameof(SenderFiles)} stoped.");
            base.Dispose();
        }

        #endregion

        /// <summary>
        /// Производит операцию над файлом, согласно назначению класса.
        /// </summary>
        /// <param name="fileTransferInfo">Информация о классе.</param>
        /// <returns>Обработанный класс.</returns>
        protected override FileTransferInfo DetailedProc(FileTransferInfo fileTransferInfo)
        {
            try
            {
                var ser = new DataContractSerializer(typeof(FileTransferInfo));
                MemoryStream memoryStream = new MemoryStream();
                ser.WriteObject(memoryStream, fileTransferInfo);
                var des = Encoding.UTF8.GetString(memoryStream.GetBuffer());
                var s = _proxy.Ping();
                var result = _proxy.SendFile(fileTransferInfo.Id, fileTransferInfo);
                var resLog = JsonConvert.SerializeObject(result, Formatting.Indented);
                _console.AddEvent(resLog, ConsoleMessageType.Information);
                return result.Commited ? null : fileTransferInfo;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                throw;
            }
        }

        public override string Description => $"Отправка файлов на сервер";
    }
}