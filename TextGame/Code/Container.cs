using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class Container : Component
    {
        public readonly IEnumerable<Identity> identities;

        public Container(IEnumerable<Identity> identities)
        {
            this.identities = identities;
        }

        public Container With(IEnumerable<Identity> identities)
        {
            return new Container(this.identities.Union(identities));
        }

        public Container Except(IEnumerable<Identity> identities)
        {
            return new Container(this.identities.Except(identities));
        }
    }
}
