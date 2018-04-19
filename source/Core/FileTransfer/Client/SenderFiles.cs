using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity.Attributes;

namespace OverWeightControl.Core.FileTransfer.Client
{
    public class SenderFiles : WorkFlowDecoratorBase
    {
        #region Lifetime

        [InjectionConstructor]
        public SenderFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(SenderFiles)} ready.");
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

        public override string Description => $"Отправка файлов на сервер";
    }
}