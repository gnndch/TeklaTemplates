using System;
using System.IO;
using System.Threading.Tasks;
using Tekla.Structures.Datatype;
using Tekla.Structures.Dialog;

namespace TeklaWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ApplicationWindowBase
    {
        MainWindowViewModel viewModel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            InitializeDataStorage(viewModel);

            Dialogs.SetSettings(string.Empty);
            Localization localization = new Localization
            {
                Language = (string)Settings.GetValue("language")
            };
            string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string FullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string LocalizationFile = Path.Combine(FullPath.Substring(0, FullPath.LastIndexOf("\\")), AssemblyName + ".ail");
            if (File.Exists(LocalizationFile))
            {
                localization.LoadFile(LocalizationFile);
            }
            Window.Title = localization.GetText("albl_Title");

            if (GetConnectionStatus())
            {
                InitializeDistanceUnitDecimals();
            }
        }

        private void WPFOkCreateCancel_CreateClicked(object sender, EventArgs e)
        {
            new Task(delegate
            {
                viewModel.MainAction();
            }).Start();
        }

        private void WPFOkCreateCancel_OkClicked(object sender, EventArgs e)
        {
            new Task(delegate
            {
                viewModel.MainAction();
            }).Start();
            Close();
        }

        private void WPFOkCreateCancel_CancelClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
