using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OverWeightControl.Clients.ActsUI;
using OverWeightControl.Core.CompositionRoot;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.ConsoleService;
using OverWeightControl.Core.FileTransfer.Client;
using OverWeightControl.Core.FileTransfer.Server;
using OverWeightControl.Core.FileTransfer.WorkFlow;
using OverWeightControl.Core.Settings;
using OverWeightControl.Core.Unity;
using Unity;
using Unity.Interception.Utilities;

namespace OverWeightControl
{
    public class Starter
    {
        private readonly IConsoleService _console;

        public Starter()
        {
            try
            {
                // Регистрация компонентов инфраструктуры.
                RegisterDependencies(
                    Container, CompositionRoot.InfrastructureDependencies);

                _console = Container.Resolve<IConsoleService>();

                Container.AddExtension(new DecoratorContainerExtension());
                // Регистрация рабочего процесса.
                RegisterDependencies(
                    Container, CompositionRoot.WorkFlowDependencies);

                // Регистрация приложений.
                RegisterDependencies(
                    Container, CompositionRoot.ApplicationsDependencies);

                EditorSettingsStorage.ShowModal(Container);
                _console.Flush();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }
            finally
            {
                var disposes = Container.Registrations
                    .Select(m => m.MappedToType)
                    .Where(f => f is IDisposable);
                    disposes.ForEach(d => ((IDisposable)d).Dispose());
            }
        }
        
        private IUnityContainer RegisterDependencies(
            IUnityContainer container,
            ICollection<Dependency> dependencies)
        {
            var regList = dependencies
                .Where(f => f.Register)
                .OrderBy(ks => ks.Order);
            foreach (var dependency in regList)
            {
                container.RegisterType(
                    dependency.Abstractions,
                    dependency.Realization,
                    dependency.Name,
                    dependency.Lifetime);
            }

            return container;
        }

        public IConsoleService ConsoleService => _console;

        public IUnityContainer Container => CompositionRoot.Container;
    }

    public static class CompositionRoot
    {
        static CompositionRoot()
        {
            InfrastructureDependencies = GetInfrastructureDependencies();
            WorkFlowDependencies = GetWorkFlowDependencies();
            ApplicationsDependencies = GetApplicationsDependencies();
        }

        private static IUnityContainer s_container;

        public static IUnityContainer Container => s_container
                                                   ?? (s_container = new UnityContainer());

        public static ICollection<Dependency> ApplicationsDependencies { get; set; }
        private static ICollection<Dependency> GetApplicationsDependencies()
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

        public static ICollection<Dependency> InfrastructureDependencies { get; set; }
        private static ICollection<Dependency> GetInfrastructureDependencies()
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

        public static ICollection<Dependency> WorkFlowDependencies { get; set; }
        private static ICollection<Dependency> GetWorkFlowDependencies()
        {
            return new List<Dependency>
            {
                new Dependency(1)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(FinderFiles)
                },
                new Dependency(2)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(BufferedFiles)
                },
                new Dependency(3)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(Md5HashComputerFiles)
                },
                new Dependency(4)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(CompresserFiles)
                },
                new Dependency(5)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(SenderFiles)
                },
                new Dependency(6)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(SenderFiles),
                    Register = false
                },
                new Dependency(7)
                {
                    Abstractions = typeof(IWorkFlowProducerConsumer),
                    Realization = typeof(UnCompresserFiles),
                    Register = false
                }
            };
        }
    }
}
