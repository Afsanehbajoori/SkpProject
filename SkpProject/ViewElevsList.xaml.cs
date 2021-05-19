using DataAccess;
using DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ViewElevsList.xaml
    /// </summary>
    public partial class ViewElevsList : Window
    {
        ElevDataAccess elevDataAccess = new ElevDataAccess();
        ObservableCollection<Elev> elevs = new ObservableCollection<Elev>();
        public Elev currentElev { get; set; } = new Elev();

        //public ViewElevsList()
        //{
        //    InitializeComponent();
        //    fillData();
        //    ElevsGrid.ItemsSource = elevs;
        //}

        //private void fillData()
        //{
        //    elevs = elevDataAccess.elevs;
        //}


        private void ElevsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (ElevsGrid.SelectedItems)
            //{
                currentElev = ElevsGrid.SelectedItems as Elev;
               // ElevLable.Content = currentElev.GetBasicInfo();
            //}
            

        }

        private void btnGodkendt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSlet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
