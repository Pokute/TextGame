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
            var door = new Identity();
            var doorLook = new Lookable((enl, i) => { return "A sturdy wooden door. It is closed. It has a keyhole."; });
            EntityList el = new EntityList() 
            {
                { game_handler_identity, new ComponentList() { new GameHandler(false) } },
                { door, new ComponentList() {
                    doorLook,
                    new GameActionSource(new GameAction(door, "open door", new Interaction.Action((EntityList enl, Identity id) =>
                    {
                        if (enl[id].Contains(doorLook))
                            return new List<Change>() {
                                new ChangeComponent(id, doorLook, new Lookable((enl2, id2) => { return "A sturdy wooden door. It is open. It has a keyhole."; }))
                            };
                        else
                            return null;
                    }))),
                } },
                { starting_room, new ComponentList() {
                    new Room("Existential angst", "You aren't quite sure if you exist, and even if you do, whether it's worth it."),
                    new Container(new List<Identity> { door }),
                } },
                { new Identity(), new ComponentList() { new Player("Bob", starting_room) } },
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
