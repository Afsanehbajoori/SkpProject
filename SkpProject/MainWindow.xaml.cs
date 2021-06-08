using DataAccess;
using DataAccess.Models;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using Spire.Doc;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using SkpProject;

using Spire.Pdf.General.Find;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
using Section = iTextSharp.text.Section;
using GemBox.Document;


namespace SkpProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        //ElevDataAccess elevDataAccess = new ElevDataAccess();

        //ObservableCollection<Elev> elevs = new ObservableCollection<Elev>();

        //public Elev currentElev { get; set; } = new Elev();

        public Student currentStudent { get; set; } = new Student();
        public Dictionary<string, string> fileDictionary = new Dictionary<string, string>();
       
       

        public MainWindow()
        {
            InitializeComponent();
            //skal tilføjes i excel dele
            //// dataGridView.AutoGeneratingColumn += dataGridView_AutoGeneratingColumn;
 

        }


        private bool validationRadioButtonMethod()
        {
            IEnumerable<RadioButton> radioButtons = radioButtonValidation.Children.OfType<RadioButton>();
            Dictionary<string, List<RadioButton>> radioBtnList = new Dictionary<string, List<RadioButton>>();

            bool isValid = true;

            foreach (RadioButton item in radioButtons)
            {
                if (!radioBtnList.ContainsKey(item.GroupName))
                {
                    radioBtnList.Add(item.GroupName, new List<RadioButton> { item });
                }
                else
                {
                    radioBtnList[item.GroupName].Add(item);
                }


            }

            foreach (var item in radioBtnList.Keys)
            {
                if ((radioBtnList[item].Find(x => x.IsChecked == true)) == null)
                {
                    isValid = false;
                }

            }

            return isValid;
        }



        //private bool validationOfErfaring()
        //{
            //IEnumerable<RadioButton> radioButtons = radioButtonErfaringValidation.Children.OfType<RadioButton>();
            //Dictionary<string, List<RadioButton>> radioBtnList = new Dictionary<string, List<RadioButton>>();

            //bool isValid2 = true;

            //foreach (RadioButton item in radioButtons)
            //{
            //    if (!radioBtnList.ContainsKey(item.GroupName))
            //    {
            //        radioBtnList.Add(item.GroupName, new List<RadioButton> { item });
            //    }
            //    else
            //    {
            //        radioBtnList[item.GroupName].Add(item);
            //    }


            //}

            //foreach (var item in radioBtnList.Keys)
            //{
            //    if ((radioBtnList[item].Find(x => x.IsChecked == true)) == null)
            //    {
            //        isValid2 = false;
            //    }

            //}

            //return isValid2;
        //}


        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            UnderviserPanel.Visibility = Visibility.Collapsed;
            LederPanel.Visibility = Visibility.Collapsed;
        }

        private void btnUnderviser_Click(object sender, RoutedEventArgs e)
        {
            UnderviserPanel.Visibility = Visibility.Visible;
            HomePanel.Visibility = Visibility.Collapsed;
            LederPanel.Visibility = Visibility.Collapsed;
        }

        private void btnLeder_Click(object sender, RoutedEventArgs e)
        {
            LederPanel.Visibility = Visibility.Visible;
            HomePanel.Visibility = Visibility.Collapsed;
            UnderviserPanel.Visibility = Visibility.Collapsed;
        }


        private void signinButton_Click(object sender, RoutedEventArgs e)
        {
            ViewElevsList viewelevslist = new ViewElevsList();
            if (passwordText.Password == "1234")
            {
                viewelevslist.Show();
                this.Close();
            }
            else if (passwordText.Password == "")
            {
                MessageBox.Show("Indtast adgangskode!!");
                passwordText.Focus();
            }
            else
            {
                MessageBox.Show("ugyldig adgangskode!!");
                passwordText.Focus();
            }

        }




        private void btnOpen_Click_2(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel File |*.xls;*.xlsx;*.xlsm";
            Nullable<bool> result = openFile.ShowDialog();
           
            if ((bool)result)
            {

                //skal tilføjes i excel del
                ///// txtFilePath.Text = openFile.FileName;

                // string name = "Sheet1";
                //skal tilføjes i excel del
                ////string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFilePath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
               //// OleDbConnection Con = new OleDbConnection(constr);
               //// OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$]", Con); // Hent data fra excel

                ////Con.Open();

               ///// OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);//OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$A1:G4]", Con);
                DataTable data = new DataTable();
                ////sda.Fill(data);

                List<Elev> students = new List<Elev>();
                // index, navn på kolonnen. fx = 0: "CPRNr"
                Dictionary<int, string> studentDataIndexName = new Dictionary<int, string>();
                // Spaghetti-kode løsning på at finde den data vi skal hente fra elever.
                string[] _columnNamesStudent = new string[] { "cprnr", "fnavn", "enavn" ,"uddannelseapp" , "elevtype" };

                for (int i = 0; i < data.Columns.Count; i++)
                {
                    if (_columnNamesStudent.Contains(data.Columns[i].ToString().ToLower()))
                    {
                        studentDataIndexName.Add(i, data.Columns[i].ToString());
                    }
                }

                // Tjekker om kolonnen skal bruges af systemet, og tilføjer index og navnet til `studentDataIndexName`

                //for (int j = 0; j < data.Columns.Count; j++)
                //{
                //    string columnName = data.Columns[j].ToString();
                //    if (_columnNamesStudent.Contains(columnName.ToLower()))
                //    {
                //        studentDataIndexName.Add(j, columnName);
                //    }
                //}


                foreach (DataRow row in data.Rows)
                {
                    Elev _student = new Elev();

                    foreach (var key in studentDataIndexName.Keys)
                    {
                        // Finder Elev property der har det samme navn som `value` i `dict[key]`,
                        // Og sætter værdien til den property fra `row`'s `ItemArray`, hvor `key` svarer til tilpassende data.
                        (_student.GetType().GetProperty(studentDataIndexName[key])).SetValue(_student, row.ItemArray[key]);
                    }
                    students.Add(_student);  // Elev tilføjes til listen
                }

                //skal tilføjes i excel del
               ///// dataGridView.ItemsSource = students;
            }
        }


        // Taget fra: https://stackoverflow.com/a/23159526
        private void dataGridView_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var desc = e.PropertyDescriptor as PropertyDescriptor;
            var att = desc.Attributes[typeof(DataGridColumnNameAttribute)] as DataGridColumnNameAttribute;
            if (att != null)
            {
                e.Column.Header = att.Name;
            }
        }




        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchStudentTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = SearchStudentTxt.Text;
            Data _data = new Data();
           // _data.CreateStudentsData();
            _data.GetStudents();
            //Student stu = new Student();
            //stu.CalculateAge();
            List<Student> GetStudents = _data.students.Where(student => (student.FirstName.ToLower()).StartsWith(text.ToLower()) || student.LastName.ToLower().StartsWith(text.ToLower())).ToList();
            //List<Student> GetStudents = Data.students.Where(student => (student.FirstName).StartsWith(text)).ToList();
            SearchStudentBox.ItemsSource = GetStudents;
            //ObservableCollection<Student> GetStudents = Data.students.Select(student => (student.FirstName).StartsWith(text)).ToList();
        }

        private void SearchStudentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SearchStudentBox.SelectedIndex >= 0)
            {
                //Student stu = new Student();
                //stu.CalculateAge();
                currentStudent = SearchStudentBox.SelectedItem as Student;
                App.Current.Resources["SelectedNavn"] = currentStudent.LastName;
                StudentsFullInfo.Content = currentStudent.FullInfo;
                string StrCurrentCprNr = SearchStudentBox.SelectedItem.ToString();
                ViseAlder.Text = CalculateAge(StrCurrentCprNr);
            }
        }

        //private void calculateAge_Click(object sender, RoutedEventArgs e)
        //{
            
            
        //}

    
        //private void btnOpenPdfFile_Click(object sender, RoutedEventArgs e)
        //{
        //    //this.Hide();
        //    ////fileWatch();
        //    //OpenPdfFile openPdfFile = new OpenPdfFile();
        //    //openPdfFile.Show();
        //    Student currentStudent = SearchStudentBox.SelectedItem as Student;
        //    string filnavn = currentStudent.LastName;
        //    OpenFileDialog openFile = new OpenFileDialog();
        //    openFile.Filter = "PDF |*.pdf";
        //    var fileName= openFile.FileName = $"C:\\Users\\afba\\Desktop\\{filnavn}.pdf";
        //    Nullable<bool> result = openFile.ShowDialog();

        //    if ((bool)result)
        //    {
        //        string path = openFile.FileName;
        //        pdfWebViewer.Navigate(new Uri("about:blank"));
        //        pdfWebViewer.Navigate(path);



        //        //fileDictionary.Add(filnavn, path);
        //        //SearchStudentBox.Items.Add(filnavn);
                
        //    }
        //}



        //private void btnSubmit_Click(object sender, RoutedEventArgs e)
        //{
        //    //initialize word object
        //    Document document = new Document();
        //    FileDialog fileDialog = new OpenFileDialog();
        //    fileDialog.ShowDialog();
        //    string path = fileDialog.FileName;
        //    document.LoadFromFile(path);
        //    //get strings to replace 
        //    Dictionary<string, string> dicReplace = GetReplaceDictionary();
        //    //Replace text 
        //    foreach (KeyValuePair<string, string> kvp in dicReplace)
        //    {
        //        document.Replace(kvp.Key, kvp.Value, true, true);
        //    }
        //    ////Save doc file.
        //    //document.SaveToFile(path, FileFormat.Docx);
        //    ////Convert to PDF
        //    //document.SaveToFile(path, FileFormat.PDF);
        //    MessageBox.Show("All tasks are finished.");
        //    document.Close();
        //}

        //Dictionary<string, string> GetReplaceDictionary()
        //{
        //    Dictionary<string, string> replaceDict = new Dictionary<string, string>();
        //    replaceDict.Add("#ForNavvn#", "Afsaneh");

        //    return replaceDict;
        //}

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void DateTimePiker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{

        //    var today = DateTime.Today;
        //    var age = today.Year - DateTimePiker.SelectedDate.Value.Year;
        //    //if(DateTimePiker.SelectedDate.Value.Date) > today.AddYears(-age)) age--;
        //    ShowAge.Text = Convert.ToString(age);
        //}

        public string CalculateAge(string CPRNR)
        {

            DateTime dtToday = DateTime.Today;
             //CPRNR = "2005204525";

            //int value = Convert.ToInt32(CPRNrTxt.Text);
            //string strBirthDate = CPRNrTxt.Text.Substring(0, 6);
            string strBirthDate = CPRNR.Substring(0, 6);


            string strDD = strBirthDate.Substring(0, 2);
            string strMM = strBirthDate.Substring(2, 2);
            string strYY = strBirthDate.Substring(4, 2);
            int intYY = Convert.ToInt32(strYY);
            string strYYYY;
            if (intYY < 30)
            {

                strYYYY = "20" + strYY;


            }

            else
            {
                strYYYY = "19" + strYY;
            }

            string strAllBirth = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtBirthDate = Convert.ToDateTime(strAllBirth);
            int years = dtToday.Year - dtBirthDate.Year;
            if (dtToday.Month < dtBirthDate.Month || (dtToday.Month == dtBirthDate.Month && dtToday.Day < dtBirthDate.Day))
                years = years - 1;

            int intStudentAge = years;
            return intStudentAge.ToString();

        }

       

        private void calculateAgeFromTextBox_Click(object sender, RoutedEventArgs e)
        {
            //string StrCurrentCprNr = CPRNrTxt.Text.Trim();
            string StrCurrentCprNr = SearchStudentBox.SelectedItem.ToString();
            ViseAlder.Text = CalculateAge(StrCurrentCprNr);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            bool isValid = true;
            bool isValid2 = true;
            //isValid2 = validationOfErfaring();
            isValid = validationRadioButtonMethod();

            if (!isValid)

            {
                MessageBox.Show("Du skal udfylde alle felter!");
                
            }

            else if (!isValid2)
            {
                MessageBox.Show("Du skal udfylde alle felter!");
                
            }

            else if (ComboboxValidation.SelectedIndex < 0)
            {
                MessageBox.Show("Du skal udfylde alle felter!");
                
            }
            else
            {
                MessageBox.Show("Er du sikker?");

                chooseEUVProgrammering();
                //Document_Export();
                clear();

            }


        }

        


        public void chooseEUVProgrammering()
        {


            IEnumerable<RadioButton> radioButtons = Grundforløbet.Children.OfType<RadioButton>();
            IEnumerable<RadioButton> radioBtnHf = Hovedforløbet.Children.OfType<RadioButton>();
            if (over25.IsChecked == true && NineClassYes.IsChecked == true && experienceYes.IsChecked == true)      //&& ItSupport.IsSelected
            {

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "PDF |*.pdf";
                openFile.FileName = $"C:\\Users\\afba\\Desktop\\EUV1Programmering.pdf";
                Nullable<bool> result = openFile.ShowDialog();


                if ((bool)result)
                {
                    string path = openFile.FileName;
                    Student currentStudent = SearchStudentBox.SelectedItem as Student;
                    string filnavn = currentStudent.LastName;
                    string filcprnr = currentStudent.CPRNR;
                    
                    var education =(ComboBoxItem)ComboboxValidation.SelectedItem;
                    var educationContent = (string)education.Content;

                    var skillValue = Age.Children.OfType<RadioButton>().FirstOrDefault(x => x.IsChecked.HasValue && x.IsChecked.Value);
                    var skillContent = (string)skillValue.Name;

                    var groundforløb = Grundforløbet.Children.OfType<RadioButton>().FirstOrDefault(x => x.IsChecked.HasValue && x.IsChecked.Value);
                    var groundforløbContent = (string)groundforløb.Content;

                  


                    DateTime Now = DateTime.Now;
                    Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();
                    var newFile = $"C:\\Users\\afba\\Desktop\\{filnavn}.pdf";
                    PdfReader pdfReader = new PdfReader(path);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
                    var pdfFormFields = pdfStamper.AcroFields;
                    pdfFormFields.SetField("Navn", filnavn);
                    pdfFormFields.SetField("Cprnr", filcprnr);
                    for(int page=1; page <= pdfReader.NumberOfPages ;page++)
                    {
                        pdfFormFields.SetField("Evt speciale", educationContent);
                    }
                   
                    pdfFormFields.SetField("Uddannelse", skillContent);


                    foreach (var item in pdfFormFields.Fields)
                    {
                        Console.WriteLine("{0} , {1}  ", item.Key, item.Value);
                    }

                    pdfFormFields.SetField("Uddannelse", groundforløbContent);
                    pdfFormFields.SetField("RKV gennemført", Now.Day.ToString() + "/" + Now.Month.ToString());
                    pdfFormFields.SetField("År", Now.Year.ToString());
                    pdfFormFields.SetField("Fra", Now.Hour.ToString() + ":" + Now.Minute.ToString());
                    pdfFormFields.SetField("Dato", Now.Day.ToString() + "/" + Now.Month.ToString() + "/" + Now.Year.ToString());

                    foreach (var item in radioButtons)
                    {
                        if (!(bool)GrundforløbetNej.IsChecked)
                        {
                            pdfFormFields.SetField("GF nej", "Nej");
                        }
                        if (!(bool)GrundforløbetDeleHeraf.IsChecked)
                        {
                            pdfFormFields.SetField("GF dele", "Nej");
                        }
                        if (!(bool)GrundforløbetJa.IsChecked)
                        {
                            pdfFormFields.SetField("GF ja", "Nej");
                        }
                    }

                        foreach (var item in radioButtons)
                    {
                        if((bool)GrundforløbetNej.IsChecked)
                        {
                            pdfFormFields.SetField("GF nej", "Yes");
                        }
                        if ((bool)GrundforløbetDeleHeraf.IsChecked)
                        {
                            pdfFormFields.SetField("GF dele", "Yes");
                        }
                        if ((bool)GrundforløbetJa.IsChecked)
                        {
                            pdfFormFields.SetField("GF ja", "Yes");
                        }

                       
                    }

                    foreach (var item in radioBtnHf)
                    {
                        if (!(bool)HovedforløbetNej.IsChecked)
                        {
                            pdfFormFields.SetField("HF nej", "Nej");
                        }
                        if (!(bool)HovedforløbetDeleHeraf.IsChecked)
                        {
                            pdfFormFields.SetField("HF dele", "Nej");
                        }
                        if (!(bool)HovedforløbetJa.IsChecked)
                        {
                            pdfFormFields.SetField("HF ja", "Nej");
                        }
                    }

                    foreach (var item in radioBtnHf)
                    {
                        if ((bool)HovedforløbetNej.IsChecked)
                        {
                            pdfFormFields.SetField("HF nej", "Yes");
                        }
                        if ((bool)HovedforløbetDeleHeraf.IsChecked)
                        {
                            pdfFormFields.SetField("HF dele", "Yes");
                        }
                        if ((bool)HovedforløbetJa.IsChecked)
                        {
                            pdfFormFields.SetField("HF ja", "Yes");
                        }


                    }

                    var GFlængde = GFLængde.Text.ToString();
                    var HFlængde = HFLængde.Text.ToString();
                    var praktiklængdeÅr = PraktikÅrLængde.Text.ToString();
                    var praktiklængdeMåneder = PraktikMånederLængde.Text.ToString();
                    var praktiklængdeUger = PraktikUgerLængde.Text.ToString();

                    pdfFormFields.SetField("GF Uger", GFlængde);
                    pdfFormFields.SetField("HF Uger", HFlængde);
                    pdfFormFields.SetField("Praktik År", praktiklængdeÅr);
                    pdfFormFields.SetField("Praktik Md", praktiklængdeMåneder);
                    pdfFormFields.SetField("Praktik Uger", praktiklængdeUger);
                  
                   


                    ////Document doc = new Document(@"..\..\Table.doc");
                    ////Section section = doc.Sections[0];
                    ////ITable table = section.Tables[0];
                    //////#region replace text
                    //////TableCell cell1 = table.Rows[1].Cells[1];
                    //////Paragraph p1 = cell1.Paragraphs[0];
                    //////p1.Text = "abc";

                    //////TableCell cell2 = table.Rows[1].Cells[2];
                    //////Paragraph p2 = cell2.Paragraphs[0];
                    //////p2.Items.Clear();
                    //////p2.AppendText("def");

                    //////TableCell cell3 = table.Rows[1].Cells[3];
                    //////Paragraph p3 = cell3.Paragraphs[0];
                    //////(p3.Items[0] as TextRange).Text = "hij";
                    //////#endregion


                    //pdfFormFields.SetField("Grundforløbet", );
                    pdfStamper.FormFlattening = false;




                    //PdfFormWidget formWidget = pdfStamper.FormFlattening as PdfFormWidget;
                    //for(int i=0; i< formWidget.FieldsWidget.List.Count; i++)
                    //{
                    //    PdfField field = formWidget.FieldsWidget.List[i] as PdfField;
                    //    string fieldNavn = field.Name;
                    //    bool isRequired = field.Required;
                    //    if(isRequired)
                    //    {
                    //        MessageBox.Show("Mangler du nogle?");
                    //    }
                    //}




                   // pdfStamper.FormFlattening = false;
                    pdfStamper.Close();
                   //pdfWebViewer.Navigate(new Uri("about:blank"));
                   pdfWebViewer.Navigate(newFile);


                }
            }

        }

        public void clear()
        {
            IEnumerable<RadioButton> radioButtons = radioButtonValidation.Children.OfType<RadioButton>();
            Dictionary<string, List<RadioButton>> radioBtnList = new Dictionary<string, List<RadioButton>>();



            foreach (RadioButton item in radioButtons)
            {
                if (item.GroupName == "RadioClass")
                {
                    item.IsChecked = false;
                }
                if (item.GroupName == "experience")
                {
                    item.IsChecked = false;
                }
                if (item.GroupName == "age")
                {
                    item.IsChecked = false;
                }


            }
            

            if (this.ComboboxValidation.SelectedItem != null)
            {
                this.ComboboxValidation.SelectedIndex = -1;
            }
        }

       

        private void passwordText_KeyDown(object sender, KeyEventArgs e)
        {
            ViewElevsList viewElevsList = new ViewElevsList();
            if (e.Key == Key.Enter)
            {
                if(passwordText.Password == "1234")
                {
                    viewElevsList.Show();
                    this.Close();
                }
                else if(passwordText.Password == "")
                {
                    MessageBox.Show("Indtast adgangskode!!");
                }
                else
                {
                    MessageBox.Show("ugyldig adgangskode!!");
                }

            }
            

        }
    }

}


        