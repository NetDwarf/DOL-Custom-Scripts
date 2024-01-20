using System;
using DOL.GS;
using DOL.Events;
using DOL.GS.PacketHandler;
using log4net;
using DOL;
using DOL.AI.Brain;
using DOL.GS.Scripts;
using DOL.GS.GameEvents;
using DOL.GS.Quests;
using DOL.GS.Spells;
using DOL.GS.Effects;
using DOL.Database;
using System.Reflection;
using DOL.GS.Finance;

namespace DOL.GS.Scripts
{
	public class Santa: GameNPC
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
		public override bool Interact(GamePlayer t)
		{
			if (!base.Interact(t)) return false;
			TurnTo(t.Coordinate);
			t.Out.SendMessage("Hello "+t.Name+", would you like a [Present]? " +
            "Each Present costs 500 Bounty Points.", eChatType.CT_Say,eChatLoc.CL_PopupWindow);
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
                

                case "Present":
                    var price = Currency.BountyPoints.Mint(500);
                    if (t.GetBalance(price.Currency).Amount >= price.Amount)
                    {
                        int RandLottery = Util.Random(1, 7);//Creates a random number between 1 and 7

                        if (RandLottery == 1)
                        {
                            t.ReceiveItem(this, "present1");
                            t.RemoveMoney(price); SendReply(t, "Here is your present!");
                        }
                        else if (RandLottery == 2)
                        {
                            t.ReceiveItem(this, "present2");
                            t.RemoveMoney(price); SendReply(t, "Here is your present!");
                        }
                        else if (RandLottery == 3)
                        {
                            t.ReceiveItem(this, "present3");
                            t.RemoveMoney(price); SendReply(t, "Here is your present!");
                        }
                        else if (RandLottery == 4)
                        {
                            t.ReceiveItem(this, "present4");
                            t.RemoveMoney(price); SendReply(t, "Here is your present!");
                        }
                        else if (RandLottery == 5)
                        {
                            t.ReceiveItem(this, "present5");
                            t.RemoveMoney(price); SendReply(t, "Here is your present!");
                        }
                        else if (RandLottery == 6)
                        {
                            t.ReceiveItem(this, "present6");
                            t.RemoveMoney(price); SendReply(t, "Here is your present!");
                        }
                        else if (RandLottery == 7)
                        {
                            t.ReceiveItem(this, "present7");
                            t.RemoveMoney(price); SendReply(t, "Here is your present!");
                        }
                       
                    }
                    else { t.Client.Out.SendMessage("Your on my noughty list, sorry.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
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
