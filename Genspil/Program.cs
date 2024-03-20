namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoardGame game = new();

            //game.AddGame();
            //game.AddGame();


            //game.WriteFile();

            //game.Show();

            //game.ReadFile();

            game.Delete();

            Console.ReadKey();
        }
    }
}
