
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;


namespace SkpProject
{
    //public class ViewModel : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    public void OnPropertyChanged(PropertyChangedEventArgs e)
    //    {
    //        if (PropertyChanged != null)
    //            PropertyChanged(this, e);
    //    }
    //    private Stream docStream;
    //    public Stream DocumentStream
    //    {
    //        get
    //        {
    //            return docStream;
    //        }
    //        set
    //        {
    //            docStream = value;
    //            OnPropertyChanged(new PropertyChangedEventArgs("DocumentStream"));
    //        }
    //    }
    //    public ViewModel()
    //    {
    //        //docStream = new FileStream(@"..\..\Resources\EUV1.pdf.Ink", FileMode.OpenOrCreate);
    //        OpenFileDialog openFile = new OpenFileDialog();
    //        openFile.Filter = "PDF |*.pdf";
    //        Nullable<bool> result = openFile.ShowDialog();

    //        if ((bool)result)
    //        {
    //            MainWindow mainWindow = new MainWindow();
    //            mainWindow.txtOpenPdfFile.Text = openFile.FileName;
    //        }
    //    }
    //}
}
