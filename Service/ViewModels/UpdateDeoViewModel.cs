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
	public class UpdateDeoViewModel : BindableBase
	{
		private string validationTip;
		private DEO_OPREME deo;
		private string dubina;
		private string validationDubina;

		public string ValidationTip { get => validationTip; set { validationTip = value; OnPropertyChanged("ValidationTip"); } }
		public DEO_OPREME Deo { get => deo; set { deo = value; OnPropertyChanged("Deo"); } }
		public Window MyWindow { get; set; }
		public DeoOpremeViewModel DOVM { get; set; }
		public string Dubina { get => dubina; set { dubina = value; OnPropertyChanged("Dubina"); } }
		public string ValidationDubina { get => validationDubina; set { validationDubina = value; OnPropertyChanged("ValidationDubina"); } }

		public ICommand SaveChangesCommand { get; set; }

		public UpdateDeoViewModel()
		{
			SaveChangesCommand = new SaveChangesDeoCommand(this);

			ValidationTip = String.Empty;
		}

		public void Save()
		{
			try
			{
				DBManager.Instance.UpdateDeoOpreme(Deo);
			}
			catch (Exception)
			{
				MessageBox.Show("Nepoznata greska prilikom promene!", "Geska!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			MyWindow.Close();
			DOVM.UpdateList();
		}

		public bool CanSave
		{
			get { return Validate(); }
		}

		private bool Validate()
		{
			bool retVal = true;
			if (String.IsNullOrWhiteSpace(Deo.TIP_OPREME))
			{
				ValidationTip = "Naziv tipa ne sme biti prazan!";
				retVal = false;
			}
			else
			{
				ValidationTip = String.Empty;
			}

			if (String.IsNullOrWhiteSpace(Dubina))
			{
				ValidationDubina = "Dubina je obavezno poslje!";
				retVal = false;
			}
			else if (!Dubina.All(char.IsNumber))
			{
				ValidationDubina = "Dubina mora biti broj!";
				retVal = false;
			}
			else
			{
				Int32.TryParse(Dubina, out int d);
				if (d > 20 || d < 0)
				{
					ValidationDubina = "Dubina mora biti u rangu brojeva 0 - 20!";
					retVal = false;
				}
				else
				{
					ValidationDubina = String.Empty;
					Deo.DUBINA = (byte)d;
				}
			}

			return retVal;
		}
	}
}
