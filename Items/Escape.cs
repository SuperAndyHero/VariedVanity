using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace VariedVanity.Items
{
	public class Escape : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Escape Button");
			Tooltip.SetDefault("Escape Escape Escape Escape"
				+ "\nA key right off someones keyboard!"
				+ "\nCloses the game"
				+ "\nMake sure your progress has been saved first");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = 4;
			item.rare = 4;
			item.autoReuse = true;
		}
		
		public override void UseStyle(Player player)
		{
			Main.instance.Exit();
		}
	}
}
