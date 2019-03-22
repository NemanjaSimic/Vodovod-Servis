using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class ProsecnaDubinaCommand : ICommand
	{
		private RadniciViewModel RadniciViewModel;
		public ProsecnaDubinaCommand(RadniciViewModel radniciViewModel)
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
			return RadniciViewModel.CanRacunajProsecnuDubinu;
		}

		public void Execute(object parameter)
		{
			RadniciViewModel.RacunajProsecnuDubinu();
		}
	}
}
