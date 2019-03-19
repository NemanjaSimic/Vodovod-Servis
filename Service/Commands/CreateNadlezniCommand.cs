using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.ViewModels;
using Service.Commands;

namespace Service.Commands
{
	public class CreateNadlezniCommand : ICommand
	{
		private NadlezniViewModel NadlezniViewModel;
		public CreateNadlezniCommand(NadlezniViewModel nadlezniViewModel)
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
			return NadlezniViewModel.CanCreate();
		}

		public void Execute(object parameter)
		{
			NadlezniViewModel.Create();
		}
	}
}
