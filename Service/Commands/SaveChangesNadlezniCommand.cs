using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.ViewModels;

namespace Service.Commands
{
	public class SaveChangesNadlezniCommand : ICommand
	{
		private UpdateNadlezniViewModel UpdateNadlezniViewModel;
		public SaveChangesNadlezniCommand(UpdateNadlezniViewModel updateNadlezniViewModel)
		{
			UpdateNadlezniViewModel = updateNadlezniViewModel;
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
			return UpdateNadlezniViewModel.CanSave;
		}

		public void Execute(object parameter)
		{
			UpdateNadlezniViewModel.Save();
		}
	}
}
