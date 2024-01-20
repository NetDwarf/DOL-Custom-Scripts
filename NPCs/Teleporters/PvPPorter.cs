using System;
using System.Reflection;
using DOL.Events;
using DOL.GS.Geometry;
using DOL.GS.PacketHandler;

using log4net;

namespace DOL.GS.Scripts
{
    public class PvPPorter : GameNPC
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AddToWorld()
        {
            this.Level = 57;
           
            this.Name = "PvP Teleporter";
            base.AddToWorld();
            return true;
        }
        public override bool Interact(GamePlayer player)
        {
            if (!base.Interact(player)) return false;
            TurnTo(player.Coordinate);
            player.Out.SendMessage("Hello " + player.Name + ", You can currently be translocated to the [PvP zone].  Number of Players Currently In the PvP Zone = " + WorldMgr.GetClientsOfRegionCount(51) + " ", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
            player.Bind(true);

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
                #region PvP Zone
                case "PvP BuffArea":
                    SendReply(t,
                        "" + t.Name + ", are you sure you wish to go to the [PvP zone]?");
                    break;
                case "PvP zone":
                    SendReply(t, "I'm now translocating you to the PvP zone!");
                    t.MoveTo(Position.Create(regionID: 51, x: 476642, y: 461501, z: 4200, heading: 35));
                    break;
                #endregion PvP Zone

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