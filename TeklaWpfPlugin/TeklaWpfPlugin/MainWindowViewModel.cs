using System.ComponentModel;
using Tekla.Structures.Dialog;

namespace TeklaWpfPlugin
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // MVVM binding here.
        // For example:
        private string beamClass = string.Empty;
        [StructuresDialog("beamClass", typeof(Tekla.Structures.Datatype.String))]
        public string BeamClass
        {
            get { return beamClass; }
            set { beamClass = value; OnPropertyChanged("BeamClass"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}