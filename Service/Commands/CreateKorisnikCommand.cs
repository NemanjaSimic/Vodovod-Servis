using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class CreateKorisnikCommand : ICommand
	{
		private KorisniciViewModel KorisniciViewModel;
		public CreateKorisnikCommand(KorisniciViewModel korisniciViewModel)
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
			return KorisniciViewModel.CanCreate;
		}

		public void Execute(object parameter)
		{
			KorisniciViewModel.Create();
		}
	}
}
