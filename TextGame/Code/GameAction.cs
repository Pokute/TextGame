using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class GameAction
    {
        public readonly Identity owner;
        public readonly String name;
        public readonly Interaction.Action action;

        public GameAction(Identity owner,String name, Interaction.Action action)
        {
            this.owner = owner;
            this.name = name;
            this.action = action;
        }
    }
}
