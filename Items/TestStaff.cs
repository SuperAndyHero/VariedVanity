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
    public class TestStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("For Testing.");
            Item.staff[item.type] = true;
        }

        int maxProjectiles = 50;

        public override void SetDefaults()
        {
            item.damage = 1;
            item.magic = true;
            item.mana = 1;
            item.width = 40;
            item.height = 40;
            item.useTime = 64;
            item.useAnimation = 64;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.rare = -11;
            item.UseSound = SoundID.Item18;
            item.autoReuse = true;
            item.shootSpeed = 4f;
        }

        public override bool UseItem(Player player)//one of the messages shows for everyone in multiplayer
        {
            if (player.whoAmI == Main.myPlayer)
            {
                int index = Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("Test1Orb"), item.damage, item.knockBack, Main.myPlayer, 0, 0);
                for (int i = 0; i < maxProjectiles; ++i)
                {
                    index = Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("Test1Orb"), item.damage, item.knockBack, Main.myPlayer, 0, index);
                }
            }
            return true;
        }
    }
}