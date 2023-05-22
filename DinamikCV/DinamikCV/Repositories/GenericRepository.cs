using DinamikCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinamikCV.Repositories
{
    public class GenericRepository<T> where T: class, new()
    {
        DBCVEntities db=new DBCVEntities(); 
        public List <T> TList()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p); 
            db.SaveChanges();
        }

        public void TRemove(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        public T TGet(int id) 
        {
            return db.Set<T>().Find(id);
        
        }
    }
}