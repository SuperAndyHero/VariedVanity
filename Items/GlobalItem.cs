using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace VariedVanity.Items
{
    public class VanityGlobalItem : GlobalItem
    {
        public override bool DrawHead(int head)
         {
            Item foxMask = new Item();
            foxMask.SetDefaults(ItemID.FoxMask);
            if (head == 132)  
                return false;
            return true;
         }  
    }
}
