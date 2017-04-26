using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class Lookable : Component
    {
        public delegate string LookDelegate(EntityList entitylist, Identity identity);
        public readonly LookDelegate lookdelegate;

        public Lookable(LookDelegate lookdelegate)
        {
            this.lookdelegate = lookdelegate;
        }
    }
}
