using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.ViewModels;

namespace Service.Commands
{
	public class ReserveDeoCommand : ICommand
	{
		private StanjeViewModel StanjeViewModel;
		public ReserveDeoCommand(StanjeViewModel stanjeViewModel)
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
			return StanjeViewModel.CanReserve;
		}

		public void Execute(object parameter)
		{
			StanjeViewModel.Reserve();
		}
	}
}
