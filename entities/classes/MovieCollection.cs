using System.Collections.Generic;
using static System.Console;

namespace acervo_filmes
{
    public class MovieCollection : ICollection<Movie>
    {
        private List<Movie> movieList = new List<Movie>();
        public void Start()
        {
            string option;
            do
            {
                option = Menu();
                switch (option)
                {
                    case "1": break;
                    case "2": break;
                    case "3": break;
                    case "4": break;
                    case "5": break;
                    case "6":
                        WriteLine("Programa encerrado!");
                        break;
                    default:
                        WriteLine("Digite uma opção válida");
                        WriteLine("[Enter] para continuar");
                        ReadKey();
                        break;
                }

            } while (option != "6");
        }

        public string Menu()
        {
            Clear();
            WriteLine("ACERVO DE FILMES");
            WriteLine("\nEscolha uma opção:\n");
            WriteLine("[1] Listar filmes");
            WriteLine("[2] Buscar filme");
            WriteLine("[3] Inserir novo filmes");
            WriteLine("[4] Atualizar um filme");
            WriteLine("[5] Deletar um filme");
            WriteLine("[6] Fechar programa");
            return ReadLine();
        }


        public List<Movie> List() => movieList;

        public void Update(int id, Movie movie) => movieList[id] = movie;

        public void Delete(int id) => movieList[id].Delete();

        public void Insert(Movie movie) => movieList.Add(movie);

        public Movie GetById(int id) => movieList[id];
    }
}