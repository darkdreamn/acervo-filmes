using System.Collections.Generic;

namespace acervo_filmes
{
    public class Movie : CollectionDetails
    {
        public Movie(int id, string name, string description, string year, Genders gender)
        : base(id, name, description, year, gender) { }


        public void Delete()
        {
            Deleted = true;
        }


    }
}