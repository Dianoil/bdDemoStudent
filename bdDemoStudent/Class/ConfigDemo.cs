using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using bdDemoStudent.View;

namespace bdDemoStudent.Class
{
    class ConfigDemo
    {
        public string patchAppExe =
               System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public struct configMainApp
        {
            public bool ch_1;
            public bool ch_2;
            public bool ch_3;
            public bool ch_2_1;
            public bool ch_2_2;
            public bool ch_2_3;
            public bool ch_2_4;
            public bool ch_2_5;
            public bool ch_2_6;
            public bool ch_2_7;
            public bool ch_2_8;
            public bool ch_2_9;
        }
        public configMainApp savDat = new configMainApp();
        WinMain pm;
        public ConfigDemo(WinMain demwin)
        {
            pm = demwin;
            try
            {
                FileSystem.FileOpen(1, patchAppExe + "\\demo_wpf.ini", OpenMode.Binary);
                ValueType tempState = new configMainApp();
                FileSystem.FileGet(1, ref tempState);
                savDat = ((configMainApp)tempState);
                pm.Check2_1.IsChecked = savDat.ch_2_1;
                pm.Check2_2.IsChecked = savDat.ch_2_2;
                pm.Check2_3.IsChecked = savDat.ch_2_3;
                pm.Check2_4.IsChecked = savDat.ch_2_4;
                pm.Check2_5.IsChecked = savDat.ch_2_5;
                pm.Check2_6.IsChecked = savDat.ch_2_6;
                pm.Check2_7.IsChecked = savDat.ch_2_7;
                pm.Check2_8.IsChecked = savDat.ch_2_8;
                pm.Check2_9.IsChecked = savDat.ch_2_9;
                FileSystem.FileClose(1);
            }
            catch { FileSystem.FileClose(1); }
        }
        public int SavConfig()
        {
            savDat.ch_2_1 = (bool)pm.Check2_1.IsChecked;
            savDat.ch_2_2 = (bool)pm.Check2_2.IsChecked;
            savDat.ch_2_3 = (bool)pm.Check2_3.IsChecked;
            savDat.ch_2_4 = (bool)pm.Check2_4.IsChecked;
            savDat.ch_2_5 = (bool)pm.Check2_5.IsChecked;
            savDat.ch_2_6 = (bool)pm.Check2_6.IsChecked;
            savDat.ch_2_7 = (bool)pm.Check2_7.IsChecked;
            savDat.ch_2_8 = (bool)pm.Check2_8.IsChecked;
            savDat.ch_2_9 = (bool)pm.Check2_9.IsChecked;
            FileSystem.FileOpen(1, patchAppExe + "\\demo_wpf.ini", OpenMode.Random);
            FileSystem.FilePut(1, savDat);
            FileSystem.Seek(1, 1);
            FileSystem.FileClose(1);
            return 0;
        }
    }
}
