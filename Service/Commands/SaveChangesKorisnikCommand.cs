using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.ViewModels;

namespace Service.Commands
{
	public class SaveChangesKorisnikCommand : ICommand
	{
		private UpdateKorisnikViewModel UpdateKorisnikViewModel;
		public SaveChangesKorisnikCommand(UpdateKorisnikViewModel updateKorisnikViewModel)
		{
			UpdateKorisnikViewModel = updateKorisnikViewModel;
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
			return UpdateKorisnikViewModel.CanSave;
		}

		public void Execute(object parameter)
		{
			UpdateKorisnikViewModel.Save();
		}
	}
}
