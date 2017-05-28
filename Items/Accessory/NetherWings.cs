using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class NetherWings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Wings);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Nether Wings";
            item.toolTip = "Allows for flight and slow fall.";
            item.width = 47;
            item.height = 37;
            item.value = 60000;
            item.rare = 5;

            item.accessory = true;

            item.rare = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 190;
            if (Main.rand.Next(4) == 0)
            {

                Dust.NewDust(player.position, player.width, player.height, 206);
            }

        }

        public override void VerticalWingSpeeds(ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.65f;
			ascentWhenRising = 0.07f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 2.2f;
			constantAscend = 0.095f;
		}

		public override void HorizontalWingSpeeds(ref float speed, ref float acceleration)
		{
			speed = 9f;
			acceleration *= 1.3f;
		}  
public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "NetherCrystal", 1);
			modRecipe.AddIngredient(575, 20);
			 modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}		
    }
}