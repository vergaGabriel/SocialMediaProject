using Domain;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class PostageRepository : IPostageRepository
    {
        private readonly SqlContext sqlContext;

        public PostageRepository()
        {
            sqlContext = new SqlContext();
        }

        public bool AddPostage(Postage postage)
        {
            if (postage == null) return false;
            sqlContext.Postages.Add(postage);
            sqlContext.SaveChanges();
            return true;
        }

        public bool DeletePostage(int id)
        {
            if (id <= 0) return false;
            var postage = sqlContext.Postages.Find(id);
            sqlContext.Postages.Remove(postage);
            return true;
        }

        public List<Postage> GetAll()
        {
            return sqlContext.Postages.ToList();
        }

        public Postage GetPostageById(int id)
        {
            return sqlContext.Postages.Find(id);
        }

        public bool UpdatePostage(int id, Postage postage)
        {
            var postageOld = sqlContext.Postages.Find(id);

            if (postageOld == null)
            {
                throw new KeyNotFoundException("Postage not found!");
            }

            postageOld.Author = postage.Author;
            postageOld.Content = postage.Content;
            postageOld.DateHour = postage.DateHour;

            sqlContext.SaveChanges();
            return true;
        }
    }
}
