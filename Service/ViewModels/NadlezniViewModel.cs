using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.Models;
using Service.Commands;
using System.Windows;
using Service.Views;

namespace Service.ViewModels
{
	public class NadlezniViewModel : BindableBase
	{
		private List<NADLEZNI> nadlezni;
		private ZAPOSLENI newZaposleni;
		private string validationIme;
		private string validationPrez;
		private string validationJMBG;

		public List<NADLEZNI> Nadlezni { get => nadlezni; set { nadlezni = value; OnPropertyChanged("Nadlezni"); } }
		public ZAPOSLENI NewZaposleni { get => newZaposleni; set { newZaposleni = value; OnPropertyChanged("NewZaposleni"); } }
		public NADLEZNI SelectedNadlezni { get; set; }

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

		public NadlezniViewModel()
		{
			UpdateList();
			NewZaposleni = new ZAPOSLENI();

			CreateCommand = new CreateNadlezniCommand(this);
			DeleteCommand = new DeleteNadlezniCommand(this);
			UpdateCommand = new UpdateNadlzeniCommand(this);

			ValidationIme = "Ime ne sme biti prazno!";
			ValidationPrez = "Prezime ne sme biti prazno!";
			ValidationJMBG = "JMBG ne sme biti prazan!";
		}

		public void UpdateList()
		{
			try
			{
				Nadlezni = DBManager.Instance.GetNADLEZNIs();
				GetCredentialsForNadleznis();
			}
			catch (Exception)
			{
				MessageBox.Show("Prekinuta konekcija sa bazom, restartujte aplikaciju!", "Greska na serveru!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void GetCredentialsForNadleznis()
		{
			List<NADLEZNI> tempList = new List<NADLEZNI>();
			ZAPOSLENI tempZaposleni = null;
			foreach (var item in Nadlezni)
			{
				NADLEZNI tempNadlezni = new NADLEZNI() { JMBG_ZAP = item.JMBG_ZAP };
				tempZaposleni = DBManager.Instance.GetZaposleniByJMBG(item.JMBG_ZAP);
				tempNadlezni.ZAPOSLENI = tempZaposleni;
				tempList.Add(tempNadlezni);
			}
			Nadlezni = tempList;
		}

		#region CRUD
		public void Create()
		{
			try
			{
				DBManager.Instance.CreateNadlezni(NewZaposleni);
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
				DBManager.Instance.DeleteNadlezni(SelectedNadlezni.JMBG_ZAP);
				UpdateList();
			}
			catch (Exception)
			{
				MessageBox.Show("Greska na servisu, izabrani zaposleni ne postoji!", "Konflikt!", MessageBoxButton.OK, MessageBoxImage.Error);
				UpdateList();
			}
		}

		public bool CanDelete
		{
			get { return SelectedNadlezni == null ? false : true; }
		}

		public void Update()
		{
			Window win = new UpdateNadlzeni();

			win.DataContext = new UpdateNadlezniViewModel()
			{
				Nadlezni = new NADLEZNI()
				{ JMBG_ZAP = SelectedNadlezni.JMBG_ZAP,
					ZAPOSLENI = new ZAPOSLENI()
					{
						JMBG_ZAP = SelectedNadlezni.JMBG_ZAP,
						IME_ZAP = SelectedNadlezni.ZAPOSLENI.IME_ZAP,
						PREZ_ZAP = SelectedNadlezni.ZAPOSLENI.PREZ_ZAP
					}
				},
				MyWindow = win,
				NVWM = this
			};
			
			win.ShowDialog();
		}

		public bool CanUpdate
		{
			get { return SelectedNadlezni == null ? false : true; }
		}
		#endregion

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

	}
}
