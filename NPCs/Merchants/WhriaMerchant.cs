using DOL.GS.PacketHandler;
using DOL.AI.Brain;
using DOL.GS.Profession;

namespace DOL.GS.Scripts
{
    public class WhriaMerchant : GameBountyMerchant
    {
        #region Constructor

        public WhriaMerchant()
            : base()
        {
            SetOwnBrain(new BlankBrain());
        }

        #endregion Constructor

        #region AddToWorld

        public override bool AddToWorld()
        {

           
            Level = 60;
            Name = "Dragon Merchant";
            GuildName = "";
            Model = 1903;
         
            MaxSpeedBase = 0;
            Realm = 0;
   
            Catalog = MerchantCatalog.Create("dragon_merchant");

            return base.AddToWorld();
        }

        #endregion AddToWorld
        public override bool Interact(GamePlayer player)
        {
            Catalog = MerchantCatalog.Create("dragon_merchant");
            player.Out.SendMerchantWindow(Catalog, eMerchantWindowType.Normal);
            return true;
        }
    }  
 }

