using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	public class VSphere : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Variable Sphere");
			Tooltip.SetDefault("wip");
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
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("VOrb");
			item.shootSpeed = 2f;
		}
	}
}