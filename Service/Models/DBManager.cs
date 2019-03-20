using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Models
{
	public class DBManager
	{
		private static DBManager instance;

		public static DBManager Instance
		{
			get
			{
				if (instance == null)
					instance = new DBManager();
				return instance;

			}
		}

		private DBManager() { }

		#region Zapolseni
		public void CreateZaposleni(ZAPOSLENI newZaposleni)
		{
			using (var dbManager = new VodovodEntities())
			{
				try
				{
					dbManager.ZAPOSLENIs.Add(newZaposleni);
					//dbManager.SaveChanges();
				}
				catch (Exception)
				{

					throw;
				}
				
			}
		}

		public void DeleteZaposleni(string jmbg)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.ZAPOSLENIs.Remove(dbManager.ZAPOSLENIs.ToList().Find(z => z.JMBG_ZAP.Equals(jmbg)));
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}


		public List<ZAPOSLENI> GetZaposlenis()
		{
			List<ZAPOSLENI> retVal = new List<ZAPOSLENI>();
			using (var dbManager = new VodovodEntities())
			{
				retVal = dbManager.ZAPOSLENIs.ToList();
			}
			return retVal;
		}

		public ZAPOSLENI GetZaposleniByJMBG(string jmbg)
		{
			ZAPOSLENI retVal = null;
			using (var dbManager = new VodovodEntities())
			{
				retVal = dbManager.ZAPOSLENIs.ToList().Find(z => z.JMBG_ZAP.Equals(jmbg));
			}
			return retVal;
		}
		#endregion

		#region Nadlezni
		public List<NADLEZNI> GetNADLEZNIs()
		{
			List<NADLEZNI> retVal = new List<NADLEZNI>();
			using (var dbManager = new VodovodEntities())
			{
				try
				{
					retVal = dbManager.NADLEZNIs.ToList();
				}
				catch (Exception)
				{

					throw;
				}
			}
			return retVal;
		}

		public void CreateNadlezni(ZAPOSLENI newZaposleni)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.NADLEZNIs.Add(newZaposleni.NADLEZNI);
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void DeleteNadlezni(string jmbg)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.NADLEZNIs.Remove(dbManager.NADLEZNIs.ToList().Find(n => n.JMBG_ZAP.Equals(jmbg)));
					dbManager.SaveChanges();
				}
				DeleteZaposleni(jmbg);

			}
			catch (Exception)
			{

				throw;
			}
		}

		public void UpdateNadlezni(NADLEZNI nadlezni)
		{
			DeleteNadlezni(nadlezni.JMBG_ZAP);
			CreateNadlezni(nadlezni.ZAPOSLENI);
		}
		#endregion

		#region Radnici
		public List<RADNIIK> GetRADNICIs()
		{
			List<RADNIIK> retVal = new List<RADNIIK>();
			using (var dbManager = new VodovodEntities())
			{
				try
				{
					retVal = dbManager.RADNIIKs.ToList();
				}
				catch (Exception)
				{

					throw;
				}
			}
			return retVal;
		}

		public void CreateRadnik(ZAPOSLENI newZaposleni)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.RADNIIKs.Add(newZaposleni.RADNIIK);

					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void DeleteRadnik(string jmbg)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.RADNIIKs.Remove(dbManager.RADNIIKs.ToList().Find(n => n.JMBG_ZAP.Equals(jmbg)));
					dbManager.SaveChanges();
				}
				DeleteZaposleni(jmbg);

			}
			catch (Exception)
			{

				throw;
			}
		}

		public void UpdateRadnik(RADNIIK radnik)
		{
			DeleteRadnik(radnik.JMBG_ZAP);
			CreateRadnik(radnik.ZAPOSLENI);
		}
		#endregion

		#region Korisnici
		public List<KORISNIK> GetKORISNICIs()
		{
			List<KORISNIK> retVal = new List<KORISNIK>();
			using (var dbManager = new VodovodEntities())
			{
				try
				{
					retVal = dbManager.KORISNIKs.ToList();
				}
				catch (Exception)
				{

					throw;
				}
			}
			return retVal;
		}

		public void CreateKorisnik(KORISNIK newKorisnik)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.KORISNIKs.Add(newKorisnik);
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void DeleteKorisnik(string jmbg)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.KORISNIKs.Remove(dbManager.KORISNIKs.ToList().Find(n => n.JMBG_KOR.Equals(jmbg)));
					dbManager.SaveChanges();
				}

			}
			catch (Exception)
			{

				throw;
			}
		}

		public void UpdateKorisnik(KORISNIK korisnik)
		{
			DeleteKorisnik(korisnik.JMBG_KOR);
			CreateKorisnik(korisnik);
		}
		#endregion
	}
}
