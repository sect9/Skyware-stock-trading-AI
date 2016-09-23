﻿using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
    public class CarnivorousPlantMinion : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Carnivorous Plant";
            projectile.width = 24;
            projectile.height = 18;

            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.netImportant = true;

            projectile.alpha = 0;
            projectile.timeLeft *= 5;
            projectile.penetrate = -1;
            projectile.minionSlots = 1;

            Main.projFrames[projectile.type] = 7;
        }

        public override bool PreAI()
        {
            MyPlayer mp = Main.player[projectile.owner].GetModPlayer<MyPlayer>(mod);
            if (mp.player.dead)
            {
                mp.carnivorousPlantMinion = false;
            }
            if (mp.carnivorousPlantMinion)
            {
                projectile.timeLeft = 2;
            }

            // Has a target
            if(projectile.ai[0] >= 0)
            {
                NPC target = Main.npc[(int)projectile.ai[0]];

                if(target.active && (target.position - mp.player.position).Length() <= 320)
                {
                    projectile.frameCounter++;
                    if(projectile.frameCounter >= 6)
                    {
                        projectile.frame = (projectile.frame + 1) % 4;
                        projectile.frameCounter = 0;
                    }

                    float speed = 16;

                    Vector2 projCenter = new Vector2(projectile.position.X + projectile.width * 0.5F, projectile.position.Y + projectile.height * 0.5F);
                    float xDir = target.position.X + (target.width * 0.5F) - projCenter.X;
                    float yDir = target.position.Y + (target.height * 0.5F) - projCenter.Y;
                    float length = (float)Math.Sqrt(xDir * xDir + yDir * yDir);

                    if(length < speed)
                    {
                        projectile.velocity.X = xDir;
                        projectile.velocity.Y = yDir;

                        if(length > speed / 2)
                        {
                            projectile.rotation = projectile.velocity.ToRotation();
                        }
                    }
                    else
                    {
                        length = speed / length;
                        xDir *= length;
                        yDir *= length;
                        projectile.velocity.X = xDir;
                        projectile.velocity.Y = yDir;

                        projectile.rotation = projectile.velocity.ToRotation();
                    }
                }
                else
                {
                    projectile.ai[0] = -1;
                }
            }
            else // Does not have a target.
            {
                for(int i = 0; i < 200; ++i)
                {
                    if(Main.npc[i].active && Main.npc[i].CanBeChasedBy(projectile) && (Main.npc[i].position - mp.player.position).Length() <= 320)
                    {
                        projectile.ai[0] = i;
                        break;
                    }
                }

                projectile.frameCounter++;
                if (projectile.frameCounter >= 6)
                {
                    projectile.frame++;
                    if(projectile.frame >= Main.projFrames[projectile.type])
                        projectile.frame = 4;
                    projectile.frameCounter = 0;
                }

                float acceleration = 0.2f;
                Vector2 direction = mp.player.Center - projectile.Center;
                if (direction.Length() < 200f)
                    acceleration = 0.12f;
                if (direction.Length() < 140f)
                    acceleration = 0.06f;
                if (direction.Length() > 100f)
                {
                    if (Math.Abs(mp.player.Center.X - projectile.Center.X) > 20f)
                    {
                        projectile.velocity.X = projectile.velocity.X + acceleration * (float)Math.Sign(mp.player.Center.X - projectile.Center.X);
                    }
                    if (Math.Abs(mp.player.Center.Y - projectile.Center.Y) > 10f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y + acceleration * (float)Math.Sign(mp.player.Center.Y - projectile.Center.Y);
                    }
                }
                else if (projectile.velocity.Length() > 2f)
                {
                    projectile.velocity *= 0.96f;
                }
                if (Math.Abs(projectile.velocity.Y) < 1f)
                {
                    projectile.velocity.Y = projectile.velocity.Y - 0.1f;
                }
                float maxSpeed = 15f;
                if (projectile.velocity.Length() > maxSpeed)
                {
                    projectile.velocity = Vector2.Normalize(projectile.velocity) * maxSpeed;
                }
                projectile.rotation = projectile.velocity.ToRotation();
                int dir = projectile.direction;
            }

            return false;
        }
    }
}
