using System.Collections.Generic;
namespace acervo_filmes
{
    public interface ICollection<T>
    {
        void List();
        void GetById();
        void Insert();
        void Delete();
        void Update();
    }
}