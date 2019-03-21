using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class DeleteStanjeCommand : ICommand
	{
		private StanjeViewModel StanjeViewModel;
		public DeleteStanjeCommand(StanjeViewModel stanjeViewModel)
		{
			StanjeViewModel = stanjeViewModel;
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
			return StanjeViewModel.CanDelete;
		}

		public void Execute(object parameter)
		{
			StanjeViewModel.Delete();
		}
	}
}
