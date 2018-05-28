using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using OverWeightControl.Common.BelModel;
using OverWeightControl.Common.Model;
using OverWeightControl.Core.Clients;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity;
using Unity.Attributes;
using Unity.Interception.Utilities;

namespace OverWeightControl.Core.FileTransfer.RecognitionServer
{
    public class JsonReadFiles : WorkFlowDecoratorBase
    {
        private readonly ModelContext _context;
        private readonly Form _validationForm;

        #region LifeTime

        [InjectionConstructor]
        public JsonReadFiles(
            ISettingsStorage settings,
            IConsoleService console,
            IWorkFlowProducerConsumer consumer,
            DbContext context,
            IUnityContainer container)
            : base(consumer, settings, console)
        {
            _context = (ModelContext)context;
            _console.AddEvent($"{nameof(JsonReadFiles)} ready.");
            /*if (!String.IsNullOrEmpty(settings.Key(ArgsKeyList.HandValidation)))
            {
                _validationForm = container.Resolve<Form>("ValidationForm");
            }*/
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

        protected override FileTransferInfo DetailedProc( FileTransferInfo fileTransferInfo)
        {
            try
            {
                var json = Encoding.UTF8.GetString(fileTransferInfo.Data);
                var bl = BlankList.GetList(
                    json,
                    ex => _console?.AddException(ex));
                var parsedAct = bl.ToModelFormat(ex => _console?.AddException(ex));
                if (bool.TryParse(_settings[ArgsKeyList.HandValidation], out bool buf)
                    && buf
                    && ((IEditable<Act>)_validationForm).LoadData(parsedAct)
                    && _validationForm.ShowDialog() == DialogResult.OK
                    && ((IEditable<Act>)_validationForm).UpdateData(parsedAct)) { }

                _context.Acts.Add(parsedAct);
                _context.SaveChanges();

                return fileTransferInfo;
            }
            catch (DbEntityValidationException ve)
            {
                _console.AddException(ve);
                ve.EntityValidationErrors
                    .SelectMany(sm => sm.ValidationErrors)
                    .ForEach(e => _console.AddEvent(e.ErrorMessage, ConsoleMessageType.Exception));
                ErrorFileCopy(fileTransferInfo);

                return fileTransferInfo;
            }
            catch (Exception e)
            {
                _console.AddException(e);
                ErrorFileCopy(fileTransferInfo);
                return fileTransferInfo;
            }
        }

        public override string Description => "Загружено файлов для верификации";

        private void ErrorFileCopy(FileTransferInfo fileTransferInfo)
        {
            var dir = $"{AppDomain.CurrentDomain.BaseDirectory}Errors\\";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            File.WriteAllBytes(
                $"{dir}{fileTransferInfo.Id}.{fileTransferInfo.Ext}",
                fileTransferInfo.Data);
        }
    }
}
