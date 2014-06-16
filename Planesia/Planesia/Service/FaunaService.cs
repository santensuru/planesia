using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Repository;
using Planesia.Models;

namespace Planesia.Service
{
    public class FaunaService
    {
        IFaunaRepository faunaRepository;

        public FaunaService()
        {
            faunaRepository = new FaunaRepositoryDb();
        }

        public FaunaService(IFaunaRepository repository)
        {
            faunaRepository = repository;
        }

        public List<Fauna> GetAllFaunas()
        {
            return faunaRepository.Faunas;
        }

        public Fauna GetFaunaById(int id)
        {
            return faunaRepository.GetFaunaById(id);
        }

        public void AddFauna(Fauna f)
        {
            faunaRepository.AddFauna(f);
        }

        public void UpdateFauna(Fauna f)
        {
            faunaRepository.UpdateFauna(f);
        }

        public void DeleteFauna(int id)
        {
            faunaRepository.DeleteFauna(id);
        }
    }
}