using Terraria.ID;
using LeafsAwakening.Common.AbstractClasses;
using Terraria.ModLoader;

namespace LeafsAwakening.Content.Weapons.Throwing.SharpLeaves
{
	public class SharpLeaf : AThrowingWeapon
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.width = 30;
			Item.height = 30;
			Item.shoot = ModContent.ProjectileType<SharpLeafProjectile>();
		}
	}
	public class SharpLeafProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			Projectile.width = 30;
			Projectile.height = 30;	
		}
	}
}
