using DOL.GS.Geometry;
using DOL.GS.PacketHandler;
/* Need to fix
 * EquipTemplate for Hib and Mid
 * Oceanus for all realms.
 * Kobold Undercity for Mid
 * personal guild and hearth teleports
 */

namespace DOL.GS.Scripts
{
    public class LiveTeleporter : GameNPC
    {
        public override bool AddToWorld()
        {
            switch (Realm)
            {
                case eRealm.Albion:
                    Name = "Channeler Deng'ani";
                    GuildName = "Teleporter";
                    Model = 760;
                    break;
                case eRealm.Midgard:
                    Name = "Channeler Sidral";
                    GuildName = "Teleporter";
                    Model = 184;
                    break;
                case eRealm.Hibernia:
                    Name = "Channeler Garl";
                    GuildName = "Teleporter";
                    Model = 1152;
                    break;
                default:
                    break;
            }
                    Level = 75;
                    Size = 50;
            //Fix Templates Alb is this below mid and hib are different

                    GameNpcInventoryTemplate template = new GameNpcInventoryTemplate(); // This line creates a new Template for this npc, so now we can add items for him to wear.
                    /// Add equipment to the teleporter.
                    template.AddNPCEquipment(eInventorySlot.Cloak, 57, 66);
                    template.AddNPCEquipment(eInventorySlot.TorsoArmor, 1005, 86);
                    template.AddNPCEquipment(eInventorySlot.LegsArmor, 140, 6);
                    template.AddNPCEquipment(eInventorySlot.ArmsArmor, 141, 6);
                    template.AddNPCEquipment(eInventorySlot.HandsArmor, 142, 6);
                    template.AddNPCEquipment(eInventorySlot.FeetArmor, 143, 6);
                    template.AddNPCEquipment(eInventorySlot.TwoHandWeapon, 1166);
                    /// How to pick items not explained in this document.
                    Inventory = template.CloseTemplate(); // Close the template after hes dressed
                    SwitchWeapon(GameLiving.eActiveWeaponSlot.TwoHanded); // Pick his active weapon to show as equiped
            return base.AddToWorld(); // Finish up and add him to the world.
        }

