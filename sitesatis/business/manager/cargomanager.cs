using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace sitesatis.Models.repository.manager
{
    public class cargomanager : IDatabase<cargo>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();
        public void create(cargo t)
        {
            DB.cargoes.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.cargoes.Remove(DB.cargoes.Find(id));
            DB.SaveChanges();
        }

        public cargo filterread(Expression<Func<cargo, bool>> filtre)
        {
            return DB.cargoes.SingleOrDefault(filtre);
        }

        public IEnumerable<cargo> read()
        {
            return DB.cargoes.ToList();
        }

        public void update(cargo t)
        {
            DB.cargoes.Attach(t);
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}