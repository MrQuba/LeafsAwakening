using Terraria.ModLoader;
using LeafsAwakening.Content.DamageClasses;

namespace LeafsAwakening.Common.AbstractClasses
{
	public abstract class ALeafWeapon : AbstractItem
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.DamageType = ModContent.GetInstance<LeafDamage>();
		}
	}
}
