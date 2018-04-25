using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverWeightControl.Clients.ActsUI;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.ConsoleService;
using OverWeightControl.Core.FileTransfer.Client;
using OverWeightControl.Core.FileTransfer.Server;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using Unity;

namespace OverWeightControl
{
    [JsonObject]
    public class CompositionRoot
    {
        private static string _fileName = "starts.cfg";
        private static string _fullName => $"{AppDomain.CurrentDomain.BaseDirectory}{_fileName}";

        private CompositionRoot() { }

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
                    Abstractions = typeof(ActEditForm),
                    Realization = typeof(ActEditForm),
                    Register = false
                },
                new Dependency(2)
                {
                    Abstractions = typeof(EditorSettingsStorage),
                    Realization = typeof(EditorSettingsStorage),
                    Register = false
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
                    Realization = typeof(DefaultConsoleService)
                },
                new Dependency(2)
                {
                    Abstractions = typeof(ISettingsStorage),
                    Realization = typeof(DefaultSettingsStorage)
                },
                new Dependency(3)
                {
                    Abstractions = typeof(ArgsFileLocation),
                    Realization = typeof(ArgsFileLocation)
                },
                new Dependency(4)
                {
                    Abstractions = typeof(IConsoleService),
                    Realization = typeof(FileConsoleServiceService),
                    Register = false
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
                    Name = nameof(FinderFiles)
                },
                new Dependency(2)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(BufferedFiles),
                    Name = nameof(BufferedFiles)
                },
                new Dependency(3)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(Md5HashComputerFiles),
                    Name = nameof(Md5HashComputerFiles)
                },
                new Dependency(4)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(CompresserFiles),
                    Name = nameof(CompresserFiles)
                },
                new Dependency(5)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(SenderFiles),
                    Name = nameof(SenderFiles)
                },
                /*new Dependency(6)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(SenderFiles),
                    Register = false
                },*/
                new Dependency(7)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(UnCompresserFiles),
                    Name = nameof(UnCompresserFiles),
                    Register = false
                }
            };
        }

        private static CompositionRoot LoadFromFile()
        {
            var jss = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var json = File.ReadAllText(_fullName);
            return JsonConvert
                .DeserializeObject<CompositionRoot>(json, jss) as CompositionRoot;
        }

        internal void SaveConfigToFile()
        {
            var jss = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var json = JsonConvert.SerializeObject(this, jss);
            File.WriteAllText(_fullName, json);
        }

        internal ICollection<Roles> NodeRoles { get; set; }
    }
}