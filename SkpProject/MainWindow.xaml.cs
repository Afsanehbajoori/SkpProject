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
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using SkpProject;



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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           
            bool isValid = true;
            bool isValid2 = true;
            //isValid2 = validationOfErfaring();
            isValid = validationRadioButtonMethod();
           
            if (!isValid)

            {
                MessageBox.Show("Du skal udfylde alle felter!");
                this.Focus();
            }

            else if(!isValid2)
            {
                MessageBox.Show("Du skal udfylde alle felter!");
                this.Focus();
            }
            
            else if(ComboboxValidation.SelectedIndex <0)
            {
                MessageBox.Show("Du skal udfylde alle felter!");
                this.Focus();
            }
            else
            {
                MessageBox.Show("Er du sikker?");
                clear();
            }
            

        }

        public void clear()
        {
            IEnumerable<RadioButton> radioButtons = radioButtonValidation.Children.OfType<RadioButton>();
            Dictionary<string, List<RadioButton>> radioBtnList = new Dictionary<string, List<RadioButton>>();



            foreach (RadioButton item in radioButtons)
            {
                if (item.GroupName == "RadioClass" )
                {
                    item.IsChecked = false;
                }
                if(item.GroupName == "erfaring")
                {
                    item.IsChecked = false;
                }
                if (item.GroupName == "age")
                {
                    item.IsChecked = false;
                }


            }

            if(this.ComboboxValidation.SelectedItem !=null)
            {
                this.ComboboxValidation.SelectedIndex = -1;
            }
        }

        private void signinButton_Click(object sender, RoutedEventArgs e)
        {
            ViewElevsList viewelevslist = new ViewElevsList();
            viewelevslist.Show();
            this.Close();
        }

        private void søgeElevText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            Student stu = new Student();
            stu.CalculateAge();
            List<Student> GetStudents = _data.students.Where(student => (student.FirstName.ToLower()).StartsWith(text.ToLower()) || student.LastName.ToLower().StartsWith(text.ToLower())).ToList();
            //List<Student> GetStudents = Data.students.Where(student => (student.FirstName).StartsWith(text)).ToList();
            SearchStudentBox.ItemsSource = GetStudents;
            //ObservableCollection<Student> GetStudents = Data.students.Select(student => (student.FirstName).StartsWith(text)).ToList();
        }

        private void SearchStudentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SearchStudentBox.SelectedIndex >= 0)
            {
                Student stu = new Student();
                stu.CalculateAge();
                currentStudent = SearchStudentBox.SelectedItem as Student;
                StudentsFullInfo.Content = currentStudent.FullInfo;
            }
        }

        private void calculateAge_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        
        private void DateTimePiker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var today = DateTime.Today;
            var age = today.Year - DateTimePiker.SelectedDate.Value.Year;
            //if(DateTimePiker.SelectedDate.Value.Date) > today.AddYears(-age)) age--;
            ShowAge.Text = Convert.ToString(age);
        }

        

        private void regneAge_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student();
            stu.CalculateAge();
            
        }

        private void btnOpenPdfFile_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            ////fileWatch();
            //OpenPdfFile openPdfFile = new OpenPdfFile();
            //openPdfFile.Show();
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF |*.pdf";
            Nullable<bool> result = openFile.ShowDialog();

            if ((bool)result)
            {
                string path = openFile.FileName;
                pdfWebViewer.Navigate(new Uri("about:blank"));
                pdfWebViewer.Navigate(path);
            }
        }

    }




}


        