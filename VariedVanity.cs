using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using Microsoft.Kinect;

namespace VariedVanity //REMOVE "includePDB = true" in release
{
	public class VariedVanity : Mod
	{
        public static Effect halfRedEffect;
        public static Effect halfGreenEffect;

        internal static VariedVanity instance;

        public static Texture2D shaderTex;
        public static Texture2D shaderTex2;
        //private KinectSensor sensor;

        public VariedVanity()
		{
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }

        /*public override void ModifyTransformMatrix(ref SpriteViewMatrix Transform)
        {
            
        }*/

        /*public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
			{
				// Make sure your logic here goes from lowest priority to highest so your intended priority is maintained.
				if (Main.LocalPlayer.GetModPlayer<VanityPlayer>().ZoneNeon)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/IDK");
					priority = MusicPriority.BiomeLow;
				}
			}
		}*/

        /*public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
		{
			if (VanityWorld.neonTiles > 50)
			{
				float darkStrength = VanityWorld.neonTiles / 1000f; // copy example monolith
				darkStrength = Math.Min(darkStrength, 100f);

				int sunR = backgroundColor.R;
				int sunG = backgroundColor.G;
				int sunB = backgroundColor.B;
				// Remove some green and more red.
				sunR -= (int)(220f * darkStrength * (backgroundColor.R / 255f));
				sunG -= (int)(220f * darkStrength * (backgroundColor.G / 255f));
				sunB -= (int)(220f * darkStrength * (backgroundColor.R / 255f));
				sunR = Utils.Clamp(sunR, 15, 255);
				sunG = Utils.Clamp(sunG, 15, 255);
				sunB = Utils.Clamp(sunB, 15, 255);
				backgroundColor.R = (byte)sunR;
				backgroundColor.G = (byte)sunG;
				backgroundColor.B = (byte)sunB;
			}
		}*/

        /*public override void Load()
		{
			instance = this;
			if (!Main.dedServ) // All code below runs only if we're not loading on a server
			{
				Main.music[MusicID.Title] = GetMusic("Sounds/Music/waa");
			}
		}
		
		public override void Unload()
		{
			if (!Main.dedServ)
			{
				Main.music[MusicID.Title] = Main.soundBank.GetCue("Music_" + MusicID.Title);
			}
			instance = null;
		}*/

