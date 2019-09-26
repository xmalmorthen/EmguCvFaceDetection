using DAL.dataBases;
using DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.actions
{
    public class get : iDALGet
    {
        private bdFaceRepositoryEntities db;

        public get()
        {
            this.db = new bdFaceRepositoryEntities();
        }

        public List<caPerson> person(Expression<Func<caPerson, bool>> filter = null)
        {
            return this.db.caPerson.Where(filter).ToList();
        }

        public List<caUsers> user(Expression<Func<caUsers, bool>> filter = null)
        {
            return this.db.caUsers.Where(filter).ToList();
        }

        public List<caFaces> faces(Expression<Func<caFaces, bool>> filter = null)
        {
            return this.db.caFaces.Where(filter).ToList();
        }

        public Boolean userExistByNip(string model) {
            return this.user(qry => qry.nip.Equals(model.Trim()) && qry.active.Equals(true)).Any();
        }

        public Boolean userExistByUserName(string model)
        {
            return this.user(qry => qry.username.Equals(model.Trim()) && qry.active.Equals(true)).Any();
        }


    }
}
