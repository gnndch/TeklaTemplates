using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Solid;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaWpfApplication
{
    internal class MainWindowViewModel : ViewModel
    {
        // MVVM binding here.
        // For example:
        //private string beamClass;
        //public string BeamClass
        //{
        //    get { return beamClass; }
        //    set { SetValue(ref beamClass, value); }
        //}

        public MainWindowViewModel()
        {
            // Set initial user control values here.
            // For example:
            //BeamClass = "5";
        }

        internal void MainAction()
        {
            // Main action here.
        }
    }
}