using Microsoft.Xna.Framework;
using LeafsAwakening.Common.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeafsAwakening.Content.Projectiles;
using LeafsAwakening.Common.AbstractClasses;
using Terraria.DataStructures;
using LeafsAwakening.Common.Players;

namespace LeafsAwakening.Content.Weapons.Plants.PeaShooter
{

    // Inspired with Calamity Squirrel Squire Minnion
    public class PeaShooterProjectile : AProjectile, ILocalizedModType
    {

        private int attackTimer = 0;
        private int attackDelay = 90;
        public ref float AttackTimer => ref Projectile.ai[1];
        public const float SIZE = 2f;
        bool appliedSlots = false;
        public bool Attacking
        {
            get => Projectile.localAI[1] == 1f;
            set => Projectile.localAI[1] = value.ToInt();
        }
        // TODO, rework ai
		public override void AI()
        {
            if (!appliedSlots)
            {
                appliedSlots = true;
				Owner.GetModPlayer<LeafPlayer>().takePlantsSlots(SIZE);
			}
            ProjectileUtils.CheckActive(Owner, Projectile, ModContent.BuffType<PeaShooterMinionBuff>());
            if (!Owner.HasBuff(ModContent.BuffType<PeaShooterMinionBuff>()))
            {
                Owner.GetModPlayer<LeafPlayer>().takePlantsSlots(-SIZE);
                appliedSlots = false;
				Projectile.Kill();
                return;
            }
            if (attackTimer == attackDelay && NPCUtils.FindClosestNPC(700f, Projectile) != null)
            {
                attackTimer = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(),
                    Projectile.Center,
                    Vector2.One,
                    ModContent.ProjectileType<Pea>(),
                    Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
            else if (attackTimer == attackDelay) attackTimer = 0;
            else attackTimer++;

        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.CloneDefaults(ProjectileID.DD2BallistraTowerT1);
            Projectile.width = 24;
            Projectile.height = 16;
            Projectile.ignoreWater = true;
            Projectile.scale = 1.5f;
        }

        public override bool? CanCutTiles()
        {
            return true;
        }
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }
        public override bool? CanDamage() => false;
        public override bool OnTileCollide(Vector2 oldVelocity) => false;
        public override void OnKill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                int index = Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, Main.rand.Next(61, 64), Projectile.scale);
                Main.gore[index].velocity *= 0.1f;
            }
        }
    }
    public class PeaShooterMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<PeaShooterProjectile>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
    public class PeaShooter : ALeafWeapon
    {
		public override void SetDefaults()
		{
			base.SetDefaults();
            Item.sentry = true;
            Item.damage = 15;
            Item.useAnimation = 15;
            Item.useTime = 15;
			Item.mana = 10;
			Item.width = 32;
			Item.height = 32;
			Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Cyan;
			Item.shoot = ModContent.ProjectileType<PeaShooterProjectile>(); 
            Item.buffType = ModContent.BuffType<PeaShooterMinionBuff>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position
			position = Main.MouseWorld;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(Item.buffType, 2);

			// Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;

			// Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
			return false;
		}
	}

}