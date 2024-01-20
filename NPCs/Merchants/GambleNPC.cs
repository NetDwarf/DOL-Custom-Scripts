//Developed By Alezzandroz
//V 1.0

using System;
using DOL;
using DOL.GS;
using DOL.Events;
using DOL.Database;
using System.Collections;
using DOL.GS.PacketHandler;
using DOL.GS.Finance;

namespace DOL.GS.Scripts
{
    public class GambleNPC : GameNPC
    {
        long bpWon = 0;
        long bpLost = 0;
        #region Interazione
        public override bool Interact(GamePlayer player)
        {
            if (!base.Interact(player)) return false;
            TurnTo(player, 500);
            SendReply(player, "Hi, whisper me how much you wish to gamble and see if you win!\n\n Players have stolen " + bpWon + "off me today! \n But I have managed to steal " + bpLost + " back from the players, hahaha");
            return true;
        }
        #endregion
        #region Settaggio
        public override bool WhisperReceive(GameLiving source, string str)
        {
            if (!base.WhisperReceive(source, str)) return false;
            if (!(source is GamePlayer)) return false;
            GamePlayer player = (GamePlayer)source;

            long amount = long.Parse(str);
            var bps = Currency.BountyPoints.Mint(amount);
            if (player.GetBalance(Currency.BountyPoints).Amount >= bps.Amount)
            {
                if (Util.Chance(50))
                {
                    SendReply(player, "You have doubled your bounty points and gain " + amount + " plus the money you just bet!");
                    player.AddMoney(bps);
                    bpWon += amount;
                    Emote(eEmote.Cheer);
                }
                else
                {
                    SendReply(player, ":( You lose " + amount + " bounty points");
                    player.RemoveMoney(bps);
                    bpLost += amount;
                    Emote(eEmote.Cry);
                }
            }
            return true;
        }
        #endregion
        private void SendReply(GamePlayer target, string msg)
        {
            target.Out.SendMessage(
                msg,
                eChatType.CT_Say, eChatLoc.CL_PopupWindow);
        }
    }
}