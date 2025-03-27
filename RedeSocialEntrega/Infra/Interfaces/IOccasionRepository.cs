using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IOccasionRepository
    {
        Occasion GetOccasionById(int id);
        bool AddOccasion(Occasion occasion);
        List<Occasion> GetAll();
        bool UpdateOccasion(int id, Occasion occasion);
        bool DeleteOccasion(int id);
    }
}
