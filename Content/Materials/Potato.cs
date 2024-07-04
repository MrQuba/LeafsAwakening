using Terraria.ID;
using Terraria.ModLoader;

namespace LeafsAwakening.Content.Materials
{
	public class Potato : ModItem
	{
		// NOTE: I did not make Potato texture, I extracted it from Minecraft assets
		public override void SetDefaults() {
			// TODO, add potato specific code
			Item.CloneDefaults(ItemID.Vine);
		}
	}
}
