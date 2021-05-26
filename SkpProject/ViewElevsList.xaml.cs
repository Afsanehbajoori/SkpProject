using DataAccess;
using DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Windows.Xps.Packaging;


namespace SkpProject
{
    /// <summary>
    /// Interaction logic for ViewElevsList.xaml
    /// </summary>
    public partial class ViewElevsList : Window
    {

        //private IDocumentPaginatorSource _docText;
        //public IDocumentPaginatorSource DocText
        //{
        //    get
        //    {

        //        return _docText;
        //    }

        //    set
        //    {
        //        _docText = value;
        //        RaisePropertyChanged("DocText");
        //    }
        //}



        public Student currentStudent { get; set; } = new Student();
        public Dictionary<string, string> fileDictionary = new Dictionary<string, string>();



        public ViewElevsList()
        {
            InitializeComponent();
           
        }

       

        private void SearchStudentTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = SearchStudentTxt.Text;
            Data _data = new Data();
            // _data.CreateStudentsData();
            _data.GetStudents();
            
            List<Student> GetStudents = _data.students.Where(student => (student.FirstName.ToLower()).StartsWith(text.ToLower()) || student.LastName.ToLower().StartsWith(text.ToLower())).ToList();
            //List<Student> GetStudents = Data.students.Where(student => (student.FirstName).StartsWith(text)).ToList();
            SearchStudentBox.ItemsSource = GetStudents;
            //ObservableCollection<Student> GetStudents = Data.students.Select(student => (student.FirstName).StartsWith(text)).ToList();
        }


        //private void SearchStudentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (SearchStudentBox.SelectedIndex >= 0)
        //    {
        //        currentStudent = SearchStudentBox.SelectedItem as Student;
        //        //StudentsFullInfo.Content = currentStudent.FullInfo;
        //        string filnavn = currentStudent.LastName;
        //        OpenFileDialog openFile = new OpenFileDialog();

        //        //openFile.Filter = "PDF |*.pdf";
        //        openFile.DefaultExt = ".pdf";
        //        openFile.FileName = $"C:\\Users\\afba\\Desktop\\{filnavn}.pdf";

        //        //openFile.DefaultExt = ".docx";
        //        //openFile.Filter= ".Docx Files (*.docx)|*.docx";

        //        //open pdf file in the program
        //       // string newXPSDocName = String.Concat(System.IO.Path.GetDirectoryName(openFile.FileName), "\\", System.IO.Path.GetFileNameWithoutExtension(openFile.FileName), ".pdf");
        //        //PDF_Placeholder.Document = ConvertWordDocToXPSDoc(pdffile.FileName, newXPSDocName).GetFixedDocumentSequence();


        //        //Nullable<bool> result = openFile.ShowDialog();

        //        //if ((bool)result)
        //        //{


        //        // open pdf file in web browser:
        //        string path = openFile.FileName;
        //        pdfWebViewer.Navigate(new Uri("about:blank"));
        //            pdfWebViewer.Navigate(path);


        //            //open word documents in documents viewwr:
        //            //Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
        //            //string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(openFile.FileName), "\\",
        //            //           System.IO.Path.GetFileNameWithoutExtension(openFile.FileName), ".xps");
        //            //DocText = ConvertWordDocToXPSDoc(openFile.FileName, newXPSDocumentName).GetFixedDocumentSequence();

        //        //}
        //    }
        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void checkedBox_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {


            //fileDictionary.Remove(item.ToString());
            SearchStudentBox.Items.Remove(SearchStudentBox.SelectedItem);



            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("hi");
            //var selectedItem = SearchStudentBox.Items.Cast<CheckBox>().Where(x => x.IsChecked == true).Select(x => x.Content) ;

            Student currentStudent = SearchStudentBox.SelectedItem as Student;
            string filnavn = currentStudent.LastName;

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = ".pdf";
            openFile.FileName = $"C:\\Users\\afba\\Desktop\\{filnavn}.pdf";
            string path = openFile.FileName;
            pdfWebViewer.Navigate(new Uri("about:blank"));
            pdfWebViewer.Navigate(path);

            //fileDictionary.Add(filnavn, path);
            //SearchStudentBox.Items.Add(filnavn);

        }
    }
}