        public override bool Interact(GamePlayer player) // What to do when a player clicks on me
        {
            if (!base.Interact(player)) return false;
            switch (Realm)
            {
                case eRealm.Albion:
                    SayTo(player, "Greetings, I am able to channel energy to transport you to distant lands. I can send you to the following locations:\n" +
                                    "[Forest Sauvage] in the Frontiers\n" +
                                    "[Castle Sauvage] in Camelot Hills\n" +
                                    "[Snowdonia Fortress] in Black Mtns. North\n" +
                                    "[Avalon Marsh] wharf\n" +
                                    "[Gothwaite Harbor] in the [Shrouded Isles]\n" +
                                    "[Oceanus] haven in the lost lands of Atlantis\n" +
                                    "[The Inconnu Crypt] in the Catacombs\n" +
                                    "[Camelot] our glorious capital\n" +
                                    "[Entrance] to the areas of [Housing]\n" +
                                    "A [Battleground] appropriate to your season\n\n" +
                                    "Or one of the many [towns] throughout Albion");
                    if (player.Level < 15) // Add server rule check for tutorial
                    {
                        SayTo(player, "You are also eligible for passage to [Holtham] in Constantine's Sound.");
                    }
                    else
                    {
                        // Add Check for Svarhamr
                        SayTo(player, "In addition to the other locations to which you may travel, you are eligible to teleport to the [NEEDALB], the Svartalf village in Malmohus.");
                    }
                    break;

                case eRealm.Midgard:
                    SayTo(player, "Greetings, I am able to channel energy to transport you to distant lands. I can send you to the following locations:\n" +
                                    "[Uppland] in the Frontiers\n" +
                                    "[Svasud Faste] in Mularn\n" +
                                    "[Vindsaul Faste] in West Svealand\n" +
                                    "Beaches of [Gotar] near Nailiten\n" +
                                    "[Aegirhamn] in the [Shrouded Isles]\n" +
                                    "[Oceanus] Haven in the lost land of Atlantis\n" +
                                    "[Kobold Undercity] in the Catacombs\n" +
                                    "Our glorious city of [Jordheim]\n" +
                                    "[Entrance] to the areas of [Housing]\n" +
                                    "A [Battleground] appropriate to your season\n\n" +
                                    "Or one of the many [towns] throughout Midgard");
                    if (player.Level < 15) // Add server rule check for tutorial
                    {
                        SayTo(player, "You are also eligible for passage to [Hafheim] in Grenlock's Sound.");
                    }
                    else
                    {
                        // Add Check for Svarhamr
                        SayTo(player, "In addition to the other locations to which you may travel, you are eligible to teleport to the [Svarhamr], the Svartalf village in Malmohus.");
                    }
                    break;

                case eRealm.Hibernia:
                    SayTo(player, "Greetings, I am able to channel energy to transport you to distant lands. I can send you to the following locations:\n" +
                                    "[Cruachan Gorge] in the Frontiers\n" +
                                    "[Druim Ligen] in Connacht or [Druim Cain] in Bri Leith\n" +
                                    "[Shannon Estuary] watchtower\n" +
                                    "[Domnann] Grove in the [Shrouded Isles]\n" +
                                    "[Oceanus] heaven in the lost land of Atlantis\n" +
                                    "[Shar Labyrinth] in the Catacombs\n" +
                                    "[Tir na Nog] our glorious capital\n" +
                                    "[Entrance] to the areas of [Housing]\n" +
                                    "A [Battleground] appropriate to your season\n\n" +
                                    "Or one of the many [towns] throughout Hibernia");
                    if (player.Level < 15) // Add server rule check for tutorial
                    {
                        SayTo(player, "You are also eligible for passage to [Fintain] in Lamfhota's Sound.");
                    }
                    else
                    {
                        // Add Check for Azure refuge
                        SayTo(player,"In adition to the other locations to which you may travel, you are eligible to teleport to the Azure refuge [Tailtiu] in Sheeroe Hills.");
                    }
                    break;

                default:
                    SayTo(player, "I have no Realm set, so don't know what locations to offer..");
                    break;
            }
            return true;
        }

