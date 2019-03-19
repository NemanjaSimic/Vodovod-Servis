using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class SaveChangesRadnikCommand: ICommand
	{
		private UpdateRadnikViewModel UpdateRadnikViewModel;
		public SaveChangesRadnikCommand(UpdateRadnikViewModel updateRadnikViewModel)
		{
			UpdateRadnikViewModel = updateRadnikViewModel;
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
			return UpdateRadnikViewModel.CanSave;
		}

		public void Execute(object parameter)
		{
			UpdateRadnikViewModel.Save();
		}
	}
}
