using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OverWeightControl.Clients.ActsUI;
using OverWeightControl.Clients.ActsUI.Database;
using OverWeightControl.Common.Serialization;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.ConsoleService;
using OverWeightControl.Core.FileTransfer;
using OverWeightControl.Core.FileTransfer.Client;
using OverWeightControl.Core.FileTransfer.RecognitionServer;
using OverWeightControl.Core.FileTransfer.Server;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.RemoteInteraction;
using OverWeightControl.Core.Settings;
using OverWeightControl.Core.Upgrade;
using Unity;
using Unity.Lifetime;

namespace OverWeightControl
{
    [JsonObject]
    public class CompositionRoot
    {
        private static string _fileName = "starts.cfg";
        private static string _fullName => $"{AppDomain.CurrentDomain.BaseDirectory}{_fileName}";

        private CompositionRoot()
        {
            NodeRoles= new List<NodeRole>();
        }

        internal static CompositionRoot Factory()
        {
            if (File.Exists(_fullName))
            {
                ins = LoadFromFile();
                return ins;
            }
            else
            {
                ins = new CompositionRoot();
                ins.SetDefaultDependency();
                ins.SaveConfigToFile();
                return ins;
            }
        }

        private void SetDefaultDependency()
        {
            InfrastructureDependencies = GetInfrastructureDependencies();
            WorkFlowDependencies = GetWorkFlowDependencies();
            ApplicationsDependencies = GetApplicationsDependencies();
        }


        private static IUnityContainer s_container;
        private static CompositionRoot ins;
        public static CompositionRoot Instance => ins ?? Factory();

        [JsonIgnore]
        public static IUnityContainer Container => s_container
                                                   ?? (s_container = new UnityContainer());

        [JsonProperty]
        public ICollection<Dependency> ApplicationsDependencies { get; set; }
        private ICollection<Dependency> GetApplicationsDependencies()
        {
            return new List<Dependency>
            {
                new Dependency(1)
                {
                    Abstractions = typeof(Form),
                    Realization = typeof(ActEditForm),
                    Name = nameof(ActEditForm),
                    Register = true
                },
                new Dependency(2)
                {
                    Abstractions = typeof(Form),
                    Realization = typeof(EditorSettingsStorage),
                    Name = nameof(EditorSettingsStorage),
                    Register = true
                },
                new Dependency(3)
                {
                    Abstractions = typeof(Form),
                    Realization = typeof(PackageAdmining),
                    Name = nameof(PackageAdmining),
                    Register = true
                },
                new Dependency(3)
                {
                    Abstractions = typeof(Form),
                    Realization = typeof(ValidationForm),
                    Name = nameof(ValidationForm),
                    Register = true
                },
                new Dependency(4)
                {
                    Abstractions = typeof(Form),
                    Realization = typeof(ActDbView),
                    Name = nameof(ActDbView),
                    Register = true
                }
            };
        }

