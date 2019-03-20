using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class CreateMagacinCommand : ICommand
	{
		private MagacinViewModel MagacinViewModel;
		public CreateMagacinCommand(MagacinViewModel magacinViewModel)
		{
			MagacinViewModel = magacinViewModel;
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
			return MagacinViewModel.CanCreate;
		}

		public void Execute(object parameter)
		{
			MagacinViewModel.Create();
		}
	}
}
