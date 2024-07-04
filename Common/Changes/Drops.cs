using LeafsAwakening.Content.Materials;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeafsAwakening.Common.Changes
{
	public class Drops : GlobalNPC
	{
		private List<int> Zombies = new();
		private void initGroups()
		{
			Zombies.Add(NPCID.Zombie);
			Zombies.Add(NPCID.ZombieDoctor);
			Zombies.Add(NPCID.ZombieElf);
			Zombies.Add(NPCID.ZombieElfBeard);
			Zombies.Add(NPCID.ZombieElfGirl);
			Zombies.Add(NPCID.ZombieEskimo);
			Zombies.Add(NPCID.ZombieMerman);
			Zombies.Add(NPCID.ZombieMushroom);
			Zombies.Add(NPCID.ZombieMushroomHat);
			Zombies.Add(NPCID.ZombiePixie);
			Zombies.Add(NPCID.ZombieRaincoat);
			Zombies.Add(NPCID.ZombieSuperman);
			Zombies.Add(NPCID.ZombieSweater);
			Zombies.Add(NPCID.ZombieXmas);
		}
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if(Zombies.Contains(npc.type))
			{
				// TODO, add loot for zombies:
				// 2-10 Potatoes
				// 25% chance
			}
		}
	}
}
