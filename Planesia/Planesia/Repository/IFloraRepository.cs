using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planesia.Models;

namespace Planesia.Repository
{
    public interface IFloraRepository
    {
        List<Flora> Floras { get; }

        Flora GetFloraById(int id);

        void AddFlora(Flora f);

        void UpdateFlora(Flora f);

        void DeleteFlora(int id);
    }
}
