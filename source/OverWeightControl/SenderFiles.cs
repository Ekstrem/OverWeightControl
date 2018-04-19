using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;

namespace OverWeightControl
{
    /// <summary>
    /// Отправляет файл на сервер.
    /// </summary>
    public class SenderFiles : WorkFlowDecoratorBase
    {
        #region Lifetime

        public SenderFiles(
            IWorkFlowProducerConsumer consumer,
            ISettingsStorage settings,
            IConsoleService console)
            : base(consumer, settings, console)
        {
            _console.AddEvent($"{nameof(SenderFiles)} ready.");
        }

        /// <summary>
        /// Выполняет определяемые приложением задачи, связанные с удалением,
        /// высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public override void Dispose()
        {
            _console.AddEvent($"{nameof(SenderFiles)} stoped.");
            base.Dispose();
        }

        #endregion

        public override string Description => $"Песылка файлов";
    }
}