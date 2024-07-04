using Terraria.ID;

namespace LeafsAwakening.Common.AbstractClasses
{
	public abstract class AThrowingWeapon : ALeafWeapon
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ThrowingKnife);
			base.SetDefaults();
		}
	}
}
