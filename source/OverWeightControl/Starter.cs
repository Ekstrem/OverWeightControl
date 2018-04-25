using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.Interception.Utilities;
using OverWeightControl.Core.Console;
using OverWeightControl.Core.Unity;
using OverWeightControl.Clients.ParrentUI;


namespace OverWeightControl
{
    public class Starter
    {
        private IConsoleService _console;
        private readonly CompositionRoot _compositionRoot;

        public Starter()
        {
            try
            {
                _compositionRoot = CompositionRoot.Factory();
                
                ContainerRegistations();                

                var mainForm = Container.Resolve<MainForm>();
                mainForm.Initial(_compositionRoot.NodeRoles, IsAdminMode);
                mainForm.ShowDialog();

                _console.Flush();
            }
            catch (Exception e)
            {
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

        private void ContainerRegistations()
        {
            // Регистрация компонентов инфраструктуры.
            RegisterDependencies(
                Container, _compositionRoot.InfrastructureDependencies);

            _console = Container.Resolve<IConsoleService>();

            Container.AddExtension(new DecoratorContainerExtension());
            // Регистрация рабочего процесса.
            RegisterDependencies(
                Container, _compositionRoot.WorkFlowDependencies);

            // Регистрация приложений.
            RegisterDependencies(
                Container, _compositionRoot.ApplicationsDependencies);
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

        public static bool IsAdminMode { get; set; }

        public static void Main(string[] args)
        {
            IsAdminMode = args.Contains("-admin");
            var app = new Starter();
        }
    }
}
