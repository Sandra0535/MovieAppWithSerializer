using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWithSerializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieController movieController = new MovieController();
            MovieController.Start();
        }
    }
}
