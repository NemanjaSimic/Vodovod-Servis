using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Service.Commands;

namespace Service.ViewModels
{
    public class PutDeoViewModel : BindableBase
    {
		private List<DEO_OPREME> deos;
		private List<string> magacins;
		private string idDeo;
		private string validationID;



		public List<string> Magacins { get => magacins; set { magacins = value; OnPropertyChanged("Magacins"); } }
		public List<DEO_OPREME> Deos { get => deos; set { deos = value; OnPropertyChanged("Deos"); } }
		public MAGACIN SelectedMagacin { get; set; }
		public DEO_OPREME SelectedDeo { get; set; }
		public ICommand PutCommand { get; set; }

		public string MAG { get; set; }
		public string IdDeo { get => idDeo; set { idDeo = value; OnPropertyChanged("IdDeo"); } }
		public string ValidationID { get => validationID; set { validationID = value; OnPropertyChanged("ValidationID"); } }



		public PutDeoViewModel()
		{
			Magacins = new List<string>();
			UpdateLists();
			PutCommand = new PutDeoMagacinCommand(this);
			ValidationID = String.Empty;
		}


		public void UpdateLists()
		{
			List<MAGACIN> tempMag = DBManager.Instance.GetMAGACINs();
			foreach (var item in tempMag)
			{
				Magacins.Add(item.ID_MAG);
			}
			Deos = DBManager.Instance.GetDEO_OPREMEs();
		}

		public bool CanPut
		{
			get { return Validate(); }
		}

		public void Put()
		{
			try
			{
				NALAZI_U novDeo = new NALAZI_U()
				{
					ID_DEO = IdDeo,
					DEO_OPREME_ID_TIP = SelectedDeo.ID_TIP,
					DEO_OPREME = SelectedDeo,
					MAGACIN = SelectedMagacin,
					MAGACIN_ID_MAG = SelectedMagacin.ID_MAG,
				};
				DBManager.Instance.CreateDeoMagacin(novDeo);
				IdDeo = String.Empty;
				UpdateLists();
			}
			catch (Exception)
			{
				MessageBox.Show("Deo sa datim ID-em vec postoji!", "Konflikt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public bool Validate()
		{
			bool retVal = true;
			if (SelectedMagacin == null || SelectedDeo == null)
			{
				retVal = false;
			}

			if (String.IsNullOrEmpty(ValidationID))
			{
				retVal = false;
				ValidationID = "ID dela opreme ne sme biti prazan!";
			}
			else if (ValidationID.Length > 10)
			{
				retVal = false;
				ValidationID = "ID dela opreme ne sme biti duzi od 10 karaktera!";
			}
			else
			{
				ValidationID = String.Empty;
			}


			return retVal;
		}

    }
}
