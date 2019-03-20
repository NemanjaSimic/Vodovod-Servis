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
	public class UpdateMagacinViewModel : BindableBase
	{
		private string validationKap;
		private string stringKap;
		private MAGACIN magacin;

		public string ValidationKap { get => validationKap; set { validationKap = value; OnPropertyChanged("ValidationKap"); } }
		public string StringKap { get => stringKap; set { stringKap = value; OnPropertyChanged("StringKap"); } }
		public MAGACIN Magacin { get => magacin; set { magacin = value; OnPropertyChanged("Magacin"); } }
		public Window MyWindow { get; set; }
		public MagacinViewModel MVM { get; set; }

		public ICommand SaveChangesCommand { get; set; }

		public UpdateMagacinViewModel()
		{
			SaveChangesCommand = new SaveChangesMagacinCommand(this);

			ValidationKap = String.Empty;
		}

		public void Save()
		{
			try
			{
				DBManager.Instance.UpdateMagacin(Magacin);
			}
			catch (Exception)
			{
				MessageBox.Show("Nepoznata greska prilikom promene!", "Geska!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			MyWindow.Close();
			MVM.UpdateList();
		}

		public bool CanSave
		{
			get { return Validate(); }
		}

		private bool Validate()
		{
			bool retVal = true;
			if (String.IsNullOrEmpty(StringKap))
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
					Magacin.KAPACITET = (short)kapTemp;
					ValidationKap = String.Empty;
				}
			}
			return retVal;
		}
	}
}
