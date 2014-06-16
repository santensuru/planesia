using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Models;

namespace Planesia.Repository
{
    public class FloraRepositoryMock : IFloraRepository
    {
        List<Flora> floras;

        public FloraRepositoryMock()
        {
            floras = new List<Flora>();

            floras.Add(new Flora() { FloraId = 1, FloraName = "ABC" });
            floras.Add(new Flora() { FloraId = 2, FloraName = "DEF" });
            floras.Add(new Flora() { FloraId = 3, FloraName = "GHI" });
            floras.Add(new Flora() { FloraId = 4, FloraName = "JKL" });
            floras.Add(new Flora() { FloraId = 5, FloraName = "MNO" });
        }
        
        public List<Flora> Floras
        {
            get { return floras; }
        }

        public Flora GetFloraById(int id)
        {
            Flora result = (from f in Floras
                            where f.FloraId == id
                            select f).FirstOrDefault<Flora>();

            return result;
        }

        public void AddFlora(Flora f)
        {
            floras.Add(f);
        }

        public void UpdateFlora(Flora f)
        {
            int index = floras.FindIndex(p => p.FloraId == f.FloraId);
            if (index < 0)
            {
                floras.Add(f);
            }
            else
            {
                floras[index] = f;
            }
        }

        public void DeleteFlora(int id)
        {
            Flora result = (from f in floras
                            where f.FloraId == id
                            select f).FirstOrDefault<Flora>();

            floras.Remove(result);
        }
    }
}