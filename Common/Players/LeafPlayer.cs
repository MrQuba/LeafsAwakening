using Terraria.ModLoader;

namespace LeafsAwakening.Common.Players
{
	public class LeafPlayer : ModPlayer
	{
		private const int BASE_MAX_PLANTS = 15;
		private int CURRENT_MAX_PLANTS = BASE_MAX_PLANTS;
		private float takenSlots = 0.0f;
		/// <summary>
		/// Reserves slots for the plant
		/// </summary>
		/// <param name="slots">Amount of Slots Plant takes</param>
		/// <returns>true if plant can be spawned, false otherwise</returns>
		public bool takePlantsSlots(float slots)
		{
			if(spaceForNewPlant(slots))
			{
				takenSlots += slots;
				// TODO, add logic for preventing possible overflows (more plants than slots)
				return true;
			}
			return false;
		}
		private bool spaceForNewPlant(float slots = 0.0f)
		{
			return (takenSlots + slots <= CURRENT_MAX_PLANTS) ? true : false; 
		}
	}
}
