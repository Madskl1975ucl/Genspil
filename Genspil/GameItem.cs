using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil
{
    public class GameItem
    {

        private int _id { get; set; }
        private string _name { get; set; }
        private string _numberOfPlayers { get; set; }
        //private string _language;
        //private string _category;
        //private string _condition;
        //private double _price;


        public override string ToString()
        {
            return $"Navn: {_name}, Antal spillere: {_numberOfPlayers}";
        }


        public GameItem(string name, string numberOfPlayers)
        {
            _name = name;
            _numberOfPlayers = numberOfPlayers;
        }


        //public GameItem(string id, string name, string numberOfPlayers, string language, string category, string condition, double price)
        //{
        //    _id = id;
        //    _name = name;
        //    _numberOfPlayers = numberOfPlayers;
        //    _language = language;
        //    _category = category;
        //    _condition = condition;
        //    _price = price;
        //}

    }
}
