using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class CancelReservationCommand : ICommand
	{
		private StanjeViewModel StanjeViewModel;
		public CancelReservationCommand(StanjeViewModel stanjeViewModel)
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
			return StanjeViewModel.CanCancelReservation;
		}

		public void Execute(object parameter)
		{
			StanjeViewModel.CancelReservation();
		}
	}
}
