using Microsoft.Xna.Framework;
using LeafsAwakening.Common.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeafsAwakening.Content.DamageClasses;
using LeafsAwakening.Content.Projectiles;
using LeafsAwakening.Common.AbstractClasses;

namespace LeafsAwakening.Content.Weapons.Plants.PeaShooter
{

    // Inspired with Calamity Squirrel Squire Minnion
    public class PeaShooter : AProjectile, ILocalizedModType
    {

        private int attackTimer = 0;
        private int attackDelay = 90;
        public ref float AttackTimer => ref Projectile.ai[1];
        public bool Attacking
        {
            get => Projectile.localAI[1] == 1f;
            set => Projectile.localAI[1] = value.ToInt();
        }
        public override void AI()
        {
            ProjectileUtils.CheckActive(Owner, Projectile, ModContent.BuffType<PeaShooterMinionBuff>());
            if (!Owner.HasBuff(ModContent.BuffType<PeaShooterMinionBuff>()))
            {
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
            if (player.ownedProjectileCounts[ModContent.ProjectileType<PeaShooter>()] > 0)
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
}