using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	public class RSphere : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radical Sphere");
			Tooltip.SetDefault("Creates colorful crystals that change directions randomly");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.magic = true;
			item.mana = 3;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noUseGraphic = true;
			item.value = 100;
			item.rare = 4;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ROrb");
			item.shootSpeed = 2f;
		}
	}
}