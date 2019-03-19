using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class UpdateKorisnikCommand : ICommand
	{
		private KorisniciViewModel KorisniciViewModel;
		public UpdateKorisnikCommand(KorisniciViewModel korisniciViewModel)
		{
			KorisniciViewModel = korisniciViewModel;
		}
		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}

		public bool CanExecute(object parameter)
		{
			return KorisniciViewModel.CanUpdate;
		}

		public void Execute(object parameter)
		{
			KorisniciViewModel.Update();
		}
	}
}
