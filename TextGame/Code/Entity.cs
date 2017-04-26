using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class Entity
    {
        public readonly Identity identity;
        public readonly IEnumerable<Component> components;

        public Entity(Identity identity, IEnumerable<Component> components)
        {
            this.identity = identity;
            this.components = components;
        }
    }
}
