using System.Collections.Generic;
using Model;
namespace Service
{
    public interface IService<T> where T : Entity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Save(T entity);
        void Update(T entity);
        void Delete(int id);
        int GenerateNewId();
        T GetByName(string name);
    }
}
