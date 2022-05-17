using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace acervo_filmes
{
    public class MovieCollection : ICollection<Movie>
    {
        private List<Movie> movieList = new List<Movie>();

        public void ReadFile()
        {
            Movie newMovie;
            var path = Path.Combine(Environment.CurrentDirectory, "files", "file.txt");
            StreamReader file = new StreamReader(path);
            string[] line;
            while (!file.EndOfStream)
            {
                line = file.ReadLine().Split(';');
                newMovie = new Movie(int.Parse(line[0]), line[1], line[2], line[3], (Genders)int.Parse(line[4]));
                movieList.Add(newMovie);
            }
            file.Close();
        }
        public void Start()
        {
            ReadFile();
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
                    case "3":
                        Insert();
                        break;
                    case "4":
                        Update();
                        break;
                    case "5":
                        Delete();
                        break;
                    case "6":
                        WriteLine("Programa encerrado!");
                        break;
                    default:
                        WriteLine("\nDigite uma opção válida");
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
                        WriteLine($"Nome: {movie.Name}, >> Filme deletado da lista\n");
                    else
                    {
                        WriteLine($"Id: {movie.Id}, \tNome: {movie.Name}");
                        WriteLine($"Descrição: {movie.Description}");
                        WriteLine($"Gênero: {movie.Gender}");
                        WriteLine($"Ano: {movie.Year}");
                        WriteLine();
                    }
                }
            }
            WriteLine("\n[Enter] para continuar");
            ReadKey();
        }
        public void GetById()
        {
            int idSearch = GetIdSearch();

            if (movieList.Exists(x => x.Id == idSearch))
            {
                if (movieList[idSearch - 1].Deleted == true)
                    WriteLine($"Nome: {movieList[idSearch - 1]}, Filme deletado da lista");
                else
                {
                    WriteLine($"Nome: {movieList[idSearch - 1].Name}");
                    WriteLine($"Descrição: {movieList[idSearch - 1].Description}");
                    WriteLine($"Gênero: {movieList[idSearch - 1].Gender}");
                    WriteLine($"Ano: {movieList[idSearch - 1].Year}");
                }
            }
            else
                WriteLine("Filme não encontrado");
            WriteLine("\n[Enter] para continuar");
            ReadKey();
        }
        public int GetIdSearch()
        {
            int idSearch = 0;
            do
            {
                Clear();
                WriteLine("ACERVO DE FILMES");
                Write("\nDigite o Id para localizar: ");
                try
                {
                    idSearch = int.Parse(ReadLine());
                    break;
                }
                catch
                {
                    WriteLine("Digite um valor válido");
                    WriteLine("[Enter] para continuar");
                    ReadKey();
                }
            } while (true);
            WriteLine();

            return idSearch;
        }
        public void Update()
        {
            int idSearch = GetIdSearch();

            if (movieList.Exists(x => x.Id == idSearch))
            {
                if (movieList[idSearch - 1].Deleted == true)
                    WriteLine($"O filme: {movieList[idSearch - 1].Name} >> foi deletado");
                else
                {
                    string name;
                    string description;
                    string year;
                    int gender;

                    Clear();
                    WriteLine("ACERVO DE FILMES");
                    WriteLine("Informações Atuais:");
                    WriteLine($"Nome: {movieList[idSearch - 1].Name}");
                    WriteLine($"Descrição: {movieList[idSearch - 1].Description}");
                    WriteLine($"Gênero: {movieList[idSearch - 1].Gender}");
                    WriteLine($"Ano: {movieList[idSearch - 1].Year}");

                    WriteLine("\nPreencha com novas informações:");
                    try
                    {
                        Write("Nome: ");
                        name = ReadLine();
                        Write("Descrição: ");
                        description = ReadLine();
                        WriteLine("Escolha um Gênero: ");
                        foreach (int i in Enum.GetValues(typeof(Genders)))
                            WriteLine($"[{i}] {Enum.GetName(typeof(Genders), i)}");
                        gender = int.Parse(ReadLine());
                        Write("Ano: ");
                        year = ReadLine();

                        movieList[idSearch - 1].Name = name;
                        movieList[idSearch - 1].Description = description;
                        movieList[idSearch - 1].Gender = (Genders)gender;
                        movieList[idSearch - 1].Year = year;
                        WriteLine("Filme atualizado!");
                    }
                    catch
                    {
                        WriteLine("Valores válidos");
                    }
                }
            }
            else
                WriteLine("Filme não encontrado");
            WriteLine("\n[Enter] para continuar");
            ReadKey();
        }
        public void Insert()
        {
            string name;
            string description;
            string year;
            int gender;
            Movie newMovie;

            WriteLine("Preencha com as informações:");
            try
            {
                Write("Nome: ");
                name = ReadLine();
                Write("Descrição: ");
                description = ReadLine();
                WriteLine("Escolha um Gênero: ");
                foreach (int i in Enum.GetValues(typeof(Genders)))
                    WriteLine($"[{i}] {Enum.GetName(typeof(Genders), i)}");
                gender = int.Parse(ReadLine());
                Write("Ano: ");
                year = ReadLine();

                newMovie = new Movie(movieList.Count + 1, name, description, year, (Genders)gender);
                movieList.Add(newMovie);
                WriteLine("Filme adicionado!");
            }
            catch
            {
                WriteLine("Valores válidos");
            }
            WriteLine("[Enter] para continuar");
            ReadKey();
        }
        public void Delete()
        {
            int idSearch = GetIdSearch();
            string choose;

            if (movieList.Exists(x => x.Id == idSearch))
            {
                try
                {
                    WriteLine($"Filme: {movieList[idSearch - 1].Name}");
                    WriteLine("[1] Confirmar");
                    WriteLine("[2] Cancelar");
                    choose = ReadLine();

                    if (choose == "1")
                    {
                        movieList[idSearch - 1].Deleted = true;
                        WriteLine("Filme deletado!");
                    }
                    else if (choose == "2")
                        WriteLine("Operação cancelada");
                    else
                        WriteLine("Opção não existente");
                }
                catch
                {
                    WriteLine("Valores inválidos");
                }
            }
            else
                WriteLine("Filme não encontrado");
            WriteLine("\n[Enter] para continuar");
            ReadKey();
        }
    }
}