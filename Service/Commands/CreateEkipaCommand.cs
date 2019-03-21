using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class CreateEkipaCommand : ICommand
	{
		private EkipeViewModel EkipeViewModel;
		public CreateEkipaCommand(EkipeViewModel ekipeViewModel)
		{
			EkipeViewModel = ekipeViewModel;
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
			return EkipeViewModel.CanCreate;
		}

		public void Execute(object parameter)
		{
			EkipeViewModel.Create();
		}
	}
}
