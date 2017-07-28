using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Armor.PrimalstoneArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class PrimalstoneFaceplate : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primalstone Faceplate");
			Tooltip.SetDefault("Increases melee and magic damage by 30% and maximum mana by 60 \n Reduces damage taken by 12% and movement speed by 15%");
		}
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 30;
            item.value = 10000;
            item.rare = 9;
            item.defense = 15;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("PrimalstoneBreastplate") && legs.type == mod.ItemType("PrimalstoneLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {            
            player.setBonus = "Melee and magic hits on enemies trigger Unstable Afflction\nEnemies suffering from the Unstable Affliction have different effects\n Reduces your movement speed by 10%";
            player.GetModPlayer<MyPlayer>(mod).primalSet = true;
            player.moveSpeed -= 0.10F;
            int dust1 = Dust.NewDust(player.position, player.width, player.height - 38, 206);
            Main.dust[dust1].scale = 2f;
        }
        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.12F;
            player.statManaMax2 += 60;
            player.meleeDamage += .13f;
            player.magicDamage += .13f;
            player.moveSpeed -= 0.15F;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ArcaneGeyser", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}