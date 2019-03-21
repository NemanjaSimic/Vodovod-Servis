using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Service.Commands;
using Service.Views;

namespace Service.ViewModels
{
	public class RadniciViewModel : BindableBase
	{
		private List<RADNIIK> radnici;
		private ZAPOSLENI newZaposleni;
		private string validationEkipa;
		private List<string> ekipe;
		private string validationIme;
		private string validationPrez;
		private string validationJMBG;

		public List<RADNIIK> Radnici { get => radnici; set { radnici = value; OnPropertyChanged("Radnici"); } }
		public ZAPOSLENI NewZaposleni { get => newZaposleni; set { newZaposleni = value; OnPropertyChanged("NewZaposleni"); } }
		public RADNIIK SelectedRadnik { get; set; }
		public string SelectedEkipa { get; set; }
		public List<string> Ekipe { get => ekipe; set { ekipe = value; OnPropertyChanged("Ekipe"); } }

		#region Commands
		public ICommand CreateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand PutInCommand { get; set; }
		public ICommand TakeOutCommand { get; set; }
		#endregion

		#region Validations
		public string ValidationEkipa { get => validationEkipa; set { validationEkipa = value; OnPropertyChanged("ValidationEkipa"); } }
		public string ValidationIme { get => validationIme; set { validationIme = value; OnPropertyChanged("ValidationIme"); } }
		public string ValidationPrez { get => validationPrez; set { validationPrez = value; OnPropertyChanged("ValidationPrez"); } }
		public string ValidationJMBG { get => validationJMBG; set { validationJMBG = value; OnPropertyChanged("ValidationJMBG"); } }
		#endregion

		public RadniciViewModel()
		{
			UpdateList();
			UpdateEkipe();
			NewZaposleni = new ZAPOSLENI();

			CreateCommand = new CreateRadnikCommand(this);
			DeleteCommand = new DeleteRadnikCommand(this);
			UpdateCommand = new UpdateRadnikCommand(this);
			PutInCommand = new PutInEkipaCommand(this);
			TakeOutCommand = new TakeOutFromEkipaCommand(this);

			ValidationIme = String.Empty;
			ValidationPrez = String.Empty;
			ValidationJMBG = String.Empty;
			ValidationEkipa = String.Empty;
		}

