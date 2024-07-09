using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using LeafsAwakening.Content.DamageClasses;
using LeafsAwakening.Common.Players;

namespace LeafsAwakening.Content.Accessories
{
	public class BreezeDash : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.EoCShield);
			Item.DamageType = ModContent.GetInstance<LeafDamage>();
			Item.damage = 15;
			Item.crit = 1;
			Item.defense = 0;

		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<DashPlayer>().DashAccessoryEquipped = true;
		}
	}
}
