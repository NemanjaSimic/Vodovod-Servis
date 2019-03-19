using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;

namespace Service.ViewModels
{
    public class ZaposleniViewModel
    {
		private List<ZAPOSLENI> zaposleni;

		public ZaposleniViewModel()
		{
			UpdateList();
		}

		public List<ZAPOSLENI> Zaposleni { get => zaposleni; set => zaposleni = value; }

		public void UpdateList()
		{
			Zaposleni = DBManager.Instance.GetZaposlenis();
		}
	}
}