		public void UpdateList()
		{
			try
			{
				Radnici = DBManager.Instance.GetRADNICIs();
				GetCredentialsForNadleznis();
			}
			catch (Exception)
			{
				MessageBox.Show("Prekinuta konekcija sa bazom, restartujte aplikaciju!", "Greska na serveru!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void UpdateEkipe()
		{
			List<EKIPA> tempList = DBManager.Instance.GetEKIPAs();
			Ekipe = new List<string>();
			foreach (var item in tempList)
			{
				Ekipe.Add(item.ID_EK);
			}
		}

		private void GetCredentialsForNadleznis()
		{
			List<RADNIIK> tempList = new List<RADNIIK>();
			ZAPOSLENI tempZaposleni = null;
			foreach (var item in Radnici)
			{
				RADNIIK tempRadnik = new RADNIIK() { JMBG_ZAP = item.JMBG_ZAP, EKIPA_ID_EK = item.EKIPA_ID_EK };
				tempZaposleni = DBManager.Instance.GetZaposleniByJMBG(item.JMBG_ZAP);
				tempRadnik.ZAPOSLENI = tempZaposleni;
				tempList.Add(tempRadnik);
			}
			Radnici = tempList;
		}

		#region CRUD
		public void Create()
		{
			try
			{
				NewZaposleni.RADNIIK = new RADNIIK() { JMBG_ZAP = NewZaposleni.JMBG_ZAP, ZAPOSLENI = NewZaposleni };
				DBManager.Instance.CreateRadnik(NewZaposleni);
				UpdateList();
				NewZaposleni = new ZAPOSLENI();
			}
			catch (Exception)
			{
				MessageBox.Show("Zaposleni sa datim JMBG-om vec postoji!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
				UpdateList();
			}
		}

		public bool CanCreate()
		{
			return Validate();
		}

		public void Delete()
		{
			try
			{
				DBManager.Instance.DeleteRadnik(SelectedRadnik.JMBG_ZAP);
				UpdateList();
			}
			catch (Exception)
			{
				MessageBox.Show("Zaposleni se nalazi u nekoj ekipi!", "Konflikt!", MessageBoxButton.OK, MessageBoxImage.Error);
				UpdateList();
			}
		}

		public bool CanDelete
		{
			get { return SelectedRadnik == null ? false : true; }
		}

		public void Update()
		{
			Window win = new UpdateRadnik();

			win.DataContext = new UpdateRadnikViewModel()
			{
				Radnik = new RADNIIK()
				{ JMBG_ZAP = SelectedRadnik.JMBG_ZAP,
					ZAPOSLENI = new ZAPOSLENI()
					{
						JMBG_ZAP = SelectedRadnik.JMBG_ZAP,
						IME_ZAP = SelectedRadnik.ZAPOSLENI.IME_ZAP,
						PREZ_ZAP = SelectedRadnik.ZAPOSLENI.PREZ_ZAP
					}
				},
				MyWindow = win,
				NVWM = this
			};
			
			win.ShowDialog();
		}

		public bool CanUpdate
		{
			get { return SelectedRadnik == null ? false : true; }
		}
		#endregion

		public void PutInEkipa()
		{
			try
			{
				if(String.IsNullOrEmpty(SelectedRadnik.EKIPA_ID_EK))
				{
					SelectedRadnik.EKIPA_ID_EK = SelectedEkipa;
					DBManager.Instance.UpdateRadnik(SelectedRadnik);
				}
				else
				{
					MessageBox.Show("Radnik se vec nalazi u jednoj od ekipa!","Konflikt",MessageBoxButton.OK, MessageBoxImage.Error);
				}
				UpdateList();
			}
			catch (Exception)
			{
				MessageBox.Show("Greska pri konekciji sa bazom!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public bool CanPutIn
		{
			get { return ValidatePutIn(); }
		}

		public void TakeOutFromEkipa()
		{
			try
			{
				if (!String.IsNullOrEmpty(SelectedRadnik.EKIPA_ID_EK))
				{
					SelectedRadnik.EKIPA_ID_EK = null;
					DBManager.Instance.UpdateRadnik(SelectedRadnik);
				}
				else
				{
					MessageBox.Show("Radnik se ne nalazi ni u jednoj od ekipa!", "Konflikt", MessageBoxButton.OK, MessageBoxImage.Error);

				}
				UpdateList();
			}
			catch (Exception)
			{
				MessageBox.Show("Greska pri konekciji sa bazom!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public bool CanTakeOut
		{
			get { return SelectedRadnik == null ? false : true; }
		}
		private bool Validate()
		{
			bool retVal = true;

			if (String.IsNullOrEmpty(NewZaposleni.IME_ZAP))
			{
				ValidationIme = "Ime ne sme biti prazno!";
				retVal = false;
			}
			else
			{
				ValidationIme = String.Empty;
			}

			if (String.IsNullOrEmpty(NewZaposleni.PREZ_ZAP))
			{
				ValidationPrez = "Prezime ne sme biti prazno!";
				retVal = false;
			}
			else
			{
				ValidationPrez = String.Empty;
			}

			if (String.IsNullOrEmpty(NewZaposleni.JMBG_ZAP))
			{
				retVal = false;
				ValidationJMBG = "JMBG ne sme biti prazan!";
			}
			else if (!NewZaposleni.JMBG_ZAP.All(char.IsNumber))
			{
				retVal = false;
				ValidationJMBG = "JMBG mora sadrzati samo brojeve!";
			}
			else if (NewZaposleni.JMBG_ZAP.Length != 13)
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

		private bool ValidatePutIn()
		{
			bool retVal = true;

			if (String.IsNullOrEmpty(SelectedEkipa))
			{
				retVal = false;
				ValidationEkipa = "Izabrati ekipu za ubacivanje radnika!";
			}
			else
			{
				ValidationEkipa = String.Empty;
			}

			if (SelectedRadnik == null)
			{
				retVal = false;
			}

			return retVal;
		}

	}
}
