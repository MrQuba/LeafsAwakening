using LeafsAwakening.Content.DamageClasses;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LeafsAwakening.Common.AbstractClasses
{
	public abstract class AProjectile : ModProjectile
	{
		public Player Owner => Main.player[Projectile.owner];
		public override void SetDefaults()
		{
			Projectile.tileCollide = true;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.timeLeft = 600;
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.DamageType = ModContent.GetInstance<LeafDamage>();
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			return false;
		}

	}
}
