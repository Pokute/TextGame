using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public abstract class Change
    {
        public readonly Identity identity;

        public Change(Identity identity)
        {
            this.identity = identity;
        }
    }

    public class ChangeIdentityAdd : Change
    {
        public readonly ComponentList components;

        public ChangeIdentityAdd(Identity identity)
            : base(identity)
        {
        }
    }

    public class ChangeIdentityRemove : Change
    {
        public ChangeIdentityRemove(Identity identity)
            : base(identity)
        {
        }
    }

    public class ChangeComponent : Change
    {
        public readonly Component from;
        public readonly Component into;

        public ChangeComponent(Identity identity, Component from, Component into)
            : base(identity)
        {
            this.from = from;
            this.into = into;
        }
    }

    public class Interaction
    {
        public delegate IEnumerable<Change> Action(EntityList entitylist, Identity identity);

        public GameAction action;
        public IEnumerable<Change> changes;

        public Interaction(EntityList entitylist, GameAction action)
        {
            this.action = action;
            this.changes = action.action(entitylist, action.owner);
        }
    }
}
