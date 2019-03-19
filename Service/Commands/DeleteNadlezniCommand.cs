using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.ViewModels;
using System.Windows.Input;

namespace Service.Commands
{
	public class DeleteNadlezniCommand : ICommand
	{
		private NadlezniViewModel NadlezniViewModel;
		public DeleteNadlezniCommand(NadlezniViewModel nadlezniViewModel)
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
			return NadlezniViewModel.CanDelete;
		}

		public void Execute(object parameter)
		{
			NadlezniViewModel.Delete();
		}
	}
}
