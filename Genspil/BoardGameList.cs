using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Genspil
{
    // Principper
    // Brug List<GameItem> frem for List<string>
    // Konverter List<GameItem> til List<string> & omvendt (fjerner string override & string.split & .join)
    // Properties for at få adgang til GameItem.Name 
    // gameItems.txt = ren kommasepareret fil - udskrivning af data klares med $ stringinterpolation

    //todo:0 Færdigør fields i GameItem
    //todo:1 Konverter List<GameItem> til List<string> & omvendt (2 hjælpemetoder??)
    //todo:2 Lav properties på GameItem fields
    //todo:3 Lav ID metode
    //todo:4 Lav Søgning (på et GameItem field) + kombination af fields
    //todo:5 Lav Opdatering
    //todo:6 Lav Sortering efter navn & genre


    public class BoardGameList
    {

        private List<GameItem> _gameItems = new List<GameItem>();
        private List<string> _lines = new List<string>();

        private string _path = @"c:\temp\gameItems.txt";


        // create-metoden (crud), der opretter et nyt spil
        public void AddGame()
        {
            var name = string.Empty;
            var numberOfPlayers = string.Empty;

            Console.WriteLine("Opret spil:");

            Console.Write("Skriv navn: ");
            name = Console.ReadLine().ToLower();

            Console.Write("Skriv antal spillere: ");
            numberOfPlayers = Console.ReadLine();

            _gameItems.Add(new GameItem(name, numberOfPlayers));
        }


        /// <summary>
        /// Tilføjer et GameItem til bunden af filen
        /// </summary>
        public void WriteFile()
        {
            foreach (GameItem item in _gameItems)
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                string appendText = $"{item.Name},{item.NumberOfPlayers}" + Environment.NewLine;
                File.AppendAllText(_path, appendText);
            }
        }

        /// <summary>
        /// Overskriver den gamle fil, så det opdaterede GameItem bliver sat ind på samme plads
        /// </summary>
        public void WriteLineToFile()
        {
            File.Delete(_path);

            foreach (GameItem item in _gameItems)
            {
                string overwriteText = $"{item.Name},{item.NumberOfPlayers}" + Environment.NewLine;
                File.AppendAllText(_path, overwriteText);
            }
        }

        /// <summary>
        /// Læs gameItems.txt og indsæt hver linje som element på listen _lines
        /// </summary>
        public void ReadFile()
        {
            _lines.Clear();
            _lines = File.ReadAllLines(_path).ToList();
        }



        //Show metoder (brug ShowGameItems)
        
        //public void Show()
        //{
        //    // Open the file to read from.            
        //    string readText = File.ReadAllText(_path);
        //    Console.WriteLine(readText);
        //}         
        public void ShowGameItems()
        {
            ReadFile();
            ConvertListStringToListGameItem();


            Console.WriteLine("{0,-15} {1,-10}", "Navn", "Spillere");
            Console.WriteLine("-----------------------------------");

            // Print each element in _gameItems             
            foreach (GameItem item in _gameItems)
            {
                Console.WriteLine("{0,-15} {1,-10}", item.Name, item.NumberOfPlayers);
                //Console.WriteLine($"Navn: {item.Name}, Antal spillere: {item.NumberOfPlayers}");
            }

            _gameItems.Clear();

        }      
        //public void ShowLines()
        //{
        //    // Print each element in _lines           
        //    foreach (string line in _lines)
        //    {
        //        Console.WriteLine(line);
        //    }
        //}



        // Skal laves om så den sletter på ID
        public void Delete()
        {
            ReadFile();

            Console.Write("Skriv hvilken linje du vil slette: ");

            int inputDelete;
            int.TryParse(Console.ReadLine(), out inputDelete);

            if (inputDelete < _lines.Count)
            {
                _lines.RemoveAt(inputDelete);
                File.WriteAllLines(_path, _lines);
            }
        }



        public void SearchAll()
        {
            ReadFile();

            Console.WriteLine("Søgning: ");
            string searchText = Console.ReadLine().ToLower();

            List<string> results = _lines.FindAll(line => line.Contains(searchText));

            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }



        // pseudo til update

        // ReadAllLines til List "lines"
        // Show()
        // Bruger input: vælg linje til opdatering - gem i variable og brug igen i WriteToFile (overwrite)
        // Show() valgte linje
        // Array Split med , delimiter
        // Array[0] navn, [1] antal spillere osv.
        // bruger input: vælg den del der skal opdateres
        // bruger input: skriv den del der skal opdateres
        // string .Join til en string
        // WriteToFile til samme linje
        public void Update()
        {
            int inputUpdate;

      
            ReadFile();

            Console.Write("Skriv nummeret på det spil, du vil opdatere: ");

            int.TryParse(Console.ReadLine(), out inputUpdate);

            Console.WriteLine(_lines[inputUpdate]);

            if (inputUpdate >= 0 && inputUpdate < _lines.Count)
            {
                string[] splitString = new string[2];

                splitString = _lines[inputUpdate].Split(',');

                Console.Write("Skriv det tal, der svarer til den del, du vil opdatere: ");

                int userInput;
                int.TryParse(Console.ReadLine(), out userInput);

                Console.Write("Skriv, hvad der skal opdateres: ");

                splitString[userInput] = Console.ReadLine().ToLower();

                string joinedString = string.Join(",", splitString);

                _lines[inputUpdate] = joinedString;

                ConvertListStringToListGameItem();

            }
        }



        // Hjælpemetoder.

        /// <summary>
        /// Konverterer en liste af strings (_lines) til en liste af GameItem (_gameItems)
        /// </summary>
        public void ConvertListStringToListGameItem()
        {
            _gameItems.Clear();
            _gameItems = _lines.Select(item =>
            {
                var parts = item.Split(',');
                return new GameItem(parts[0], parts[1]);
            }
            ).ToList();
        }

        /// <summary>
        /// Konverterer en liste af GameItem (_gameItems) til en liste af strings (_lines)
        /// </summary>
        public void ConvertListGameItemToListString()
        {
            _lines.Clear();
            _lines = _gameItems.Select(item => item.Name + "," + item.NumberOfPlayers).ToList();
        }














        // read-metoden (crud), der henter et brætspil til læsning
        public BoardGameList GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        //// update-metode (crud), der opdaterer oplysninger for et gemt spil i persistance-filen 
        //public BoardGameList UpdateGame(int id)
        //{
        //    throw new NotImplementedException();
        //}

    }

}
