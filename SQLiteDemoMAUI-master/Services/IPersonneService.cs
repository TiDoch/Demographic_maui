using MardocheDespagne_MAUI_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MardocheDespagne_MAUI_demo.Services
{
    public interface IPersonneService
    {
        Task<List<Personne>> GetPersonList();
        Task<int> AddPerson(Personne studentModel);
        Task<int> DeletePerson(Personne studentModel);
        Task<int> UpdatePerson(Personne studentModel);
    }
}
