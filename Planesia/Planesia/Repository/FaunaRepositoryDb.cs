using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Models;
using System.Data.Entity;

namespace Planesia.Repository
{
    public class FaunaRepositoryDb : IFaunaRepository
    {
        private PlanesiaDBsEntities context = new PlanesiaDBsEntities();

        public List<Fauna> Faunas
        {
            get
            {
                List<Fauna> result;

                result = context.Faunas.ToList();

                return result;
            }
        }

        public Fauna GetFaunaById(int id)
        {
            Fauna fauna;

            fauna = (from c in context.Faunas
                     where c.FaunaId == id
                     select c).FirstOrDefault<Fauna>();

            return fauna;
        }

        public void AddFauna(Fauna f)
        {
            context.Faunas.Add(f);
            context.SaveChanges();
        }

        public void UpdateFauna(Fauna f)
        {
            context.Entry(f).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteFauna(int id)
        {
            Fauna fauna;
            fauna = context.Faunas.Find(id);
            context.Faunas.Remove(fauna);
            context.SaveChanges();
        }
    }
}