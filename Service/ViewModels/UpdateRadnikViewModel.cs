using Service.Commands;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Service.ViewModels
{
	public class UpdateRadnikViewModel : BindableBase
	{
		private string validationIme;
		private string validationPrez;
		private RADNIIK radnik;

		public string ValidationIme { get => validationIme; set { validationIme = value; OnPropertyChanged("ValidationIme"); } }
		public string ValidationPrez { get => validationPrez; set { validationPrez = value; OnPropertyChanged("ValidationPrez"); } }
		public RADNIIK Radnik { get => radnik; set { radnik = value; OnPropertyChanged("Radnik"); } }
		public Window MyWindow { get; set; }
		public RadniciViewModel NVWM { get; set; }

		public ICommand SaveChangesCommand { get; set; }

		public UpdateRadnikViewModel()
		{
			SaveChangesCommand = new SaveChangesRadnikCommand(this);

			ValidationIme = "";
			ValidationPrez = "";
		}

		public void Save()
		{
			try
			{
				DBManager.Instance.UpdateRadnik(Radnik);
			}
			catch (Exception)
			{
				MessageBox.Show("Nepoznata greska prilikom promene!", "Geska!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			MyWindow.Close();
			NVWM.UpdateList();
		}

		public bool CanSave
		{
			get { return Validate(); }
		}

		private bool Validate()
		{
			bool retVal = true;
			if (String.IsNullOrEmpty(Radnik.ZAPOSLENI.IME_ZAP))
			{
				ValidationIme = "Ime ne sme biti prazno!";
				retVal = false;
			}
			else
			{
				ValidationIme = "";
			}


			if (String.IsNullOrEmpty(Radnik.ZAPOSLENI.PREZ_ZAP))
			{
				ValidationPrez = "Prezime ne sme biti prazno!";
				retVal = false;
			}
			else
			{
				ValidationPrez = "";
			}
			return retVal;

		}
	}
}
