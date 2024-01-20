/* Powered by Krusck
* for Server: Apocalipse PvP
* in data 05/06/09
* Supported by Dawn of Light
* Work Whit 1695 SVN 
*/


using System;
using System.Collections;
using DOL.GS;
using DOL.Database;
using DOL.GS.PacketHandler;
using DOL.GS.Geometry;

namespace DOL.GS.Commands
{
    [CmdAttribute("&move", //command to handle
         ePrivLevel.GM, //minimum privelege level
         "Teleports all players from a regionID to their Home Village", //command description
        //Usage
         "/move <regionID>")]


    public class Move : AbstractCommandHandler, ICommandHandler
    {
        public void OnCommand(GameClient client, string[] args)
        {
            if (args.Length < 2)
            {
                client.Out.SendMessage("Use: /move <regionID>", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                return;
            }

            ushort from_region = Convert.ToByte(args[1]);

            foreach (GameClient cl in WorldMgr.GetClientsOfRegion(from_region))
            {
                if (cl.Player.Realm == eRealm.Albion)
                {
                    cl.Player.MoveTo(Position.Create(regionID: 1, x: 560421, y: 511840, z: 2344, heading: 1));  //EDIT THIS line WHIT YOUR LOC want to be teleport
                    cl.Player.SaveIntoDatabase();
                    client.Out.SendMessage(cl.Player.Name + "", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                }
                else if (cl.Player.Realm == eRealm.Midgard)
                {
                    cl.Player.MoveTo(Position.Create(regionID: 100, x: 804763, y: 723998, z: 4699, heading: 1)); //EDIT THIS LINE WHIT YOUR LOC want to be teleport
                    cl.Player.SaveIntoDatabase();
                    client.Out.SendMessage(cl.Player.Name + "", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                }
                else if (cl.Player.Realm == eRealm.Hibernia)
                {
                    cl.Player.MoveTo(Position.Create(regionID: 200, x: 345684, y: 490996, z: 5200, heading: 1)); //EDIT THIS LINE WHIT YOUR LOC want to be teleport
                    cl.Player.SaveIntoDatabase();
                    client.Out.SendMessage(cl.Player.Name + "", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                }
                else
                {
                    client.Out.SendMessage(cl.Player.Name + "", eChatType.CT_System, eChatLoc.CL_SystemWindow);
                    return;
                }
            }
        }
    }
}