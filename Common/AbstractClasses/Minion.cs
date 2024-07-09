using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace LeafsAwakening.Content.Projectiles.Summons
{
    public abstract class Minion : ModProjectile
    {
        public override void AI()
        {
            CheckActive();
            Behavior();
        }

        public abstract void CheckActive();

        public abstract void Behavior();
    }
}
