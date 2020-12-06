using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	public class WSphere : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Whimsical Sphere");
			Tooltip.SetDefault("Creates colorful orbs that follow a wavy path");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.magic = true;
			item.mana = 3;
			item.width = 40;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noUseGraphic = true;
			item.value = 100;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("WOrb");
			item.shootSpeed = 2f;
		}
	}
}