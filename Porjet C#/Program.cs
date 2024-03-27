// See https://aka.ms/new-console-template for more information

using game;
using Porjet_C_;

namespace test
{
    class Program
    {

        enum StateMachineGame {map,menu,combat}

        static void Main(string[] args)
        {
            
            GameObject player = new GameObject();
            Component playerRender = new Render("render","P");
            Component bag = new Bag("bag");
            player.AddComponent(playerRender);
            player.AddComponent(bag);

            StateMachineGame stateMachineGame = new StateMachineGame();
            Game game = new Game(player);
            int lastState = 0;
            switch (stateMachineGame)
            {
                case 0:
                    stateMachineGame = (StateMachineGame)game.gameScript();
                    lastState = 0; 
                    break;
                case (StateMachineGame)1:
                    lastState = 1;
                    break;
                case (StateMachineGame)2:
                    lastState = 2;
                    break;

            }
            
            

        }
    }
}
    