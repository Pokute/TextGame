using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class Room : Component
    {
        public readonly String name;
        public readonly String description;

        public Room(String name, String description)
        {
            this.name = name;
            this.description = description;
        }

        public Room(Room Other)
        {
            this.name = Other.name;
            this.description = Other.description;
        }

        public void Look(EntityList entitylist, Identity identity)
        {
            var container = entitylist[identity].Component<Container>();
            if (container != null)
            {
                var lookables = container.identities
                    .Where((i) => { return (entitylist[i].Component<Lookable>() != null); });

                if (lookables.Count() > 0)
                    Console.WriteLine("You see:");

                foreach (Identity i in lookables)
                    Console.WriteLine(entitylist[i].Component<Lookable>().lookdelegate(entitylist, i));
            }
        }
    }
}
