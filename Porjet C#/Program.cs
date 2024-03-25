// See https://aka.ms/new-console-template for more information

using game;
using Porjet_C_;

namespace test
{
    class Program
    {

    

        static void Main(string[] args)
        {
            
            GameObject player = new GameObject();
            Component playerRender = new Render("render","P");
            Component bag = new Bag("bag");
            player.AddComponent(playerRender);
            player.AddComponent(bag);
            Game game = new Game(player);
            game.gameScript();

        }
    }
}
    