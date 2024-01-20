// A little script to help with the missing Jump Points in some clients... by jaystar
// Using Mob name and case to port to xyz locs.

using DOL.GS.Geometry;
using DOL.AI.Brain;

namespace DOL.GS.Scripts
{
    public class RadiusPorter : GameNPC
    {
        public const int INTERVAL = 2 * 1000;

        protected virtual int Timer(RegionTimer callingTimer)
        {
            int range = ((this.Brain as StandardMobBrain).AggroRange);
            foreach (GamePlayer player in this.GetPlayersInRadius((500))) //500 units seems to be a good range, but change to your needs
            {
                switch (Name)
                {
                    case "SVASUDNF":
                        player.MoveTo(Position.Create(regionID: 163, x: 651951, y: 313721, z: 9432, heading: 1006));
                        break;
                    case "DLNF":
                        player.MoveTo(Position.Create(regionID: 163, x: 396561, y: 618476, z: 9825, heading: 1966));
                        break;
                }
                



            }
            return INTERVAL;
        }

        public override bool AddToWorld()
        {
            
            new RegionTimer(this, new RegionTimerCallback(Timer), INTERVAL);
            return base.AddToWorld();

        }
       
    }
}

