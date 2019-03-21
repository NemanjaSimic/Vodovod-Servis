using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Service.Models;
using Service.Commands;

namespace Service.ViewModels
{
	public class StanjeViewModel : BindableBase
	{
		private List<NALAZI_U> stanje;
		private List<string> ekipe;
		private string validationEkipa;

		#region Properties
		public List<NALAZI_U> Stanje { get => stanje; set { stanje = value; OnPropertyChanged("Stanje"); } }
		public List<string> Ekipe { get => ekipe; set { ekipe = value; OnPropertyChanged("Ekipe"); } }
		public NALAZI_U SelectedStanje { get; set; }
		public string SelectedEkipa { get; set; }
		public string ValidationEkipa { get => validationEkipa; set { validationEkipa = value; OnPropertyChanged("ValidationEkipa"); } }
		public ICommand ReserveCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand CancelReservationCommand { get; set; }
		#endregion

		public StanjeViewModel()
		{
			Stanje = new List<NALAZI_U>();
			Ekipe = new List<string>();

			ReserveCommand = new ReserveDeoCommand(this);
			DeleteCommand = new DeleteStanjeCommand(this);
			CancelReservationCommand = new CancelReservationCommand(this);

			ValidationEkipa = String.Empty;
			UpdateStanje();
			UpdateEkipe();
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

		public void UpdateStanje()
		{
			Stanje = DBManager.Instance.GetNALAZI_Us();
		}

		public bool CanDelete
		{
			get { return ValidateDelete(); }
		}

		public void Delete()
		{
			try
			{
				if (!String.IsNullOrWhiteSpace(SelectedStanje.EKIPA_ID_EK))
				{
					MessageBox.Show("Deo je rezervisan za ekipu!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DBManager.Instance.DeleteDeoMagacin(SelectedStanje);
					UpdateStanje();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Greska na servisu!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
				throw;
			}
		}


		public bool CanReserve
		{
			get { return ValidateReserve(); }
		}

		public void Reserve()
		{
			try
			{
				if (!String.IsNullOrWhiteSpace(SelectedStanje.EKIPA_ID_EK))
				{
					MessageBox.Show("Deo je vec rezervisan!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
					UpdateStanje();
				}
				else
				{
					SelectedStanje.EKIPA_ID_EK = SelectedEkipa;
					DBManager.Instance.UpdateDeoMagacin(SelectedStanje);
					SelectedStanje = null;
					UpdateStanje();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Greska na servisu!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
				throw;
			}
		}

		public bool CanCancelReservation
		{
			get { return SelectedStanje == null ? false : true; }
		}

		public void CancelReservation()
		{
			try
			{
				if (String.IsNullOrWhiteSpace(SelectedStanje.EKIPA_ID_EK))
				{
					MessageBox.Show("Deo nema rezervaciju!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
					UpdateStanje();
				}
				else
				{
					SelectedStanje.EKIPA_ID_EK = null;
					DBManager.Instance.UpdateDeoMagacin(SelectedStanje);
					SelectedStanje = null;
					UpdateStanje();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Greska na servisu!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
				throw;
			}
		}

		public bool ValidateReserve()
		{
			bool retVal = true;
			if (String.IsNullOrWhiteSpace(SelectedEkipa))
			{
				ValidationEkipa = "Ekipa mora biti izabrana!";
				retVal = false;
			}
			else
			{
				ValidationEkipa = String.Empty;
			}

			if (SelectedStanje == null)
			{
				retVal = false;
			}

			return retVal;
		}

		public bool ValidateDelete()
		{
			bool retVal = true;

			if (SelectedStanje == null)
			{
				retVal = false;
			}

			return retVal;
		}

	}
}
