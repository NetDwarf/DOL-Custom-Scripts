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

    public class ChampionNPC : GameNPC
    {
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
        public override bool Interact(GamePlayer player)
        {

            TurnTo(player, 100);
            this.TargetObject = player;

            if (!base.Interact(player)) return false;
            if (player.ChampionLevel >= 5)
            {
                player.Out.SendMessage("Hello, I'am the Kings Armsmaster.\n" +
                  "I have [Weapons] if you are truely worthy!\n", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
                return true;
            }
            if (player.ChampionLevel <= 4)
                 player.Out.SendMessage("Hello, I'am the Kings Armsmaster.\n" +
                "Reach Champion level 5 and I shall grant you a reward, you are currently Champion Level" + player.ChampionLevel + " !", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
             return true;
        }

        public override bool WhisperReceive(GameLiving player, string str)
        {
            GamePlayer t = (GamePlayer)player;

            switch (str)
            {
                #region Albion Champion Weapons

                case "Weapons":
                    {
                        if (t.CharacterClass.Equals(CharacterClass.Wizard) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("UpsilonWizardStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Sorcerer) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("UpsilonSorcererStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Cabalist) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("UpsilonCabalistStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Theurgist) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("UpsilonTheurgistStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }
                        if (t.CharacterClass.Equals(CharacterClass.Necromancer) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("UpsilonNecromancerStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }
                        if (t.CharacterClass.Equals(CharacterClass.Armsman) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanDexteraBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanDexteraEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanDexteraMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanSatagoArchMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanSatagoFlamberge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanSatagoHalberd");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));

                            ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanSatagoLance");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));

                            ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanSatagoMattock");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));

                            ItemTemplate tgeneric8 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ArmsmanSatagoPike");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric8));

                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Cleric) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ClericDexteraMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Friar) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FriarDexteraMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("FriarSatagoQuarterStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Heretic) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticDexteraBarbedChain");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticDexteraFlail");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("HereticDexteraMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Infiltrator) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorDexteraBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorDexteraEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorLaevusBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("InfiltratorLaevusEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Mercenary) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryDexteraBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryDexteraEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryDexteraMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryLaevusBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryLaevusEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MercenaryLaevusMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));

                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Minstrel) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelDexteraBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelDexteraEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("MinstrelDexteraHarp");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Paladin) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinDexteraBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinDexteraEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinDexteraMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinSatagoGreatEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinSatagoGreatHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("PaladinSatagoGreatSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Reaver) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverDexteraBarbedChain");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverDexteraBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverDexteraEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverDexteraFlail");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ReaverDexteraMace");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Scout) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutDexteraBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutDexteraBow");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ScoutDexteraEdge");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }
                #endregion Albion Champion Weapons

                #region Midgard Champion Weapons

                        if (t.CharacterClass.Equals(CharacterClass.Bonedancer) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnsuzBonedancerStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Runemaster) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnsuzRunemasterStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }
                        if (t.CharacterClass.Equals(CharacterClass.Spiritmaster) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnsuzSpiritmasterStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Warlock) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("AnsuzWarlockStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Warrior) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazWarriorAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazWarriorHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazWarriorSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazWarriorTwohandedAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazWarriorTwohandedHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazWarriorTwohandedSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Valkyrie) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazValkyrieSlashingSpear");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazValkyrieSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazValkyrieThrustingSpear");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazValkyrieTwohandedSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Healer) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazHealerTwohandedHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazHealerHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Shaman) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazShamanHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazShamanTwohandedHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Hunter) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazCompoundBow");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazHunterSlashingSpear");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazHunterSpear");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazHunterSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazHunterTwohandedSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Savage) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageSlashingGlaiverh");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageSlashingGlaivelh");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageThrashingGlaiverh");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));

                            ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageThrashingGlaivelh");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));

                            ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageTwohandedAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));

                            ItemTemplate tgeneric8 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageTwohandedHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric8));

                            ItemTemplate tgeneric9 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSavageTwohandedSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric9));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Shadowblade) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazShadowbladeAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazShadowbladeHeavyAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazShadowbladeHeavyAxe2");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazShadowbladeHeavySword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazShadowbladeSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Skald) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSkaldAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSkaldHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSkaldSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSkaldTwohandedAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSkaldTwohandedHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazSkaldTwohandedSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Thane) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazThaneAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazThaneHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazThaneSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazThaneTwohandedAxe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazThaneTwohandedHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ThurisazThaneTwohandedSword");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }
                        #endregion Midgard Champion Weapons

                #region Hibernia Champion Weapons

                        if (t.CharacterClass.Equals(CharacterClass.Animist) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DraiochtAnimistStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Bainshee) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DraiochtBainsheeStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Eldritch) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DraiochtEldritchStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Enchanter) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DraiochtEnchanterStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Mentalist) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DraiochtMentalistStaff");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Valewalker) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharValewalkerScythe");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Vampiir) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("VampiirFuarSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Bard) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BardDocharHarp");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharBardBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharBardHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Druid) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharDruidBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharDruidHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Warden) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharWardenBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharWardenHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Blademaster) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharBlademasterBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharBlademasterHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharBlademasterSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterFuarBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterFuarHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("BlademasterFuarSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Champion) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharChampionBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharChampionHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharChampionSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharChampionWarblade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharChampionWarhammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Hero) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharHeroBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharHeroHammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharHeroSpear");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharHeroSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharHeroWarblade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                            ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharHeroWarhammer");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Nightshade) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharNightshadeBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharNightshadeSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NightshadeFuarBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("NightshadeFuarSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }

                        if (t.CharacterClass.Equals(CharacterClass.Ranger) && t.ChampionLevel >= 5)
                        {
                            ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RangerFuarBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                            ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("RangerFuarSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                            ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharRangerBlade");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                            ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharRangerSteel");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                            ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("DocharRecurveBow");
                            t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));
                            t.UpdatePlayerStatus();
                            t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                        }
                    }
                    break;
                        #endregion Hibernia Champion Weapons

                #region Champion Jewelry

                case "Jewelry":
                    {
                        ItemTemplate tgeneric0 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionCloak");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric0));

                        ItemTemplate tgeneric1 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionNecklace");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric1));

                        ItemTemplate tgeneric2 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionBelt");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric2));

                        ItemTemplate tgeneric3 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionJewel");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric3));

                        ItemTemplate tgeneric4 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionRing");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric4));

                        ItemTemplate tgeneric5 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionBand");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric5));

                        ItemTemplate tgeneric6 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionBracer");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric6));

                        ItemTemplate tgeneric7 = (ItemTemplate)GameServer.Database.FindObjectByKey<ItemTemplate>("ChampionWristBand");
                        t.Inventory.AddItem(eInventorySlot.FirstEmptyBackpack, GameInventoryItem.Create(tgeneric7));
                        t.UpdatePlayerStatus();
                        t.Out.SendMessage("Here you are!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
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
                #endregion Champion Jewelry  