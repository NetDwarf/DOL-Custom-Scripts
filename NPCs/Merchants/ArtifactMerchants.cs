using System;
using System.Reflection;
using DOL.GS.PacketHandler;
using DOL.Database;
using DOL.Events;
using log4net;
using DOL.GS.Profession;

namespace DOL.GS.Items
{
	
    #region Albion Artifacts Weapons

    public class AlbArtWeaps
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [GameServerStartedEvent]
        public static void OnServerStartup(DOLEvent e, object sender, EventArgs args)
        {

            MerchantItem m_item = null;
            m_item = (MerchantItem)GameServer.Database.SelectObject<MerchantItem>( DB.Column("ItemListID").IsEqualTo("AlbArtWeaps"));
            if (m_item == null)
            {
                #region Merchant Artifact Weapons

                #region Page 1 Alb
                // main hand weapons 

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Malice_Axe_Slash";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 0;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "MaliceAxe_slash_2h";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 1;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "MaliceAxe_crush";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 2;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "MaliceAxe_crush_2h";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 3;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "GoldenSpear_alb";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 5;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "CrocToothDagger_Slash_Alb";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 7;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "CrocToothDagger_Crush_Alb";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 8;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "CrocToothDagger_Thrust_Alb";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 9;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "TraitorsDagger_Thrust_Alb";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 11;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Traitors_Dagger_Slash_Alb";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 12;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Battler_Alb_Crush";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 14;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Battler_Alb_Crush_2h";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 15;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Battler_Alb_Slash";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 16;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Battler_Alb_Slash_2h";
                    m_item.PageNumber = 0;
                    m_item.SlotPosition = 17;
                    
                    GameServer.Database.AddObject(m_item);

                    #endregion

                #region Page 2 Alb

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Snakecharmers_Flex_Slash";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 0;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Snakecharmers_Flex_Crush";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 1;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Bruiser_Crush";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 4;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Bruiser_Crush_2h";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 5;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Bruiser_Crush_Pole";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 6;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Scepter_Crush";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 8;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "SoK_Slash";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 10;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "SoK_Slash_2h";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 11;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "SoK_Slash_Pole";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 12;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "SoK_Thrust_Pole";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 13;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "SOK_Alb_Thrust_1h";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 14;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Fools_Bow_Alb";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 16;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Braggarts_Bow_Alb";
                    m_item.PageNumber = 1;
                    m_item.SlotPosition = 17;
                    
                    GameServer.Database.AddObject(m_item);


                    #endregion Page 2 alb

                #region Page 3 Alb
                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "SOTG_Caster";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 0;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "SOFG_Melee";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 1;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Tartaros_Gift_Caster";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 3;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Tartaros_Gift_Melee";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 4;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Traldors_Oracle_Caster";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 6;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Traldors_Oracle_Melee";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 7;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Atens_Shield";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 10;
                    
                    GameServer.Database.AddObject(m_item);


                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Atens_Shield_Medium";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 11;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Atens_Shield_Large";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 12;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Cyclops_Eye_Shield_Large";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 14;
                    
                    GameServer.Database.AddObject(m_item);


                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Cyclops_Eye_Shield_Small";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 15;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Cyclops_Eye_Shield_Medium";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 16;
                    
                    GameServer.Database.AddObject(m_item);

                    m_item = new MerchantItem();
                    m_item.ItemListID = "AlbArtWeaps";
                    m_item.ItemTemplateID = "Shield_Of_Khaos";
                    m_item.PageNumber = 2;
                    m_item.SlotPosition = 18 ;
                    
                    GameServer.Database.AddObject(m_item);

                    #endregion Page 3 alb

                #endregion Merchant Items
            }
            
        }
    }
    #endregion Albion Artifact Weapons

    #region Midgard Artifact Weapons

    public class MidArtWeaps
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [GameServerStartedEvent]
        public static void OnServerStartup(DOLEvent e, object sender, EventArgs args)
        {
            MerchantItem m_item = null;
            m_item = (MerchantItem)GameServer.Database.SelectObject<MerchantItem>(DB.Column("ItemListID").IsEqualTo("MidArtWeaps"));
            if (m_item == null)
            {
                #region Midgard Merchant Items

                

                #region Page 1 Mid
                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Malice_Axe_Axe";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "MaliceAxe_Axe_2h";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 1;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "MaliceAxe_Hammer";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "MaliceAxe_Hammer_2h";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "GoldenSpear_Mid";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "GoldenSpear_Mid_2h";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "CrocToothDagger_Slash_Mid";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "CrocToothDagger_Crush_Mid";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 9;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "CrocToothDagger_Leftaxe_Mid";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Traitors_Dagger_Slash_Mid";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);

                // Weapons that can used in LeftHand

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "TraitorsDagger_Axe";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "TraitorsDagger_Leftaxe";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 14;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Battler_Mid_Slash";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 16;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Battler_Mid_2h";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 17;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Battler_Mid_Crush";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 18;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Battler_Mid_Crush_2h";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 19;
                
                GameServer.Database.AddObject(m_item);

                #endregion Page 1 Mid

                #region Page 2 Mid

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Snakecharmers_wrap";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Bruiser_2h";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Bruiser_Hammer";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "SOK_Sword";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "SOK_Sword_2h";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "SOK_Slash_Spear";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "SOK_Thrust_Spear";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Fools_Bow_Mid";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Braggarts_Bow_Mid";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);


                #endregion Page 2 Mid

                #region Page 3 Mid
                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "SOTG_Caster";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Tartaros_Gift_Caster";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Traldors_Oracle_Caster";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 4;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Atens_Shield";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Atens_Shield_Medium";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Atens_Shield_Large";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Cyclops_Eye_Shield_Large";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Cyclops_Eye_Shield_Small";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Cyclops_Eye_Shield_Medium";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtWeaps";
                m_item.ItemTemplateID = "Shield_Of_Khaos";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 14;
                
                GameServer.Database.AddObject(m_item);


                #endregion 3 Mid

                #endregion Midgard Labyrinth Weapons
            }
        }
    }
    #endregion Midgard Labyrinth Weapons

    #region Hibernia Artifact Weapons

    public class HibArtWeaps
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [GameServerStartedEvent]
        public static void OnServerStartup(DOLEvent e, object sender, EventArgs args)
        {
                MerchantItem m_item = null; 
            m_item = (MerchantItem)GameServer.Database.SelectObject<MerchantItem>(DB.Column("ItemListID").IsEqualTo("HibArtWeaps"));
            if (m_item == null)
            {

                

                #region Hibernia Merchant Items

               
                #region Page 1 Hib

                
                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "MaliceAxe_Blade";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "MaliceAxe_Blunt";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 1;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "MaliceAxe_Lw_Slash";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "MaliceAxe_Lw_Blunt";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "GoldenSpear_Hib";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "GoldenSpear_Hib_2h";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "CrocToothDagger_Hib_Blade";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "CrocToothDagger_Hib_Blunt";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 9;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "CrocToothDagger_Hib_Trust";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "TraitorsDagger_Hib_Blade";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "TraitorsDagger_Hib_Thrust";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Battler_Hib_Blades";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 15;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Battler_Hib_Blunt";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 16;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Battler_Hib_Blunt_2h";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 17;
                
                GameServer.Database.AddObject(m_item);
                 


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Battler_Hib_Blade_2h";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 18;
                
                GameServer.Database.AddObject(m_item);
                 

                #endregion Page 1 Hib

                
                #region Page 2 Hib

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Snakecharmers_Scythe";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Bruiser_Blunt";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Bruiser_Lw";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Scepter_Blunt";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "SOK_Blade";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "SOK_Slash_Lw";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "SOK_Slash_Celtspear";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 9;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "SOK_Thrust_Celtspear";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "SOK_Hib_Thrust_2h";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);
                 


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "SOK_Hib_Thrust";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Fools_Bow_Hib";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 14;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Braggarts_Bow_Hib";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 15;
                
                GameServer.Database.AddObject(m_item);
   
                #endregion Page 2 Hib


                #region Page 3 Hib
                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "SOTG_Caster";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Tartaros_Gift_Caster";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Traldors_Oracle_Caster";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 4;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Atens_Shield";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Atens_Shield_Medium";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Atens_Shield_Large";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Cyclops_Eye_Shield_Large";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Cyclops_Eye_Shield_Small";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Cyclops_Eye_Shield_Medium";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtWeaps";
                m_item.ItemTemplateID = "Shield_Of_Khaos";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 14;
                
                GameServer.Database.AddObject(m_item);


                #endregion 3 Hib

                #endregion Hibernia Merchant Items
                
            }
        }
    }
    #endregion a

    #region Albion Artifact Armor

    public class AlbArtArmor
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [GameServerStartedEvent]
        public static void OnServerStartup(DOLEvent e, object sender, EventArgs args)
        {
            MerchantItem m_item = null;
            m_item = (MerchantItem)GameServer.Database.SelectObject<MerchantItem>(DB.Column("ItemListID").IsEqualTo("AlbArtArmor"));
            if (m_item == null)
            {



                #region Albion Merchant Items


                #region Page 1 Alb


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 1;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Studded";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_plate";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 4;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Studded";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 9;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Plate";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Crown_of_Zahur_Studded";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 14;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 15;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Plate";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 16;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Eirenes_Hauberk_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 18;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Eirenes_Hauberk_Plate";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 19;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Enyalios_Boots_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 21;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Enyalios_Boots_Plate";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 22;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 24;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 25;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Studded";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 26;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 27;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Plate";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 28;
                
                GameServer.Database.AddObject(m_item);
                #endregion Page 1 Hib


                #region Page 2 Alb

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GSV_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GSV_Studded_Melee";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 1;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GSV_Studded_Archer";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GOV_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GOV_Cloth_Int";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 4;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GOV_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GOV_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GOV_Chain";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "GOV_Plate";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Chain";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Plate";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 14;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Sharkskin_Gloves_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 16;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Nailahs_Robe_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 18;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Nailah_Robe_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 19;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Winged_Helm_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 21;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Winged_Helm_Chain";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 22;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Winged_Helm_Plate";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 23;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Wings_Dive_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 25;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Wings_Dive_Chain";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 26;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "AlbArtArmor";
                m_item.ItemTemplateID = "Wings_Dive_Plate";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 27;
                
                GameServer.Database.AddObject(m_item);
                #endregion Page 2 Hib


                #endregion Hibernia Merchant Items

            }
        }
    }
    #endregion 

    #region Midgard Artifact Armor

    public class MidArtArmor
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [GameServerStartedEvent]
        public static void OnServerStartup(DOLEvent e, object sender, EventArgs args)
        {
            MerchantItem m_item = null;
            m_item = (MerchantItem)GameServer.Database.SelectObject<MerchantItem>(DB.Column("ItemListID").IsEqualTo("MidArtArmor"));
            if (m_item == null)
            {



                #region Midgard Merchant Items


                #region Page 1 Mid


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 1;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Studded";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Studded";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Crown_of_Zahur_Studded";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Eirenes_Hauberk_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 15;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Enyalios_Boots_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 18;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 20;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 21;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Studded";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 22;
                
                GameServer.Database.AddObject(m_item);



                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Chain";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 23;
                
                GameServer.Database.AddObject(m_item);

                #endregion Page 1 Hib


                #region Page 2 Mid

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "GSV_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "GSV_Studded_Melee";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 1;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "GSV_Studded_Archer";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "GOV_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 4;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "GOV_Cloth_Int";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "GOV_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "GOV_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "GOV_Chain";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Chain";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Sharkskin_Gloves_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 15;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Nailahs_Robe_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 17;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Nailah_Robe_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 19;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Winged_Helm_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 21;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Winged_Helm_Chain";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 22;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Wings_Dive_Studded";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 24;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "MidArtArmor";
                m_item.ItemTemplateID = "Wings_Dive_Chain";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 25;
                
                GameServer.Database.AddObject(m_item);
                #endregion Page 2 Hib

                #endregion Hibernia Merchant Items

            }
        }
    }
    #endregion 

    #region Hibernia Artifact Armor

    public class HibArtArmor
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [GameServerStartedEvent]
        public static void OnServerStartup(DOLEvent e, object sender, EventArgs args)
        {
                MerchantItem m_item = null; 
            m_item = (MerchantItem)GameServer.Database.SelectObject<MerchantItem>(DB.Column("ItemListID").IsEqualTo("HibArtArmor"));
            if (m_item == null)
            {

                

                #region Hibernia Merchant Items

               
                #region Page 1 Hib

                
                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 1;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Reinforced";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Alvarus_Leggings_Scale";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Reinforced";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Arms_Of_The_Winds_Scale";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Crown_of_Zahur_Reinforced";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Crown_Of_Zahur_Scale";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Eirenes_Hauberk_Scale";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 15;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Enyalios_Boots_Reinforced";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 17;
                
                GameServer.Database.AddObject(m_item);
                 


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Enyalios_Boots_Scale";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 18;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Cloth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 20;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Leather";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 21;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Reinforced";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 22;
                
                GameServer.Database.AddObject(m_item);



                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Foppish_Sleeves_Scale";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 23;
                
                GameServer.Database.AddObject(m_item);

                #endregion Page 1 Hib

                
                #region Page 2 Hib

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GSV_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GSV_Reinforced_Melee";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GSV_Reinforced_Archery";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GSV_Reinforced_Bard";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GOV_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GOV_Cloth_Int";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GOV_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 9;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GOV_Reinforced";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "GOV_Scale";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 14;
                
                GameServer.Database.AddObject(m_item);
                 

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Reinforced";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 15;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Maddening_Scalars_Scale";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 16;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Sharkskin_Gloves_Reinforced";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 18;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Nailahs_Robe_Cloth";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 20;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Nailah_Robe_Leather";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 21;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Winged_Helm_Reinforced";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 23;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Winged_Helm_Scale";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 24;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Wings_Dive_Reinforced";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 26;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "HibArtArmor";
                m_item.ItemTemplateID = "Wings_Dive_Scale";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 27;
                
                GameServer.Database.AddObject(m_item);
                #endregion Page 2 Hib

                #endregion Hibernia Merchant Items
                
            }
        }
    }
    #endregion 

    #region Artifact Items / Cloaks

    public class ArtItems
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [GameServerStartedEvent]
        public static void OnServerStartup(DOLEvent e, object sender, EventArgs args)
        {
            MerchantItem m_item = null;
            m_item = (MerchantItem)GameServer.Database.SelectObject<MerchantItem>(DB.Column("ItemListID").IsEqualTo("ArtItems"));
            if (m_item == null)
            {



                #region Hibernia Merchant Items


                #region Page 1 Items


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Band_Of_Stars";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Belt_Of_The_Moon";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 1;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Belt_Of_The_Sun";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Bracer_Of_Zoarkat";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Ceremonial_Bracers_Acuity";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 4;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Ceremonial_Bracers_Con";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Ceremonial_Bracers_Dex";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Ceremonial_Bracers_Qui";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Ceremonial_Bracers_Str";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Egg_Of_Youth";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 9;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Erinys_Charm";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Eternal_Plant";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 11;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "A_Flask";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 12;
                
                GameServer.Database.AddObject(m_item);



                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Lost_Memories_Archers";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 13;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Lost_Memories_Caster";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 14;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Lost_Memories_Melee";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 15;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Goddess_Necklace";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 16;
                
                GameServer.Database.AddObject(m_item);



                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Jacinas_Sash";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 17;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Kalares_Necklace";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 18;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Nights_Shroud_Bracelet";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 19;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Oglidarshs_Belt";
                m_item.PageNumber = 0;
                m_item.SlotPosition = 20;
                
                GameServer.Database.AddObject(m_item);

                #endregion Page 1 Items
                #region Page 2 Items

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Orions_Belt_Caster";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Orions_Belt_Archer";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Orions_Belt_Melee";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 3;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Orions_Belt_Frair";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 4;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Phoebus_Harp";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 5;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Ring_of_Dance";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Ring_Of_Fire";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 7;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Ring_of_Unyielding_Will";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 8;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Scorpions_Tail_Ring";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 9;
                
                GameServer.Database.AddObject(m_item);

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Snatcher";
                m_item.PageNumber = 1;
                m_item.SlotPosition = 10;
                
                GameServer.Database.AddObject(m_item);

                #endregion Page 2 Items
                #region Page 3 Items

                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Cloudsong";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 0;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Harpy_Feather_Cloak";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 2;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Healers_Embrace";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 4;
                
                GameServer.Database.AddObject(m_item);


                m_item = new MerchantItem();
                m_item.ItemListID = "ArtItems";
                m_item.ItemTemplateID = "Shades_of_Mist";
                m_item.PageNumber = 2;
                m_item.SlotPosition = 6;
                
                GameServer.Database.AddObject(m_item);

                #endregion Page 3 Items

                #endregion Hibernia Merchant Items

            }
        }
    }
    #endregion 
}
namespace DOL.GS.Scripts
{
    public class AAW : GameBountyMerchant // Alb Artifacr Weapons Merchant
    {
        #region Constructor

