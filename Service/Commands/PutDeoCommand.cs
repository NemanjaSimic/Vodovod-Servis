using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
    public class PutDeoCommand : ICommand
    {
		private DeoOpremeViewModel DeoOpremeViewModel;
		public PutDeoCommand(DeoOpremeViewModel deoOpremeViewModel)
		{
			DeoOpremeViewModel = deoOpremeViewModel;
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
			return DeoOpremeViewModel.CanPut;
		}

		public void Execute(object parameter)
		{
			DeoOpremeViewModel.Put();
		}
	}
}
