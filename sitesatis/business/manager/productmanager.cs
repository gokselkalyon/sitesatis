﻿using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace sitesatis.Models.repository.manager
{
    public class productmanager : IDatabase<product>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();

        public void create(product t)
        {
            DB.products.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.products.Remove(DB.products.Find(id));
            DB.SaveChanges();
        }

        public product filterread(Expression<Func<product, bool>> filtre)
        {

            return DB.products.SingleOrDefault(filtre);
        }

        public IEnumerable<product> read()
        {
           
            return DB.products.ToList();
        }

        public void update(product t)
        {
            DB.products.Attach(t);
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
        public int count()
        {
            return DB.products.Count();
        }

    }
}