using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
    public class TalonginusProj : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.Trident);
            projectile.name = "Talonginus";
            
            aiType = ProjectileID.Trident;
        }      
    }
}