using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Spitfly : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Spitfly";
            npc.displayName = "Spitfly";
            npc.width = 24;
            npc.height = 24;
            npc.damage = 55;
            npc.defense = 9;
            npc.lifeMax = 85;
            npc.soundHit = 44;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 2;
            npc.noGravity = true;
            aiType = NPCID.TheHungryII;
            Main.npcFrameCount[npc.type] = 2;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 1) && spawnInfo.spawnTileY > Main.rockLayer && Main.hardMode ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.05f, 0.05f, 0.4f);
        }
    }
}
