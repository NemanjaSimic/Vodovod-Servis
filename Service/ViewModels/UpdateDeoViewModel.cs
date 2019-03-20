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

		public string ValidationTip { get => validationTip; set { validationTip = value; OnPropertyChanged("ValidationTip"); } }
		public DEO_OPREME Deo { get => deo; set { deo = value; OnPropertyChanged("Deo"); } }
		public Window MyWindow { get; set; }
		public DeoOpremeViewModel DOVM { get; set; }

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
			if (String.IsNullOrEmpty(Deo.TIP_OPREME))
			{
				ValidationTip = "Naziv tipa ne sme biti prazan!";
				retVal = false;
			}
			else
			{
				ValidationTip = String.Empty;
			}

			return retVal;
		}
	}
}
