using System;
using System.Reflection;

using DOL.Events;
using DOL.GS.Geometry;
using DOL.GS.PacketHandler;

using log4net;

namespace DOL.GS.Scripts
{
    public class PvEPorter : GameNPC
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AddToWorld()
        {
            this.Level = 50;
           
            this.Name = "PvE Teleport";
            base.AddToWorld();
            return true;
        }
        public override bool Interact(GamePlayer player)
        {
            if (!base.Interact(player)) return false;
            TurnTo(player.Coordinate);
            player.Out.SendMessage("Hello " + player.Name + ", You can currently be translocated to the [Starting Area], [BP Dungeon] or [Housing].", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
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
				
				case "Starting Area":
				
				if (!t.InCombat)
				{	
                    SendReply(t, "I'm now translocating you to the Starting Area!");
                    t.MoveTo(Position.Create(regionID: 88, x: 31963, y: 32907, z: 16000, heading: 35));
				}
					else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }

                    break;
				
				case "BP Dungeon":
				
				if (!t.InCombat)
				{
				
					SendReply(t, "I'm now translocating you to the BP Dungeon!");
                    t.MoveTo(Position.Create(regionID: 125, x: 32156, y: 32101, z: 16000, heading: 35));
					
				}
					else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }

                    break;
					
				case "Housing":
				
				if (!t.InCombat)
				{
				
                    SendReply(t, "Housing Is Closed Until 12/15/2015");
//                    t.MoveTo(Position.Create(regionID: 51, x: 476642, y: 461501, z: 4200, heading: 35));

}
				else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }

                    break;

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