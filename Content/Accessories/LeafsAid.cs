using Terraria;
using Terraria.ModLoader;
namespace LeafsAwakening.Content.Accessories
{
	public class LeafsAid : ModItem
	{
		public override void SetDefaults()
		{
			Item.accessory = true;
			Item.width = 30;
			Item.height = 30;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneForest)
			{
				player.endurance += 0.25f;
				player.lifeRegen += 5;
			}
			else
			{
				player.endurance -= 0.25f;
				player.lifeRegen -= 5;
			}
		}
	}
}