        [JsonProperty]
        public ICollection<Dependency> InfrastructureDependencies { get; set; }
        private ICollection<Dependency> GetInfrastructureDependencies()
        {
            return new List<Dependency>
            {
                new Dependency(1)
                {
                    Abstractions = typeof(IConsoleService),
                    Realization = typeof(DefaultConsoleService),
                    AllowRoles = new List<NodeRole>
                    {
                    }
                },
                new Dependency(2)
                {
                    Abstractions = typeof(ISettingsStorage),
                    Realization = typeof(DefaultSettingsStorage),
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK,
                        NodeRole.AFC,
                        NodeRole.VerificationStation,
                        NodeRole.ReportsStation
                    }
                },
                new Dependency(3)
                {
                    Abstractions = typeof(ArgsFileLocation),
                    Realization = typeof(ArgsFileLocation),
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK,
                        NodeRole.AFC,
                        NodeRole.VerificationStation,
                        NodeRole.ReportsStation
                    }
                },
                new Dependency(4)
                {
                    Abstractions = typeof(IConsoleService),
                    Realization = typeof(FileConsoleServiceService),
                    Register = false,
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK,
                        NodeRole.AFC,
                        NodeRole.VerificationStation,
                        NodeRole.ReportsStation
                    }
                },
                new Dependency(5)
                {
                    Abstractions = typeof(Host),
                    Realization = typeof(Host),
                    Register = false,
                    AllowRoles = new List<NodeRole> {NodeRole.AFC}
                },
                new Dependency(6)
                {
                    Abstractions = typeof(Proxy),
                    Realization = typeof(Proxy),
                    Register = false,
                    AllowRoles = new List<NodeRole> {NodeRole.PPVK}
                },
                new Dependency(7)
                {
                    Abstractions = typeof(DbContext),
                    Realization = typeof(ModelContext),
                    Register = false,
                    AllowRoles = new List<NodeRole> {NodeRole.VerificationStation, NodeRole.ReportsStation}
                },
                new Dependency(8)
                {
                    Abstractions = typeof(IDownloader),
                    Realization = typeof(Downloader),
                    Register = true,
                    AllowRoles = new List<NodeRole> {NodeRole.AFC}
                },
                new Dependency(8)
                {
                    Abstractions = typeof(UpdateClient),
                    Realization = typeof(UpdateClient),
                    Register = true,
                    AllowRoles = new List<NodeRole> {NodeRole.PPVK}
                }
            };
        }

        [JsonProperty]
        public ICollection<Dependency> WorkFlowDependencies { get; set; }
        private ICollection<Dependency> GetWorkFlowDependencies()
        {
            return new List<Dependency>
            {
                new Dependency(1)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(FinderFiles),
                    Name = nameof(FinderFiles),
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK,
                        NodeRole.VerificationStation,
                        NodeRole.ReportsStation
                    }
                },
                new Dependency(2)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(BufferedFiles),
                    Name = nameof(BufferedFiles),
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK,
                        NodeRole.VerificationStation,
                        NodeRole.ReportsStation
                    }
                },
                new Dependency(3)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(Md5HashComputerFiles),
                    Name = nameof(Md5HashComputerFiles),
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK
                    }
                },
                new Dependency(4)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(CompresserFiles),
                    Name = nameof(CompresserFiles),
                    Register = false,
                    AllowRoles = new List<NodeRole>()
                },
                new Dependency(5)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(SenderFiles),
                    Name = nameof(SenderFiles),
                    AllowRoles = new List<NodeRole> {NodeRole.PPVK}
                },
                new Dependency(7)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(RecivingFiles),
                    Name = nameof(RecivingFiles),
                    Register = false,
                    Lifetime = new PerResolveLifetimeManager(),
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.AFC
                    }
                },
                new Dependency(8)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(UnCompresserFiles),
                    Name = nameof(UnCompresserFiles),
                    Register = false,
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.AFC
                    }
                },
                new Dependency(9)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(BackUpFiles),
                    Name = nameof(BackUpFiles),
                    Register = false,
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK,
                        NodeRole.AFC,
                        NodeRole.VerificationStation,
                        NodeRole.ReportsStation
                    }
                },
                new Dependency(10)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(SaveFileInfo),
                    Name = nameof(SaveFileInfo),
                    Register = false,
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.AFC
                    }
                },
                new Dependency(11)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(SaveForAfcFiles),
                    Name = nameof(SaveForAfcFiles),
                    Register = false,
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.AFC
                    }
                },
                new Dependency(12)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(JsonReadFiles),
                    Name = nameof(JsonReadFiles),
                    Register = false,
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.VerificationStation
                    }
                },
                new Dependency(14)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(DeleteFiles),
                    Name = nameof(DeleteFiles),
                    Register = true,
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK,
                        NodeRole.VerificationStation
                    }
                },
                new Dependency(15)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(FinalizeFiles),
                    Name = nameof(FinalizeFiles),
                    Register = true,
                    AllowRoles = new List<NodeRole>
                    {
                        NodeRole.PPVK,
                        NodeRole.AFC,
                        NodeRole.VerificationStation,
                        NodeRole.ReportsStation
                    }
                }
            };
        }

        private static CompositionRoot LoadFromFile()
        {
            try
            {
                var jss = new JsonSerializerSettings { Formatting = Formatting.Indented };
                var json = File.ReadAllText(_fullName);
                return JsonConvert
                    .DeserializeObject<CompositionRoot>(json, jss) as CompositionRoot;
            }
            catch (Exception e)
            {
                s_container?.Resolve<IConsoleService>()?.AddException(e);
                return null;
            }
        }

        internal void SaveConfigToFile()
        {
            try
            {
                var jss = new JsonSerializerSettings {Formatting = Formatting.Indented};
                var json = JsonConvert.SerializeObject(this, jss);
                File.WriteAllText(_fullName, json);
            }
            catch (Exception e)
            {
                s_container?.Resolve<IConsoleService>()?.AddException(e);
            }
        }

        [JsonProperty]
        internal ICollection<NodeRole> NodeRoles { get; set; }
    }
}