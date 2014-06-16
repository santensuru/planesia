using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Models;

namespace Planesia.Repository
{
    public class FaunaRepositoryMock : IFaunaRepository
    {
        List<Fauna> faunas;

        public FaunaRepositoryMock()
        {
            faunas = new List<Fauna>();

            faunas.Add(new Fauna() { FaunaId = 1, FaunaName = "ABC" });
            faunas.Add(new Fauna() { FaunaId = 2, FaunaName = "DEF" });
            faunas.Add(new Fauna() { FaunaId = 3, FaunaName = "GHI" });
            faunas.Add(new Fauna() { FaunaId = 4, FaunaName = "JKL" });
            faunas.Add(new Fauna() { FaunaId = 5, FaunaName = "MNO" });
        }
        
        public List<Fauna> Faunas
        {
            get { return faunas; }
        }

        public Fauna GetFaunaById(int id)
        {
            Fauna result = (from f in Faunas
                            where f.FaunaId == id
                            select f).FirstOrDefault<Fauna>();

            return result;
        }

        public void AddFauna(Fauna f)
        {
            faunas.Add(f);
        }

        public void UpdateFauna(Fauna f)
        {
            int index = faunas.FindIndex(p => p.FaunaId == f.FaunaId);
            if (index < 0)
            {
                faunas.Add(f);
            }
            else
            {
                faunas[index] = f;
            }
        }

        public void DeleteFauna(int id)
        {
            Fauna result = (from f in faunas
                            where f.FaunaId == id
                            select f).FirstOrDefault<Fauna>();

            faunas.Remove(result);
        }
    }
}