using System;
using DOL.GS;
using DOL.AI.Brain;
using DOL.GS.Geometry;

namespace DOL.GS.Scripts
{
    public class Antipass : GameNPC
    {
        public override bool AddToWorld()
        {
            this.SetOwnBrain(new AntipassBrain());
            Brain.Start();
            base.AddToWorld();
            Name = "No Pass";
            Flags |= GameNPC.eFlags.PEACE;
            //Flags |= (uint)GameNPC.eFlags.CANTTARGET;
            Flags |= GameNPC.eFlags.FLYING;      
            Model = 666;
            Size = 50;
            Level = 90;
            MaxSpeedBase = 0;
            return true;
        }
    }
}

namespace DOL.AI.Brain
{
    public class AntipassBrain : StandardMobBrain
    {
        public AntipassBrain()
            : base()
        {
            ThinkInterval = 50;
            AggroLevel = 100;
            AggroRange = 400;
        }

        public override void Think()
        {
            foreach (GamePlayer player in Body.GetPlayersInRadius((ushort)AggroRange))
            {
                if (player.Client.Account.PrivLevel != 3)
                {
                    var offset = Vector.Create(Body.Orientation, length: AggroRange + 10);
                    var pos = player.Position.With(Body.Coordinate) + offset;
                    player.MoveTo(player.Position.With(Body.Coordinate) + offset);
                }
            }
        }
    }
}