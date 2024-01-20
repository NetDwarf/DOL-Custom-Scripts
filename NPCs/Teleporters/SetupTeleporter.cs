using System;
using DOL.GS.Geometry;
using DOL.Events;
using DOL.GS.PacketHandler;
using log4net;
using DOL.Database;
using System.Reflection;

namespace DOL.GS.Scripts
{
    public class SetupTeleporter : GameNPC
	{
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AddToWorld()
        {
            GameNpcInventoryTemplate template = new GameNpcInventoryTemplate();
            switch (Realm)
            {
                case eRealm.Albion:
                    template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2230); break;
                case eRealm.Midgard:
                    template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2232);
                    template.AddNPCEquipment(eInventorySlot.ArmsArmor, 2233);
                    template.AddNPCEquipment(eInventorySlot.LegsArmor, 2234);
                    template.AddNPCEquipment(eInventorySlot.HandsArmor, 2235);
                    template.AddNPCEquipment(eInventorySlot.FeetArmor, 2236);
                    break;
                case eRealm.Hibernia:
                    template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2231); ; break;
            }

            Inventory = template.CloseTemplate();
            Flags = eFlags.PEACE;	// Peace flag.
            return base.AddToWorld();
        }

        private static ServerProperty curMap = DOLDB<ServerProperty>.SelectObject(DB.Column("Key").IsEqualTo("current_map"));

		public override bool Interact(GamePlayer player)
		{
			if (!base.Interact(player)) return false;
			TurnTo(player.Coordinate);
			player.Out.SendMessage("Hello "+player.Name+"! Would you like to return to the main [Setup]\n" +
            "enter the current [PvP] area, or challenge [Gjalpinulva] the Dragon?", eChatType.CT_Say,eChatLoc.CL_PopupWindow);
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
                case "PvP":
                    if (!t.InCombat)
                    {
                        if (curMap.Value == "Aegir's Landing PvP")
                        {
                            Say("I'm now teleporting you to the current PvP area");
                            t.MoveTo(Position.Create(regionID: 151, x: 255443, y: 316099, z: 4048, heading: 2194));
                        }
                        else if (curMap.Value == "Knarr PvP")
                        {
                            Say("I'm now teleporting you to the current PvP area");
                            t.MoveTo(Position.Create(regionID: 151, x: 348551, y: 433572, z: 3712, heading: 3338));
                        }
                        else if (curMap.Value == "Gothwaite PvP")
                        {
                            Say("I'm now teleporting you to the current PvP area");
                            t.MoveTo(Position.Create(regionID: 51, x: 526034, y: 505253, z: 3424, heading: 1549));
                        }
                        else if (curMap.Value == "Mag Mell PvP")
                        {
                            Say("I'm now teleporting you to the current PvP area");
                            t.MoveTo(Position.Create(regionID: 200, x: 296554, y: 454088, z: 7139, heading: 1101));
                        }
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Setup":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Setup");
                        t.MoveTo(Position.Create(regionID: 70, x: 569762, y: 538694, z: 6104, heading: 3268));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Gjalpinulva":

                    //if (t.Group.MemberCount >= 4) //You have enough
                    {
                        Say("I'm now teleporting you to the Dragon Gjalpinulva");
                        t.MoveTo(Position.Create(regionID: 100, x: 694102, y: 996417, z: 2861, heading: 935));
                        break;
                    }
                    //else if (t.Group.MemberCount <= 3) //You dont have enough
                    //t.Out.SendMessage("You need a group of at least 4 adventurers for this encounter!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                    //break;

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