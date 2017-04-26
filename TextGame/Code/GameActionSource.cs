using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class GameActionSource : Component, IGameActionSource
    {
        IEnumerable<GameAction> gameactions;

        public GameActionSource(IEnumerable<GameAction> gameactions)
        {
            this.gameactions = gameactions;
        }

        public GameActionSource(GameAction gameaction) :
            this(new List<GameAction>() { gameaction })
        {
        }

        public IEnumerable<GameAction> GetGameActions(Identity identity)
        {
            return gameactions;
        }
    }
}
