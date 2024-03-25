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

        internal int _id;
        internal string _name;
        internal string _numberOfPlayers;
        //internal string _language;
        //internal string _category;
        //internal string _condition;
        //internal double _price;


        public override string ToString()
        {
            return $"{_name},{_numberOfPlayers};";
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
