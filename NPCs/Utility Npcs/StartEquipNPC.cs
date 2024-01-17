using System;
using System.Collections;
using System.Timers;

using DOL;
using DOL.AI.Brain;
using DOL.GS;
using DOL.GS.Scripts;
using DOL.GS.GameEvents;
using DOL.GS.PacketHandler;
using DOL.GS.Quests;
using DOL.GS.Spells;
using DOL.GS.Effects;
using DOL.Database;
using DOL.Events;


namespace DOL.GS.Scripts
{

  public class StartEquipNPC : GameNPC
  {
    const byte enable_Weapons = 1;
    const byte enable_Armors = 1;

    public override bool Interact(GamePlayer player)
    {   

      TurnTo(player, 100);
      this.TargetObject = player;

      if (!base.Interact(player)) return false;

      if (enable_Weapons == 1 && enable_Armors == 1)
        if (!player.InCombat)
        {
          player.Out.SendMessage("Hello, I'am the Kings Armory Master.\n" +
            "In order to help you in battle our king is providing free equipment from our \n" +
            "realm armory.  We have [Armor], [Weapons] and [Jewelry] in our storage.\n", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
          return true;
        }
        

        if (enable_Armors != 1)
        {
          player.Out.SendMessage("Hello,\nI'am the Armory Master of our Realm.\n" +
            "In order to help our recruits to join our battle our king started to give equipment from our realm armory to aid you in fight.\n" +
            "Do you need any [Armour] or a [Jewelry] ?.\n", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
          return true;
        }

        if (enable_Weapons != 1)
        {
          player.Out.SendMessage("Hello,\nI'am the Armory Master of our Realm.\n" +
            "In order to help our recruits to join our battle our king started to give equipment from our realm armory to aid you in fight.\n" +
            "Do you need any [Armor and Jewelry] or a [Cloak] ?.\n", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
          return true;
        }
        return false;
    }

    public override bool WhisperReceive(GameLiving player, string str)
    {
      GamePlayer t = (GamePlayer)player;

      switch (str)
      {
        case "Weapons":
          if (enable_Weapons == 1)
          if (t.Realm == eRealm.Albion)
          {
            if (!t.InCombat)
            {

              t.Out.SendMessage("What do you need ?\n" +
              "[2h Crushing Weapon]\n[2h Slashing Weapon]\n[2h Thrusting Weapon]\n[1h Slashing Weapon]\n" +
              "[1h Crushing Weapon]\n[1h Thrusting Weapon]\n[Offhand Sword]\n" +
              "[Offhand Crushing Weapon]\n[Offhand Dagger]\n[Friar Staff]\n" +
              "[Caster Staff]\n[Slash Whip]\n[Crush Whip]\n" +
              "[Small Shield]\n[Medium Shield]\n[Large Shield]\n" +
              "[Polearm Slash]\n[Polearm Thrust]\n[Polearm Crush]\n[Longbow]\n[Instrument]\n[Staff]", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
            }
          }

          if (t.Realm == eRealm.Midgard)
          {
            if (!t.InCombat)
            {
              t.Out.SendMessage("What do you need ?\n" +
              "[1h Axe]\n[1h Sword]\n[1h Hammer]\n"+
              "[Left Axe]\n[2h Axe]\n[2h Sword]\n" +
              "[2h Hammer]\n[Spear]\n[Composite Bow]\n"+
              "[h2h Slash]\n[h2h Thrust]\n[Small Shield]\n[Medium Shield]\n[Large Shield]\n[Staff]", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
            }
          }

          if (t.Realm == eRealm.Hibernia)
          {
            if (!t.InCombat)
            {
              t.Out.SendMessage("What do you need ?\n" +
              "[1h Blade]\n[1h Piercer]\n[1h Blunt]\n"+
              "[Offhand Blade]\n[Offhand Blunt]\n"+
              "[Offhand Piercer]\n[2h Blunt]\n[2h Blade]"+
              "\n[Scythe]\n[Celtic Spear]\n[Small Shield]\n[Medium Shield]\n[Large Shield]\n[Staff]" +
              "\n[Recurve Bow]\n[Harp]", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
            }
          }
          break;
      #region Armour
      case "Armor":
          if (enable_Armors == 1)
          {
              if (t.CharacterClass == CharacterClass.Wizard)
            {
              ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WizardEpicVest");
              ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WizardEpicLegs");
              ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WizardEpicArms");
              ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WizardEpicGloves");
              ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WizardEpicBoots");
              ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
              ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
              ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WizardEpicHelm");


              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
              t.UpdatePlayerStatus();
              SendReply(t, "Here you are !");
            }

            /// Does not exist
            // if (t.CharacterClass == CharacterClass.Priest)
            // {
            //     ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PriestEpicVest");
            //     generic0.CopyFrom(tgeneric0);

            //     ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PriestEpicLegs");
            //     generic1.CopyFrom(tgeneric1);

            //     ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PriestEpicArms");
            //     generic2.CopyFrom(tgeneric2);

            //     ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PriestEpicGloves");
            //     generic3.CopyFrom(tgeneric3);

            //     ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PriestEpicBoots");
            //     generic4.CopyFrom(tgeneric4);

            //     ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PriestCloak");
            //     generic5.CopyFrom(tgeneric5);

            //     ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
            //     generic6.CopyFrom(tgeneric6);

            //     ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PriestEpicHelm");
            //     generic7.CopyFrom(tgeneric7);


            //     t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
            //     t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
            //     t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
            //     t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
            //     t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
            //     t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
            //     t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
            //     t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
            //     t.UpdatePlayerStatus();
            //     SendReply(t, "Here you are !");
            // }

            if (t.CharacterClass == CharacterClass.Minstrel)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Sorcerer)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SorcererEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SorcererEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SorcererEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SorcererEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SorcererEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SorcererEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Cleric)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ClericEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ClericEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ClericEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ClericEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ClericEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ClericEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Paladin)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Mercenary)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryEpicBoots");

                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");

                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryEpicHelm");


                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Reaver)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverEpicVest");

                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverEpicLegs");

                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverEpicArms");

                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverEpicGloves");

                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverEpicBoots");

                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");

                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverEpicHelm");


                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Cabalist)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("CabalistEpicVest");

                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("CabalistEpicLegs");

                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("CabalistEpicArms");

                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("CabalistEpicGloves");

                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("CabalistEpicBoots");

                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");

                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");

                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("CabalistEpicHelm");


                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Necromancer)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NecromancerEpicVest");

                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NecromancerEpicLegs");

                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NecromancerEpicArms");

                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NecromancerEpicGloves");

                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NecromancerEpicBoots");

                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");

                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NecromancerEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Infiltrator)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Scout)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Armsman)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Theurgist)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("TheurgistEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("TheurgistEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("TheurgistEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("TheurgistEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("TheurgistEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("TheurgistEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Heretic)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Friar)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FriarEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FriarEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FriarEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FriarEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FriarEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeStaff");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FriarEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Spiritmaster)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SpiritmasterEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SpiritmasterEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SpiritmasterEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SpiritmasterEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SpiritmasterEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SpiritmasterEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Runemaster)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RunemasterEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RunemasterEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RunemasterEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RunemasterEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RunemasterEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RunemasterEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Bonedancer)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BonedancerEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BonedancerEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BonedancerEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BonedancerEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BonedancerEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BonedancerEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Warlock)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarlockEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarlockEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarlockEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarlockEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarlockEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarlockEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Hunter)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HunterEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HunterEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HunterEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HunterEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HunterEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HunterEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Shadowblade)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShadowbladeEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShadowbladeEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShadowbladeEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShadowbladeEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShadowbladeEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShadowbladeEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Healer)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HealerEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HealerEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HealerEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HealerEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HealerEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HealerEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Shaman)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShamanEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShamanEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShamanEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShamanEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShamanEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ShamanEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Warrior)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarriorEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarriorEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarriorEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarriorEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarriorEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WarriorEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Berserker)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BerserkerEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BerserkerEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BerserkerEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BerserkerEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BerserkerEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BerserkerEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Thane)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThaneEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThaneEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThaneEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThaneEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThaneEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThaneEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Skald)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SkaldEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SkaldEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SkaldEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SkaldEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SkaldEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SkaldEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Savage)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SavageEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SavageEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SavageEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SavageEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SavageEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("SavageEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Valkyrie)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValkyrieEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValkyrieEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValkyrieEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValkyrieEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValkyrieEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValkyrieEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Champion)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Enchanter)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EnchanterEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EnchanterEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EnchanterEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EnchanterEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EnchanterEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EnchanterEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Eldritch)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EldritchEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EldritchEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EldritchEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EldritchEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EldritchEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("EldritchEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Mentalist)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MentalistEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MentalistEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MentalistEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MentalistEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MentalistEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MentalistEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Animist)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnimistEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnimistEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnimistEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnimistEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnimistEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnimistEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

                if (t.CharacterClass == CharacterClass.Champion)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Bard)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BardEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BardEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BardEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BardEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BardEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BardEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }
            if (t.CharacterClass == CharacterClass.Nightshade)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NightshadeEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NightshadeEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NightshadeEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NightshadeEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NightshadeEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NightshadeEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }
            if (t.CharacterClass == CharacterClass.Ranger)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RangerEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RangerEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RangerEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RangerEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RangerEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RangerEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }
            if (t.CharacterClass == CharacterClass.Hero)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HeroEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HeroEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HeroEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HeroEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HeroEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HeroEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }
            if (t.CharacterClass == CharacterClass.Warden)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WardenEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WardenEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WardenEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WardenEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WardenEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("WardenEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }
            if (t.CharacterClass == CharacterClass.Blademaster)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }
            if (t.CharacterClass == CharacterClass.Druid)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DruidEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DruidEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DruidEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DruidEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DruidEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DruidEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Valewalker)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValewalkerEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValewalkerEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValewalkerEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValewalkerEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValewalkerEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ValewalkerEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Bainshee)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BainsheeEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BainsheeEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BainsheeEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BainsheeEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BainsheeEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
                ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BainsheeEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }

            if (t.CharacterClass == CharacterClass.Vampiir)
            {
                ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("VampiirEpicVest");
                ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("VampiirEpicLegs");
                ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("VampiirEpicArms");
                ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("VampiirEpicGloves");
                ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("VampiirEpicBoots");
                ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
                ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("VampiirEpicHelm");

                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));
                t.UpdatePlayerStatus();
                SendReply(t, "Here you are !");
            }
          } 
          break;


        case "Jewelry":
            if (t.Realm != eRealm.None)
          {
            ItemTemplate tgeneric45 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeJewel1");
            ItemTemplate tgeneric46 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeBracer1");
            ItemTemplate tgeneric47 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeRing1");

            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric45));
            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric46));
            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric47));
            t.UpdatePlayerStatus();
            SendReply(t, "Here you are !");
          }
          break;
      #endregion
      case "2h Crushing Weapon":
            if (t.Realm == eRealm.Albion)
            {
              ItemTemplate tgeneric8 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbCrush2h");
              t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric8));
              t.UpdatePlayerStatus();              
            }
           break;

         case "2h Slashing Weapon":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric9 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbSlash2h");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric9));
             t.UpdatePlayerStatus();
           }
           break;

         case "2h Thrusting Weapon":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric10 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbThrust2H");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric10));
             t.UpdatePlayerStatus();
           }
           break;

         case "1h Slashing Weapon":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric11 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbSlash");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric11));
             t.UpdatePlayerStatus();
           }
           break;

         case "1h Crushing Weapon":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric12 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbCrush");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric12));
             t.UpdatePlayerStatus();
           }
           break;

         case "1h Thrusting Weapon":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric13 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbThrust");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric13));
             t.UpdatePlayerStatus();
           }
           break;

         case "Offhand Sword":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric14 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbSlash");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric14));
             t.UpdatePlayerStatus();
           }
           break;

         case "Offhand Crushing Weapon":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric15 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbCrush");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric15));
             t.UpdatePlayerStatus();
           }
           break;

         case "Offhand Dagger":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric16 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbThrust");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric16));
             t.UpdatePlayerStatus();
           }
           break;

         case "Friar Staff":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric17 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeStaff");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric17));
             t.UpdatePlayerStatus();
           }
           break;

         case "Caster Staff":
             ItemTemplate tgeneric18 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric18));
             t.UpdatePlayerStatus();
           break;

         case "Slash Whip":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric19 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbFlexSlash");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric19));
             t.UpdatePlayerStatus();
           }
           break;

         case "Crush Whip":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric20 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbFlexCrush");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric20));
             t.UpdatePlayerStatus();
           }
           break;

         case "Bow":
             ItemTemplate tgeneric21 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeBow");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric21));
             t.UpdatePlayerStatus();
           break;

         case "Small Shield":
             ItemTemplate tgeneric22 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeSmallShield");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric22));
             t.UpdatePlayerStatus();
         break;

         case "Medium Shield":
           ItemTemplate tgeneric23 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMediumShield");
           t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric23));
           t.UpdatePlayerStatus();
         break;

         case "Large Shield":
           ItemTemplate tgeneric24 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeLargeShield");
           t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric24));
           t.UpdatePlayerStatus();
         break;

     case "Polearm Crush":
         ItemTemplate tgeneric25 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbCrushPolearm");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric25));
         t.UpdatePlayerStatus();
         break;

         case "Polearm Slash":
           if (t.Realm == eRealm.Albion)
           {
             ItemTemplate tgeneric26 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbSlashPolearm");
             t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric26));
             t.UpdatePlayerStatus();
           }
         break;

         case "Polearm Thrust":
         if (t.Realm == eRealm.Albion)
         {
           ItemTemplate tgeneric27 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeAlbThrustPolearm");
           t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric27));
           t.UpdatePlayerStatus();
         }
         break;

         case "Instrument":
         if (t.Realm == eRealm.Albion)
         {
           ItemTemplate tgeneric28 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("freeharp");
           t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric28));
           t.UpdatePlayerStatus();
         }
         break;

       case "Longbow":
         if (t.Realm == eRealm.Albion)
         {
           ItemTemplate tgeneric30 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeBowa");
           t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric30));
           t.UpdatePlayerStatus();
         }
         break;       

       case "1h Axe":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric42 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidAxe");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric42));
         t.UpdatePlayerStatus();
       }
       break;

     case "1h Sword":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric43 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidSlash");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric43));
         t.UpdatePlayerStatus();
       }
       break;

     case "1h Hammer":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric44 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidCrush");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric44));
         t.UpdatePlayerStatus();
       }
       break;

     case "Left Axe":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric44 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidAxe");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric44));
         t.UpdatePlayerStatus();
       }
       break;

     case "2h Axe":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric44 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidAxe2H");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric44));
         t.UpdatePlayerStatus();
       }
       break;

     case "2h Hammer":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric44 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidCrush2H");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric44));
         t.UpdatePlayerStatus();
       }
       break;

     case "2h Sword":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric44 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidSlash2H");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric44));
         t.UpdatePlayerStatus();
       }
       break;

     case "Spear":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric45 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidSpearSlash");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric45));
         t.UpdatePlayerStatus();
       }
       break;

     case "Composite Bow":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric46 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeBowm");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric46));
         t.UpdatePlayerStatus();
       }
       break;

     case "h2h Slash":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric47 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidH2HSlash");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric47));
         t.UpdatePlayerStatus();
       }
       break;

     case "h2h Thrust":
       if (t.Realm == eRealm.Midgard)
       {
         ItemTemplate tgeneric48 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeMidH2HThrust");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric48));
         t.UpdatePlayerStatus();
       }
       break;

     case "1h Blade":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric31 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibSlash");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric31));
         t.UpdatePlayerStatus();
       }
       break;

     case "1h Piercer":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric32 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibThrust");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric32));
         t.UpdatePlayerStatus();
       }
       break;

     case "1h Blunt":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric33 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibCrush");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric33));
         t.UpdatePlayerStatus();
       }
       break;

     case "Offhand Blade":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric34 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibSlash");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric34));
         t.UpdatePlayerStatus();
       }
       break;

     case "Offhand Blunt":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric35 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibCrush");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric35));
         t.UpdatePlayerStatus();
       }
       break;

     case "Offhand Piercer":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric36 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibThrust");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric36));
         t.UpdatePlayerStatus();
       }
       break;

     case "2h Blunt":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric37 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibCrush2H");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric37));
         t.UpdatePlayerStatus();
       }
       break;

     case "2h Blade":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric38 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibSlash2H");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric38));
         t.UpdatePlayerStatus();
       }
       break;

     case "Scythe":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric39 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibScythe");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric39));
         t.UpdatePlayerStatus();
       }
       break;

     case "Celtic Spear":
       if (t.Realm == eRealm.Hibernia)
       {
         ItemTemplate tgeneric40 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeHibSpearThrust");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric40));
         t.UpdatePlayerStatus();
       }
       break;

     case "Recurve Bow":
         ItemTemplate tgeneric41 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeBowh");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric41));
         t.UpdatePlayerStatus();
       break;

     case "Harp":
       if (t.Realm != eRealm.None)
       {
         ItemTemplate tgeneric42 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("freeharp");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric42));
         t.UpdatePlayerStatus();
       }
       break;

     case "Staff":
       if (t.Realm != eRealm.None)
       {
         ItemTemplate tgeneric43 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("starter_staff_caster");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric43));
         t.UpdatePlayerStatus();
       }
       break;

     case "Cloak":
       if (t.Realm != eRealm.None)
       {
         ItemTemplate tgeneric44 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FreeCloak");
         t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric44));
         t.UpdatePlayerStatus();
       }
       break;

        }
        return true;
      }
  
  
   private void SendReply(GamePlayer target, string msg)
    {
      target.Out.SendMessage(msg, eChatType.CT_System, eChatLoc.CL_PopupWindow);
    }
  }
}

