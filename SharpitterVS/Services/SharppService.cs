using System;
using System.Linq;
using SharpitterVS.Models;
using SharpitterVS.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpitterVS.Services {
	
	public class SharppService {

        //private SharpitterDbMysql db;
        private SharpitterDbLocal db;
		
		public SharppService () {
            //this.db = new SharpitterDbMysql();
            this.db = new SharpitterDbLocal();
		}

		public bool PostSharpp(Sharpp _sharpp){
            db.Sharpps.Add(_sharpp);
            db.SaveChanges();
			return true;
		}

		public bool ExcluiSharpp(Sharpp _sharpp){
            db.Sharpps.Remove(_sharpp);
            db.SaveChanges();
            return true;
		}

		public List<Sharpp> GetRecentes(){
            var result = from s in db.Sharpps
                         orderby s.Registro descending
                         select s;

            List<Sharpp> sharpps = new List<Sharpp>();

            foreach (Sharpp s in result) {
                sharpps.Add(s);
            }

            return sharpps;
        }

        public void DeleteAll() {
            foreach(Sharpp s in db.Sharpps.ToList<Sharpp>()) {
                this.ExcluiSharpp(s);
            }
        }

	}

}