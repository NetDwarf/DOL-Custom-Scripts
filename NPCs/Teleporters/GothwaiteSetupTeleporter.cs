using System;
using DOL.GS.Geometry;
using DOL.Events;
using DOL.GS.PacketHandler;
using log4net;
using DOL.Database;
using System.Reflection;

namespace DOL.GS.Scripts
{
    public class GothwaiteSetupTeleporter : GameNPC
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override bool AddToWorld()
        {
            Model = 2026;
            Name = "ZONE TELEPORTER";
            GuildName = "Zone Teleporter";
            Level = 50;
            Size = 60;
            Flags = eFlags.PEACE;	// Peace flag.
            return base.AddToWorld();
        }

        private static ServerProperty curMap = GameServer.Database.SelectObject<ServerProperty>(DB.Column("Key").IsEqualTo("current_map"));

        public override bool Interact(GamePlayer player)
        {
            if (!base.Interact(player)) return false;
            TurnTo(player.Coordinate);
            player.Out.SendMessage("Hello " + player.Name + "!  I am the Arbiter and I can teleport you to the following locations\n\n[Main Setup]\n\n" +
            "[PvP Setup]\n\n[Gjalpinulva]\n\n[Master Level Trials]", eChatType.CT_Say, eChatLoc.CL_PopupWindow);
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
                case "PvP Setup":
                    if (!t.InCombat)
                    {
                        /*if (curMap.Value == "Aegir's Landing PvP")
                        {
                            Say("I'm now teleporting you to the current PvP Setup area");
                            t.MoveTo(Position.Create(regionID: 151, x: 255443, y: 316099, z: 4048, heading: 2194));
                        }
                         else if (curMap.Value == "Knarr PvP")
                         {
                             Say("I'm now teleporting you to the current PvP Setup area");
                             t.MoveTo(Position.Create(regionID: 151, x: 348551, y: 433572, z: 3712, heading: 3338));
                         }*/
                        //if (curMap.Value == "Gothwaite PvP")
                         //{
                        Say("I'm now teleporting you to the current PvP Setup area");
                             t.MoveTo(Position.Create(regionID: 51, x: 526034, y: 505253, z: 3424, heading: 1549));
                        // }
                             /* else if (curMap.Value == "Mag Mell PvP")
                              {
                                  Say("I'm now teleporting you to the current PvP Setup area");
                                  t.MoveTo(Position.Create(regionID: 200, x: 296554, y: 454088, z: 7139, heading: 1101));
                              }*/
                         }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Main Setup":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to the Main Setup area");
                        t.MoveTo(Position.Create(regionID: 70, x: 569762, y: 538694, z: 6104, heading: 3268));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Gjalpinulva":
                    if (!t.InCombat)

                    //if (t.Group.MemberCount >= 4) //You have enough
                    {
                        Say("I'm now teleporting you to Gjalpinulva's Lair");
                        t.MoveTo(Position.Create(regionID: 100, x: 694102, y: 996417, z: 2861, heading: 935));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                //else if (t.Group.MemberCount <= 3) //You dont have enough
                //t.Out.SendMessage("You need a group of at least 4 adventurers for this encounter!", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                //break;
                case "Master Level Trials":
                    SendReply(t, "Which trial would you like to take?\n\n[Cetus]\n\n[Runihura]\n\n[Medussa]\n\n[Martikhoras]\n\n[Ammut]\n\n[Chimera]\n\n[Typhon]\n\n[Talos]\n\n[Phoenix]\n\n[Draco]");
                    break;

                case "Cetus":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Cetus");
                        t.MoveTo(Position.Create(regionID: 78, x: 30258, y: 36507, z: 17005, heading: 2305));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Runihura":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Runihura");
                        t.MoveTo(Position.Create(regionID: 73, x: 335638, y: 464204, z: 10727, heading: 8));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Medussa":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Medussa");
                        t.MoveTo(Position.Create(regionID: 80, x: 68870, y: 21562, z: 18146, heading: 2014));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Martikhoras":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Manticore");
                        t.MoveTo(Position.Create(regionID: 88, x: 31982, y: 30892, z: 16300, heading: 4091));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Ammut":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Ammut");
                        t.MoveTo(Position.Create(regionID: 83, x: 44901, y: 36638, z: 15656, heading: 3074));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Chimera":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Chimera");
                        t.MoveTo(Position.Create(regionID: 73, x: 548432, y: 561198, z: 10672, heading: 2445));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Typhon":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Typhon");
                        t.MoveTo(Position.Create(regionID: 89, x: 45990, y: 22136, z: 14876, heading: 3073));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Talos":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Talos");
                        t.MoveTo(Position.Create(regionID: 73, x: 477955, y: 695019, z: 16156, heading: 2576));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Phoenix":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to the Phoenix");
                        t.MoveTo(Position.Create(regionID: 90, x: 34885, y: 37445, z: 19063, heading: 2054));
                    }
                    else { t.Client.Out.SendMessage("You can't port while in combat.", eChatType.CT_Say, eChatLoc.CL_PopupWindow); }
                    break;

                case "Draco":
                    if (!t.InCombat)
                    {
                        Say("I'm now teleporting you to Draco");
                        t.MoveTo(Position.Create(regionID: 91, x: 31886, y: 34425, z: 15763, heading: 2046));
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
                eChatType.CT_Say, eChatLoc.CL_PopupWindow);
        }
        [ScriptLoadedEvent]
        public static void OnScriptCompiled(DOLEvent e, object sender, EventArgs args)
        {
            log.Info("\tTeleporter initialized: true");
        }
    }
}