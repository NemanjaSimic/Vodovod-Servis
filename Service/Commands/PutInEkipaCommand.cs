using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.ViewModels;

namespace Service.Commands
{
	public class PutInEkipaCommand : ICommand
	{
		private RadniciViewModel RadniciViewModel;
		public PutInEkipaCommand(RadniciViewModel radniciViewModel)
		{
			RadniciViewModel = radniciViewModel;
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
			return RadniciViewModel.CanPutIn;
		}

		public void Execute(object parameter)
		{
			RadniciViewModel.PutInEkipa();
		}
	}
}
