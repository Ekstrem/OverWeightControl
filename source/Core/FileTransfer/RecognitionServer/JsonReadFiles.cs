using System;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.RecognitionServer
{
    public class JsonReadFiles : WorkFlowDecoratorBase, IDisposable
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
            return base.DetailedProc(fileTransferInfo);
        }

        public override string Description => "Загружено файлов для верификации";
    }
}
