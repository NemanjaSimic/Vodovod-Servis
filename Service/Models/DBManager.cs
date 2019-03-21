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
			using (var dbManager = new VodovodEntities())
			{
				dbManager.RADNIIKs.Add(newZaposleni.RADNIIK);

				dbManager.SaveChanges();
			}
		}

		public void DeleteRadnik(string jmbg)
		{
			using (var dbManager = new VodovodEntities())
			{
				dbManager.RADNIIKs.Remove(dbManager.RADNIIKs.ToList().Find(n => n.JMBG_ZAP.Equals(jmbg)));
				dbManager.SaveChanges();
			}
			DeleteZaposleni(jmbg);
		}

		public void UpdateRadnik(RADNIIK radnik)
		{
			using (var dbManager = new VodovodEntities())
			{
				RADNIIK tempRad = dbManager.RADNIIKs.ToList().Find(n => n.JMBG_ZAP.Equals(radnik.JMBG_ZAP));
				tempRad.EKIPA_ID_EK = radnik.EKIPA_ID_EK;
				dbManager.SaveChanges();
			}
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
			using (var dbManager = new VodovodEntities())
			{
				dbManager.KORISNIKs.Remove(dbManager.KORISNIKs.ToList().Find(n => n.JMBG_KOR.Equals(jmbg)));
				dbManager.SaveChanges();
			}
		}

		public void UpdateKorisnik(KORISNIK korisnik)
		{
			using (var dbManager = new VodovodEntities())
			{
				KORISNIK tempKor = dbManager.KORISNIKs.ToList().Find(n => n.JMBG_KOR.Equals(korisnik.JMBG_KOR));
				tempKor = korisnik;
				dbManager.SaveChanges();
			}
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

		public DEO_OPREME GetDeoOpremeByID(byte idTip)
		{
			DEO_OPREME retVal = new DEO_OPREME();
			using (var dbManager = new VodovodEntities())
			{
				retVal = dbManager.DEO_OPREME.ToList().Find(d => d.ID_TIP == idTip);
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
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public void UpdateDeoOpreme(DEO_OPREME deo)
		{
			using (var dbManager = new VodovodEntities())
			{
				DEO_OPREME temp = dbManager.DEO_OPREME.ToList().Find(d => d.ID_TIP == deo.ID_TIP);
				temp.TIP_OPREME = deo.TIP_OPREME;
				dbManager.SaveChanges();
			}

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
			using (var dbManager = new VodovodEntities())
			{
				MAGACIN temp = dbManager.MAGACINs.ToList().Find(m => m.ID_MAG.Equals(magacin.ID_MAG));
				temp.KAPACITET = magacin.KAPACITET;
				dbManager.SaveChanges();
			}
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

		public List<NALAZI_U> GetNALAZI_Us()
		{
			List<NALAZI_U> retVal = new List<NALAZI_U>();
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					retVal = dbManager.NALAZI_U.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return retVal;
		}
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

		public void DeleteDeoMagacin(NALAZI_U deo)
		{
			try
			{
				using (var dbManager = new VodovodEntities())
				{
					dbManager.NALAZI_U.Remove(dbManager.NALAZI_U.ToList()
						.Find(d => d.DEO_OPREME_ID_TIP == deo.DEO_OPREME_ID_TIP 
						&& d.MAGACIN_ID_MAG.Equals(deo.MAGACIN_ID_MAG) 
						&& d.ID_DEO.Equals(deo.ID_DEO)));
					dbManager.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void UpdateDeoMagacin(NALAZI_U deo)
		{
			DeleteDeoMagacin(deo);
			CreateDeoMagacin(deo);
			//try
			//{
			//	using (var dbManager = new VodovodEntities())
			//	{
			//		NALAZI_U temp = dbManager.NALAZI_U.ToList()
			//			.Find(d => d.DEO_OPREME_ID_TIP == deo.DEO_OPREME_ID_TIP
			//			&& d.MAGACIN_ID_MAG.Equals(deo.MAGACIN_ID_MAG)
			//			&& d.ID_DEO.Equals(deo.ID_DEO));
			//		temp.EKIPA_ID_EK = deo.EKIPA_ID_EK;
			//	}
			//}
			//catch (Exception)
			//{

			//	throw;
			//}
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
