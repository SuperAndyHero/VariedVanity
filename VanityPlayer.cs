using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity
{
    public class VisualPlayer : ModPlayer
    {
        public int ViewerRange = 0;
        //public bool ViewerOverlay = false;
        //public short DyeTest = ItemID.None;
		public bool tree = false;
		public bool crab = false;
        public bool fennix = false;
		public bool poptop = false;
        public bool tail1 = false;
        public bool tail2 = false;
		//public bool useSandEffect = false;
		public bool useSnowEffect = false;
		public bool useRetroEffect = false;
		public bool useUnstableEffect = false;
        public bool blurEffect = false;
        //public bool useBloodEffect = false;
        public bool useInvert = false;//:shrug:
		public bool ShowBlocks = false;
        //public float PlayerPosX = 0;
        //public float PlayerPosY = 0;
		
		public bool ZoneNeon = false; //main biome bool
		public bool FountainNeon = false;
		public bool NeonWater = false;

        /*public override void PreUpdateBuffs()
        {
            //player.gravControl = true;
            //player.gravDir = -1f;
        }*/

		public override void UpdateBiomes()
        {
			NeonWater = false;
			
            ZoneNeon = (VanityWorld.neonTiles > 50);
			
			if (ZoneNeon || FountainNeon)
			{
				NeonWater = true;
			}  
        }

        public override void UpdateBiomeVisuals()
		{
			player.ManageSpecialBiomeVisuals("Test2", useRetroEffect, player.Center);
			player.ManageSpecialBiomeVisuals("testInvert", useInvert, player.Center);
			//player.ManageSpecialBiomeVisuals("Sandstorm", useSandEffect, player.Center);
			player.ManageSpecialBiomeVisuals("ModName:ScreenColorFilter", useSnowEffect, player.Center);
			player.ManageSpecialBiomeVisuals("VariedVanity:Shake", useUnstableEffect, player.Center);//VariedVanity:Shake
            //player.ManageSpecialBiomeVisuals("BloodMoon", useBloodEffect, player.Center);
        }
		
		/*public override void UpdateDead()
		{
			eFlames = false;
			badHeal = false;
		}*/
        //public bool tail3 = false;

        public override void ResetEffects()
        {
            //Main.NewText((player.position.X / 16) + "X");
            //Main.NewText((player.position.Y / 16) + "Y");
			
			tree = false;
			crab = false;
            fennix = false;
			poptop = false;
			//useSandEffect = false;
			//useSnowEffect = false;
            tail1 = false;
            tail2 = false;
            //tail3 = false;
			//useUnstableEffect = false;
			//useInvert = false;
            //useRetroEffect = false;
            //DyeTest = ItemID.None;
            //ShowBlocks = false;
            //Main.NewText(PlayerPosX);
            //Main.NewText(PlayerPosY);
            //PlayerPosX = player.position.X;
            //PlayerPosY = player.position.Y;
			
			/*if(FountainNeon)
			{
				Main.NewText("Fountain Neon True");
			}*/
			
			//NeonWater = false;
			
			//FountainNeon = false;
			
			
        }

        public override void ModifyZoom(ref float zoom)
        {
            if (ViewerRange == 1)
            {
                zoom = 1;
            }
            else if (ViewerRange == 2)
            {
                zoom = 2;
            }
            else if (ViewerRange == 3)
            {
                zoom = 4;
            }
            else if (ViewerRange == 4)
            {
                zoom = 8;
            }
            else if (ViewerRange == 5)
            {
                zoom = 16;
            }
            else if (ViewerRange == 6)
            {
                zoom = 32;
            }
            else if (ViewerRange == 7)
            {
                zoom = 64;
            }
        }

        /*private static void BeginShaderBatch(SpriteBatch batch)
        {
            batch.End();
            RasterizerState rasterizerState = Main.LocalPlayer.gravDir == 1f ? RasterizerState.CullCounterClockwise : RasterizerState.CullClockwise;
            batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, rasterizerState, null, Main.GameViewMatrix.TransformationMatrix);
        }*/

        public static readonly PlayerLayer MiscEffectsBack = new PlayerLayer("VariedVanity", "MiscEffectsBack", PlayerLayer.MiscEffectsBack, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("VariedVanity");
            VisualPlayer modPlayer = drawPlayer.GetModPlayer<VisualPlayer>();
            if (modPlayer.tail1)
            {
                if (drawInfo.drawPlayer.dead)
                    return;
                Texture2D texture = mod.GetTexture("Items/Tail01");
                int frameSize = texture.Height / 20;
                Rectangle tail1frame = drawPlayer.legFrame;
                tail1frame.Width = 56;//or 74 if even

                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);//-6
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y - 3);//-3
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), tail1frame, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, frameSize / 2f), 1f, drawInfo.spriteEffects, 0);
                data.shader = drawInfo.shieldShader;
                Main.playerDrawData.Add(data);
            }
            if (modPlayer.tail2)
            {
                if (drawInfo.drawPlayer.dead)
                    return;
                Texture2D texture = mod.GetTexture("Items/Tail02");
                int frameSize = texture.Height / 20;
                Rectangle tail2frame = drawPlayer.legFrame;
                tail2frame.Width = 40;//or 74 if even

                int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);//-6
                int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y - 3);//-3
                DrawData data = new DrawData(texture, new Vector2(drawX, drawY), tail2frame, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, frameSize / 2f), 1f, drawInfo.spriteEffects, 0);
                data.shader = drawInfo.shieldShader;
                Main.playerDrawData.Add(data);
            }
        });

        public static readonly PlayerLayer MiscEffects = new PlayerLayer("VariedVanity", "MiscEffects", PlayerLayer.MiscEffectsFront, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("VariedVanity");
            VisualPlayer modPlayer = drawPlayer.GetModPlayer<VisualPlayer>();

            Texture2D texture = mod.GetTexture("Items/Fennix");
            Texture2D textureAlt = mod.GetTexture("Items/FennixAttack");
			Texture2D texture2 = mod.GetTexture("Items/Poptop");
			Texture2D texture3 = mod.GetTexture("Items/Tree");
			Texture2D texture4 = mod.GetTexture("Items/CrabbyHat");
    
            if (modPlayer.fennix)
            {
                if (drawInfo.drawPlayer.controlUseItem)
                {
                    if (drawInfo.drawPlayer.dead)
                        return;
                    int frameSize = texture.Height / 20;
                    Rectangle fennixframe = drawPlayer.legFrame;
                    fennixframe.Width = 86;//or 74 if even

                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X - 6);//-13
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y - 3);//-3
                    DrawData data = new DrawData(textureAlt, new Vector2(drawX, drawY), fennixframe, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, frameSize / 2f), 1f, drawInfo.spriteEffects, 0);
                    data.shader = drawInfo.shieldShader;
                    Main.playerDrawData.Add(data);
                }
                else
                {
                    if (drawInfo.drawPlayer.dead)
                        return;
                    int frameSize = texture.Height / 20;
                    Rectangle fennixframe = drawPlayer.legFrame;
                    fennixframe.Width = 86;//or 74 if even

                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X - 6);//-13
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y - 3);//-3

                    DrawData data = new DrawData(texture, new Vector2(drawX, drawY), fennixframe, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, frameSize / 2f), 1f, drawInfo.spriteEffects, 0); //SpriteEffects.None 
                    //data.shader = GameShaders.Armor.GetSecondaryShader(drawInfo.shieldShader, player); //modPlayer.DyeTest


                    data.shader = drawInfo.shieldShader;

                    Main.playerDrawData.Add(data);
                }
            }
			if (modPlayer.poptop)
            {
                    if (drawInfo.drawPlayer.dead)
                        return;
                    int frameSize = texture.Height / 20;
                    Rectangle fennixframe = drawPlayer.legFrame;
                    fennixframe.Width = 86;//or 74 if even

                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X - 6);//-13
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y - 3);//-3
                    DrawData data = new DrawData(texture2, new Vector2(drawX, drawY), fennixframe, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, frameSize / 2f), 1f, drawInfo.spriteEffects, 0);
                    data.shader = drawInfo.shieldShader;
                    Main.playerDrawData.Add(data);
            }
			if (modPlayer.tree)
            {
                    if (drawInfo.drawPlayer.dead)
                        return;
                    Rectangle fennixframe = drawPlayer.legFrame;
                    fennixframe.Width = 80;

                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X - 3);//-6
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y - 144);//-3
                    DrawData data = new DrawData(texture3, new Vector2(drawX, drawY), null, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, texture.Width / 2f), 1f, SpriteEffects.None, 0);
                    data.shader = drawInfo.shieldShader;
                    Main.playerDrawData.Add(data);
            }
			if (modPlayer.crab)
            {
                    if (drawInfo.drawPlayer.dead)
                        return;
                    int frameSize = texture.Height / 20;
                    Rectangle fennixframe = drawPlayer.bodyFrame;
                    fennixframe.Width = 40;

                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X + 17);//-6
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y - 9);//-3
                    DrawData data = new DrawData(texture4, new Vector2(drawX, drawY), fennixframe, Lighting.GetColor((int)((drawInfo.position.X + drawPlayer.width / 2f) / 16f), (int)((drawInfo.position.Y + drawPlayer.height / 2f) / 16f)), 0f, new Vector2(texture.Width / 2f, frameSize / 2f), 1f, drawInfo.spriteEffects, 0);
                    data.shader = drawInfo.headArmorShader;
                    Main.playerDrawData.Add(data);
			}
        });

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            //Face.visible = false;
            MiscEffectsBack.visible = true;
            layers.Insert(0, MiscEffectsBack);
            MiscEffects.visible = true;
            layers.Add(MiscEffects);
        }
    }
}
