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
    public class EkipeViewModel : BindableBase
    {
		private List<EKIPA> ekipas;
		private EKIPA newEkipa;
		private string validationID;

		public List<EKIPA> Ekipas { get => ekipas; set { ekipas = value; OnPropertyChanged("Ekipas"); } }
		public EKIPA NewEkipa { get => newEkipa; set { newEkipa = value; OnPropertyChanged("NewEkipa"); } }
		public EKIPA SelectedEkipa { get; set; }
	

		#region Commands
		public ICommand CreateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		#endregion

		#region Validations
		public string ValidationID { get => validationID; set { validationID = value; OnPropertyChanged("ValidationID"); } }
		#endregion

		public EkipeViewModel()
		{
			UpdateList();
			NewEkipa = new EKIPA();

			CreateCommand = new CreateEkipaCommand(this);
			DeleteCommand = new DeleteEkipaCommand(this);
			//UpdateCommand = new UpdateEkipaCommand(this);

			ValidationID = "ID ekipe ne sme biti prazan!";
		}

		public void UpdateList()
		{
			try
			{
				Ekipas = DBManager.Instance.GetEKIPAs();
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
				NewEkipa.BR_RAD = 0;
				DBManager.Instance.CreateEkipa(NewEkipa);
				UpdateList();
				NewEkipa = new EKIPA();
				ValidationID = String.Empty;

			}
			catch (Exception)
			{
				MessageBox.Show("Ekipa sa datim ID-em vec postoji!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
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
				DBManager.Instance.DeleteEkipa(SelectedEkipa.ID_EK);
				UpdateList();
			}
			catch (Exception)
			{
				MessageBox.Show("Greska na servisu, izabrana ekipa ne postoji!", "Konflikt!", MessageBoxButton.OK, MessageBoxImage.Error);
				UpdateList();
			}
		}

		public bool CanDelete
		{
			get { return SelectedEkipa == null ? false : true; }
		}

		public void Update()
		{
			//Window win = new UpdateMagacin();

			//win.DataContext = new UpdateMagacinViewModel()
			//{
			//	Magacin = new MAGACIN()
			//	{
			//		ID_MAG = SelectedMagacin.ID_MAG,
			//		KAPACITET = SelectedMagacin.KAPACITET
			//	},
			//	MyWindow = win,
			//	MVM = this,
			//	StringKap = SelectedMagacin.KAPACITET.ToString()
			//};

			//win.ShowDialog();
		}

		public bool CanUpdate
		{
			get { return SelectedEkipa == null ? false : true; }
		}
		#endregion

		private bool Validate()
		{
			bool retVal = true;

			if (String.IsNullOrEmpty(NewEkipa.ID_EK))
			{
				ValidationID = "ID ekipe ne sme biti prazan!";
				retVal = false;
			}
			else if (NewEkipa.ID_EK.Length > 10)
			{
				ValidationID = "ID ekipe ne sme biti duzi od 10 karaktera!";
				retVal = false;
			}
			else
			{
				ValidationID = String.Empty;
			}
			
			return retVal;
		}
	}
}
