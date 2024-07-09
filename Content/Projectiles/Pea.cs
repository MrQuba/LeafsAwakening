using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeafsAwakening.Content.DamageClasses;
using LeafsAwakening.Common.AbstractClasses;

namespace LeafsAwakening.Content.Projectiles
{
    public class Pea : AProjectile, ILocalizedModType
    {
        public ref float AttackTimer => ref Projectile.ai[1];
        public bool Attacking
        {
            get => Projectile.localAI[1] == 1f;
            set => Projectile.localAI[1] = value.ToInt();
        }
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.damage = 16;
        }
        // source for homing code: https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Content/Projectiles/ExampleHomingProjectile.cs
        public override void AI()
        {
            //ProjectileUtils.HomingAI(Projectile, 600f, 7f);
        }
    }
}