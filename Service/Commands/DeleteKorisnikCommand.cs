using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class DeleteKorisnikCommand : ICommand
	{
		private KorisniciViewModel KorisniciViewModel;
		public DeleteKorisnikCommand(KorisniciViewModel korisniciViewModel)
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
			return KorisniciViewModel.CanDelete;
		}

		public void Execute(object parameter)
		{
			KorisniciViewModel.Delete();
		}
	}
}
