using System;

namespace acervo_filmes.entities
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieCollection movieCollection = new MovieCollection();
            movieCollection.Start();
            Console.ReadKey();
        }
    }
}
