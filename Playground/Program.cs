using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            TMDbClient client = new TMDbClient("APIKey");
            Movie movie = client.GetMovieAsync(47964).Result;

            Console.WriteLine($"Movie name: {movie.Title}");
        }
    }
}
