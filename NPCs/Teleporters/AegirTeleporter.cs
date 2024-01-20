using System;
using DOL.GS.Geometry;
using DOL.Events;
using DOL.GS.PacketHandler;
using log4net;
using System.Reflection;

namespace DOL.GS.Scripts
{
    public class AegirTeleporter : GameNPC
	{
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AddToWorld()
        {
            Model = 2026;
            Name = "PvP TELEPORTER";
            GuildName = "PvP Teleporter";
            Level = 50;
            Size = 60;
            Flags = eFlags.PEACE;	// Peace flag.
            return base.AddToWorld();
        }
		public override bool Interact(GamePlayer player)
		{
			if (!base.Interact(player)) return false;
			TurnTo(player.Coordinate);
			player.Out.SendMessage("Hello " + player.Name + "! Would you like to port to [PvP] or return to the [Main Setup]?", eChatType.CT_Say,eChatLoc.CL_PopupWindow);
			return true;
		}
		public override bool WhisperReceive(GameLiving source, string str)
		{
			if(!base.WhisperReceive(source,str)) return false;
		  	if(!(source is GamePlayer)) return false;
			GamePlayer t = (GamePlayer) source;
			TurnTo(t.Coordinate);
			switch(str)
			{
                case "Main Setup":    
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to the Main Setup area");
                        t.MoveTo(Position.Create(regionID: 70, x: 569762, y: 538694, z: 6104, heading: 3268));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "PvP":
                    if (!t.InCombat)
                    {
                        int RandPvP = Util.Random(1, 5);//Creates a random number between 1 and 5
                        if (RandPvP == 1)
                        {// send you to  the gloc below if number 1 comes up random
                            t.MoveTo(Position.Create(regionID: 151, x: 293728, y: 356301, z: 3488, heading: 112));
                        }
                        else if (RandPvP == 2)
                        {
                            t.MoveTo(Position.Create(regionID: 151, x: 288205, y: 359354, z: 3280, heading: 2060));
                        }
                        else if (RandPvP == 3)
                        {
                            t.MoveTo(Position.Create(regionID: 151, x: 284841, y: 357002, z: 3338, heading: 2813));
                        }
                        else if (RandPvP == 4)
                        {
                            t.MoveTo(Position.Create(regionID: 151, x: 292049, y: 354989, z: 3867, heading: 1237));
                        }
                        else if (RandPvP == 5)
                        {
                            t.MoveTo(Position.Create(regionID: 151, x: 291402, y: 356049, z: 3866, heading: 3831));
                        }
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
					eChatType.CT_Say,eChatLoc.CL_PopupWindow);
			}
		[ScriptLoadedEvent]
        public static void OnScriptCompiled(DOLEvent e, object sender, EventArgs args)
        {
            log.Info("\tTeleporter initialized: true");
        }	
    }
}