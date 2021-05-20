using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SkpProject
{
    /// <summary>
    /// Interaction logic for OpenPdfFile.xaml
    /// </summary>
    public partial class OpenPdfFile : Window
    {
        public OpenPdfFile()
        {
            InitializeComponent();
            //this.Loaded+=new RoutedEventHandler()

            //OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "PDF |*.pdf";
            //Nullable<bool> result = openFile.ShowDialog();

            //if ((bool)result)
            //{
            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.txtOpenPdfFile.Text = openFile.FileName;
            //    string path = mainWindow.txtOpenPdfFile.Text;


            //    //it's work with pdf reader
            //    // PdfReader pdf_Reader = new PdfReader(path);
            //    // string sText = "";
            //    // for(int i=1; i<=pdf_Reader.NumberOfPages;i++)
            //    // {
            //    //     sText = sText + PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
            //    // }
            //    //lblPDF_Output.Text = sText;


            //    //System.Diagnostics.Process.Start(path);

            //    pdfWebViewer.Navigate(new Uri("about:blank"));
            //    pdfWebViewer.Navigate(path);

            //}

            //this is for bold reports
            //this.ReportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory,@"..\Resources\EUV1.pdf" );
            //this.ReportViewer.RefreshReport();

        }




    }
}
