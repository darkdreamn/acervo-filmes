using System.Collections.Generic;
namespace acervo_filmes
{
    public interface ICollection<T>
    {
        List<T> List();
        T GetById(int id);
        void Insert(T item);
        void Delete(int id);
        void Update(int id, T item);
    }
}