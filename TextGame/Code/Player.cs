using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class Player : Component, IGameActionSource
    {
        public readonly String name;
        public readonly Identity room;

        public Player(String name)
        {
            this.name = name;
        }

        public Player(String name, Identity room)
        {
            this.name = name;
            this.room = room;
        }

        public Player(Player Other, Identity room)
        {
            this.name = Other.name;

            if (room != this.room)
            {
                //this.room.OnExit();
                //room.OnEnter();
            }

            this.room = room;
        }

        public IEnumerable<GameAction> GetGameActions(Identity identity)
        {
            return new List<GameAction>()
            {
                new GameAction(identity, "look", Look)
            };
        }

        private IEnumerable<Change> Look(EntityList entitylist, Identity identity)
        {
            Console.WriteLine("You look around.");

            if (room != null)
            {
                entitylist[room].Component<Room>().Look(entitylist, room);
            }

            return null;
        }
    }
}
