﻿using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.Commands
{
	public class BrojMagacinaCommand : ICommand
	{
		private RadniciViewModel RadniciViewModel;
		public BrojMagacinaCommand(RadniciViewModel radniciViewModel)
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
			return RadniciViewModel.CanRacunajBrojMagacina;
		}

		public void Execute(object parameter)
		{
			RadniciViewModel.RacunajBrojMagacina();
		}
	}
}
