using System;
using System.Reflection;
using DOL.Events;
using DOL.GS.Geometry;
using DOL.GS.PacketHandler;

using log4net;

namespace DOL.GS.Scripts
{
    public class PvPSafePorter : GameNPC
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AddToWorld()
        {
            Name = "PvP Lobby";
			GuildName = "Teleporter";
            Model = 403;
            Size = 37;
            Level = 50;
            Flags |= eFlags.PEACE;
			
			return base.AddToWorld();
        }
        public override bool Interact(GamePlayer player)
        {
            if (!base.Interact(player)) return false;
            TurnTo(player.Coordinate);
            player.Out.SendMessage("Hello " + player.Name + ", You can currently be translocated to the [PvP Safe Zone].  Number of Players Currently In the PvP Safe Zone = " + WorldMgr.GetClientsOfRegionCount(91) + " ", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
			
            return true;
        }



        public override bool WhisperReceive(GameLiving source, string str)
        {
            if (!base.WhisperReceive(source, str)) return false;
            if (!(source is GamePlayer)) return false;
            GamePlayer t = (GamePlayer)source;
            TurnTo(t.Coordinate);

            switch (str)
            {



                #region PvP Safe Zone

                case "PvP Safe Zone":
				
					if (!t.InCombat)
                    {
                    SendReply(t, "I'm now translocating you to the PvP zone!");
                    t.MoveTo(Position.Create(regionID: 91, x: 31955, y: 30276, z: 15733, heading: 35));
					}
					else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }

                    break;
                #endregion PvP Safe Zone

                default: break;
            }
            return true;
        }

        private void SendReply(GamePlayer target, string msg)
        {
            target.Client.Out.SendMessage(
                msg,
                eChatType.CT_Say, eChatLoc.CL_PopupWindow);
        }

        [ScriptLoadedEvent]
        public static void OnScriptCompiled(DOLEvent e, object sender, EventArgs args)
        {
            log.Info("\tTeleporter initialized: true");
        }
    }

}