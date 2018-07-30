using System.Windows;
using Tekla.Structures.Model;

namespace TeklaWpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Events events = new Events();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow();
            if (new Model().GetConnectionStatus())
            {
                events.TeklaStructuresExit += Events_ExitEvent;

                new System.Windows.Interop.WindowInteropHelper(window).Owner = Tekla.Structures.Dialog.MainWindow.Frame.Handle;
                window.Show();
            }
        }

        void Events_ExitEvent()
        {
            Shutdown();
        }
    }
}
