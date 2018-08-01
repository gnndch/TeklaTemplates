using System.Collections.Generic;
using System.IO;
using Tekla.Structures;
using Tekla.Structures.Datatype;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;

namespace TeklaWpfPlugin
{
    [Plugin("TekalWpfPlugin")]
    [PluginUserInterface("TekalWpfPlugin.MainWindow")]
    public class Plugin : PluginBase
    {
        private string BeamClass;

        private PluginData data;
        public Plugin(PluginData data)
        {
            this.data = data;

            Dialogs.SetSettings(string.Empty);
            TeklaStructures.Environment.Localization.Language = (string)Settings.GetValue("language");
            string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string FullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string LocalizationFile = Path.Combine(FullPath.Substring(0, FullPath.LastIndexOf("\\")), AssemblyName + ".ail");
            if (File.Exists(LocalizationFile))
            {
                TeklaStructures.Environment.Localization.LoadFile(LocalizationFile);
            }
        }

        private void GetValuesFromDialog()
        {
            BeamClass = data.beamClass;
            if (IsDefaultValue(BeamClass))
            {
                BeamClass = "5";
            }
        }

        public override List<InputDefinition> DefineInput()
        {
            Picker picker = new Picker();
            List<InputDefinition> inputList = new List<InputDefinition>();
            Tekla.Structures.Geometry3d.Point p1 = picker.PickPoint("Pick point");
            InputDefinition input1 = new InputDefinition(p1);
            inputList.Add(input1);
            return inputList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            GetValuesFromDialog();

            Tekla.Structures.Geometry3d.Point point = Input[0].GetInput() as Tekla.Structures.Geometry3d.Point;
            Tekla.Structures.Geometry3d.Point point2 = new Tekla.Structures.Geometry3d.Point(1000, 0, 0);
            Beam beam = new Beam { StartPoint = point, EndPoint = point2 };
            beam.Profile.ProfileString = "I30K1_20_93";
            beam.Finish = "PAINT";

            beam.Class = BeamClass;

            bool result = false;
            result = beam.Insert();
            return true;
        }
    }
}
