using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LeafsAwakening.Common.Players
{
	//https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Content/Items/Accessories/ExampleShield.cs some code comes from here
	public class DashPlayer : ModPlayer
	{

		public bool DashAccessoryEquipped = false;
		public enum DashDirection
		{
			None = -1,
			Left = 2,
			Right = 3,
		}
		public DashDirection Direction = DashDirection.None; 
		public int DashCooldown = 50; 
		public int DashDuration = 35;
		public float DashVelocity = 10f;

		public int DashDelay = 0; // frames remaining till we can dash again
		public int DashTimer = 0; // frames remaining in the dash

		public override void ResetEffects()
		{
			DashAccessoryEquipped = false;
			if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[(int)DashDirection.Right] < 15)
			{
				Direction = DashDirection.Right;
			}
			else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[(int)DashDirection.Left] < 15)
			{
				Direction = DashDirection.Left;
			}
			else
			{
				Direction = DashDirection.None;
			}
		}

		// This is the perfect place to apply dash movement, it's after the vanilla movement code, and before the player's position is modified based on velocity.
		// If they double tapped this frame, they'll move fast this frame
		public override void PreUpdateMovement()
		{
			// if the player can use our dash, has double tapped in a direction, and our dash isn't currently on cooldown
			if (CanUseDash() && Direction != DashDirection.None && DashDelay == 0)
			{
				Vector2 newVelocity = Player.velocity;

				switch (Direction)
				{
					case DashDirection.Left when Player.velocity.X > -DashVelocity:
					case DashDirection.Right when Player.velocity.X < DashVelocity:
						{
							// X-velocity is set here
							float dashDirection = Direction == DashDirection.Right ? 1 : (float)DashDirection.None;
							newVelocity.X = dashDirection * DashVelocity;
							break;
						}
					default:
						return; // not moving fast enough, so don't start our dash
				}

				// start our dash
				DashDelay = DashCooldown;
				DashTimer = DashDuration;
				Player.velocity = newVelocity;

				// Here you'd be able to set an effect that happens when the dash first activates
				// Some examples include:  the larger smoke effect from the Master Ninja Gear and Tabi
			}

			if (DashDelay > 0)
				DashDelay--;

			if (DashTimer > 0)
			{ // dash is active
			  // This is where we set the afterimage effect.  You can replace these two lines with whatever you want to happen during the dash
			  // Some examples include:  spawning dust where the player is, adding buffs, making the player immune, etc.
			  // Here we take advantage of "player.eocDash" and "player.armorEffectDrawShadowEOCShield" to get the Shield of Cthulhu's afterimage effect
				Player.eocDash = DashTimer;
				Player.armorEffectDrawShadowEOCShield = true;

				// count down frames remaining
				DashTimer--;
			}
		}

		private bool CanUseDash()
		{
			return DashAccessoryEquipped
				&& Player.dashType == DashID.None // player doesn't have Tabi or EoCShield equipped (give priority to those dashes)
				&& !Player.setSolar // player isn't wearing solar armor
				&& !Player.mount.Active; // player isn't mounted, since dashes on a mount look weird
		}
	}
}
