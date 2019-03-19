using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Service.Commands;
using Service.Models;
using Service.ViewModels;

namespace Service.ViewModels
{
	public class UpdateNadlezniViewModel : BindableBase
	{
		private string validationIme;
		private string validationPrez;
		private NADLEZNI nadlezni;

		public string ValidationIme { get => validationIme; set { validationIme = value; OnPropertyChanged("ValidationIme"); } }
		public string ValidationPrez { get => validationPrez; set { validationPrez = value; OnPropertyChanged("ValidationPrez"); } }
		public NADLEZNI Nadlezni { get => nadlezni; set { nadlezni = value; OnPropertyChanged("Nadlezni"); } }
		public Window MyWindow { get; set; }
		public NadlezniViewModel NVWM { get; set; }

		public ICommand SaveChangesCommand { get; set; }

		public UpdateNadlezniViewModel()
		{
			SaveChangesCommand = new SaveChangesNadlezniCommand(this);

			ValidationIme = "";
			ValidationPrez = "";
		}

		public void Save()
		{
			try
			{
				DBManager.Instance.UpdateNadlezni(Nadlezni);
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
			if (String.IsNullOrEmpty(Nadlezni.ZAPOSLENI.IME_ZAP))
			{
				ValidationIme = "Ime ne sme biti prazno!";
				retVal = false;
			}
			else
			{
				ValidationIme = "";
			}


			if (String.IsNullOrEmpty(Nadlezni.ZAPOSLENI.PREZ_ZAP))
			{
				ValidationPrez = "Ime ne sme biti prazno!";
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
