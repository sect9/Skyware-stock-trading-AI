using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.Masks
{
    public class ScarabMask : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Scarabeus Mask";
            item.width = 22;
            item.height = 20;

            item.value = 3000;
            item.rare = 1;
            item.vanity = true;
        }
    }
}