using LeafsAwakening.Common.AbstractClasses;
using LeafsAwakening.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeafsAwakening.Content.Weapons.Plants.PotatoMine
{
    public class PotatoMineProjectile : AProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
            ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Type] = true; // Deal triple damage when not moving and "armed".
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true; // Damage dealt to players does not scale with difficulty in vanilla.
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 32;
            Projectile.height = 27;
            Projectile.penetrate = -1;
			Projectile.aiStyle = ProjAIStyleID.Explosive;
            AIType = ProjectileID.ProximityMineI;
        }
    }
    public class PotatoMine : AThrowingWeapon
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 32;
            Item.height = 27;
            Item.damage = 30;
            Item.shoot = ModContent.ProjectileType<PotatoMineProjectile>();
            Item.stack = 9999;
        }
		public override void AddRecipes()
		{
            CreateRecipe().
                AddIngredient(ItemID.Bomb, 1);
		}
	}
}
