using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class GameHandler : Component
    {
        public readonly bool quitting;

        public GameHandler(bool quitting = false)
        {
            this.quitting = quitting;
        }

        public GameHandler(GameHandler Other, string action)
        {
        }

        public GameHandler(GameHandler Other, bool? quitting)
        {
            this.quitting = quitting ?? Other.quitting;
        }

        IEnumerable<GameAction> Actions(Identity identity, EntityList entitylist)
        {
            var quitaction = new GameAction(identity, "quit", Quit);
            var actions = new List<GameAction>() { quitaction };
            foreach (Identity i in entitylist.Keys)
            {
                foreach (Component c in entitylist[i])
                    if (c.GetType().GetInterfaces().Contains(typeof(IGameActionSource)))
                    {
                        actions.AddRange((c as IGameActionSource).GetGameActions(i));
                    }
            }
            //actions.AddRange(entitylist.Aggregate( .Where( .Values.OfType<IGameActionSource>().Select((gas) => { return gas.GetGameActions(); }));
            return actions;
        }

        public GameAction GetGameActionForString(Identity identity, EntityList entitylist, string actionstring)
        {
            var matchedActions = Actions(identity, entitylist).Where((a) => a.name == actionstring);
            if (matchedActions.Count() == 0)
            {
                return null;
            }
            else 
            {
                if (matchedActions.Count() >= 2)
                {

                }
                return matchedActions.First();
            }
        }

        IEnumerable<Change> Quit(EntityList entitylist, Identity identity)
        {
            return new List<Change>() { new ChangeComponent(identity, this, new GameHandler(this, true)) };
        }
    }
}
