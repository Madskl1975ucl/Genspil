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

        //private int _id;
        public string Name { get; set; }
        public string NumberOfPlayers { get; set; }
        //private string _language;
        //private string _category;
        //private string _condition;
        //private double _price;


        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}
        //public string NumberOfPlayers
        //{
        //    get { return _numberOfPlayers; }
        //    set { _numberOfPlayers = value; }
        //}



        public GameItem(string name, string numberOfPlayers)
        {
            Name = name;
            NumberOfPlayers = numberOfPlayers;
        }



    }
}
