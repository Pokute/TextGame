using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var game_handler_identity = new Identity();
            var starting_room = new Identity();
            EntityList el = new EntityList() 
            {
                { game_handler_identity, new ComponentList() { new GameHandler(false) } },
                //{ starting_room, new ComponentList() { new Room("Existential angst", "You aren't quite sure if you exist, and even if you do, whether it's worth it.") } },
                //{ new Identity(), new ComponentList() { new Player("Bob", starting_room) } },
            };

            while (el[game_handler_identity].Component<GameHandler>().quitting == false)
            {
                var line = Console.ReadLine();
                var action = el[game_handler_identity].Component<GameHandler>().GetGameActionForString(game_handler_identity, el, line);
                if (action != null)
                   el = new EntityList(el, action);
            } 
        }
    }
}
