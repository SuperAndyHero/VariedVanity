using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;
using Terraria.Graphics.Effects;


namespace VariedVanity.NPCs
{
    public class VanityGlobalNPC : GlobalNPC
	{
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix);

            Texture2D texture = mod.GetTexture("Misc/stockIMG3"); //Overlay
            Filters.Scene["WaterFilter"].GetShader().UseTargetPosition(new Vector2(0, 0));
            Filters.Scene["WaterFilter"].GetShader().UseImage(texture);
            Filters.Scene["WaterFilter"].GetShader().UseColor(0.25f, 0.3f, 1.5f);
            Filters.Scene["WaterFilter"].GetShader().UseSecondaryColor(0.7f, 0.95f, 1f);
            Filters.Scene["WaterFilter"].GetShader().UseImageOffset(new Vector2(5f, 6f));
            Filters.Scene["WaterFilter"].GetShader().UseIntensity(0.8f);
            Filters.Scene["WaterFilter"].GetShader().UseDirection(new Vector2(0.50f, 0.44f));
            Filters.Scene["WaterFilter"].GetShader().UseProgress(8f);
            Filters.Scene["WaterFilter"].GetShader().Shader.Parameters["uSpeed"].SetValue(new Vector4(6.33f, 4.7f, 3.2f, 7f));
            Filters.Scene["WaterFilter"].GetShader().Apply();

            return base.PreDraw(npc, spriteBatch, drawColor);
        }
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {

                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.GameViewMatrix.ZoomMatrix);
            base.PostDraw(npc, spriteBatch, drawColor);
        }

        //public override bool InstancePerEntity => true;

        //public bool eFlames;

        /*public override void ResetEffects(NPC npc) {
			eFlames = false;
		}*/

        /*public override void SetDefaults(NPC npc) {
			// We want our ExampleJavelin buff to follow the same immunities as BoneJavelin
			npc.buffImmune[mod.BuffType<Buffs.ExampleJavelin>()] = npc.buffImmune[BuffID.BoneJavelin];
		}*/

        /*public override void NPCLoot(NPC npc) {
			if (npc.lifeMax > 5 && npc.value > 0f) {
				Item.NewItem(npc.getRect(), mod.ItemType("ExampleItem"));
				if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExamplePlayer>().ZoneExample) {
					Item.NewItem(npc.getRect(), mod.ItemType("BossItem"));
				}
			}
			if ((npc.type == NPCID.Pumpking && Main.pumpkinMoon || npc.type == NPCID.IceQueen && Main.snowMoon) && NPC.waveNumber > 10) {
				int chance = NPC.waveNumber - 10;
				if (Main.expertMode) {
					chance++;
				}
				if (Main.rand.Next(5) < chance) {
					int stack = 1;
					if (NPC.waveNumber >= 15) {
						stack = Main.rand.Next(4, 7);
						if (Main.expertMode) {
							stack++;
						}
					}
					else if (Main.rand.NextBool()) {
						stack++;
					}
					string type = npc.type == NPCID.Pumpking ? "ScytheBlade" : "Icicle";
					Item.NewItem(npc.getRect(), mod.ItemType(type), stack);
				}
			}
			if (npc.type == NPCID.DukeFishron && !Main.expertMode) {
				Item.NewItem(npc.getRect(), mod.ItemType("Bubble"), Main.rand.Next(5, 8));
			}
			if (npc.type == NPCID.Bunny && npc.AnyInteractions()) {
				int left = (int)(npc.position.X / 16f);
				int top = (int)(npc.position.Y / 16f);
				int right = (int)((npc.position.X + npc.width) / 16f);
				int bottom = (int)((npc.position.Y + npc.height) / 16f);
				bool flag = false;
				for (int i = left; i <= right; i++) {
					for (int j = top; j <= bottom; j++) {
						Tile tile = Main.tile[i, j];
						if (tile.active() && tile.type == mod.TileType("ElementalPurge") && !NPC.AnyNPCs(mod.NPCType("PuritySpirit"))) {
							i -= Main.tile[i, j].frameX / 18;
							j -= Main.tile[i, j].frameY / 18;
							i = i * 16 + 16;
							j = j * 16 + 24 + 60;
							for (int k = 0; k < 255; k++) {
								Player player = Main.player[k];
								if (player.active && player.position.X > i - NPC.sWidth / 2 && player.position.X + player.width < i + NPC.sWidth / 2 && player.position.Y > j - NPC.sHeight / 2 && player.position.Y < j + NPC.sHeight / 2) {
									flag = true;
									break;
								}
							}
							if (flag) {
								NPC.NewNPC(i, j, mod.NPCType("PuritySpirit"));
								break;
							}
						}
					}
					if (flag) {
						break;
					}
				}
			}
		}*/

        /*public override void DrawEffects(NPC npc, ref Color drawColor) {
			if (eFlames) {
				if (Main.rand.Next(4) < 3) {
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("EtherealFlame"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) {
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}*/

        /*public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {

			if (player.GetModPlayer<ExamplePlayer>().ZoneExample) {
				spawnRate = (int)(spawnRate * 5f);
				maxSpawns = (int)(maxSpawns * 5f);
			}
		}*/
    }
}
