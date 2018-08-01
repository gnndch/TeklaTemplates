using System;
using Tekla.Structures.Dialog;

namespace TeklaWpfPlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : PluginWindowBase
    {
        private MainWindowViewModel dataModel;
        public MainWindow(MainWindowViewModel DataModel)
        {
            InitializeComponent();
            dataModel = DataModel;
        }

        private void WPFOkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e)
        {
            Apply();
            Close();
        }
        private void WPFOkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e)
        {
            Apply();
        }
        private void WPFOkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e)
        {
            Modify();
        }
        private void WPFOkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e)
        {
            Get();
        }
        private void WPFOkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e)
        {
            ToggleSelection();
        }
        private void WPFOkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
