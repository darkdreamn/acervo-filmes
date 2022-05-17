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
                    case "1":
                        List();
                        break;
                    case "2":
                        GetById();
                        break;
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
        public void List()
        {
            Clear();
            WriteLine("ACERVO DE FILMES");
            WriteLine("\nMostrar todos os filmes: \n");

            if (movieList.Count == 0)
                WriteLine("Nenhum filme cadastrado");
            else
            {
                foreach (var movie in movieList)
                {
                    if (movie.Deleted == true)
                        WriteLine($"Nome: {movie.Name}, File deletado da lista");
                    else
                    {
                        WriteLine($"Id: {movie.Id}, Nome: {movie.Name}");
                        WriteLine($"Descrição: {movie.Description}");
                        WriteLine($"Gênero: {movie.Gender}, Ano: {movie.Year}");
                    }
                }
            }
            WriteLine("[Enter] para continuar");
            ReadKey();
        }
        public void GetById()
        {
            int idSearch = 0;

            Clear();
            WriteLine("ACERVO DE FILMES");
            Write("\nDigite o Id para localizar: ");
            idSearch = int.Parse(ReadLine());
            WriteLine();

            if (movieList.Exists(x => x.Id == idSearch))
            {
                WriteLine($"Nome: {movieList[idSearch].Name}");
                WriteLine($"Descrição: {movieList[idSearch].Description}");
                WriteLine($"Gênero: {movieList[idSearch].Gender}, Ano: {movieList[idSearch].Year}");
            }
            else
                WriteLine("Filme não encontrado");
            WriteLine("[Enter] para continuar");
            ReadKey();
        }
        public void Update(int id, Movie movie) => movieList[id] = movie;

        public void Delete(int id) => movieList[id].Delete();

        public void Insert(Movie movie) => movieList.Add(movie);

    }
}