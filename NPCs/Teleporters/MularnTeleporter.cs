using System;
using DOL.GS.Geometry;
using DOL.Events;
using DOL.GS.PacketHandler;
using log4net;
using System.Reflection;

namespace DOL.GS.Scripts
{
    public class MularnTeleporter : GameNPC
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
            Flags |= GameNPC.eFlags.PEACE;
            return base.AddToWorld();
        }
		public override bool Interact(GamePlayer player)
		{
			if (!base.Interact(player)) return false;
			//TurnTo(player.X,player.Y);
			player.Out.SendMessage("Hello "+player.Name+"! Would you like to port to the [PvP Buff Zone],  [Direct to PvP] or return to the [Main Setup]?", eChatType.CT_Say,eChatLoc.CL_PopupWindow);
			return true;
		}
		public override bool WhisperReceive(GameLiving source, string str)
		{
			if(!base.WhisperReceive(source,str)) return false;
		  	if(!(source is GamePlayer)) return false;
			GamePlayer t = (GamePlayer) source;
			//TurnTo(t.X,t.Y);
			switch(str)
			{
                case "PvP Buff Zone":
                    Say("I'm now teleporting you to the Mularn Buff Zone");
                    t.MoveTo(Position.Create(regionID: 100, x: 764614, y: 705751, z: 4672, heading: 2123));
                    break;

                case "Main Setup":
                    Say("I'm now teleporting you to the Main Setup");
                    t.MoveTo(Position.Create(regionID: 1, x: 531200, y: 479688, z: 2200, heading: 2197));
                    break;

                case "Direct to PvP":
                    if (!t.InCombat)
                    {
                        int RandPvP = Util.Random(1, 5);//Creates a random number between 1 and 5
                        if (RandPvP == 1)
                        {// send you to  the gloc below if number 1 comes up random
                            t.MoveTo(Position.Create(regionID: 100, x: 803840, y: 726390, z: 4764, heading: 1665));
                        }
                        else if (RandPvP == 2)
                        {
                            t.MoveTo(Position.Create(regionID: 100, x: 801137, y: 724544, z: 4754, heading: 3052));
                        }
                        else if (RandPvP == 3)
                        {
                            t.MoveTo(Position.Create(regionID: 100, x: 807682, y: 727720, z: 4688, heading: 1222));
                        }
                        else if (RandPvP == 4)
                        {
                            t.MoveTo(Position.Create(regionID: 100, x: 800570, y: 723071, z: 4688, heading: 3665));
                        }
                        else if (RandPvP == 5)
                        {
                            t.MoveTo(Position.Create(regionID: 100, x: 806696, y: 726604, z: 4717, heading: 29));
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