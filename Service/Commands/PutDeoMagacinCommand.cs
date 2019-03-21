using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.ViewModels;

namespace Service.Commands
{
    public class PutDeoMagacinCommand : ICommand
    {
		private PutDeoViewModel PutDeoViewModel;
		public PutDeoMagacinCommand(PutDeoViewModel putDeoViewModel)
		{
			PutDeoViewModel = putDeoViewModel;
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
			return PutDeoViewModel.CanPut;
		}

		public void Execute(object parameter)
		{
			PutDeoViewModel.Put();
		}
	}
}
