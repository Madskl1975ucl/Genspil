using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    // customtypen BoardGame med varibler for objektet
    public class BoardGame
    {
        private int _id;
        private string _name;
        private int _numberOfPlayers;
        private string _language;
        private string _category;
        private string _condition;
        private double _price;

        // constructor til BoardGame, der skal modtage et id (som argument) fra brugerinput
        public BoardGame(int id) 
        {
            _id = id;
        }

        // CRUD = Create Read Update Delete 
        // create-metoden (crud), der opretter et nyt spil
        public BoardGame AddGame() 
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

    // BoardGames klassen arver alle metoder fra BoardGame
    public class BoardGames : BoardGame
    {
        private List<BoardGame> _boardGames;

        // contructor for Boardgames, der medtager id fra BoardGame base(id) OR 0
        public BoardGames(int id = 0) : base(id) 
        {
            _boardGames = new List<BoardGame>();
        }

        // metode, der henter listen med spil
        public List<BoardGame> GetAllGames() 
        {
            throw new NotImplementedException();
            //return _boardGames;
        }
    }


}