        public AAW()
            : base()
        {
        }

        #endregion Constructor

        #region AddToWorld

        public override bool AddToWorld()
        {
            int color = Util.Random(0, 86);
            GameNpcInventoryTemplate template = new GameNpcInventoryTemplate();
            template.AddNPCEquipment(eInventorySlot.Cloak, 3800);
            template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2928);
            template.AddNPCEquipment(eInventorySlot.LegsArmor, 2929);
            template.AddNPCEquipment(eInventorySlot.ArmsArmor, 2930);
            template.AddNPCEquipment(eInventorySlot.HandsArmor, 2931);
            template.AddNPCEquipment(eInventorySlot.FeetArmor, 2932);

            Inventory = template.CloseTemplate();
            Level = 60;
            Name = "Artifact Weapons";
            GuildName = "Items that Level";
            Model = 33;
            Size = 54;
            RespawnInterval = 2000;
            MaxSpeedBase = 0;
            Realm = 0;
            Flags |= GameNPC.eFlags.PEACE;
            Catalog = MerchantCatalog.Create("AlbArtWeaps");

            return base.AddToWorld();
        }

        #endregion AddToWorld
    }

    public class AAA : GameBountyMerchant // Alb Artifact Armor Merchant
    {
        #region Constructor

        public AAA()
            : base()
        {
        }

        #endregion Constructor

        #region AddToWorld

        public override bool AddToWorld()
        {
            int color = Util.Random(0, 86);
            GameNpcInventoryTemplate template = new GameNpcInventoryTemplate();
            template.AddNPCEquipment(eInventorySlot.Cloak, 3800);
            template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2928);
            template.AddNPCEquipment(eInventorySlot.LegsArmor, 2929);
            template.AddNPCEquipment(eInventorySlot.ArmsArmor, 2930);
            template.AddNPCEquipment(eInventorySlot.HandsArmor, 2931);
            template.AddNPCEquipment(eInventorySlot.FeetArmor, 2932);

            Inventory = template.CloseTemplate();
            Level = 60;
            Name = "Artifact Armor";
            GuildName = "Items that Level";
            Model = 33;
            Size = 54;
            RespawnInterval = 2000;
            MaxSpeedBase = 0;
            Realm = 0;
            Flags |= GameNPC.eFlags.PEACE;
            Catalog = MerchantCatalog.Create("AlbArtArmor");

            return base.AddToWorld();
        }

        #endregion AddToWorld
    }

    public class MAW : GameBountyMerchant // Mid Artifacr Weapons Merchant
    {
        #region Constructor

        public MAW()
            : base()
        {
        }

        #endregion Constructor

        #region AddToWorld

        public override bool AddToWorld()
        {
            int color = Util.Random(0, 86);
            GameNpcInventoryTemplate template = new GameNpcInventoryTemplate();
            template.AddNPCEquipment(eInventorySlot.Cloak, 3801);
            template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2928);
            template.AddNPCEquipment(eInventorySlot.LegsArmor, 2929);
            template.AddNPCEquipment(eInventorySlot.ArmsArmor, 2930);
            template.AddNPCEquipment(eInventorySlot.HandsArmor, 2931);
            template.AddNPCEquipment(eInventorySlot.FeetArmor, 2932);

            Inventory = template.CloseTemplate();
            Level = 60;
            Name = "Artifact Weapons";
            GuildName = "Items that Level";
            Model = 144;
            Size = 54;
            RespawnInterval = 2000;
            MaxSpeedBase = 0;
            Realm = 0;
            Flags |= GameNPC.eFlags.PEACE;
            Catalog = MerchantCatalog.Create("MidArtWeaps");

            return base.AddToWorld();
        }

        #endregion AddToWorld
    }

    public class MAA : GameBountyMerchant // Mid Artifact Armor Merchant
    {
        #region Constructor

        public MAA()
            : base()
        {
        }

        #endregion Constructor

        #region AddToWorld

        public override bool AddToWorld()
        {
            int color = Util.Random(0, 86);
            GameNpcInventoryTemplate template = new GameNpcInventoryTemplate();
            template.AddNPCEquipment(eInventorySlot.Cloak, 3801);
            template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2928);
            template.AddNPCEquipment(eInventorySlot.LegsArmor, 2929);
            template.AddNPCEquipment(eInventorySlot.ArmsArmor, 2930);
            template.AddNPCEquipment(eInventorySlot.HandsArmor, 2931);
            template.AddNPCEquipment(eInventorySlot.FeetArmor, 2932);

            Inventory = template.CloseTemplate();
            Level = 60;
            Name = "Artifact Armor";
            GuildName = "Items that Level";
            Model = 144; 
            Size = 54;
            RespawnInterval = 2000;
            MaxSpeedBase = 0;
            Realm = 0;
            Flags |= GameNPC.eFlags.PEACE;
            Catalog = MerchantCatalog.Create("MidArtArmor");

            return base.AddToWorld();
        }

        #endregion AddToWorld
    }

    public class HAW : GameBountyMerchant // Hib Artifacr Weapons Merchant
    {
        #region Constructor

        public HAW()
            : base()
        {
        }

        #endregion Constructor

        #region AddToWorld

        public override bool AddToWorld()
        {
            int color = Util.Random(0, 86);
            GameNpcInventoryTemplate template = new GameNpcInventoryTemplate();
            template.AddNPCEquipment(eInventorySlot.Cloak, 3802);
            template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2928);
            template.AddNPCEquipment(eInventorySlot.LegsArmor, 2929);
            template.AddNPCEquipment(eInventorySlot.ArmsArmor, 2930);
            template.AddNPCEquipment(eInventorySlot.HandsArmor, 2931);
            template.AddNPCEquipment(eInventorySlot.FeetArmor, 2932);

            Inventory = template.CloseTemplate();
            Level = 60;
            Name = "Artifact Weapons";
            GuildName = "Items that Level";
            Model = 335;
            Size = 54;
            RespawnInterval = 2000;
            MaxSpeedBase = 0;
            Realm = 0;
            Flags |= GameNPC.eFlags.PEACE;
            Catalog = MerchantCatalog.Create("HibArtWeaps");

            return base.AddToWorld();
        }

        #endregion AddToWorld
    }

    public class HAA : GameBountyMerchant // Hib Artifact Armor Merchant
    {
        #region Constructor

        public HAA()
            : base()
        {
        }

        #endregion Constructor

        #region AddToWorld

        public override bool AddToWorld()
        {
            int color = Util.Random(0, 86);
            GameNpcInventoryTemplate template = new GameNpcInventoryTemplate();
            template.AddNPCEquipment(eInventorySlot.Cloak, 3802);
            template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2928);
            template.AddNPCEquipment(eInventorySlot.LegsArmor, 2929);
            template.AddNPCEquipment(eInventorySlot.ArmsArmor, 2930);
            template.AddNPCEquipment(eInventorySlot.HandsArmor, 2931);
            template.AddNPCEquipment(eInventorySlot.FeetArmor, 2932);

            Inventory = template.CloseTemplate();
            Level = 60;
            Name = "Artifact Armor";
            GuildName = "Items that Level";
            Model = 335;
            Size = 54;
            RespawnInterval = 2000;
            MaxSpeedBase = 0;
            Realm = 0;
            Flags |= GameNPC.eFlags.PEACE;
            Catalog = MerchantCatalog.Create("HibArtArmor");

            return base.AddToWorld();
        }

        #endregion AddToWorld
    }

    public class ArtifactItems : GameBountyMerchant // Artifact Armor Merchant 
    {
        #region Constructor

        public ArtifactItems ()
            : base()
        {
        }

        #endregion Constructor

        #region AddToWorld

        public override bool AddToWorld()
        {
            GameNpcInventoryTemplate template = new GameNpcInventoryTemplate();
            template.AddNPCEquipment(eInventorySlot.Cloak, 1724);
            template.AddNPCEquipment(eInventorySlot.TorsoArmor, 2928);
            template.AddNPCEquipment(eInventorySlot.LegsArmor, 2929);
            template.AddNPCEquipment(eInventorySlot.ArmsArmor, 2930);
            template.AddNPCEquipment(eInventorySlot.HandsArmor, 2931);
            template.AddNPCEquipment(eInventorySlot.FeetArmor, 2932);

            Inventory = template.CloseTemplate();
            Level = 60;
            Name = "Artifact Items";
            GuildName = "Items that Level";
            Size = 54;
            RespawnInterval = 2000;
            MaxSpeedBase = 0;
            Realm = 0;
            Flags |= GameNPC.eFlags.PEACE;
            Catalog = MerchantCatalog.Create("ArtItems");

            return base.AddToWorld();
        }

		public void SendReply(GamePlayer player, string msg)
		{
        #endregion
			player.Out.SendMessage(msg, eChatType.CT_System, eChatLoc.CL_PopupWindow);
		}
	}
}







