using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class UpdateMagacinCommand : ICommand
	{
		private MagacinViewModel MagacinViewModel;
		public UpdateMagacinCommand(MagacinViewModel magacinViewModel)
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
			return MagacinViewModel.CanUpdate;
		}

		public void Execute(object parameter)
		{
			MagacinViewModel.Update();
		}
	}
}
