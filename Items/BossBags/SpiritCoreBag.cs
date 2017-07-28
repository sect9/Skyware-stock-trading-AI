using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.BossBags
{
    public class SpiritCoreBag : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right Click to open");
		}


        public override void SetDefaults()
        {
			item.width = 20;
            item.height = 20;
            item.rare = -2;

            item.maxStack = 30;

			item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
		{
            string[] lootTable = { "SummonStaff", "ShadowStaff", "SpiritBall", "WispSword" };
            int loot = Main.rand.Next(lootTable.Length);

            player.QuickSpawnItem(mod.ItemType("ShadowLens"));

            if (Main.rand.Next(4) == 1)
            {
                player.QuickSpawnItem(mod.ItemType("SpiritBar"), Main.rand.Next(3, 6));
            }

            if (Main.rand.Next(4) == 1)
            {

                player.QuickSpawnItem(mod.ItemType("StellarBar"), Main.rand.Next(3, 6));
            }

            if (Main.rand.Next(4) == 1)
            {

                player.QuickSpawnItem(mod.ItemType("Rune"), Main.rand.Next(3, 6));
            }

            if (Main.rand.Next(4) == 1)
            {
                player.QuickSpawnItem(mod.ItemType("SoulShred"), Main.rand.Next(5, 9));
            }

            if (Main.rand.Next(4) == 1)
            {

                player.QuickSpawnItem(mod.ItemType("DuskStone"), Main.rand.Next(4, 8));

            }

            if (Main.rand.Next(4) == 1)
            {

                player.QuickSpawnItem(mod.ItemType("SpiritCrystal"), Main.rand.Next(3, 6));
            }
        
        int yikea = Main.rand.Next(7, 12);
            {
                for (int I = 0; I < yikea; I++)
                {
                    player.QuickSpawnItem(ItemID.GoldCoin);
                }
            }
            player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
        }
    }
}
