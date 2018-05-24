using System;
using System.IO;
using System.Text;
using OverWeightControl.Common.BelModel;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.RecognitionServer
{
    public class JsonReadFiles : WorkFlowDecoratorBase
    {
        #region LifeTime

        [InjectionConstructor]
        public JsonReadFiles(
            ISettingsStorage settings,
            IConsoleService console,
            IWorkFlowProducerConsumer consumer)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(JsonReadFiles)} ready.");
        }

        ~JsonReadFiles()
        {
            Dispose();
        }

        public override void Dispose()
        {
            _console.AddEvent($"{nameof(JsonReadFiles)} stoped.");
            base.Dispose();
        }

        #endregion

        protected override FileTransferInfo DetailedProc(FileTransferInfo fileTransferInfo)
        {
            try
            {
                var json = Encoding.UTF8.GetString(fileTransferInfo.Data);
                var bl = BlankList.GetList(json);
                var parsedAct = bl.ToModelFormat();

                return fileTransferInfo;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                var dir = $"{AppDomain.CurrentDomain.BaseDirectory}Errors";
                if (Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                File.WriteAllBytes(
                    $"{dir}{fileTransferInfo.Id}.{fileTransferInfo.Ext}",
                    fileTransferInfo.Data);
                return null;
            }
        }

        public override string Description => "Загружено файлов для верификации";
    }
}
