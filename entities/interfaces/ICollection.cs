using System.Collections.Generic;
namespace acervo_filmes
{
    public interface ICollection<T>
    {
        void List();
        void ObtainById();
        void Insert();
        void Delete();
        void Update();
    }
}