using Terraria;
using Terraria.ModLoader;

namespace LeafsAwakening.Content.DamageClasses
{
	public class LeafDamage : DamageClass
	{
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			if (damageClass == DamageClass.Generic)
				return StatInheritanceData.Full;

			return new StatInheritanceData(
				damageInheritance: 0f,
				critChanceInheritance: 0f,
				attackSpeedInheritance: 0f,
				armorPenInheritance: 0f,
				knockbackInheritance: 0f
			);
		}

		public override bool GetEffectInheritance(DamageClass damageClass)
		{
			return false;
		}

		public override void SetDefaultStats(Player player)
		{
			player.GetArmorPenetration<LeafDamage>() += 10;
		}
		public override bool UseStandardCritCalcs => true;

		public override bool ShowStatTooltipLine(Player player, string lineName)
		{
			return true;
		}
	}
}