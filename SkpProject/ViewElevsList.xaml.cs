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

namespace SkpProject
{
    /// <summary>
    /// Interaction logic for ViewElevsList.xaml
    /// </summary>
    public partial class ViewElevsList : Window
    {

        public Student currentStudent { get; set; } = new Student();
        public ViewElevsList()
        {
            InitializeComponent();
           
        }

       


        

        private void btnGodkendt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSlet_Click(object sender, RoutedEventArgs e)
        {

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

        private void SearchStudentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchStudentBox.SelectedIndex >= 0)
            {
                Student stu = new Student();
                stu.CalculateAge();
                currentStudent = SearchStudentBox.SelectedItem as Student;
                //StudentsFullInfo.Content = currentStudent.FullInfo;
            }
        }
    }
}
