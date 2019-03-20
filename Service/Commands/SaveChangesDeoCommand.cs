using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class SaveChangesDeoCommand : ICommand
	{
		private UpdateDeoViewModel UpdateDeoViewModel;
		public SaveChangesDeoCommand(UpdateDeoViewModel updateDeoViewModel)
		{
			UpdateDeoViewModel = updateDeoViewModel;
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
			return UpdateDeoViewModel.CanSave;
		}

		public void Execute(object parameter)
		{
			UpdateDeoViewModel.Save();
		}
	}
}

