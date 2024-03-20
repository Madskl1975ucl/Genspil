using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil
{
    // customtypen BoardGame med varibler for objektet
    public class BoardGame
    {

        private List<GameItem> _gameItems = new List<GameItem>();
        //private List<string> _lines; 

        private string _path = @"c:\temp\gameItems.txt";



        // create-metoden (crud), der opretter et nyt spil
        public void AddGame()
        {

            var name = string.Empty;
            var numberOfPlayers = string.Empty;

            Console.WriteLine("Opret spil:");

            Console.Write("Skriv navn: ");
            name = Console.ReadLine();

            Console.Write("Skriv antal spillere: ");
            numberOfPlayers = Console.ReadLine();

            _gameItems.Add(new GameItem(name, numberOfPlayers));

            foreach (GameItem item in _gameItems)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }

        // pseudokode ide
        // indlæs file
        // loop
        // fjern 
        // add
        // opdater
        // loop end
        // writetofile

        public void WriteFile()
        {

            // This text is added only once to the file.
            if (!File.Exists(_path))
            {
                // Create a file to write to.
                string createText = "Lagerliste" + Environment.NewLine;
                File.WriteAllText(_path, createText);
            }


            foreach (GameItem item in _gameItems)
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                string appendText = item + Environment.NewLine;
                File.AppendAllText(_path, appendText);
            }
        }

        //public void ReadFile()
        //{
        //    //public static string ReadAllText(string path);
        //    //_lines = new List<string>();
        //    var lines = File.ReadAllLines(_path).ToList();
        //    Console.WriteLine(lines.Count);
        //}


        public void Show()
        {
            // Open the file to read from.            
            string readText = File.ReadAllText(_path);
            Console.WriteLine(readText);
        }


        public void Delete()
        {
            Show();

            //ReadFile();

            var lines = File.ReadAllLines(_path).ToList();

            int inputDelete;
            int.TryParse(Console.ReadLine(), out inputDelete);

            if (inputDelete < lines.Count)
            {
                // delete lines[input + 2]

                lines.RemoveAt(inputDelete);
                File.WriteAllLines(_path, lines);

            }

        }



        // To-do
        // opdatering
        // Søge på listen

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }













        // read-metoden (crud), der henter et brætspil til læsning
        public BoardGame GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        // Metode, der gemmer et spil i persistance-filen
        public BoardGame SaveGame()
        {
            throw new NotImplementedException();
        }

        // update-metode (crud), der opdaterer oplysninger for et gemt spil i persistance-filen 
        public BoardGame UpdateGame(int id)
        {
            throw new NotImplementedException();
        }

        // delete-metode (crud), der sletter et gemt spil i persistance-filen
        public BoardGame DeleteGame(int id)
        {
            throw new NotImplementedException();
        }

    }

    //// BoardGames klassen arver alle metoder fra BoardGame
    //public class BoardGames : BoardGame
    //{
    //    private List<BoardGame> _boardGames;

    //    // contructor for Boardgames, der medtager id fra BoardGame base(id) OR 0
    //    public BoardGames(int id = 0) : base(id) 
    //    {
    //        _boardGames = new List<BoardGame>();
    //    }

    //    // metode, der henter listen med spil
    //    public List<BoardGame> GetAllGames() 
    //    {
    //        throw new NotImplementedException();
    //        //return _boardGames;
    //    }
    //}


}
