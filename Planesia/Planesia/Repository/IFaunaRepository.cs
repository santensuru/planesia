using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planesia.Models;

namespace Planesia.Repository
{
    public interface IFaunaRepository
    {
        List<Fauna> Faunas { get; }

        Fauna GetFaunaById(int id);

        void AddFauna(Fauna f);

        void UpdateFauna(Fauna f);

        void DeleteFauna(int id);
    }
}
