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
	public class UpdateKorisnikViewModel : BindableBase
	{
		private string validationIme;
		private string validationPrez;
		private KORISNIK korisnik;

		public string ValidationIme { get => validationIme; set { validationIme = value; OnPropertyChanged("ValidationIme"); } }
		public string ValidationPrez { get => validationPrez; set { validationPrez = value; OnPropertyChanged("ValidationPrez"); } }
		public KORISNIK Korisnik { get => korisnik; set { korisnik = value; OnPropertyChanged("Korisnik"); } }
		public Window MyWindow { get; set; }
		public KorisniciViewModel KVWM { get; set; }

		public ICommand SaveChangesCommand { get; set; }

		public UpdateKorisnikViewModel()
		{
			SaveChangesCommand = new SaveChangesKorisnikCommand(this);

			ValidationIme = "";
			ValidationPrez = "";
		}

		public void Save()
		{
			try
			{
				DBManager.Instance.UpdateKorisnik(Korisnik);
			}
			catch (Exception)
			{
				MessageBox.Show("Nepoznata greska prilikom promene!", "Geska!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			MyWindow.Close();
			KVWM.UpdateList();
		}

		public bool CanSave
		{
			get { return Validate(); }
		}

		private bool Validate()
		{
			bool retVal = true;
			if (String.IsNullOrEmpty(Korisnik.IME_KOR))
			{
				ValidationIme = "Ime ne sme biti prazno!";
				retVal = false;
			}
			else
			{
				ValidationIme = "";
			}


			if (String.IsNullOrEmpty(Korisnik.PREZ_KOR))
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
