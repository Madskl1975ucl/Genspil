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


    // customtypen BoardGame med varibler for objektet
    public class BoardGameList
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
            name = Console.ReadLine().ToLower();

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
                string createText = Environment.NewLine;
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


        public void Show()
        {
            // Open the file to read from.            
            string readText = File.ReadAllText(_path);
            Console.WriteLine(readText);
        }


        public void Delete()
        {
            Show();

            var lines = File.ReadAllLines(_path).ToList();

            int inputDelete;
            int.TryParse(Console.ReadLine(), out inputDelete);

            if (inputDelete < lines.Count)
            {
                lines.RemoveAt(inputDelete);
                File.WriteAllLines(_path, lines);
            }

        }


        public void SearchAll()
        {
            var lines = File.ReadAllLines(_path).ToList();

            Console.WriteLine("Søgning: ");
            string searchText = Console.ReadLine().ToLower();

            List<string> results = lines.FindAll(line => line.Contains(searchText));

            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }


        public void Update()
        {
            // pseudo

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


            Show();

            var lines = File.ReadAllLines(_path).ToList();

            int inputUpdate;

            Console.Write("Skriv nummeret på det spil, du vil opdatere: ");

            int.TryParse(Console.ReadLine(), out inputUpdate);

            Console.WriteLine(lines[inputUpdate]);

            if (inputUpdate >= 0 && inputUpdate < lines.Count)
            {
                string[] splitString = new string[2];
                
                splitString = lines[inputUpdate].Split(',');

                Console.Write("Skriv det tal, der svarer til den del, du vil opdatere: ");

                int userInput;
                int.TryParse(Console.ReadLine(), out userInput);

                Console.Write("Skriv, hvad der skal opdateres: ");

                splitString[userInput] = Console.ReadLine();

                string joinedString;

                joinedString = String.Join(",", splitString);

                //Console.WriteLine(joinedString);

                lines[userInput] = joinedString;

                //_gameItems.Add(joinedString);

            }
            
        }

        public void WriteLineToFile()
        {
            

            // This text is added only once to the file.
            if (!File.Exists(_path))
            {
                // Create a file to write to.
                string createText = Environment.NewLine;
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




        // read-metoden (crud), der henter et brætspil til læsning
        public BoardGameList GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        // update-metode (crud), der opdaterer oplysninger for et gemt spil i persistance-filen 
        public BoardGameList UpdateGame(int id)
        {
            throw new NotImplementedException();
        }

    }

}
