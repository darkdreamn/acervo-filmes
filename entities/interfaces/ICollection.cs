using System.Collections.Generic;
namespace acervo_filmes
{
    public interface ICollection<T>
    {
        void List();
        void GetById();
        void Insert(T item);
        void Delete(int id);
        void Update(int id, T item);
    }
}