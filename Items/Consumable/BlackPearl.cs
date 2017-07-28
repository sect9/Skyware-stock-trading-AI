using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.Tide;

namespace SpiritMod.Items.Consumable
{
    public class BlackPearl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Pearl");
            Tooltip.SetDefault("'Coveted by ancient horrors...'\nSummons The Tide \nCan only be used near the ocean");
        }


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.rare = 3;
            item.maxStack = 99;
            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            if (!(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust) && (!Main.pumpkinMoon && !Main.snowMoon))
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            Mod mod = ModLoader.GetMod("SpiritMod");

            if (TideWorld.TheTide)
                return false;
            if (!player.ZoneBeach)
            {
                Main.NewText("The Tide only ebbs by the sea.", 39, 86, 134, true);
                return false;
            }
            TideWorld.TheTide = true;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 5);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddIngredient(null, "FossilFeather", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}

