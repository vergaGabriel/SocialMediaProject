using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IPostageRepository
    {
        Postage GetPostageById(int id);
        bool AddPostage(Postage postage);
        List<Postage> GetAll();
        bool UpdatePostage(int id, Postage postage);
        bool DeletePostage(int id);
    }
}
