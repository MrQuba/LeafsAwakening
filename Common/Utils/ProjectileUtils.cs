using Terraria;

namespace LeafsAwakening.Common.Utils
{
	public class ProjectileUtils
	{
		public static bool CheckActive(Player owner, Projectile projectile, int BuffType)
		{
			if (owner.dead || !owner.active)
			{
				owner.ClearBuff(BuffType);

				return false;
			}

			if (owner.HasBuff(BuffType))
			{
				projectile.timeLeft = 2;
			}

			return true;
		}
	}
}
