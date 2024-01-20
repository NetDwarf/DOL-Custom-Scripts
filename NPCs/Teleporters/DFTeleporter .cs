using System;
using DOL.GS.Geometry;
using DOL.Events;
using DOL.GS.PacketHandler;
using log4net;
using System.Reflection;

namespace DOL.GS.Scripts
{
	public class DFTeleporter: GameNPC
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
            Flags |= eFlags.PEACE;
            return base.AddToWorld();
        }
		public override bool Interact(GamePlayer player)
		{
			if (!base.Interact(player)) return false;
			//TurnTo(player.X,player.Y);
            player.Out.SendMessage("Hello " + player.Name + "! Would you like to go deeper into [Darkness Falls], [The Breach] or move back to [Setup]?", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
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
                case "Setup":
                    Say("I'm now teleporting you to Setup");
                    t.MoveTo(Position.Create(regionID: 1, x: 531200, y: 479688, z: 2200, heading: 2197));
                    break;

                case "Darkness Falls":
                    if (!t.InCombat)
                    {
                        int RandPvP = Util.Random(1, 3);//Creates a random number between 1 and 3
                        if (RandPvP == 1)
                        {// send you to  the gloc below if number 1 comes up random
                            t.MoveTo(Position.Create(regionID: 249, x: 31670, y: 27908, z: 22893, heading: 3058));
                        }
                        else if (RandPvP == 2)
                        {
                            t.MoveTo(Position.Create(regionID: 249, x: 46385, y: 40298, z: 21357, heading: 2033));
                        }
                        else if (RandPvP == 3)
                        {
                            t.MoveTo(Position.Create(regionID: 249, x: 18093, y: 18681, z: 22893, heading: 1024));
                        }
                    }

                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "The Breach":
                    if (!t.InCombat)
                    {
                        int RandPvP = Util.Random(1, 3);//Creates a random number between 1 and 3
                        if (RandPvP == 1)
                        {// send you to  the gloc below if number 1 comes up random
                            t.MoveTo(Position.Create(regionID: 489, x: 25357, y: 52833, z: 15999, heading: 3069));
                        }
                        else if (RandPvP == 2)
                        {
                            t.MoveTo(Position.Create(regionID: 489, x: 14780, y: 37713, z: 15999, heading: 13));
                        }
                        else if (RandPvP == 3)
                        {
                            t.MoveTo(Position.Create(regionID: 489, x: 40400, y: 42105, z: 15999, heading: 2055));
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