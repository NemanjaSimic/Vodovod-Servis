using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service.ViewModels;

namespace Service.Commands
{
	public class DeleteEkipaCommand : ICommand
	{
		private EkipeViewModel EkipeViewModel;
		public DeleteEkipaCommand(EkipeViewModel ekipeViewModel)
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
			return EkipeViewModel.CanDelete;
		}

		public void Execute(object parameter)
		{
			EkipeViewModel.Delete();
		}
	}
}
