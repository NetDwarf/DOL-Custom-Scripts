using System;
using System.Reflection;
using DOL.Events;
using DOL.GS.Geometry;
using DOL.GS.PacketHandler;
using log4net;

namespace DOL.GS.Scripts
{
    public class BPFarmPorter : GameNPC
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AddToWorld()
        {
            Name = "BP Farm";
			GuildName = "Teleporter";
            Model = 881;
            Size = 37;
            Level = 50;
            Flags |= eFlags.PEACE;
			
			return base.AddToWorld();
        }
        public override bool Interact(GamePlayer player)
        {
            if (!base.Interact(player)) return false;
            TurnTo(player.Coordinate);
            player.Out.SendMessage("Hello " + player.Name + ", You can currently be translocated to your [BPFarm Zone].  Number of Players Currently In your BPFarm Zone = " + WorldMgr.GetClientsOfRegionCount(249) + " ", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
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



                #region BPFarm Zone

                case "BPFarm Zone":
				
					if (!t.InCombat)
                    {
                    SendReply(t, "I'm now translocating you to the BPFarm zone!");
                    t.MoveTo(Position.Create(regionID: 249, x: 47260, y: 49577, z: 20831, heading: 35));
					}
					else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }

                    break;
                #endregion BPFarm Zone

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