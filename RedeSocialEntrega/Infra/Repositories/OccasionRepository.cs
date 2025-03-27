using Domain;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class OccasionRepository : IOccasionRepository
    {
        private readonly SqlContext sqlContext;

        public OccasionRepository()
        {
            sqlContext = new SqlContext();
        }

        public bool AddOccasion(Occasion occasion)
        {
            if (occasion == null) return false;
            sqlContext.Occasions.Add(occasion);
            sqlContext.SaveChanges();
            return true;
        }

        public bool DeleteOccasion(int id)
        {
            if (id <= 0) return false;
            var occasion = sqlContext.Occasions.Find(id);
            sqlContext.Occasions.Remove(occasion);
            return true;
        }

        public List<Occasion> GetAll()
        {
            return sqlContext.Occasions.ToList();
        }

        public Occasion GetOccasionById(int id)
        {
            return sqlContext.Occasions.Find(id);
        }

        public bool UpdateOccasion(int id, Occasion occasion)
        {
            var occasionOld = sqlContext.Occasions.Find(id);

            if (occasionOld == null)
            {
                throw new KeyNotFoundException("Occasion/Event not found!");
            }

            occasionOld.Name = occasion.Name;
            occasionOld.Locale = occasion.Locale;
            occasionOld.Description = occasion.Description;
            occasionOld.DateHour = occasion.DateHour;

            sqlContext.SaveChanges();
            return true;
        }
    }
}
