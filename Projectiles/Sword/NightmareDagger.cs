using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Sword
{

    public class NightmareDagger : ModProjectile
    {
        public override void SetDefaults()
        {
            
            projectile.name = "Nightmare Dagger";  
            projectile.width = 20;       
            projectile.height = 20;  
            projectile.friendly = true;      
            projectile.melee = true;          
            projectile.tileCollide = true;   
            projectile.penetrate = 1;      
            projectile.timeLeft = 500;      
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;

        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;

        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int I = 0; I < 8; I++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 5, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
        }
    }
}