        public override bool WhisperReceive(GameLiving source, string str) // What to do when a player whispers me
        {
            if (!base.WhisperReceive(source, str)) return false;
            if (!(source is GamePlayer)) return false;
            GamePlayer t = (GamePlayer)source;
            TurnTo(t.Coordinate); // Turn to face the player
            // This is where we handle what is said to the NPC, we do it by using case switches.
            // it follows this format
            // switch(str){
            // case "talks":
            //       break;
            switch (Realm) // Only offer locations based on what realm i am set at.
            {
                case eRealm.Albion:
                    switch (str.ToLower())
                    {
                        //Begin Main
                        case "forest sauvage":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Forest Sauvage");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 163, x: 652700, y: 617189, z: 9560, heading: 2815));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "castle sauvage":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Castle Sauvage");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 583913, y: 487012, z: 2184, heading: 2048));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "snowdonia fortress":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Snowdonia Fortress");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 516801, y: 373238, z: 8208, heading: 1784));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "avalon marsh":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Avalon Marsh");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 462144, y: 633058, z: 1739, heading: 1769));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "gothwaite harbor":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Gothwaite Harbor.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 51, x: 526580, y: 542058, z: 3168, heading: 406));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "shrouded isles":
                            SayTo(t, "The isles of Avalon are  an excellent choice. Would you prefer the harbor of [Gothwaite] or perhaps one of the outlying towns like [Wearyall] Village, Fort [Gwyntell], or Cear [Diogel]?");
                            break;

                            // Add
                        case "oceanus":
                            if (ServerProperties.Properties.ATLANTIS_TELEPORT_PLVL > 1 && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player)
                            {
                                SayTo(t, "Atlantis Zones are disabled.");
                            }
                            else
                            {
                                SayTo(t, "Oceanus is not availible at the momment.");
                            }
                            break;
                            //End add

                        case "the inconnu crypt":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to The Iconnu Crypt.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 65, x: 33199, y: 37978, z: 16150, heading: 2097));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "camelot":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Camelot");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 10, x: 36209, y: 29843, z: 7971, heading: 18));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "housing":
                            SayTo(t, "I can send you to your [personal] house. If you do not have a personal house or wish to be sent to the housing [entrance] then you will arrive just inside the housing area. I can also send you to your [guild] house. If your guild does not own a house then you will not be transported. You may go to your [Hearth] bind as well if you are bound inside a house");
                            break;
                        case "battleground":
                            if (!ServerProperties.Properties.BG_ZONES_OPENED && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player)
                            {
                                SayTo(t, ServerProperties.Properties.BG_ZONES_CLOSED_MESSAGE);
                            }
                            else
                            {
                                if (!t.InCombat)
                                {
                                    Say("I will send you to the appropriate Battleground for your level, Good Luck.");
                                    foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                        player.Out.SendSpellCastAnimation(this, 4953, 6);
                                    if (t.Level < 5)
                                    {
                                        // Move to The Proving Grounds area 234
                                        // Need to check realm rank
                                        t.MoveTo(Position.Create(regionID: 234, x: 573154, y: 549877, z: 8640, heading: 1389));
                                    }

                                    if (t.Level > 4 && t.Level < 10)
                                    {
                                        // Move to the Lions Den area 235
                                        t.MoveTo(Position.Create(regionID: 235, x: 536907, y: 535991, z: 5056, heading: 3965));
                                    }

                                    if (t.Level > 9 && t.Level < 15)
                                    {
                                        // Move to the Hills of Claret area 236
                                        t.MoveTo(Position.Create(regionID: 236, x: 541032, y: 577287, z: 8008, heading: 3083));
                                    }

                                    if (t.Level > 14 && t.Level < 20)
                                    {
                                        // Move to Killaloe area 237
                                        t.MoveTo(Position.Create(regionID: 237, x: 544935, y: 582399, z: 8288, heading: 2632));
                                    }

                                    if (t.Level > 19 && t.Level < 25)
                                    {
                                        // Move to Thidranki area 238
                                        t.MoveTo(Position.Create(regionID: 238, x: 562805, y: 574005, z: 5408, heading: 2796));
                                    }

                                    if (t.Level > 24 && t.Level < 30)
                                    {
                                        // Move to Breamear area 239
                                        t.MoveTo(Position.Create(regionID: 239, x: 553703, y: 584974, z: 6952, heading: 2619));
                                    }

                                    if (t.Level > 29 && t.Level < 35)
                                    {
                                        // Move to Wilton are 240
                                        t.MoveTo(Position.Create(regionID: 240, x: 553692, y: 583983, z: 6952, heading: 2632));
                                    }

                                    if (t.Level > 34 && t.Level < 40)
                                    {
                                        // Move to Molvik area 241
                                        t.MoveTo(Position.Create(regionID: 241, x: 531997, y: 541272, z: 5992, heading: 4031));
                                    }

                                    if (t.Level > 39 && t.Level < 45)
                                    {
                                        // Move to Leirvik area 242
                                        t.MoveTo(Position.Create(regionID: 242, x: 322174, y: 284521, z: 10128, heading: 1283));
                                    }

                                    if (t.Level > 44 && t.Level < 50)
                                    {
                                        // Move to Cathal Valley area 165
                                        t.MoveTo(Position.Create(regionID: 165, x: 583347, y: 585349, z: 4896, heading: 2330));
                                    }
                                    if (t.Level > 49)
                                    {
                                        // Tell them oops
                                        Say("Those who have reached their 50th season use the Frontiers as their Battlegrounds.");
                                    }
                                    // Nothing else to check for

                                }
                                else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                                break;
                            }
                             break;
                        case "towns":
                             SayTo(t, "I can send you to:\n" +
                                        "[Cotswold] (Levels 10-14)\n" +
                                        "[Prydwen Keep] (Levels 15-19)\n" +
                                        "[Cear Ulfwych] (Levels 20-24)\n" +
                                        "[Campacorentin Station] (Levels 25-29)\n" +
                                        "[Adribard's Retreat] (Levels 30-34)\n" +
                                        "[Snowdonia] (Levels 35+)");
                            break;
                            //End Main
                            //Begin SI
                        case "gothwaite":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Gothwaite");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 51, x: 535512, y: 547448, z: 4800, heading: 82));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "wearyall":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Wearyall Village");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 51, x: 435140, y: 493260, z: 3088, heading: 921));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "gwyntell":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Fort Gwyntell");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 51, x: 427322, y: 416538, z: 5712, heading: 689));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "diogel":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Cear Diogel.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 51, x: 403525, y: 502582, z: 4680, heading: 561));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "entrance":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Housing.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 2, x: 584461, y: 561355, z: 3576, heading: 2256));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                            //End Si
                            //Begin Towns
                        case "cotswold":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Cotswold.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 559613, y: 511843, z: 2289, heading: 3200));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "prydwen keep":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Prydwen Keep");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 573994, y: 529009, z: 2870, heading: 2206));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "cear ulfwych":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Cear Ulfwych.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 522479, y: 615826, z: 1818, heading: 4));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "campacorentin station":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Campacorentin Station.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 493010, y: 591806, z: 1806, heading: 3881));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "adribard's retreat":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Adribard's Retreat.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 473036, y: 628049, z: 2048, heading: 3142));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "snowdonia":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Snowdonia Keep.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 6);
                                t.MoveTo(Position.Create(regionID: 1, x: 516801, y: 373238, z: 8208, heading: 1784));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                            //End Towns
                            // Only offer tutorial if player is under 15 and its enabled, must add this otherwise player can /whisper the npc
                            // And be teleported even if they dont meet the level requirements.
                        case "holtham":
                            if (ServerProperties.Properties.DISABLE_TUTORIAL && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player && t.Level <15)
                            {
                                SayTo(t, "The Tutorial is disabled.");
                            }
                            else
                            {
                                if (!t.InCombat)
                                {
                                    Say("I'm now teleporting you to Holtham.");
                                    foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                        player.Out.SendSpellCastAnimation(this, 4953, 6);
                                    t.MoveTo(Position.Create(regionID: 27, x: 97636, y: 91606, z: 5696, heading: 4025));
                                }
                                else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            }
                            break;
                        // Stonecrush Dragonsworn place for alb, put check in like for tutorial, but dont know what to check for yet, so just open it.
                        case "stonecrush":
                            if (t.Level < 100) // and a && check for the players flag for this, must complete a quest.
                            {
                                SayTo(t, "Stonecrush. - Not in DB att.");
                            }
                            break;
                        default:
                            // Clicked nothing
                            break;
                    }
                    break;
                case eRealm.Midgard:
                    switch (str.ToLower())
                    {
                        case "uppland":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Uppland");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 163, x: 597472, y: 304485, z: 8088, heading: 4084));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "svasud faste":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Svasud Faste");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 100, x: 766145, y: 673323, z: 5736, heading: 829));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "vindsaul faste":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Vindsaul Faste");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 100, x: 704404, y: 738841, z: 5704, heading: 817));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "gotar":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Gotar");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 100, x: 771081, y: 836721, z: 4624, heading: 167));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "shrouded isles":
                            SayTo(t, "The isles of Aegir are an excellent choice. Would you prefer the city of [Aegirhamn] or perhaps one of the outlying towns like [Bjarken], [Hagall], or [Knarr]?");
                            break;
                        case "oceanus":
                            if (ServerProperties.Properties.ATLANTIS_TELEPORT_PLVL > 1 && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player)
                            {
                                SayTo(t, "Atlantis Zones are disabled.");
                            }
                            else
                            {
                                SayTo(t, "Oceanus not availible at this time.");
                            }
                            break;
                        case "kobold undercity":
                            SayTo(t, "Kobold Undercity not availible at this thime..");
                            break;
                        case "jordheim":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Jordheim");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 101, x: 31619, y: 28768, z: 8800, heading: 2201));
                                //MoveTo(regionid, x , y, z, heading)
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "housing":
                            SayTo(t, "I can send you to your [personal] house. If you do not have a personal house or wish to be sent to the housing [entrance] then you will arrive just inside the housing area. I can also send you to your [guild] house. If your guild does not own a house then you will not be transported. You may go to your [Hearth] bind as well if you are bound inside a house");
                            break;
                        case "battleground":
                            if (!ServerProperties.Properties.BG_ZONES_OPENED && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player)
                            {
                                SayTo(t, ServerProperties.Properties.BG_ZONES_CLOSED_MESSAGE);
                            }
                            else
                            {
                                if (!t.InCombat)
                                {
                                    Say("I will send you to the appropriate Battleground for your level, Good Luck.");
                                    foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                        player.Out.SendSpellCastAnimation(this, 4953, 6);
                                    if (t.Level < 5)
                                    {
                                        // Move to The Proving Grounds area 234
                                        // Need to check realm rank
                                        t.MoveTo(Position.Create(regionID: 234, x: 556216, y: 574739, z: 8640, heading: 2761));
                                    }

                                    if (t.Level > 4 && t.Level < 10)
                                    {
                                        // Move to the Lions Den area 235
                                        t.MoveTo(Position.Create(regionID: 235, x: 543729, y: 575471, z: 50556, heading: 2965));
                                    }

                                    if (t.Level > 9 && t.Level < 15)
                                    {
                                        // Move to the Hills of Claret area 236
                                        t.MoveTo(Position.Create(regionID: 236, x: 582679, y: 554408, z: 8008, heading: 1654));
                                    }

                                    if (t.Level > 14 && t.Level < 20)
                                    {
                                        // Move to Killaloe area 237
                                        t.MoveTo(Position.Create(regionID: 237, x: 585970, y: 559111, z: 8288, heading: 835));
                                    }

                                    if (t.Level > 19 && t.Level < 25)
                                    {
                                        // Move to Thidranki area 238
                                        t.MoveTo(Position.Create(regionID: 238, x: 570913, y: 540584, z: 5408, heading: 478));
                                    }

                                    if (t.Level > 24 && t.Level < 30)
                                    {
                                        // Move to Breamear area 239
                                        t.MoveTo(Position.Create(regionID: 239, x: 582186, y: 539260, z: 6776, heading: 1431));
                                    }

                                    if (t.Level > 29 && t.Level < 35)
                                    {
                                        // Move to Wilton are 240
                                        t.MoveTo(Position.Create(regionID: 240, x: 534127, y: 534463, z: 6728, heading: 3945));
                                    }

                                    if (t.Level > 34 && t.Level < 40)
                                    {
                                        // Move to Molvik area 241
                                        t.MoveTo(Position.Create(regionID: 241, x: 549468, y: 577418, z: 5992, heading: 2552));
                                    }

                                    if (t.Level > 39 && t.Level < 45)
                                    {
                                        // Move to Leirvik area 242
                                        t.MoveTo(Position.Create(regionID: 242, x: 272810, y: 272742, z: 10128, heading: 360));
                                    }

                                    if (t.Level > 44 && t.Level < 50)
                                    {
                                        // Move to Cathal Valley area 165
                                        t.MoveTo(Position.Create(regionID: 165, x: 575260, y: 538161, z: 4832, heading: 1134));
                                    }
                                    if (t.Level > 49)
                                    {
                                        // Tell them oops
                                        Say("Those who have reached their 50th season use the Frontiers as their Battlegrounds.");
                                    }
                                    // Nothing else to check for

                                }
                                else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                                break;
                            }
                            break;
                        case "towns":
                            SayTo(t, "I can send you to:\n" +
                                        "[Mularn] (Levels 10-14)\n" +
                                        "[Fort Veldon] (Levels 15-19)\n" +
                                        "[Audliten] (Levels 20-24)\n" +
                                        "[Huginfel] (Levels 25-290\n" +
                                        "[Fort Atla] (Levels 30-34)\n" +
                                        "[Vindsaul Faste] (Levels 35+)");
                            break;
                            // Begin Towns
                        case "mularn":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Mularn");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 100, x: 804292, y: 726509, z: 4696, heading: 842));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "audliten":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Audliten");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 100, x: 725682, y: 760401, z: 4528, heading: 1150));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "fort veldon":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Fort Veldon.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 100, x: 800200, y: 678003, z: 5304, heading: 204));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "huginfel":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Huginfel.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 100, x: 711788, y: 784084, z: 4672, heading: 2579));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "fort atla":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Fort Atla.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 100, x: 749237, y: 816443, z: 4408, heading: 2033));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "entrance":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Housing.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 102, x: 527051, y: 561559, z: 3638, heading: 102));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                            // End Towns
                            //Begin Si
                        case "aegirhamn":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Aegirhamn.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 151, x: 293382, y: 357369, z: 3488, heading: 1096));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "bjarken":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Bjarken.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 151, x: 289626, y: 301652, z: 4160, heading: 2804));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "hagall":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Hagall.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 151, x: 379055, y: 386013, z: 7752, heading: 2187));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "knarr":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Knarr.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 151, x: 302660, y: 433690, z: 3214, heading: 2103));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                            // End SI
                        case "hafheim":
                            if (ServerProperties.Properties.DISABLE_TUTORIAL && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player && t.Level < 15)
                            {
                                SayTo(t, "The Tutorial is disabled.");
                            }
                            else
                            {
                                if (!t.InCombat)
                                {
                                    Say("I'm now teleporting you to Hafheim.");
                                    foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                        player.Out.SendSpellCastAnimation(this, 4953, 3);
                                    t.MoveTo(Position.Create(regionID: 27, x: 228981, y: 222130, z: 5696, heading: 41));
                                }
                                else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            }
                            break;
                        // Svarhamr Dragonsworn place for mid, put check in like for tutorial, but dont know what to check for yet, so just open it.
                        case "svarhamr":
                            if (t.Level < 100) // and a && check for the players flag for this, must complete a quest.
                            {
                                if (!t.InCombat)
                                {
                                    Say("I'm now teleporting you to Svarhamr.");
                                    foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                        player.Out.SendSpellCastAnimation(this, 4953, 3);
                                    t.MoveTo(Position.Create(regionID: 100, x: 742842, y: 978919, z: 3920, heading: 1680));
                                }
                                else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            }
                            break;
                        default:
                            // Clicked nothing
                            break;
                    }
                    break;
                case eRealm.Hibernia:
                    switch (str.ToLower())
                    {
                        case "cruachan gorge":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Cruachan Gorge");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 163, x: 395861, y: 618238, z: 9816, heading: 2548));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "druim ligen":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Druim Ligen");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 200, x: 334600, y: 419997, z: 5184, heading: 479));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "shannon estuary":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Shannon Estuary");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 200, x: 310320, y: 645327, z: 4855, heading: 1441));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "domnann":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Domann Grove.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 181, x: 423157, y: 442474, z: 5952, heading: 2046));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "shrouded isles":
                            SayTo(t, "The isles of Hy Brasil are an excellent choice. Would you prefer the grove of [Domnann] or perhaps one of the outlying towns like [Droighaid], [Aalid Feie], or [Necht]?");
                            break;
                        case "oceanus":
                            if (ServerProperties.Properties.ATLANTIS_TELEPORT_PLVL > 1 && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player)
                            {
                                SayTo(t, "Atlantis Zones are disabled.");
                            }
                            else
                            {
                                SayTo(t, "Oceanus is not availible at this time.");
                            }
                            break;
                        case "shar labyrinth":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Shar Labyrinth.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 93, x: 25147, y: 27035, z: 17563, heading: 308));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "tir na nog":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Tir na Nog");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 201, x: 30011, y: 33138, z: 7916, heading: 3079));
                                //MoveTo(regionid, x , y, z, heading)
                            }
                            break;
                        case "housing":
                            SayTo(t, "I can send you to your [personal] house. If you do not have a personal house or wish to be sent to the housing [entrance] then you will arrive just inside the housing area. I can also send you to your [guild] house. If your guild does not own a house then you will not be transported. You may go to your [Hearth] bind as well if you are bound inside a house");
                            break;
                        case "battleground":
                            if (!ServerProperties.Properties.BG_ZONES_OPENED && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player)
                            {
                                SayTo(t, ServerProperties.Properties.BG_ZONES_CLOSED_MESSAGE);
                            }
                            else
                            {
                                if (!t.InCombat)
                                {
                                    Say("I will send you to the appropriate Battleground for your level, Good Luck.");
                                    foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                        player.Out.SendSpellCastAnimation(this, 4953, 6);
                                    if (t.Level < 5)
                                    {
                                        // Move to The Proving Grounds area 234
                                        // Need to check realm rank
                                        t.MoveTo(Position.Create(regionID: 234, x: 541540, y: 549326, z: 8640, heading: 2707));
                                    }

                                    if (t.Level > 4 && t.Level < 10)
                                    {
                                        // Move to the Lions Den area 235
                                        t.MoveTo(Position.Create(regionID: 235, x: 580335, y: 555282, z: 5056, heading: 1127));
                                    }

                                    if (t.Level > 9 && t.Level < 15)
                                    {
                                        // Move to the Hills of Claret area 236
                                        t.MoveTo(Position.Create(regionID: 236, x: 538416, y: 539050, z: 8008, heading: 3917));
                                    }

                                    if (t.Level > 14 && t.Level < 20)
                                    {
                                        // Move to Killaloe area 237
                                        t.MoveTo(Position.Create(regionID: 237, x: 534289, y: 536526, z: 8288, heading: 3532));
                                    }

                                    if (t.Level > 19 && t.Level < 25)
                                    {
                                        // Move to Thidranki area 238
                                        t.MoveTo(Position.Create(regionID: 238, x: 534248, y: 533333, z: 5408, heading: 3985));
                                    }

                                    if (t.Level > 24 && t.Level < 30)
                                    {
                                        // Move to Breamear area 239
                                        t.MoveTo(Position.Create(regionID: 239, x: 533569, y: 533068, z: 6768, heading: 3759));
                                    }

                                    if (t.Level > 29 && t.Level < 35)
                                    {
                                        // Move to Wilton are 240
                                        t.MoveTo(Position.Create(regionID: 240, x: 581353, y: 539099, z: 6736, heading: 917));
                                    }

                                    if (t.Level > 34 && t.Level < 40)
                                    {
                                        // Move to Molvik area 241
                                        t.MoveTo(Position.Create(regionID: 241, x: 576254, y: 544246, z: 5992, heading: 1462));
                                    }

                                    if (t.Level > 39 && t.Level < 45)
                                    {
                                        // Move to Leirvik area 242
                                        t.MoveTo(Position.Create(regionID: 242, x: 279389, y: 319874, z: 10128, heading: 2470));
                                    }

                                    if (t.Level > 44 && t.Level < 50)
                                    {
                                        // Move to Cathal Valley area 165
                                        t.MoveTo(Position.Create(regionID: 165, x: 536222, y: 585564, z: 5800, heading: 1958));
                                    }
                                    if (t.Level > 49)
                                    {
                                        // Tell them oops
                                        Say("Those who have reached their 50th season use the Frontiers as their Battlegrounds.");
                                    }
                                    // Nothing else to check for

                                }
                                else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                                break;
                            }
                            break;
                        case "towns":
                            SayTo(t, "I can send you to:\n" +
                                        "[Mag Mell] (Levels 10-14)\n" +
                                        "[Tir na mBeo] (Levels 15-19)\n" +
                                        "[Ardagh] (Levels 20-24)\n" +
                                        "[Howth] (Levels 25-29)\n" +
                                        "[Connla] (Levels 30-24)\n" +
                                        "[Druim Cain] (Levels 35+)");
                            break;
                            //Begin Towns
                        case "mag mell":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Mag Mell");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 200, x: 348073, y: 489646, z: 5200, heading: 643));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "tir na mbeo":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Tir na mBeo.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 200, x: 344519, y: 527771, z: 4061, heading: 1178));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "ardagh":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Ardagh.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 200, x: 351533, y: 553440, z: 5102, heading: 3054));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "howth":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Howth.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 200, x: 342575, y: 591967, z: 5456, heading: 1014));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "connla":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Connla");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 200, x: 297173, y: 642141, z: 4848, heading: 3814));
                            }
                            break;
                        case "druim cain":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Druim Cain");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 200, x: 421838, y: 486293, z: 1824, heading: 1109));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                            // End Towns
                            //Begin SI
                        case "droighaid":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Droighaid.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 181, x: 379767, y: 421216, z: 5528, heading: 1720));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "aalid feie":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Aalid Feie");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 181, x: 313648, y: 352530, z: 3592, heading: 942));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "necht":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Necht.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 181, x: 429507, y: 318578, z: 3458, heading: 716));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                        case "entrance":
                            if (!t.InCombat)
                            {
                                Say("I'm now teleporting you to Housing.");
                                foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                    player.Out.SendSpellCastAnimation(this, 4953, 3);
                                t.MoveTo(Position.Create(regionID: 202, x: 555396, y: 526607, z: 3008, heading: 1309));
                            }
                            else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            break;
                            // End SI
                        case "fintain":
                            if (ServerProperties.Properties.DISABLE_TUTORIAL && t.Client.Account.PrivLevel == (uint)ePrivLevel.Player && t.Level < 15)
                            {
                                SayTo(t, "The Tutorial is disabled.");
                            }
                            else
                            {
                                if (!t.InCombat)
                                {
                                    Say("I'm now teleporting you to Fintain.");
                                    foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                        player.Out.SendSpellCastAnimation(this, 4953, 3);
                                    t.MoveTo(Position.Create(regionID: 27, x: 359574, y: 353555, z: 5688, heading: 18));
                                }
                                else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            }
                            break;
                        // Tailtiu Dragonsworn place for hib, put check in like for tutorial, but dont know what to check for yet, so just open it.
                        case "tailtiu":
                            if (t.Level < 100) // and a && check for the players flag for this, must complete a quest.
                            {
                                if (!t.InCombat)
                                {
                                    Say("I'm now teleporting you to Tailtiu.");
                                    foreach (GamePlayer player in this.GetPlayersInRadius(WorldMgr.VISIBILITY_DISTANCE))
                                        player.Out.SendSpellCastAnimation(this, 4953, 3);
                                    t.MoveTo(Position.Create(regionID: 200, x: 369715, y: 651594, z: 3693, heading: 1882));
                                }
                                else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                            }
                            break;
                        default:
                            // Clicked nothing
                            break;
                    }
                    break;
                default:
                    // Npc has no realm set, and therefore will not work.
                    break;
            }
            //trying a fall through
            switch (str.ToLower())
            {
                case "personal":
                    SayTo(t, "Personal House recall not yet implemented.");
                    break;
                case "guild":
                    SayTo(t, "Guild House recall not yet implemented..");
                    break;
                case "hearth":
                    SayTo(t, "I shall return you to your Hearthstone.");
                    t.MoveToBind();
                    break;
                default:
                    break;
            }


            return true;
        }
    }
}