using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Code
{
    public class EntityList : Dictionary<Identity, ComponentList>
    {
        public EntityList(Dictionary<Identity, ComponentList> entities = null) :
            base(entities ?? new Dictionary<Identity, ComponentList>())
        {
        }

        public EntityList(EntityList Other, GameAction action) :
            base(Other)
        {
            Interaction interaction = new Interaction(Other, action);
            foreach (ChangeIdentityAdd ca in interaction.changes.OfType<ChangeIdentityAdd>())
            {
                if (this.ContainsKey(ca.identity))
                    throw new ArgumentException("Trying to add an Identity that already exists");

                this.Add(ca.identity, ca.components);
            }
            foreach (ChangeIdentityRemove cr in interaction.changes.OfType<ChangeIdentityRemove>())
            {
                if (!this.ContainsKey(cr.identity))
                    throw new ArgumentException("Trying to remove Identity that does not exist");

                this.Remove(cr.identity);
            }
            foreach (ChangeComponent cc in interaction.changes.OfType<ChangeComponent>())
            {
                if (!this.ContainsKey(cc.identity))
                    throw new ArgumentException("Trying to change component of identity that does not exist");
                if (!this[cc.identity].Contains(cc.from))
                    throw new ArgumentException("Trying to change component that does not exist");

                if (cc.from == cc.into)
                    continue;

                this[cc.identity][this[cc.identity].IndexOf(cc.from)] = cc.into;
            }
        }

        public EntityList WithGameAction(GameAction action)
        {
            if (action == null)
                return this;

            return (new EntityList(this, action));
        }
    }
}
