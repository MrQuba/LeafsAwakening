using LeafsAwakening.Content.Materials;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace LeafsAwakening.Common.Changes
{
	public class Drops : GlobalNPC
	{
		private List<int> Zombies = new();
		private bool areGroupsInitialized = false;
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
			areGroupsInitialized = true;
		}
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (!areGroupsInitialized) initGroups();
			if(Zombies.Contains(npc.type))
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Potato>(), chanceDenominator: 4, minimumDropped: 2, maximumDropped: 10));
			}
		}
	}
}
