//using MovieApp.Exceptions;
//using MovieApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MovieAppClassLibrary;
using MovieAppWithSerializerClassLibrary;
using MovieAppWithSerializerClassLibrary.Service;

namespace MovieAppWithSerializer
{
    internal class MovieController
    {
        private MovieManager movieManager;
        
        public MovieController() 
        {
            //movieManager = new MovieManager();
            movieManager = new MovieManager(DataSerializer.DeserializeMovies());
        }
        public void SaveMovies()
        {
            DataSerializer.SerializeMovies(movieManager.Movies);
        }
        public static void Start()
        {
            while (true)
            {
                DisplayMenu();
                bool result = int.TryParse(Console.ReadLine(), out int option);
                if (option == 1)
                {
                    Movie newMovie = SetMovieDetails();
                    try
                    {
                        Console.WriteLine(MovieManager.AddMovies(newMovie));
                    }
                    catch(MovieStoreFullException msfe)
                    {
                        Console.WriteLine(msfe.Message);
                    }
                    //Console.WriteLine(MovieManager.AddMovies(newMovie));
                }
                else if (option == 2)
                {
                    try
                    {
                        Console.WriteLine(MovieManager.DispayMovies());
                    }
                    catch(MovieStoreEmptyException msee)
                    {
                        Console.WriteLine(msee.Message);
                    }
                    //Console.WriteLine(MovieManager.DispayMovies());
                }
                else if (option == 3)
                {
                    Console.WriteLine(MovieManager.ClearMovies());
                }
                else if (option == 4)
                {
                    Console.Write("Enter the year to find movies: ");
                    int movieSearchYear = int.Parse(Console.ReadLine());
                    Console.WriteLine(MovieManager.FindMovieByYear(movieSearchYear));
                }
                else if (option == 5)
                {
                    Console.Write("Enter the name of the movie to be removed: ");
                    string movieNameToRemove = Console.ReadLine();
                    Console.WriteLine(MovieManager.RemoveMovieByName(movieNameToRemove));
                }
                else if (option == 6)
                {
                    MovieManager.SaveMovies();
                    Console.WriteLine("Exiting from movie store");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice!!!");
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Movie Store");
            Console.WriteLine("==========================");
            Console.WriteLine("Choose any of the option below");
            Console.WriteLine("1 --> Add movies\n2 --> Display movies\n3 --> Clear All movies" +
                                "\n4 --> Find movie by year\n5 --> Remove movie by name\n6 --> Exit");
            Console.WriteLine("Enter your input");
        }
        private static Movie SetMovieDetails()
        {
            Console.WriteLine("Enter movie Id");
            int movieId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter movie name");
            string movieName = Console.ReadLine();
            Console.WriteLine("Enter movie genre");
            string movieGenre = Console.ReadLine();
            Console.WriteLine("Enter movie year");
            int movieYear = int.Parse(Console.ReadLine());
            return new Movie(movieId, movieName, movieYear, movieGenre);
        }
    }
}
