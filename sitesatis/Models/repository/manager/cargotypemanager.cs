using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sitesatis.Models.repository.manager
{
    public class cargotypemanager : IDatabase<cargo_type>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();
        
        public void create(cargo_type t)
        {
            using (satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.cargo_type.Add(t);
                DB.SaveChanges();
            }
            
        }

        public void delete(int id)
        {
            using (satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.cargo_type.Remove(DB.cargo_type.Find(id));
                DB.SaveChanges();
            }
        }

        public cargo_type filterread(int id)
        {
            using (satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                return DB.cargo_type.Find(id);
            }
        }

        public IEnumerable<cargo_type> read()
        {
            using (satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                return DB.cargo_type.ToList();
            }
        }

        public void update(cargo_type t)
        {
            using (satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.cargo_type.Attach(t);
                DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }
        }
    }
}