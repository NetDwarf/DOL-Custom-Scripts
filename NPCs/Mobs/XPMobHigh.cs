//Written by Sirru
using System;
using System.Collections;
using DOL.GS.Effects;
using DOL.GS.PacketHandler;
using DOL.GS.Spells;

namespace DOL.GS.Scripts
{
    /// <summary>
    /// Represents an in-game GameHealer NPC
    /// </summary>
    public class XPMobHigh : GameNPC
    {
        public override void Die(GameObject killer)
        {
            GamePlayer player = killer as GamePlayer;
            if (player is GamePlayer && IsWorthReward)

            player.GainExperience(eXPSource.NPC, (this.Level * 30000000));
            player.SaveIntoDatabase();
            player.Out.SendUpdatePlayer();

            DropLoot(killer);

            base.Die(killer);

            if ((Faction != null) && (killer is GamePlayer))
            {
                GamePlayer player3 = killer as GamePlayer;
                Faction.KillMember(player3);
            }

            StartRespawn();
        }
    }
}