using System.Data;

namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoardGameList game = new();

            //game.Show();

            game.Update();


            //game.AddGame();

            game.WriteFile();

            //game.SearchAll();


            //game.ReadFile();

            //game.Delete();

            game.Show();

            Console.ReadKey();
        }
    }
}
