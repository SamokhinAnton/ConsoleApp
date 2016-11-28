using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main()
        {
            var songs = new Song[]
            {
                new Song { Ganre = Ganre.Rock, Author = "Disturbed", Length = 200, Name="Warrior"},
                new Song { Ganre = Ganre.Rock, Author = "Queen", Length = 300, Name="Show must go on"},
                new Song { Ganre = Ganre.Rock, Author = "Led Zeppelin", Length = 500, Name="stairway to heaven"},
                new Song { Ganre = Ganre.Jazz, Author = "Bolden band", Length = 200, Name="some name"},
                new Song { Ganre = Ganre.Jazz, Author = "Franc Sinatra", Length = 200, Name="some name"},
                new Song { Ganre = Ganre.Blues, Author = "B.B. King", Length = 200, Name="some name"},
                new Song { Ganre = Ganre.Blues, Author = "Eric Clepton", Length = 200, Name="some name"},
                new Song { Ganre = Ganre.Blues, Author = "Ray Charls", Length = 200, Name="some name"},
            };
            Console.WriteLine("To change song name print c");
            Console.WriteLine("To find the longest song print l");
            Console.WriteLine("To print all songs of ganre print g");

            switch (Console.ReadLine())
            {
                case "c":
                    Console.WriteLine("print index of the song, index may be from 0 to {0}. Then type new snong name", songs.Length-1);
                    songs[int.Parse(Console.ReadLine())].Name = Console.ReadLine();
                    PrintAll(songs);
                    break;
                case "l":
                    int longestSongIndex = 0;
                    int length = 0;
                    for (int i = 0; i < songs.Length; i++)
                    {
                        if(length < songs[i].Length)
                        {
                            length = songs[i].Length;
                            longestSongIndex = i;
                        }
                    }
                    Console.WriteLine("song: {0}, Length: {1} sec, Author: {2}, Ganre: {3}",
                    songs[longestSongIndex].Name, songs[longestSongIndex].Length, 
                    songs[longestSongIndex].Author, songs[longestSongIndex].Ganre);
                    break;
                case "g":
                    Console.WriteLine("type ganre rock or 0, 1 or jazz, 2 or blues");
                    Ganre ganre = (Ganre)Enum.Parse(typeof(Ganre), Console.ReadLine(), true);
                    foreach(var song in songs)
                    {
                        if(song.Ganre == ganre)
                        {
                            Console.WriteLine("song: {0}, Length: {1} sec, Author: {2}, Ganre: {3}",
                            song.Name, song.Length, song.Author, song.Ganre);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("unknown identifier");
                    Main();
                    break;
            }
        }

        public enum Ganre
        {
            Rock,
            Jazz,
            Blues
        }

        public struct Song
        {
            public string Author;
            public int Length;
            public Ganre Ganre;
            public string Name;
        }

        public static void PrintAll(Song[] songs)
        {
            foreach (var song in songs)
            {
                Console.WriteLine("song: {0}, Length: {1} sec, Author: {2}, Ganre: {3}", 
                    song.Name, song.Length, song.Author, song.Ganre);
            }
        }
    }
}
