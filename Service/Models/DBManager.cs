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

		#region Deo Opreme

		public List<DEO_OPREME> GetDEO_OPREMEs()
		{
			List<DEO_OPREME> retVal = new List<DEO_OPREME>();
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					retVal = dbManager.DEO_OPREME.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return retVal;
		}

		public void CreateDeoOpreme(DEO_OPREME newDeo)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.DEO_OPREME.Add(newDeo);
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void DeleteDeoOpreme(byte idDeo)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.DEO_OPREME.Remove(dbManager.DEO_OPREME.ToList().Find(d => d.ID_TIP == idDeo));
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void UpdateDeoOpreme(DEO_OPREME deo)
		{
			DeleteDeoOpreme(deo.ID_TIP);
			CreateDeoOpreme(deo);
		}
		#endregion

		#region Magacin
		public List<MAGACIN> GetMAGACINs()
		{
			List<MAGACIN> retVal = new List<MAGACIN>();
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					retVal = dbManager.MAGACINs.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return retVal;
		}

		public void CreateMagacin(MAGACIN newMagacin)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.MAGACINs.Add(newMagacin);
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void DeleteMagacin(string idMag)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.MAGACINs.Remove(dbManager.MAGACINs.ToList().Find(m => m.ID_MAG.Equals(idMag)));
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void UpdateMagacin(MAGACIN magacin)
		{
			DeleteMagacin(magacin.ID_MAG);
			CreateMagacin(magacin);
		}

		public MAGACIN GetMagacinById(string id)
		{
			MAGACIN retVal = new MAGACIN();
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					retVal = dbManager.MAGACINs.ToList().Find(m => m.ID_MAG.Equals(id));
				}
			}
			catch (Exception)
			{

				throw;
			}
			return retVal;
		}
		#endregion

		#region DeoMagacin
		public void CreateDeoMagacin(NALAZI_U novDeo)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.NALAZI_U.Add(novDeo);
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		#endregion

		#region Ekipa
		public List<EKIPA> GetEKIPAs()
		{
			List<EKIPA> retVal = new List<EKIPA>();
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					retVal = dbManager.EKIPAs.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return retVal;
		}

		public void CreateEkipa(EKIPA newEkipa)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.EKIPAs.Add(newEkipa);
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void DeleteEkipa(string idEkipa)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.EKIPAs.Remove(dbManager.EKIPAs.ToList().Find(e => e.ID_EK.Equals(idEkipa)));
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void UpdateEkipa(EKIPA ekipa)
		{
			DeleteEkipa(ekipa.ID_EK);
			CreateEkipa(ekipa);
		}

		public EKIPA GetEkipaById(string id)
		{
			EKIPA retVal = new EKIPA();
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					retVal = dbManager.EKIPAs.ToList().Find(e => e.ID_EK.Equals(id));
				}
			}
			catch (Exception)
			{

				throw;
			}
			return retVal;
		}
		#endregion
	}
}
