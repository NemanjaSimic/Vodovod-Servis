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
    public class MagacinViewModel : BindableBase
    {
		private List<MAGACIN> magacins;
		private MAGACIN newMagacin;
		private string validationKap;
		private string validationID;
		private string stringKap;

		#region Properties
		public List<MAGACIN> Magacins { get => magacins; set { magacins = value; OnPropertyChanged("Magacins"); } }
		public MAGACIN NewMagacin { get => newMagacin; set { newMagacin = value; OnPropertyChanged("NewMagacin"); } }
		public MAGACIN SelectedMagacin { get; set; }
		public string StringKap { get => stringKap; set { stringKap = value; OnPropertyChanged("StringKap"); } }
		#endregion

		#region Commands
		public ICommand CreateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		#endregion

		#region Validations
		public string ValidationKap { get => validationKap; set { validationKap = value; OnPropertyChanged("ValidationKap"); } }
		public string ValidationID { get => validationID; set { validationID = value; OnPropertyChanged("ValidationID"); } }
		#endregion

		public MagacinViewModel()
		{
			UpdateList();
			NewMagacin = new MAGACIN();

			CreateCommand = new CreateMagacinCommand(this);
			DeleteCommand = new DeleteMagacinCommand(this);
			UpdateCommand = new UpdateMagacinCommand(this);

			ValidationKap = "Kapacitet ne sme biti prazan!";
			ValidationID = "ID Magacina ne sme biti prazan!";
		}

		public void UpdateList()
		{
			try
			{
				Magacins = DBManager.Instance.GetMAGACINs();
			}
			catch (Exception)
			{
				MessageBox.Show("Prekinuta konekcija sa bazom, restartujte aplikaciju!", "Greska na serveru!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}


		#region CRUD
		public void Create()
		{
			try
			{
				DBManager.Instance.CreateMagacin(NewMagacin);
				UpdateList();
				NewMagacin = new MAGACIN();
				StringKap = String.Empty;

			}
			catch (Exception)
			{
				MessageBox.Show("Magacin sa datim ID-em vec postoji!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
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
				MAGACIN m = DBManager.Instance.GetMagacinById(SelectedMagacin.ID_MAG);
				DBManager.Instance.DeleteMagacin(SelectedMagacin.ID_MAG);
				UpdateList();
			}
			catch (Exception)
			{
				MessageBox.Show("Magacin mora biti prazan da bi se izbrisao!", "Konflikt!", MessageBoxButton.OK, MessageBoxImage.Error);
				UpdateList();
			}
		}

		public bool CanDelete
		{
			get { return SelectedMagacin == null ? false : true; }
		}

		public void Update()
		{
			Window win = new UpdateMagacin();

			win.DataContext = new UpdateMagacinViewModel()
			{
				Magacin = new MAGACIN()
				{
					ID_MAG = SelectedMagacin.ID_MAG,
					KAPACITET = SelectedMagacin.KAPACITET
				},
				MyWindow = win,
				MVM = this,
				StringKap = SelectedMagacin.KAPACITET.ToString()
			};

			win.ShowDialog();
		}

		public bool CanUpdate
		{
			get { return SelectedMagacin == null ? false : true; }
		}
		#endregion

		private bool Validate()
		{
			bool retVal = true;

			if (String.IsNullOrWhiteSpace(NewMagacin.ID_MAG))
			{
				ValidationID = "ID magacina ne sme biti prazan!";
				retVal = false;
			}
			else
			{
				ValidationID = String.Empty;
			}

			if (String.IsNullOrWhiteSpace(StringKap))
			{
				retVal = false;
				ValidationKap = "Kapacitet ne sme biti prazan!";
			}
			else if (!StringKap.All(char.IsNumber))
			{
				retVal = false;
				ValidationKap = "Kapacitet mora sadrzati samo brojeve!";
			}
			else if (Int32.TryParse(StringKap, out int kapTemp))
			{
				if (kapTemp > 32760)
				{
					retVal = false;
					ValidationKap = "Maksimalan kapacitet je 32760!";
				}
				else if (kapTemp < 1)
				{
					retVal = false;
					ValidationKap = "Kapacitet mora biti pozitivan!";
				}
				else
				{
					NewMagacin.KAPACITET = (short)kapTemp;
					ValidationKap = String.Empty;
				}
			}
			return retVal;
		}
	}
}
