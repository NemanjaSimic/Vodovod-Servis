using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class SaveChangesMagacinCommand : ICommand
	{
		private UpdateMagacinViewModel UpdateMagacinViewModel;
		public SaveChangesMagacinCommand(UpdateMagacinViewModel updateMagacinViewModel)
		{
			UpdateMagacinViewModel = updateMagacinViewModel;
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
			return UpdateMagacinViewModel.CanSave;
		}

		public void Execute(object parameter)
		{
			UpdateMagacinViewModel.Save();
		}
	}
}
