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
    public class TestStaff2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("For Testing, 2.");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.rare = -11;
            item.UseSound = SoundID.Item18;
            item.autoReuse = true;
            item.shootSpeed = 4f;
        }

        public override bool UseItem(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                for (int i = -1; i < 2; i++)//k = max range up, this checks the area above it
                {
                    for (int j = -1; j < 2; j++)//k = max range up, this checks the area above it
                    {
                        if (Main.tile[(int)(Main.MouseWorld.X / 16 + i), (int)(Main.MouseWorld.Y / 16 + j)].active())
                        {
                            Projectile.NewProjectile((Main.MouseWorld + new Vector2(8, 8)) + new Vector2(i * 16, j * 16), Vector2.Zero, mod.ProjectileType("Orbit"), item.damage, item.knockBack, Main.myPlayer, 0, Main.tile[(int)(Main.MouseWorld.X / 16 + i), (int)(Main.MouseWorld.Y / 16 + j)].type);
                            Main.tile[(int)(Main.MouseWorld.X / 16 + i), (int)(Main.MouseWorld.Y / 16 + j)].ClearTile();
                            WorldGen.SquareTileFrame((int)(Main.MouseWorld.X / 16 + i), (int)(Main.MouseWorld.Y / 16 + j));
                        }
                    }
                }
            }
            return true;
        }
    }
}