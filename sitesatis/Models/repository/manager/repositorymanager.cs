using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sitesatis.Models.repository.manager
{
    public class repositorymanager : IDatabase<entity.repository>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();

        public void create(entity.repository t)
        {
            DB.repositories.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.repositories.Remove(DB.repositories.Find(id));
            DB.SaveChanges();
        }

        public entity.repository filterread(int id)
        {
           return DB.repositories.Find(id);
        }

        public IEnumerable<entity.repository> read()
        {
            return DB.repositories.ToList();
        }

        public void update(entity.repository t)
        {
            DB.repositories.Attach(t);
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}