using System;
using System.Reflection;

using DOL.Events;
using DOL.GS.Geometry;
using DOL.GS.PacketHandler;

using log4net;

namespace DOL.GS.Scripts
{
    public class MidPvEPorter : GameNPC
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AddToWorld()
        {
            this.Level = 50;
            this.Name = "Zerta";
			Flags |= GameNPC.eFlags.PEACE;
            base.AddToWorld();
            return true;
        }
        public override bool Interact(GamePlayer player)
        {
            if (!base.Interact(player)) return false;
            TurnTo(player.Coordinate);
            player.Out.SendMessage("Hello " + player.Name + ", You can currently be translocated to the [Nisse's Lair], [Vendo Caverns], [Varulvhamn] or [Spindelhalla] .", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
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
				
				case "Nisse's Lair":
				
				if (!t.InCombat)
				{	
                    SendReply(t, "I'm now translocating you to Nisse's Lair!");
                    t.MoveTo(Position.Create(regionID: 129, x: 34660, y: 33197, z: 16464, heading: 1104));
				}
					else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }

                    break;
				
				case "Vendo Caverns":
				
				if (!t.InCombat)
				{
				
					SendReply(t, "I'm now translocating you to Vendo Caverns!");
                    t.MoveTo(Position.Create(regionID: 126, x: 32783, y: 33088, z: 16618, heading: 2059));
					
				}
					else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }

                    break;
					
				case "Varulvhamn":
				
				if (!t.InCombat)
				{
				
                    SendReply(t, "I'm now translocating you to Varulvhamn!");
                    t.MoveTo(Position.Create(regionID: 127, x: 35134, y: 30850, z: 14995, heading: 1033));

}
				else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }

                    break;
					
				case "Spindelhalla":
				
				if (!t.InCombat)
				{
				
					SendReply(t, "I'm now translocating you to Spindelhalla!");
                    t.MoveTo(Position.Create(regionID: 125, x: 32467, y: 31872, z: 16000, heading: 3));
					
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