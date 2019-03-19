using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class UpdateNadlzeniCommand : ICommand
	{
		private NadlezniViewModel NadlezniViewModel;
		public UpdateNadlzeniCommand(NadlezniViewModel nadlezniViewModel)
		{
			NadlezniViewModel = nadlezniViewModel;
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
			return NadlezniViewModel.CanUpdate;
		}

		public void Execute(object parameter)
		{
			NadlezniViewModel.Update();
		}
	}
}
