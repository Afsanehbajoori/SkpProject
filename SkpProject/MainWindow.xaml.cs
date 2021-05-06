using DataAccess;
using DataAccess.Models;
using Microsoft.Win32;
using System;
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

namespace SkpProject
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ElevDataAccess elevDataAccess = new ElevDataAccess();

		ObservableCollection<Elev> elevs = new ObservableCollection<Elev>();

		//public Elev currentElev { get; set; } = new Elev();

		public MainWindow()
		{
			InitializeComponent();
			fillData();

		}

		private void fillData()
		{
			elevs = elevDataAccess.elevs;
		}


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

		private void btnChosseFile_Click(object sender, RoutedEventArgs e)
		{
			//OpenFileDialog openFileDialog1 = new OpenFileDialog();
			//if (openFileDialog1.ShowDialog() == DialogResult.HasValue)
			//         {
			//	this.txtBox_path.Text = openFileDialog1.FileName;
			//         }
		}

		private void btnLoadExcel_Click(object sender, RoutedEventArgs e)
		{


			//string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtBox_path.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
			//System.Data.OleDb.OleDbConnection conn = new OleDbConnection(PathConn);

			//OleDbDataAdapter myDataAdapter = new OleDbDataAdapter()





		}

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
			OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx", Multiselect = false };
            if(openFileDialog1.ShowDialog() == DialogResult.HasValue)
            {
				DataTable dt = new DataTable();
				using(XLWorkbook workbook = new XLWorkbook(openFileDialog1.FileName) )
                {
					bool isFirstRow = true;
					var rows = workbook.Worksheet(1).RowsUsed();
                    foreach (var row in rows)
                    {
						if (isFirstRow)
						{
							foreach (IXLCell cell in row.Cells())


								dt.Columns.Add(cell.Value.ToString());
							isFirstRow = false;
						}
						else

						{
							dt.Rows.Add();
							int i = 0;
							foreach (IXLCell cell in row.Cells())
								dt.Rows[dt.Rows.Count - 1][i++] = cell.Value.ToString();
						
                        }
                    }
					dataGridView.DataContext = dt.DefaultView;
					
                }

            }

            
        }
    }
}

        