using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class ComponentList : KeyedByTypeCollection<Component>
    {
        public ComponentList()
            : base()
        {
        }

        public ComponentList(IEnumerable<Component> Items)
            : base(Items)
        {
        }

        public ComponentList(ComponentList ImmutableComponentList)
            : base(ImmutableComponentList)
        {
        }

        public T Component<T>()
        {
            return (Find<T>());
        }
    }
}
