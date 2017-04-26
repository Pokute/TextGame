using System.Collections.Generic;

namespace TextGame.Code
{
    internal interface IGameActionSource
    {
        IEnumerable<GameAction> GetGameActions(Identity identity);
    }
}
