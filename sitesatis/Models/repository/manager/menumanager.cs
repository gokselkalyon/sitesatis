﻿using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sitesatis.Models.repository.manager
{
    public class menumanager:IDatabase<menu>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();

        public void create(menu t)
        {
            DB.menus.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.menus.Remove(DB.menus.Find());
            DB.SaveChanges();
        }

        public menu filterread(int id)
        {
            return DB.menus.Find(id);
        }

        public IEnumerable<menu> read()
        {
            return DB.menus.ToList();
        }

        public void update(menu t)
        {
            DB.menus.Attach(t);
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}