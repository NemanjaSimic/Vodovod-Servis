using Service.Commands;
using Service.Models;
using Service.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Service.ViewModels
{
    public class KorisniciViewModel : BindableBase
    {
		private List<KORISNIK> korisnici;
		private KORISNIK newKorisnik;
		private string validationIme;
		private string validationPrez;
		private string validationJMBG;

		public List<KORISNIK> Korisnici { get => korisnici; set { korisnici = value; OnPropertyChanged("Korisnici"); } }
		public KORISNIK NewKorisnik { get => newKorisnik; set { newKorisnik = value; OnPropertyChanged("newKorisnik"); } }
		public KORISNIK SelectedKorisnik { get; set; }

		#region Commands
		public ICommand CreateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		#endregion

		#region Validations
		public string ValidationIme { get => validationIme; set { validationIme = value; OnPropertyChanged("ValidationIme"); } }
		public string ValidationPrez { get => validationPrez; set { validationPrez = value; OnPropertyChanged("ValidationPrez"); } }
		public string ValidationJMBG { get => validationJMBG; set { validationJMBG = value; OnPropertyChanged("ValidationJMBG"); } }
		#endregion

		public KorisniciViewModel()
		{
			UpdateList();
			NewKorisnik = new KORISNIK();

			CreateCommand = new CreateKorisnikCommand(this);
			DeleteCommand = new DeleteKorisnikCommand(this);
			UpdateCommand = new UpdateKorisnikCommand(this);

			ValidationIme = "Ime ne sme biti prazno!";
			ValidationPrez = "Prezime ne sme biti prazno!";
			ValidationJMBG = "JMBG ne sme biti prazan!";
		}

		public void UpdateList()
		{
			try
			{
				Korisnici = DBManager.Instance.GetKORISNICIs();
				GetCredentialsForKorisnicis();
			}
			catch (Exception)
			{
				MessageBox.Show("Prekinuta konekcija sa bazom, restartujte aplikaciju!", "Greska na serveru!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void GetCredentialsForKorisnicis()
		{
			List<KORISNIK> tempList = new List<KORISNIK>();
			foreach (var item in Korisnici)
			{
				KORISNIK tempKorisnik = new KORISNIK()
				{
					JMBG_KOR = item.JMBG_KOR,
					IME_KOR = item.IME_KOR,
					PREZ_KOR = item.PREZ_KOR
				};
				tempList.Add(tempKorisnik);
			}
			Korisnici = tempList;
		}

		#region CRUD
		public void Create()
		{
			try
			{
				DBManager.Instance.CreateKorisnik(NewKorisnik);
				UpdateList();
				NewKorisnik = new KORISNIK();
			}
			catch (Exception)
			{
				MessageBox.Show("Korisnik sa datim JMBG-om vec postoji!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
				UpdateList();
			}
		}

		public bool CanCreate
		{
			get
			{
				return Validate();
			}
		}

		public void Delete()
		{
			try
			{
				DBManager.Instance.DeleteKorisnik(SelectedKorisnik.JMBG_KOR);
				UpdateList();
			}
			catch (Exception)
			{
				MessageBox.Show("Greska na servisu, izabrani korisnik ne postoji!", "Konflikt!", MessageBoxButton.OK, MessageBoxImage.Error);
				UpdateList();
			}
		}

		public bool CanDelete
		{
			get { return SelectedKorisnik == null ? false : true; }
		}

		public void Update()
		{
			Window win = new UpdateKorisnik();

			win.DataContext = new UpdateKorisnikViewModel()
			{
				Korisnik = new KORISNIK()
				{
					IME_KOR = SelectedKorisnik.IME_KOR,
					PREZ_KOR = SelectedKorisnik.PREZ_KOR,
					JMBG_KOR = SelectedKorisnik.JMBG_KOR
				},
				MyWindow = win,
				KVWM = this
			};

			win.ShowDialog();
		}

		public bool CanUpdate
		{
			get { return SelectedKorisnik == null ? false : true; }
		}
		#endregion

		private bool Validate()
		{
			bool retVal = true;

			if (String.IsNullOrEmpty(NewKorisnik.IME_KOR))
			{
				ValidationIme = "Ime ne sme biti prazno!";
				retVal = false;
			}
			else
			{
				ValidationIme = String.Empty;
			}

			if (String.IsNullOrEmpty(NewKorisnik.PREZ_KOR))
			{
				ValidationPrez = "Prezime ne sme biti prazno!";
				retVal = false;
			}
			else
			{
				ValidationPrez = String.Empty;
			}

			if (String.IsNullOrEmpty(NewKorisnik.JMBG_KOR))
			{
				retVal = false;
				ValidationJMBG = "JMBG ne sme biti prazan!";
			}
			else if (!NewKorisnik.JMBG_KOR.All(char.IsNumber))
			{
				retVal = false;
				ValidationJMBG = "JMBG mora sadrzati samo brojeve!";
			}
			else if (NewKorisnik.JMBG_KOR.Length != 13)
			{
				retVal = false;
				ValidationJMBG = "JMBG mora biti broj od 13 cifara!";
			}
			else
			{
				ValidationJMBG = String.Empty;
			}

			return retVal;
		}

	}
}
