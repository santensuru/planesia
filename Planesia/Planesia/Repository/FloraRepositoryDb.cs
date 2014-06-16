using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Models;
using System.Data.Entity;

namespace Planesia.Repository
{
    public class FloraRepositoryDb : IFloraRepository
    {
        private PlanesiaDBsEntities context = new PlanesiaDBsEntities();
        
        public List<Flora> Floras
        {
            get
            {
                List<Flora> result;

                result = context.Floras.ToList();

                return result;
            }
        }

        public Flora GetFloraById(int id)
        {
            Flora flora;

            flora = (from c in context.Floras
                        where c.FloraId == id
                        select c).FirstOrDefault<Flora>();

            return flora;
        }

        public void AddFlora(Flora f)
        {
            context.Floras.Add(f);
            context.SaveChanges();
        }

        public void UpdateFlora(Flora f)
        {
            context.Entry(f).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteFlora(int id)
        {
            Flora flora;
            flora = context.Floras.Find(id);
            context.Floras.Remove(flora);
            context.SaveChanges();
        }
    }
}