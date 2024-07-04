using Terraria.ID;
using Terraria.ModLoader;

namespace LeafsAwakening.Content.Materials
{
	public class Potato : ModItem
	{
		public override void SetDefaults() {
			// TODO, add potato specific code
			Item.CloneDefaults(ItemID.Vine);
		}
	}
}
