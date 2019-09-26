using DAL.dataBases;
using DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.actions
{
    public class post : iDALPost
    {
        private bdFaceRepositoryEntities db;

        public post()
        {
            this.db = new bdFaceRepositoryEntities();
        }
        public caUsers saveUser(caUsers model)
        {
            this.db.caUsers.Add(model);
            this.db.SaveChanges();
            return model;
        }

        public caFaces saveFace(caFaces model)
        {
            this.db.caFaces.Add(model);
            this.db.SaveChanges();
            return model;
        }

        public caPerson updatePerson(caPerson model)
        {
            this.db.caPerson.Add(model);
            this.db.Entry(model).State = EntityState.Modified;
            this.db.SaveChanges();

            return model;
        }

        public caUsers updateUser(caUsers model)
        {
            
            this.db.caUsers.Add(model);
            this.db.Entry(model).State = EntityState.Modified;
            this.db.SaveChanges();

            return model;
        }

        public void deactivateUser(int idUser)
        {
            caUsers model = this.db.caUsers.FirstOrDefault(qry => qry.id.Equals(idUser));

            if (model == null)
                throw new Exception("Usuario no encontrado en la base de datos");

            model.active = false;

            this.db.caUsers.Add(model);
            this.db.Entry(model).State = EntityState.Modified;
            this.db.SaveChanges();

        }

        public void deactivateFace(int idFace)
        {
            caFaces model = this.db.caFaces.FirstOrDefault(qry => qry.id.Equals(idFace));

            if (model == null)
                throw new Exception("Rostro no encontrado en la base de datos");

            model.active = false;

            this.db.caFaces.Add(model);
            this.db.Entry(model).State = EntityState.Modified;
            this.db.SaveChanges();
        }

    }
}
