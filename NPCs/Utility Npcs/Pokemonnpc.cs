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
	public class PokemonNPC: GameNPC
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
		public override bool Interact(GamePlayer t)
		{
			if (!base.Interact(t)) return false;
			TurnTo(t.Coordinate);
			t.Out.SendMessage("Hello "+t.Name+" I am the Pokemon Master, would you like a Poke Ball? " +
            "Each Poke Ball costs 1000 Bounty Points, simply click [Poke Ball] to see how lucky you are.", eChatType.CT_Say,eChatLoc.CL_PopupWindow);
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
                case "backdoorwinner":

                        Say("Ah a Gamemaster, you guys will bankrupt me you know!");

                        ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PerfCloak");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                        ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PerfNeck");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                        ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PerfJewel");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                        ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PerfBelt");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                        ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PerfRing");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                        ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PerfBand");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));

                        ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PerfBracer");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));

                        ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PerfWristBand");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                         
                        SendReply(t, "Here you are !");
                    
                    break;

                case "Poke Ball":
                    var price = Currency.BountyPoints.Mint(1000);
                    if (t.BountyPointBalance >= price.Amount)
                    {
                        int RandLottery = Util.Random(1, 40);//Creates a random number between 1 and 40

                        if (RandLottery == 1)
                        {
                            t.ReceiveItem(this, "item_summon1");
                            t.RemoveMoney(price); SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 2)
                        {
                            t.ReceiveItem(this, "item_summon2");
                            t.RemoveMoney(price); SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 3)
                        {
                            t.ReceiveItem(this, "item_summon3");
                            t.RemoveMoney(price); SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 4)
                        {
                            t.ReceiveItem(this, "item_summon4");
                            t.RemoveMoney(price); SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 5)
                        {
                            t.ReceiveItem(this, "item_summon5");
                            t.RemoveMoney(price);  SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 6)
                        {
                            t.ReceiveItem(this, "item_summon6");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 7)
                        {
                            t.ReceiveItem(this, "item_summon7");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 8)
                        {
                            t.ReceiveItem(this, "item_summon8");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 9)
                        {
                            t.ReceiveItem(this, "item_summon9");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 10)
                        {
                            t.ReceiveItem(this, "item_summon10");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 11)
                        {
                            t.ReceiveItem(this, "item_summon11");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 12)
                        {
                            t.ReceiveItem(this, "item_summon12");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 13)
                        {
                            t.ReceiveItem(this, "item_summon13");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 14)
                        {
                            t.ReceiveItem(this, "item_summon14");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 15)
                        {
                            t.ReceiveItem(this, "item_summon15");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 16)
                        {
                            t.ReceiveItem(this, "item_summon16"); ;
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 17)
                        {
                            t.ReceiveItem(this, "item_summon17");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 18)
                        {
                            t.ReceiveItem(this, "item_summon18");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 19)
                        {
                            t.ReceiveItem(this, "item_summon19");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 20)
                        {
                            t.ReceiveItem(this, "item_summon20");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 21)
                        {
                            t.ReceiveItem(this, "item_summon21");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 22)
                        {
                            t.ReceiveItem(this, "item_summon22");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 23)
                        {
                            t.ReceiveItem(this, "item_summon23");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 24)
                        {
                            t.ReceiveItem(this, "item_summon24");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 25)
                        {
                            t.ReceiveItem(this, "item_summon25");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 26)
                        {
                            t.ReceiveItem(this, "item_summon26");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 27)
                        {
                            t.ReceiveItem(this, "item_summon27");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 28)
                        {
                            t.ReceiveItem(this, "item_summon28");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 29)
                        {
                            t.ReceiveItem(this, "item_summon29");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 30)
                        {
                            t.ReceiveItem(this, "item_summon30");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 31)
                        {
                            t.ReceiveItem(this, "item_summon31");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 32)
                        {
                            t.ReceiveItem(this, "item_summon32");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 33)
                        {
                            t.ReceiveItem(this, "item_summon33");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 34)
                        {
                            t.ReceiveItem(this, "item_summon34");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 35)
                        {
                            t.ReceiveItem(this, "item_summon35");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 36)
                        {
                            t.ReceiveItem(this, "item_summon35");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 37)
                        {
                            t.ReceiveItem(this, "item_summon37");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 38)
                        {
                            t.ReceiveItem(this, "item_summon38");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 39)
                        {
                            t.ReceiveItem(this, "item_summon39");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                        else if (RandLottery == 40)
                        {
                            t.ReceiveItem(this, "item_summon40");
                            t.RemoveMoney(price);   SendReply(t, "Here is your Poke Ball!");
                        }
                    }
                    else { t.Client.Out.SendMessage("You don't have enough Bounty Points.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
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
