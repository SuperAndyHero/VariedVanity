using Terraria.ModLoader;

namespace VariedVanity.Items
{
	public class chainWallItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chain Wall");
			//Tooltip.SetDefault("aaaaaaaaaaaaa");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = mod.WallType("chainWall");
		}
	}
}