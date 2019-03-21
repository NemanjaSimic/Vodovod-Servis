﻿using Service.Commands;
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
    public class DeoOpremeViewModel : BindableBase
    {
		private List<DEO_OPREME> deo_Opremes;
		private DEO_OPREME newDeo;
		private string validationTip;
		private string validationID;
		private string idTip;
		private string validationMagacin;
		private string idDeo;
		private string validationDeo;

		public List<DEO_OPREME> Deo_Opremes { get => deo_Opremes; set { deo_Opremes = value; OnPropertyChanged("Deo_Opremes"); } }
		public DEO_OPREME NewDeo { get => newDeo; set { newDeo = value; OnPropertyChanged("NewDeo"); } }
		public DEO_OPREME SelectedDeo { get; set; }
		public string SelectedMagacin { get; set; }
		public string IdTip { get => idTip; set { idTip = value; OnPropertyChanged("IdTip"); } }
		public string IdDeo { get => idDeo; set { idDeo = value; OnPropertyChanged("IdDeo"); } }
		public List<string> Magacins { get; set; }

		#region Commands
		public ICommand CreateCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand PutCommand { get; set; }
		#endregion

		#region Validations
		public string ValidationDeo { get => validationDeo; set { validationDeo = value; OnPropertyChanged("ValidationDeo"); } }
		public string ValidationTip { get => validationTip; set { validationTip = value; OnPropertyChanged("ValidationTip"); } }
		public string ValidationID { get => validationID; set { validationID = value; OnPropertyChanged("ValidationID"); } }
		public string ValidationMagacin { get => validationMagacin; set { validationMagacin = value; OnPropertyChanged("ValidationMagacin"); } }
		#endregion

		public DeoOpremeViewModel()
		{
			NewDeo = new DEO_OPREME();
			Magacins = new List<string>();

			CreateCommand = new CreateDeoCommand(this);
			DeleteCommand = new DeleteDeoCommand(this);
			UpdateCommand = new UpdateDeoCommand(this);
			PutCommand = new PutDeoCommand(this);

			ValidationTip = String.Empty;
			ValidationID = String.Empty;
			SelectedMagacin = String.Empty;
			ValidationMagacin = String.Empty;


			UpdateList();
		}

		public void UpdateList()
		{
			try
			{
				Deo_Opremes = DBManager.Instance.GetDEO_OPREMEs();
				UpdateMagacins();
			}
			catch (Exception)
			{
				MessageBox.Show("Prekinuta konekcija sa bazom, restartujte aplikaciju!", "Greska na serveru!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void UpdateMagacins()
		{
			List<MAGACIN> tempList = DBManager.Instance.GetMAGACINs();
			foreach (var item in tempList)
			{
				Magacins.Add(item.ID_MAG);
			}

		}


		#region CRUD
		public void Create()
		{
			try
			{
				DBManager.Instance.CreateDeoOpreme(NewDeo);
				UpdateList();
				NewDeo = new DEO_OPREME();
				IdTip = String.Empty;
				SelectedMagacin = null;
			}
			catch (Exception)
			{
				MessageBox.Show("Deo opreme sa datom sifrom vec postoji!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
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
				DBManager.Instance.DeleteDeoOpreme(SelectedDeo.ID_TIP);
				UpdateList();
			}
			catch (Exception)
			{
				MessageBox.Show("Greska na servisu, izabrani deo ne postoji!", "Konflikt!", MessageBoxButton.OK, MessageBoxImage.Error);
				UpdateList();
			}
		}

		public bool CanDelete
		{
			get { return SelectedDeo == null ? false : true; }
		}

		public void Update()
		{
			Window win = new UpdateDeo();

			win.DataContext = new UpdateDeoViewModel()
			{
				Deo = new DEO_OPREME()
				{
					TIP_OPREME = SelectedDeo.TIP_OPREME,
					ID_TIP = SelectedDeo.ID_TIP
				},
				MyWindow = win,
				DOVM = this
			};

			win.ShowDialog();
		}

		public bool CanUpdate
		{
			get { return SelectedDeo == null ? false : true; }
		}
		#endregion

		public bool CanPut
		{
			get
			{
				bool retVal = true;
				if (SelectedDeo == null)
				{
					retVal = false;
				}

				if (String.IsNullOrEmpty(IdDeo))
				{
					ValidationDeo = "ID dela ne sme biti prazan!";
					retVal = false;
				}
				else if (IdDeo.Length > 10)
				{
					ValidationDeo = "ID dela ne sme biti duzi od 10 karaktera!";
					retVal = false;
				}
				else
				{
					ValidationDeo = String.Empty;
				}

				if (String.IsNullOrEmpty(SelectedMagacin))
				{
					ValidationMagacin = "Magacin mora biti izabran!";
					retVal = false;
				}
				else
				{
					ValidationMagacin = String.Empty;
				}
				return retVal;
			}
		}

		public void Put()
		{
			try
			{
				MAGACIN tempMag = DBManager.Instance.GetMagacinById(SelectedMagacin);
				NALAZI_U veza = new NALAZI_U()
				{
					DEO_OPREME_ID_TIP = SelectedDeo.ID_TIP,
					MAGACIN_ID_MAG = tempMag.ID_MAG,
					KOLICINA = 0,
					ID_DEO = IdDeo
				};
				DBManager.Instance.CreateDeoMagacin(veza);
				IdDeo = String.Empty;
				SelectedMagacin = null;
				SelectedDeo = null;
			}
			catch (Exception)
			{
				MessageBox.Show("Deo sa datim ID-em vec postoji!", "Konflikt!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private bool Validate()
		{
			bool retVal = true;

			if (String.IsNullOrEmpty(NewDeo.TIP_OPREME))
			{
				ValidationTip = "Naziv opreme ne sme biti prazan!";
				retVal = false;
			}
			else
			{
				ValidationTip = String.Empty;
			}

			if (String.IsNullOrEmpty(IdTip))
			{
				retVal = false;
				ValidationID = "ID TIP ne sme biti prazan!";
			}
			else if (!IdTip.All(char.IsNumber))
			{
				retVal = false;
				ValidationID = "ID TIP mora sadrzati samo brojeve!";
			}
			else if (Int32.TryParse(IdTip, out int idTipTemp))
			{
				if (idTipTemp > 255 || idTipTemp < 1)
				{
					retVal = false;
					ValidationID = "ID TIP mora biti broj manji od 256!";
				}
				else
				{
					NewDeo.ID_TIP = (byte)idTipTemp;
					ValidationID = String.Empty;
				}
			}
			return retVal;
		}
	}
}