        public override void Load()
		{
			instance = this;

			if (!Main.dedServ)
			{
                /*foreach (var potentialSensor in KinectSensor.KinectSensors)
                {
                    if (potentialSensor.Status == KinectStatus.Connected)
                    {
                        this.sensor = potentialSensor;
                        break;
                    }
                }

                if (null != this.sensor)
                {
                    this.sensor.ElevationAngle = 0;
                }*/
				











                    // Create new skies and screen filters
                    //Filters.Scene["ExampleMod:PuritySpirit"] = new Filter(new PuritySpiritScreenShaderData("FilterMiniTower").UseColor(0.4f, 0.9f, 0.4f).UseOpacity(0.7f), EffectPriority.VeryHigh);
                    //SkyManager.Instance["ExampleMod:PuritySpirit"] = new PuritySpiritSky();

                    //Filters.Scene["VariedVanity:MonolithVoid"] = new Filter(new ScreenShaderData("FilterCrystalDestructionVortex"), EffectPriority.VeryHigh);
                    //^would be great for a biome

                    //Filters.Scene["VariedVanity:Retro"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(1f, 0.2f, 0.2f).UseOpacity(0.2f), EffectPriority.High);

                    /*bloomEffect = GetEffect("Effects/BloomEffect");
                    Ref<Effect> bloomEffectRef = new Ref<Effect>();
                    bloomEffectRef.Value = bloomEffect;

                    GameShaders.Armor.BindShader<ArmorShaderData>(ItemType<Items.BloomDye>(), new ArmorShaderData(bloomEffectRef, "TestDyePass"));*/

                    /* Old
                    halfRedEffect = GetEffect("Effects/HalfRedEffect");
                    Ref<Effect> halfRedEffectRef = new Ref<Effect>();
                    halfRedEffectRef.Value = halfRedEffect;
                    GameShaders.Armor.BindShader<ArmorShaderData>(ItemType<Items.HalfRedDye>(), new ArmorShaderData(halfRedEffectRef, "HalfRedDyePass"));

                    halfGreenEffect = GetEffect("Effects/HalfGreenEffect");
                    Ref<Effect> halfGreenEffectRef = new Ref<Effect>();
                    halfGreenEffectRef.Value = halfGreenEffect; 
                    GameShaders.Armor.BindShader<ArmorShaderData>(ItemType<Items.HalfGreenDye>(), new ArmorShaderData(halfGreenEffectRef, "HalfGreenDyePass"));
                    */

                GameShaders.Armor.BindShader(ModContent.ItemType<Items.HalfRedDye>(), new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/HalfRedEffect")), "HalfRedDyePass"));
                GameShaders.Armor.BindShader(ModContent.ItemType<Items.HalfGreenDye>(), new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/HalfGreenEffect")), "HalfGreenDyePass"));
                GameShaders.Armor.BindShader(ModContent.ItemType<Items.HalfBlueDye>(), new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/HalfBlueEffect")), "HalfBlueDyePass"));
				
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.SwapDye1>(), new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/SwapEffect")), "SwapDyePass"));
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.SwapDye2>(), new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/SwapEffect2")), "SwapDye2Pass"));
				
				//GameShaders.Armor.BindShader(ModContent.ItemType<Items.NoiseDye>(), new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/NoiseEffect2")), "NoiseDyePass"));
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NoiseDye>(), new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/OffsetEffect")), "OffsetPass"));

				Filters.Scene["ModName:ScreenColorFilter"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0.5f, 0.5f, 0.0f).UseOpacity(0.5f), EffectPriority.Medium);
				Filters.Scene["VariedVanity:Shake"] = new Filter(new ScreenShaderData("FilterMoonLordShake"), EffectPriority.High);
				
				Ref<Effect> screenRef3 = new Ref<Effect>(GetEffect("Effects/Zoom"));
                Filters.Scene["ZoomFilter"] = new Filter(new ScreenShaderData(screenRef3, "ZoomPass"), EffectPriority.VeryHigh);
                Filters.Scene["ZoomFilter"].Load();

                Ref<Effect> screenRef4 = new Ref<Effect>(GetEffect("Effects/WaterEffect"));
                Filters.Scene["WaterFilter"] = new Filter(new ScreenShaderData(screenRef4, "WaterPass"), EffectPriority.VeryHigh);
                Filters.Scene["WaterFilter"].Load();

				Ref<Effect> screenRef5 = new Ref<Effect>(GetEffect("Effects/Refraction_ScreenShadert"));
				Filters.Scene["RefractionFilter"] = new Filter(new ScreenShaderData(screenRef5, "RefracPass"), EffectPriority.VeryHigh);
				Filters.Scene["RefractionFilter"].Load();

				Ref<Effect> screenRef2 = new Ref<Effect>(GetEffect("Effects/AuraEffect"));
                Filters.Scene["AuraFilter"] = new Filter(new ScreenShaderData(screenRef2, "AuraPass"), EffectPriority.VeryHigh);
                Filters.Scene["AuraFilter"].Load();

                Ref<Effect> screenRef = new Ref<Effect>(GetEffect("Effects/BlurEffect"));
                Filters.Scene["BlurFilter"] = new Filter(new ScreenShaderData(screenRef, "BlurPass"), EffectPriority.VeryHigh);
                Filters.Scene["BlurFilter"].Load();

                //Filters.Scene["HeatDistortionMAX"] = new Filter(new ScreenShaderData("FilterHeatDistortion").UseImage("Images/Misc/noise", 0, null).UseIntensity(0f), EffectPriority.VeryHigh);
                //filtertest2 is gameboy mode
                //Ref<Effect> vanityShaderRef = new Ref<Effect>();

                //"ArmorShiftingSands")).UseImage("Images/Misc/Perlin").UseColor(0.8f, 1.2f,1.8f).UseSecondaryColor(0.9f, 0.9f, 0.2f);

                //if (shaderTex == null) { //Only reloads texture on game startup

                Texture2D getTex = GetTexture("Misc/clouds");

               Microsoft.Xna.Framework.Color[] colors = new Microsoft.Xna.Framework.Color[getTex.Width * getTex.Height];
                    getTex.GetData(colors);

                    shaderTex = new Texture2D(Main.graphics.GraphicsDevice, getTex.Width, getTex.Height);
                    shaderTex.SetData(colors);
                //} 
                

                Ref<Effect> pixelShaderRef = Main.PixelShaderRef;

                Texture2D blankTexture = TextureManager.BlankTexture; //"backup" the blank texture
                TextureManager.BlankTexture = shaderTex; //replace blank texture with your texture
                GameShaders.Armor.BindShader(ModContent.ItemType<Items.CloudDye>(), new ArmorShaderData(pixelShaderRef, "ArmorShiftingPearlsands")).UseImage("someRandomNonsense").UseColor(2f, 2f, 2f).UseSecondaryColor(0.5f, 0.5f, 2f);

                TextureManager.BlankTexture = blankTexture; //revert back the blank texture
				
				//red
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyeRed>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(1f, 0.05f, 0.1f);
				
				//orange
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyeOrange>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(1f, 0.5f, 0.05f);
				
				//yellow
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyeYellow>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(1f, 1f, 0.05f);

				//green
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyeGreen>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(0.1f, 1f, 0.05f);

				//cyan
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyeTeal>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(0.5f, 1f, 0.8f);
				
				//light blue
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyeSky>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(0f, 0.6f, 1f);
				
				//blue
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyeBlue>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(0f, 0.4f, 2f);
				
				//purple
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyePurple>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(0.5f, 0f, 1f);
				
				//magenta
				GameShaders.Armor.BindShader(ModContent.ItemType<Items.NeonDyePink>(), new ArmorShaderData(pixelShaderRef, "ArmorMushroom")).UseColor(0.9f, 0f, 1f);

                //Ref<Effect> pixelShaderRef = Main.PixelShaderRef;
                //GameShaders.Armor.BindShader(ItemType<Items.CloudDye>(), new ArmorShaderData(pixelShaderRef, "ArmorShiftingPearlsands")).UseImage("Images/Misc/Perlin").UseColor(2f, 2f, 2f).UseSecondaryColor(0.5f, 0.5f, 2f);

                //OLD
                /*Ref<Effect> pixelShaderRef = Main.PixelShaderRef;

                Texture2D blankTexture = TextureManager.BlankTexture; //"backup" the blank texture
                Texture	Manager.BlankTexture = GetTexture("Misc/test"); //replace blank texture with your texture

                GameShaders.Armor.BindShader(ItemType<Items.CloudDye>(), new ArmorShaderData(pixelShaderRef, "ArmorShiftingPearlsands")).UseImage("ItsNull").UseColor(2f, 2f, 2f).UseSecondaryColor(0.5f, 0.5f, 2f);
                //GameShaders.Armor.BindShader(ItemType<Items.CloudDye>(), new ArmorShaderData(pixelShaderRef, "ArmorShiftingPearlsands")).UseImage("Images/Misc/Perlin").UseColor(2f, 2f, 2f).UseSecondaryColor(0.5f, 0.5f, 2f);

                TextureManager.BlankTexture = blankTexture; //revert back the blank texture*/
                //OLD

                //GameShaders.Armor.BindShader(ItemType<Items.AmazingDye>(), new ArmorShaderData(pixelShaderRef, "ArmorHades")).UseColor(0.1f, 0.5f, 1f).UseSecondaryColor(0.2f, 0.4f, 0.8f);
                //GameShaders.Armor.BindShader(ItemType<Items.AmazingDye>(), new ArmorShaderData(pixelShaderRef, "ArmorAcid")).UseColor(2f, 0f, 2f);

                //Replace Sprites
                Main.itemTexture[ItemID.FoxMask] = GetTexture("Resprites/Fox_Head_Item");
				Item foxMask = new Item();
				foxMask.SetDefaults(ItemID.FoxMask);
				Main.armorHeadLoaded[foxMask.headSlot] = true;
				Main.armorHeadTexture[foxMask.headSlot] = GetTexture("Resprites/Fox_Head");
				
				
				Main.itemTexture[ItemID.FoxShirt] = GetTexture("Resprites/Fox_Body_Item");
				Item foxShirt = new Item();
				foxShirt.SetDefaults(ItemID.FoxShirt);
				Main.armorBodyLoaded[foxShirt.bodySlot] = true;
                Main.femaleBodyTexture[foxShirt.bodySlot] = GetTexture("Resprites/Fox_Body");
				Main.armorBodyTexture[foxShirt.bodySlot] = GetTexture("Resprites/Fox_Body");
                Main.armorArmTexture[foxShirt.bodySlot] = GetTexture("Resprites/Fox_Arm");
				
				Main.itemTexture[ItemID.FoxPants] = GetTexture("Resprites/Fox_Legs_Item");
				Item foxPants = new Item();
				foxPants.SetDefaults(ItemID.FoxPants);
				Main.armorLegsLoaded[foxPants.legSlot] = true;
				Main.armorLegTexture[foxPants.legSlot] = GetTexture("Resprites/Fox_Legs");
            }
		}
	}
}
