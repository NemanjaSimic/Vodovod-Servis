using System;
using System.Collections.Generic;
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
using Service.ViewModels;

namespace Service
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		#region DataContext
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void NadlezniButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new NadlezniViewModel();
		}

		private void MrezeButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new MrezeViewModel();
		}

		private void KorisniciButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new KorisniciViewModel();
		}

		private void EkipeButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new EkipeViewModel();
		}

		private void RadniNalogButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new RadniNalogViewModel();
		}

		private void MagacinButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new MagacinViewModel();
		}

		private void DeoOpremeButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new DeoOpremeViewModel();
		}

		private void LokacijaButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new LokacijaViewModel();
		}

		private void KvaroviButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new KvarViewModel();
		}

		private void RacuniButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new RadniNalogViewModel();
		}

		private void RadniciButton_Click(object sender, RoutedEventArgs e)
		{
			DataContext = new RadniciViewModel();
		}
		#endregion
	}
}
