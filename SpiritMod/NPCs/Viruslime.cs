using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Viruslime : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Viruslime";
            npc.displayName = "Viruslime";
            npc.width = 58;
            npc.height = 40;
            npc.damage = 16;
            npc.defense = 5;
            npc.lifeMax = 100;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneCorrupt && spawnInfo.spawnTileY < Main.rockLayer ? 0.08f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            {
                if (Main.netMode != 1 && npc.life <= 0)
                {
                    Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("Viruling"));
                    spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("Viruling"));
                    spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("Viruling"));
                }
            }
        }
    }
}
