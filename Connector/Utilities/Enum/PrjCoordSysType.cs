using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>地图投影坐标系类型。
    /// </para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrjCoordSysType
    {
        /// <summary>
        /// Adindan UTM Zone 37N。 
        /// </summary>
        PCS_ADINDAN_UTM_37N,          
        
        /// <summary>
        /// Adindan UTM Zone 38N。 
        /// </summary>
        PCS_ADINDAN_UTM_38N,                    
        
        /// <summary>
        /// Afgooye UTM Zone 38N。 
        /// </summary>
        PCS_AFGOOYE_UTM_38N,                    
        
        /// <summary>
        ///  Afgooye UTM Zone 39N。 
        ///  </summary>
        PCS_AFGOOYE_UTM_39N,                   
       
        /// <summary>
        /// AGD 1966 AMG Zone 48。 
        /// </summary>
        PCS_AGD_1966_AMG_48,                    
        
        /// <summary>
        /// AGD 1966 AMG Zone 49。 
        /// </summary>
        PCS_AGD_1966_AMG_49,                    
        
        /// <summary>
        /// AGD 1966 AMG Zone 50。
        /// </summary>
        PCS_AGD_1966_AMG_50,                     
        
        /// <summary>
        /// AGD 1966 AMG Zone 51。
        /// </summary>
        PCS_AGD_1966_AMG_51,                     
        
        /// <summary>
        /// AGD 1966 AMG Zone 52。
        /// </summary>
        PCS_AGD_1966_AMG_52,                     
       
        /// <summary>
        /// AGD 1966 AMG Zone 53。 
        /// </summary>
        PCS_AGD_1966_AMG_53,                    
        
        /// <summary>
        /// AGD 1966 AMG Zone 54。 
        /// </summary>
        PCS_AGD_1966_AMG_54,                    
        
        /// <summary>
        /// AGD 1966 AMG Zone 55。 
        /// </summary>
        PCS_AGD_1966_AMG_55,                    
        
        /// <summary>
        /// AGD 1966 AMG Zone 56。
        /// </summary>
        PCS_AGD_1966_AMG_56,                     
        
        /// <summary>
        /// AGD 1966 AMG Zone 57。
        /// </summary>
        PCS_AGD_1966_AMG_57,                     
        
        /// <summary>
        /// AGD 1966 AMG Zone 58。
        /// </summary>
        PCS_AGD_1966_AMG_58,                     
        
        /// <summary>
        /// AGD 1984 AMG Zone 48。
        /// </summary>
        PCS_AGD_1984_AMG_48,                     
        
        /// <summary>
        /// AGD 1984 AMG Zone 49。 
        /// </summary>
        PCS_AGD_1984_AMG_49,                    
        
        /// <summary>
        /// AGD 1984 AMG Zone 50。 
        /// </summary>
        PCS_AGD_1984_AMG_50,                    
        
        /// <summary>
        /// AGD 1984 AMG Zone 51。 
        /// </summary>
        PCS_AGD_1984_AMG_51,                    
        
        /// <summary>
        /// AGD 1984 AMG Zone 52。
        /// </summary>
        PCS_AGD_1984_AMG_52,                     
        
        /// <summary>
        /// AGD 1984 AMG Zone 53。 
        /// </summary>
        PCS_AGD_1984_AMG_53,                    
        
        /// <summary>
        /// AGD 1984 AMG Zone 54。
        /// </summary>
        PCS_AGD_1984_AMG_54,                     
        
        /// <summary>
        /// AGD 1984 AMG Zone 55。
        /// </summary>
        PCS_AGD_1984_AMG_55,                     
        
        /// <summary>
        /// AGD 1984 AMG Zone 56。
        /// </summary>
        PCS_AGD_1984_AMG_56,                     
        
        /// <summary>
        /// AGD 1984 AMG Zone 57。
        /// </summary>
        PCS_AGD_1984_AMG_57,                    
        
        /// <summary>
        /// AGD 1984 AMG Zone 58。 
        /// </summary>
        PCS_AGD_1984_AMG_58,                    
       
        /// <summary>
        /// Bahrain State Grid。
        /// </summary>
        PCS_AIN_EL_ABD_BAHRAIN_GRID,                    
        
        /// <summary>
        /// Ain el Abd 1970 UTM Zone 37N。
        /// </summary>
        PCS_AIN_EL_ABD_UTM_37N,                     
        
        /// <summary>
        /// Ain el Abd 1970 UTM Zone 38N。
        /// </summary>
        PCS_AIN_EL_ABD_UTM_38N,                    
        
        /// <summary>
        /// Ain el Abd 1970 UTM Zone 39N。
        /// </summary>
        PCS_AIN_EL_ABD_UTM_39N,                    
       
        /// <summary>
        /// Aratu UTM Zone 22S。 
        /// </summary>
        PCS_ARATU_UTM_22S,                    
        
        /// <summary>
        /// Aratu UTM Zone 23S。 
        /// </summary>
        PCS_ARATU_UTM_23S,                    
        
        /// <summary>
        ///  Aratu UTM Zone 24S。
        ///  </summary>
        PCS_ARATU_UTM_24S,                   
        
        /// <summary>
        /// Nord de Guerre。
        /// </summary>
        PCS_ATF_NORD_DE_GUERRE,                    
        
        /// <summary>
        /// ATS 1977 UTM Zone 19N。
        /// </summary>
        PCS_ATS_1977_UTM_19N,                    
        
        /// <summary>
        /// ATS 1977 UTM Zone 20N。
        /// </summary>
        PCS_ATS_1977_UTM_20N,                    
        
        /// <summary>
        /// Batavia UTM Zone 48S。
        /// </summary>
        PCS_BATAVIA_UTM_48S,                    
       
        /// <summary>
        /// Batavia UTM Zone 49S。
        /// </summary>
        PCS_BATAVIA_UTM_49S,                    
        
        /// <summary>
        /// Batavia UTM Zone 50S。
        /// </summary>
        PCS_BATAVIA_UTM_50S,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 13。
        /// </summary>
        PCS_BEIJING_1954_GK_13,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 13N。
        /// </summary>
        PCS_BEIJING_1954_GK_13N,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 14。
        /// </summary>
        PCS_BEIJING_1954_GK_14,                     
        
        /// <summary>
        /// Beijing 1954 GK Zone 14N。
        /// </summary>
        PCS_BEIJING_1954_GK_14N,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 15。
        /// </summary>
        PCS_BEIJING_1954_GK_15,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 15N。
        /// </summary>
        PCS_BEIJING_1954_GK_15N,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 16。
        /// </summary>
        PCS_BEIJING_1954_GK_16,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 16N。
        /// </summary>
        PCS_BEIJING_1954_GK_16N,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 17。
        /// </summary>
        PCS_BEIJING_1954_GK_17,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 17N。 
        /// </summary>
        PCS_BEIJING_1954_GK_17N,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 18。
        /// </summary>
        PCS_BEIJING_1954_GK_18,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 18N。
        /// </summary>
        PCS_BEIJING_1954_GK_18N,                     
        
        /// <summary>
        /// Beijing 1954 GK Zone 19。
        /// </summary>
        PCS_BEIJING_1954_GK_19,                     
        
        /// <summary>
        /// Beijing 1954 GK Zone 19N。 
        /// </summary>
        PCS_BEIJING_1954_GK_19N,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 20。 
        /// </summary>
        PCS_BEIJING_1954_GK_20,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 20N。 
        /// </summary>
        PCS_BEIJING_1954_GK_20N,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone。
        /// </summary>
        PCS_BEIJING_1954_GK_21,                     
        
        /// <summary>
        /// Beijing 1954 GK Zone 21N。
        /// </summary>
        PCS_BEIJING_1954_GK_21N,                     
        
        /// <summary>
        /// Beijing 1954 GK Zone 22。 
        /// </summary>
        PCS_BEIJING_1954_GK_22,                    
        
        /// <summary>
        /// Beijing 1954 GK Zone 22N。
        /// </summary>
        PCS_BEIJING_1954_GK_22N,                     
        
        /// <summary>
        /// Beijing 1954 GK Zone 23。
        /// </summary>
        PCS_BEIJING_1954_GK_23,                   
        
        /// <summary>
        ///  Beijing 1954 GK Zone 23。 
        ///  </summary>
        PCS_BEIJING_1954_GK_23N,                    
        
        /// <summary>
        /// Belge Lambert 1950。 
        /// </summary>
        PCS_BELGE_LAMBERT_1950,                    
        
        /// <summary>
        /// Colombia Bogota Zone。 
        /// </summary>
        PCS_BOGOTA_COLOMBIA_BOGOTA,                    
        
        /// <summary>
        /// Colombia E Central Zone。
        /// </summary>
        PCS_BOGOTA_COLOMBIA_E_CENTRAL,                     
        
        /// <summary>
        /// Colombia East Zone。
        /// </summary>
        PCS_BOGOTA_COLOMBIA_EAST,                     
        
        /// <summary>
        /// Colombia West Zone。
        /// </summary>
        PCS_BOGOTA_COLOMBIA_WEST,                    
        
        /// <summary>
        /// Bogota UTM Zone 17N。 
        /// </summary>
        PCS_BOGOTA_UTM_17N,                    
        
        /// <summary>
        ///  Bogota UTM Zone 18N。
        /// </summary>
        PCS_BOGOTA_UTM_18N,                    
        
        /// <summary>
        /// Argentina Zone 1。 
        /// </summary>
        PCS_C_INCHAUSARGENTINA_1,                    
        
        /// <summary>
        /// Argentina Zone 2。 
        /// </summary>
        PCS_C_INCHAUSARGENTINA_2,                    
        
        /// <summary>
        /// Argentina Zone 3。 
        /// </summary>
        PCS_C_INCHAUSARGENTINA_3,                     
        
        /// <summary>
        /// Argentina Zone 4。 
        /// </summary>
        PCS_C_INCHAUSARGENTINA_4,                   
        
        /// <summary>
        /// Argentina Zone 5。
        /// </summary>
        PCS_C_INCHAUSARGENTINA_5,                    
        
        /// <summary>
        /// Argentina Zone 6。
        /// </summary>
        PCS_C_INCHAUSARGENTINA_6,                    
        
        /// <summary>
        /// Argentina Zone 7。 
        /// </summary>
        PCS_C_INCHAUSARGENTINA_7,                   
        
        /// <summary>
        /// Camacupa UTM Zone 32S。 
        /// </summary>
        PCS_CAMACUPA_UTM_32S,                    
        
        /// <summary>
        /// Camacupa UTM Zone 33S。 
        /// </summary>
        PCS_CAMACUPA_UTM_33S,                    
        
        /// <summary>
        /// Nord Tunisie。 
        /// </summary>
        PCS_CARTHAGE_NORD_TUNISIE,                    
        
        /// <summary>
        /// Sud Tunisie。
        /// </summary>
        PCS_CARTHAGE_SUD_TUNISIE,                     
        
        /// <summary>
        /// Carthage UTM Zone 32N。
        /// </summary>
        PCS_CARTHAGE_UTM_32N,                     
        
        /// <summary>
        /// Corrego Alegre UTM Zone。 
        /// </summary>
        PCS_CORREGO_ALEGRE_UTM_23S,                    
        
        /// <summary>
        /// Corrego Alegre UTM Zone 24S。
        /// </summary>
        PCS_CORREGO_ALEGRE_UTM_24S,                     
        
        /// <summary>
        /// Datum 73 UTM Zone 29N。 
        /// </summary>
        PCS_DATUM_73_UTM_ZONE_29N,                    
        
        /// <summary>
        /// Stereo 1933。 
        /// </summary>
        PCS_DEALUL_PISCULUI_1933_STEREO_33,                    
        
        /// <summary>
        /// Stereo 1970。 
        /// </summary>
        PCS_DEALUL_PISCULUI_1970_STEREO_EALUL_PISCULUI_1970_STEREO_70,                    
        
        /// <summary>
        /// Germany Zone 1。
        /// </summary>
        PCS_DHDN_GERMANY_1,                     
        
        /// <summary>
        ///  Germany Zone 2。 
        ///  </summary>
        PCS_DHDN_GERMANY_2,                   
        
        /// <summary>
        /// Germany Zone 3。 
        /// </summary>
        PCS_DHDN_GERMANY_3,                    
        
        /// <summary>
        /// Germany Zone 4。
        /// </summary>
        PCS_DHDN_GERMANY_4,                     
        
        /// <summary>
        /// Germany Zone 5。 
        /// </summary>
        PCS_DHDN_GERMANY_5,                    
        
        /// <summary>
        /// Douala UTM Zone。
        /// </summary>
        PCS_DOUALA_UTM_32N,                     
        
        /// <summary>
        /// 地理经纬坐标。</summary>
        PCS_EARTH_LONGITUDE_LATITUDE,                      
        
        /// <summary>
        /// European Datum 1950 UTM Zone 28N。 
        /// </summary>
        PCS_ED_1950_UTM_28N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 29N。 
        /// </summary>
        PCS_ED_1950_UTM_29N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 30N。 
        /// </summary>
        PCS_ED_1950_UTM_30N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 31N。
        /// </summary>
        PCS_ED_1950_UTM_31N,                     
        
        /// <summary>
        /// European Datum 1950 UTM Zone 32N。 
        /// </summary>
        PCS_ED_1950_UTM_32N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 33N。 
        /// </summary>
        PCS_ED_1950_UTM_33N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 34N。 
        /// </summary>
        PCS_ED_1950_UTM_34N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 35N。 
        /// </summary>
        PCS_ED_1950_UTM_35N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 36N。
        /// </summary>
        PCS_ED_1950_UTM_36N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 37N。
        /// </summary>
        PCS_ED_1950_UTM_37N,                    
        
        /// <summary>
        /// European Datum 1950 UTM Zone 38N。
        /// </summary>
        PCS_ED_1950_UTM_38N,                    
        
        /// <summary>
        /// Egypt Extended Purple Belt。 
        /// </summary>
        PCS_EGYPT_EXT_PURPLE_BELT,                    
        
        /// <summary>
        /// Egypt Purple Belt。
        /// </summary>
        PCS_EGYPT_PURPLE_BELT,                     
        
        /// <summary>
        /// Egypt Red Belt。 
        /// </summary>
        PCS_EGYPT_RED_BELT,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 28N。
        /// </summary>
        PCS_ETRS_1989_UTM_28N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 29N。
        /// </summary>
        PCS_ETRS_1989_UTM_29N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 30N。 
        /// </summary>
        PCS_ETRS_1989_UTM_30N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 31N。
        /// </summary>
        PCS_ETRS_1989_UTM_31N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 32N。 
        /// </summary>
        PCS_ETRS_1989_UTM_32N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 33N。 
        /// </summary>
        PCS_ETRS_1989_UTM_33N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 34N。
        /// </summary>
        PCS_ETRS_1989_UTM_34N,                     
        
        /// <summary>
        /// ETRS 1989 UTM Zone 35N。
        /// </summary>
        PCS_ETRS_1989_UTM_35N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 36N。
        /// </summary>
        PCS_ETRS_1989_UTM_36N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 37N。
        /// </summary>
        PCS_ETRS_1989_UTM_37N,                    
        
        /// <summary>
        /// ETRS 1989 UTM Zone 38N。 
        /// </summary>
        PCS_ETRS_1989_UTM_38N,                    
        
        /// <summary>
        /// Fahud UTM Zone 39N。 
        /// </summary>
        PCS_FAHUD_UTM_39N,                   
        
        /// <summary>
        ///   Fahud UTM Zone 40N。 
        /// </summary>
        PCS_FAHUD_UTM_40N,                  
        
        /// <summary>
        ///  Garoua UTM Zone 33N。
        ///  </summary>
        PCS_GAROUA_UTM_33N,                    
        
        /// <summary>
        /// GDA 1994 MGA Zone 48。
        /// </summary>
        PCS_GDA_1994_MGA_48,                    
        
        /// <summary>
        /// GDA 1994 MGA Zone 49。
        /// </summary>
        PCS_GDA_1994_MGA_49,                    
        
        /// <summary>
        /// GDA 1994 MGA Zone 50。
        /// </summary>
        PCS_GDA_1994_MGA_50,                    
        
        /// <summary>
        /// GDA 1994 MGA Zone 51。 
        /// </summary>
        PCS_GDA_1994_MGA_51,                    
        
        /// <summary>
        /// GDA 1994 MGA Zone 52。 
        /// </summary>
        PCS_GDA_1994_MGA_52,                    
        
        /// <summary>
        /// GDA 1994 MGA Zone 53。 
        /// </summary>
        PCS_GDA_1994_MGA_53,                    
        
        /// <summary>
        /// GDA 1994 MGA Zone 54。
        /// </summary>
        PCS_GDA_1994_MGA_54,                     
        
        /// <summary>
        /// GDA 1994 MGA Zone 55。
        /// </summary>
        PCS_GDA_1994_MGA_55,                     
        
        /// <summary>
        /// GDA 1994 MGA Zone 56。
        /// </summary>
        PCS_GDA_1994_MGA_56,                     
        
        /// <summary>
        /// GDA 1994 MGA Zone 57。
        /// </summary>
        PCS_GDA_1994_MGA_57,                    
        
        /// <summary>
        /// GDA 1994 MGA Zone 58。 
        /// </summary>
        PCS_GDA_1994_MGA_58,                    
       
        /// <summary>
        /// Greek Grid。
        /// </summary>
        PCS_GGRS_1987_GREEK_GRID,                     
        
        /// <summary>
        ///  Indonesia 1974 UTM Zone 46N。
        /// </summary>
        PCS_ID_1974_UTM_46N,                 
       
        /// <summary>
        /// Indonesia 1974 UTM Zone 46S。
        /// </summary>
        PCS_ID_1974_UTM_46S,                   
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 47N。
        /// </summary>
        PCS_ID_1974_UTM_47N,                  
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 47S。
        /// </summary>
        PCS_ID_1974_UTM_47S,                    
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 48N。 
        /// </summary>
        PCS_ID_1974_UTM_48N,                    
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 48S。
        /// </summary>
        PCS_ID_1974_UTM_48S,                    
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 49N。
        /// </summary>
        PCS_ID_1974_UTM_49N,                    
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 49S。 
        /// </summary>
        PCS_ID_1974_UTM_49S,             
        
        /// <summary>
        ///  Indonesia 1974 UTM Zone 50N。
        ///  </summary>
        PCS_ID_1974_UTM_50N,                   
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 50S。
        /// </summary>
        PCS_ID_1974_UTM_50S,                    
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 51N。 
        /// </summary>
        PCS_ID_1974_UTM_51N,                    
        

        /// <summary>
        /// Indonesia 1974 UTM Zone 51S。 
        /// </summary>
        PCS_ID_1974_UTM_51S,                    
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 52N。 
        /// </summary>
        PCS_ID_1974_UTM_52N,                    
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 52S。 
        /// </summary>
        PCS_ID_1974_UTM_52S,                    
        
        /// <summary>
        /// Indonesia 1974 UTM Zone 53N。
        /// </summary>
        PCS_ID_1974_UTM_53N,                    
        
        /// <summary>
        ///  Indonesia 1974 UTM Zone 53S。
        ///  </summary>
        PCS_ID_1974_UTM_53S,                   
        
        /// <summary>
        ///  Indonesia 1974 UTM Zone 54S。 
        ///  </summary>
        PCS_ID_1974_UTM_54S,                   
        
        /// <summary>
        /// Indian 1954 UTM Zone 47N。
        /// </summary>
        PCS_INDIAN_1954_UTM_47N,                    
        
        /// <summary>
        /// Indian 1954 UTM Zone 48N。
        /// </summary>
        PCS_INDIAN_1954_UTM_48N,                    
        
        /// <summary>
        /// Indian 1975 UTM Zone 47N。
        /// </summary>
        PCS_INDIAN_1975_UTM_47N,                    
        
        /// <summary>
        /// Indian 1975 UTM Zone 48N。
        /// </summary>
        PCS_INDIAN_1975_UTM_48N,                    
        
        /// <summary>
        /// Jamaica Grid。 
        /// </summary>
        PCS_JAD_1969_JAMAICA_GRID,                    
        
        /// <summary>
        ///  Jamaica 1875 Old Grid。
        ///  </summary>
        PCS_JAMAICA_1875_OLD_GRID,                   
        
        /// <summary>
        ///  Japanese Zone I。 
        ///  </summary>
        PCS_JAPAN_PLATE_ZONE_I,                    
        
        /// <summary>
        /// Japanese Zone II。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_II,                     
        
        /// <summary>
        /// Japanese Zone III。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_III,                     
        
        /// <summary>
        /// Japanese Zone IV。 
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_IV,                     
        
        /// <summary>
        ///  Japanese Zone IX。 
        ///  </summary>
        PCS_JAPAN_PLATE_ZONE_IX,                    
        
        /// <summary>
        ///  Japanese Zone V。
        ///  </summary>
        PCS_JAPAN_PLATE_ZONE_V,                    
        
        /// <summary>
        /// Japanese Zone VI。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_VI,                
        
        /// <summary>
        /// Japanese Zone VII。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_VII,                     
        
        /// <summary>
        /// Japanese Zone VIII。 
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_VIII,                     
        
        /// <summary>
        /// Japanese Zone X。 
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_X,                     
        
        /// <summary>
        /// Japanese Zone XI。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XI,                     
        
        /// <summary>
        /// Japanese Zone XII。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XII,                     
        
        /// <summary>
        /// Japanese Zone XIII。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XIII,                     
        
        /// <summary>
        /// Japanese Zone XIV。 
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XIV,                     
        
        /// <summary>
        /// Japanese Zone XIX。 
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XIX,                     
        
        /// <summary>
        /// Japanese Zone XV。 
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XV,                     
        
        /// <summary>
        /// Japanese Zone XVI。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XVI,                     
        
        /// <summary>
        /// Japanese Zone XVII。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XVII,                     
        
        /// <summary>
        /// Japanese Zone XVIII。
        /// </summary>
        PCS_JAPAN_PLATE_ZONE_XVIII,                     
        
        /// <summary>
        /// 日本测地系2000，UTM投影系51。 
        /// </summary>
        PCS_JAPAN_UTM_51,                     
        
        /// <summary>
        /// 日本测地系2000，UTM投影系52。
        /// </summary>
        PCS_JAPAN_UTM_52,                     
        
        /// <summary>
        /// 日本测地系2000，UTM投影系53。
        /// </summary>
        PCS_JAPAN_UTM_53,                     
        
        /// <summary>
        /// 日本测地系2000，UTM投影系54。 
        /// </summary>
        PCS_JAPAN_UTM_54,                     
        
        /// <summary>
        /// 日本测地系2000，UTM投影系55。
        /// </summary>
        PCS_JAPAN_UTM_55,                     
        
        /// <summary>
        /// 日本测地系2000，UTM投影系56。
        /// </summary>
        PCS_JAPAN_UTM_56,                     
        
        /// <summary>
        /// India Zone 0。
        /// </summary>
        PCS_KALIANPUR_INDIA_0,                    
        
        /// <summary>
        /// India Zone I。 
        /// </summary>
        PCS_KALIANPUR_INDIA_I,                    
        
        /// <summary>
        /// India Zone IIa。 
        /// </summary>
        PCS_KALIANPUR_INDIA_IIA,                    
        
        /// <summary>
        /// India Zone IIb。
        /// </summary>
        PCS_KALIANPUR_INDIA_IIB,                    
        
        /// <summary>
        /// India Zone IIIa。 
        /// </summary>
        PCS_KALIANPUR_INDIA_IIIA,                    
        
        /// <summary>
        /// India Zone IIIb。
        /// </summary>
        PCS_KALIANPUR_INDIA_IIIB,                    
        
        /// <summary>
        /// India Zone IVa。 
        /// </summary>
        PCS_KALIANPUR_INDIA_IVA,          
        
        /// <summary>
        /// India Zone IVb。
        /// </summary>
        PCS_KALIANPUR_INDIA_IVB,                    
        
        /// <summary>
        /// Kertau UTM Zone 47N。
        /// </summary>
        PCS_KERTAU_UTM_47N,                    
        
        /// <summary>
        /// Kertau UTM Zone 48N。
        /// </summary>
        PCS_KERTAU_UTM_48N,           
        
        /// <summary>
        /// Finland Zone 1。
        /// </summary>
        PCS_KKJ_FINLAND_1,                    
        
        /// <summary>
        /// Finland Zone 2。 
        /// </summary>
        PCS_KKJ_FINLAND_2,                    
       
        /// <summary>
        /// Finland Zone 3。 
        /// </summary>
        PCS_KKJ_FINLAND_3,          
        
        /// <summary>
        /// Finland Zone 4。 
        /// </summary>
        PCS_KKJ_FINLAND_4,                    
        
        /// <summary>
        /// Kuwait Oil Co - Lambert。
        /// </summary>
        PCS_KOC_LAMBERT,                    
        
        /// <summary>
        /// Kuwait Utility KTM。
        /// </summary>
        PCS_KUDAMS_KTM,                     
        
        /// <summary>
        /// La Canoa UTM Zone 20N。 
        /// </summary>
        PCS_LA_CANOA_UTM_20N,          
        
        /// <summary>
        /// La Canoa UTM Zone 21N。
        /// </summary>
        PCS_LA_CANOA_UTM_21N,                    
        
        /// <summary>
        /// Ghana Metre Grid。 
        /// </summary>
        PCS_LEIGON_GHANA_GRID,                    
        
        /// <summary>
        /// Portuguese National Grid。 
        /// </summary>
        PCS_LISBON_PORTUGUESE_GRID,                    
        
        /// <summary>
        /// Lome UTM Zone 31N。 
        /// </summary>
        PCS_LOME_UTM_31N,          
        
        /// <summary>
        /// Philippines Zone I。 
        /// </summary>
        PCS_LUZON_PHILIPPINES_I,                    
        
        /// <summary>
        /// Philippines Zone II。 
        /// </summary>
        PCS_LUZON_PHILIPPINES_II,          
        
        /// <summary>
        /// Philippines Zone III。
        /// </summary>
        PCS_LUZON_PHILIPPINES_III,                    
        
        /// <summary>
        /// Philippines Zone IV。 
        /// </summary>
        PCS_LUZON_PHILIPPINES_IV,                    
        
        /// <summary>
        /// Philippines Zone V。
        /// </summary>
        PCS_LUZON_PHILIPPINES_V,                    
        
        /// <summary>
        /// Malongo 1987 UTM Zone 32S 。 
        /// </summary>
        PCS_MALONGO_1987_UTM_32S,          
        
        /// <summary>
        /// Massawa UTM Zone 37N。 
        /// </summary>
        PCS_MASSAWA_UTM_37N,                    
        
        /// <summary>
        /// Nord Maroc。 
        /// </summary>
        PCS_MERCHICH_NORD_MAROC,          
        
        /// <summary>
        /// Sahara。 
        /// </summary>
        PCS_MERCHICH_SAHARA,          
        
        /// <summary>
        /// Sud Maroc。 
        /// </summary>
        PCS_MERCHICH_SUD_MAROC,                    
        
        /// <summary>
        /// Austria (Ferro) Cent. 
        /// </summary>
        PCS_MGI_FERRO_AUSTRIA_CENTRAL,          
        
        /// <summary>
        /// Austria (Ferro) East Zone。
        /// </summary>
        PCS_MGI_FERRO_AUSTRIA_EAST,                    
        
        /// <summary>
        /// Austria (Ferro) West Zone。 
        /// </summary>
        PCS_MGI_FERRO_AUSTRIA_WEST,                    
        
        /// <summary>
        /// Mhast UTM Zone 32S。 
        /// </summary>
        PCS_MHAST_UTM_32S,                    
        
        /// <summary>
        /// Nigeria East Belt。 
        /// </summary>
        PCS_MINNA_NIGERIA_EAST_BELT,                    
        
        /// <summary>
        /// Nigeria Mid Belt。 
        /// </summary>
        PCS_MINNA_NIGERIA_MID_BELT,                    
        
        /// <summary>
        /// Nigeria West Belt。 
        /// </summary>
        PCS_MINNA_NIGERIA_WEST_BELT,                    
        
        /// <summary>
        /// Minna UTM Zone 31N。 
        /// </summary>
        PCS_MINNA_UTM_31N,          
        
        /// <summary>
        /// Minna UTM Zone 32N。
        /// </summary>
        PCS_MINNA_UTM_32N,                    
        
        /// <summary>
        /// Monte Mario (Rome) Italy 1。
        /// </summary>
        PCS_MONTE_MARIO_ROME_ITALY_1,          
        
        /// <summary>
        /// Monte Mario (Rome) Italy 2。 
        /// </summary>
        PCS_MONTE_MARIO_ROME_ITALY_2,          
            
        /// <summary>
        /// M'poraloko UTM Zone 32N。 
        /// </summary>
        PCS_MPORALOKO_UTM_32N,          
        
        /// <summary>
        /// M'poraloko UTM Zone 32S。 
        /// </summary>
        PCS_MPORALOKO_UTM_32S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 1。 
        /// </summary>
        PCS_NAD_1927_AK_1,        
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 10。
        /// </summary>
        PCS_NAD_1927_AK_10,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 2。
        /// </summary>
        PCS_NAD_1927_AK_2,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 3。 
        /// </summary>
        PCS_NAD_1927_AK_3,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 4。
        /// </summary>
        PCS_NAD_1927_AK_4,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 5。 
        /// </summary>
        PCS_NAD_1927_AK_5,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 6。
        /// </summary>
        PCS_NAD_1927_AK_6,           
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 7。
        /// </summary>
        PCS_NAD_1927_AK_7,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 8。
        /// </summary>
        PCS_NAD_1927_AK_8,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alaska 9。 
        /// </summary>
        PCS_NAD_1927_AK_9,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alabama East。
        /// </summary>
        PCS_NAD_1927_AL_E,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Alabama West。
        /// </summary>
        PCS_NAD_1927_AL_W,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Arkansas North。
        /// </summary>
        PCS_NAD_1927_AR_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Arkansas South。 
        /// </summary>
        PCS_NAD_1927_AR_S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Arizona Central。
        /// </summary>
        PCS_NAD_1927_AZ_C,          
        
        /// <summary> 
        /// NAD 1927 SPCS Zone Arizona East。 
        /// </summary>
        PCS_NAD_1927_AZ_E,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Arizona West。
        /// </summary>
        PCS_NAD_1927_AZ_W,                    
        
        /// <summary>
        /// NAD 1927 BLM Zone 14N。 
        /// </summary>
        PCS_NAD_1927_BLM_14N,          
        
        /// <summary>
        ///  NAD 1927 BLM Zone 15N。 
        ///  </summary>
        PCS_NAD_1927_BLM_15N,                   
        
        /// <summary>
        /// NAD 1927 BLM Zone 16N。
        /// </summary>
        PCS_NAD_1927_BLM_16N,                    
        
        /// <summary>
        /// NAD 1927 BLM Zone 17N。 
        /// </summary>
        PCS_NAD_1927_BLM_17N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone California I。
        /// </summary>
        PCS_NAD_1927_CA_I,         
        
        /// <summary>
        /// NAD 1927 SPCS Zone California II。
        /// </summary>
        PCS_NAD_1927_CA_II,                             
        
        /// <summary>
        /// NAD 1927 SPCS Zone California II。
        /// </summary>
        PCS_NAD_1927_CA_III,                    
        
        /// <summary>
        ///  NAD 1927 SPCS Zone California IV。 
        ///  </summary>
        PCS_NAD_1927_CA_IV,         
        
        /// <summary>
        /// NAD 1927 SPCS Zone California V。
        /// </summary>
        PCS_NAD_1927_CA_V,                             
        
        /// <summary>
        /// NAD 1927 SPCS Zone California VI。 
        /// </summary>
        PCS_NAD_1927_CA_VI,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone California VII。
        /// </summary>
        PCS_NAD_1927_CA_VII,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Colorado Central。 
        /// </summary>
        PCS_NAD_1927_CO_C,                    
        
        /// <summary>
        ///  NAD 1927 SPCS Zone Colorado North。 
        /// </summary>
        PCS_NAD_1927_CO_N,         
        
    
        /// <summary>
        /// NAD 1927 SPCS Zone Colorado South。
        /// </summary>
        PCS_NAD_1927_CO_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Connecticut。 
        /// </summary>
        PCS_NAD_1927_CT,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Delaware。
        /// </summary>
        PCS_NAD_1927_DE,                     
        
        /// <summary>
        /// NAD 1927 SPCS Zone Florida East。
        /// </summary>
        PCS_NAD_1927_FL_E,           
        
        /// <summary>
        /// NAD 1927 SPCS Zone Florida North。 
        /// </summary>
        PCS_NAD_1927_FL_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Florida West。 
        /// </summary>
        PCS_NAD_1927_FL_W,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Georgia East。
        /// </summary>
        PCS_NAD_1927_GA_E,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Georgia West。 
        /// </summary>
        PCS_NAD_1927_GA_W,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Guam。 
        /// </summary>
        PCS_NAD_1927_GU,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Hawaii 1。 
        /// </summary>
        PCS_NAD_1927_HI_1,                             
        
        /// <summary>
        /// NAD 1927 SPCS Zone Hawaii 2。 
        /// </summary>
        PCS_NAD_1927_HI_2,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Hawaii 3。 
        /// </summary>
        PCS_NAD_1927_HI_3,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Hawaii 4。
        /// </summary>
        PCS_NAD_1927_HI_4,           
        
        /// <summary>
        /// NAD 1927 SPCS Zone Hawaii 5。 
        /// </summary>
        PCS_NAD_1927_HI_5,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Iowa North。
        /// </summary>
        PCS_NAD_1927_IA_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Iowa South。 
        /// </summary>
        PCS_NAD_1927_IA_S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Idaho Central。
        /// </summary>
        PCS_NAD_1927_ID_C,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Idaho East。
        /// </summary>
        PCS_NAD_1927_ID_E,                    
        
        /// <summary>
        /// 1927 SPCS Zone Idaho West。 
        /// </summary>
        PCS_NAD_1927_ID_W,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Illinois East。
        /// </summary>
        PCS_NAD_1927_IL_E,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Illinois West。 
        /// </summary>
        PCS_NAD_1927_IL_W,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Indiana East。 
        /// </summary>
        PCS_NAD_1927_IN_E,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Indiana West。 
        /// </summary>
        PCS_NAD_1927_IN_W,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Kansas North。 
        /// </summary>
        PCS_NAD_1927_KS_N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Kansas South。 
        /// </summary>
        PCS_NAD_1927_KS_S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Kentucky North。 
        /// </summary>
        PCS_NAD_1927_KY_N,           
        
        /// <summary>
        /// NAD 1927 SPCS Zone Kentucky South。
        /// </summary>
        PCS_NAD_1927_KY_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Louisiana North。 
        /// </summary>
        PCS_NAD_1927_LA_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Louisiana South。
        /// </summary>
        PCS_NAD_1927_LA_S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Mass. 
        /// </summary>
        PCS_NAD_1927_MA_I,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Mass.
        /// </summary>
        PCS_NAD_1927_MA_M,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Maryland。
        /// </summary>
        PCS_NAD_1927_MD,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Maine East。 
        /// </summary>
        PCS_NAD_1927_ME_E,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Maine West。
        /// </summary>
        PCS_NAD_1927_ME_W,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Michigan Central。
        /// </summary>
        PCS_NAD_1927_MI_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Michigan North。 
        /// </summary>
        PCS_NAD_1927_MI_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Michigan South。
        /// </summary>
        PCS_NAD_1927_MI_S,           
        
        /// <summary>
        /// NAD 1927 SPCS Zone Minnesota Central。
        /// </summary>
        PCS_NAD_1927_MN_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Minnesota North。 
        /// </summary>
        PCS_NAD_1927_MN_N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Minnesota South。
        /// </summary>
        PCS_NAD_1927_MN_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Missouri Central。
        /// </summary>
        PCS_NAD_1927_MO_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Missouri East。 
        /// </summary>
        PCS_NAD_1927_MO_E,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Missouri West。
        /// </summary>
        PCS_NAD_1927_MO_W,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Mississippi East。
        /// </summary>
        PCS_NAD_1927_MS_E,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Mississippi West。
        /// </summary>
        PCS_NAD_1927_MS_W,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Montana Central。
        /// </summary>
        PCS_NAD_1927_MT_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Montana North。 
        /// </summary>
        PCS_NAD_1927_MT_N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Montana South。
        /// </summary>
        PCS_NAD_1927_MT_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone North Carolina。 
        /// </summary>
        PCS_NAD_1927_NC,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone North Dakota N。
        /// </summary>
        PCS_NAD_1927_ND_N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone North Dakota S。
        /// </summary>
        PCS_NAD_1927_ND_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Nebraska North。
        /// </summary>
        PCS_NAD_1927_NE_N,                    
        
        /// <summary>
        /// 
        /// NAD 1927 SPCS Zone Nebraska South。
        /// </summary>
        PCS_NAD_1927_NE_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone New Hampshire。 
        /// </summary>        
        PCS_NAD_1927_NH,                   
        
        /// <summary>
        /// NAD 1927 SPCS Zone New Jersey。 
        /// </summary>        
        PCS_NAD_1927_NJ,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone New Mexico Cent.。 
        /// </summary>
        PCS_NAD_1927_NM_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone New Mexico East。
        /// </summary>
        PCS_NAD_1927_NM_E,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone New Mexico West。
        /// </summary>
        PCS_NAD_1927_NM_W,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Nevada Central。 
        /// </summary>
        PCS_NAD_1927_NV_C,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Nevada East。
        /// </summary>
        PCS_NAD_1927_NV_E,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Nevada West。 
        /// </summary>
        PCS_NAD_1927_NV_W,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone New York Central。
        /// </summary>
        PCS_NAD_1927_NY_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone New York East。 
        /// </summary>
        PCS_NAD_1927_NY_E,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone NY Long Island。
        /// </summary>
        PCS_NAD_1927_NY_LI,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone New York West。
        /// </summary>
        PCS_NAD_1927_NY_W,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Ohio North。 
        /// </summary>
        PCS_NAD_1927_OH_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Ohio South。 
        /// </summary>
        PCS_NAD_1927_OH_S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Oklahoma North。
        /// </summary>
        PCS_NAD_1927_OK_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Oklahoma South。 
        /// </summary>
        PCS_NAD_1927_OK_S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Oregon North。
        /// </summary>
        PCS_NAD_1927_OR_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Oregon South。
        /// </summary>
        PCS_NAD_1927_OR_S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Pennsylvania N。
        /// </summary>
        PCS_NAD_1927_PA_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Pennsylvania S。
        /// </summary>
        PCS_NAD_1927_PA_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Puerto Rico。 
        /// </summary>
        PCS_NAD_1927_PR,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Rhode Island。
        /// </summary>
        PCS_NAD_1927_RI,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone South Carolina N。 
        /// </summary>
        PCS_NAD_1927_SC_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone South Carolina S。 
        /// </summary>
        PCS_NAD_1927_SC_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone South Dakota N。
        /// </summary>
        PCS_NAD_1927_SD_N,                             
        
        /// <summary>
        /// NAD 1927 SPCS Zone South Dakota S。 
        /// </summary>
        PCS_NAD_1927_SD_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Tennessee。 
        /// </summary>
        PCS_NAD_1927_TN,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Texas Central。
        /// </summary>
        PCS_NAD_1927_TX_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Texas North。 
        /// </summary>
        PCS_NAD_1927_TX_N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Texas North Cent.。
        /// </summary>
        PCS_NAD_1927_TX_NC,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Texas South。 
        /// </summary>
        PCS_NAD_1927_TX_S,                              
        
        /// <summary>
        /// NAD 1927 SPCS Zone Texas South Cent.。 
        /// </summary>
        PCS_NAD_1927_TX_SC,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Utah Central。 
        /// </summary>
        PCS_NAD_1927_UT_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Utah North。 
        /// </summary>
        PCS_NAD_1927_UT_N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Utah South。
        /// </summary>
        PCS_NAD_1927_UT_S,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 10N。 
        /// </summary>
        PCS_NAD_1927_UTM_10N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 11N。 
        /// </summary>
        PCS_NAD_1927_UTM_11N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 12N。 
        /// </summary>
        PCS_NAD_1927_UTM_12N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 13N。
        /// </summary>
        PCS_NAD_1927_UTM_13N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 14N。 
        /// </summary>
        PCS_NAD_1927_UTM_14N,          
        
        /// <summary>
        /// NAD 1927 UTM Zone 15N。
        /// </summary>
        PCS_NAD_1927_UTM_15N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 16N。 
        /// </summary>
        PCS_NAD_1927_UTM_16N,          
        
        /// <summary>
        /// NAD 1927 UTM Zone 17N。 
        /// </summary>
        PCS_NAD_1927_UTM_17N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 18N。 
        /// </summary>
        PCS_NAD_1927_UTM_18N,          
        
        /// <summary>
        /// NAD 1927 UTM Zone 19N。 
        /// </summary>
        PCS_NAD_1927_UTM_19N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 20N。
        /// </summary>
        PCS_NAD_1927_UTM_20N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 21N。
        /// </summary>
        PCS_NAD_1927_UTM_21N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 22N。 
        /// </summary>
        PCS_NAD_1927_UTM_22N,          
        
        /// <summary>
        /// NAD 1927 UTM Zone 3N。 
        /// </summary>
        PCS_NAD_1927_UTM_3N,          
        
        /// <summary>
        /// NAD 1927 UTM Zone 4N。 
        /// </summary>
        PCS_NAD_1927_UTM_4N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 5N。 
        /// </summary>
        PCS_NAD_1927_UTM_5N,          
        
        /// <summary>
        /// NAD 1927 UTM Zone 6N。
        /// </summary>
        PCS_NAD_1927_UTM_6N,           
        
        /// <summary>
        /// NAD 1927 UTM Zone 7N。
        /// </summary>
        PCS_NAD_1927_UTM_7N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 8N。 
        /// </summary>
        PCS_NAD_1927_UTM_8N,                    
        
        /// <summary>
        /// NAD 1927 UTM Zone 9N。
        /// </summary>
        PCS_NAD_1927_UTM_9N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Virginia North。 
        /// </summary>
        PCS_NAD_1927_VA_N,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone Virginia South。 
        /// </summary>
        PCS_NAD_1927_VA_S,          
        
        /// <summary>
        /// NAD 1927 SPCS Zone St.
        /// </summary>
        PCS_NAD_1927_VI,           
        
        /// <summary>
        /// NAD 1927 SPCS Zone Vermont。
        /// </summary>
        PCS_NAD_1927_VT,           
        
        /// <summary>
        /// NAD 1927 SPCS Zone Washington North。
        /// </summary>
        PCS_NAD_1927_WA_N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Washington South。
        /// </summary>
        PCS_NAD_1927_WA_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Wisconsin Central。
        /// </summary>
        PCS_NAD_1927_WI_C,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Wisconsin North。
        /// </summary>
        PCS_NAD_1927_WI_N,           
        
        /// <summary>
        /// NAD 1927 SPCS Zone Wisconsin South。
        /// </summary>
        PCS_NAD_1927_WI_S,                     
        
        /// <summary>
        /// NAD 1927 SPCS Zone West Virginia N。 
        /// </summary>
        PCS_NAD_1927_WV_N,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone West Virginia S。 
        /// </summary>
        PCS_NAD_1927_WV_S,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Wyoming I East。 
        /// </summary>
        PCS_NAD_1927_WY_E,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Wyoming II EC。
        /// </summary>
        PCS_NAD_1927_WY_EC,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Wyoming IV West。
        /// </summary>
        PCS_NAD_1927_WY_W,                    
        
        /// <summary>
        /// NAD 1927 SPCS Zone Wyoming III WC。 
        /// </summary>
        PCS_NAD_1927_WY_WC,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 1。 
        /// </summary>
        PCS_NAD_1983_AK_1,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 10。
        /// </summary>
        PCS_NAD_1983_AK_10,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 2。 
        /// </summary>
        PCS_NAD_1983_AK_2,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 3。
        /// </summary>
        PCS_NAD_1983_AK_3,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 4。
        /// </summary>
        PCS_NAD_1983_AK_4,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 5。
        /// </summary>
        PCS_NAD_1983_AK_5,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 6。 
        /// </summary>
        PCS_NAD_1983_AK_6,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 7。 
        /// </summary>
        PCS_NAD_1983_AK_7,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 8。
        /// </summary>
        PCS_NAD_1983_AK_8,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alaska 9。
        /// </summary>
        PCS_NAD_1983_AK_9,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alabama East。
        /// </summary>
        PCS_NAD_1983_AL_E,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Alabama West。 
        /// </summary>
        PCS_NAD_1983_AL_W,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Arkansas North。
        /// </summary>
        PCS_NAD_1983_AR_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Arkansas South。 
        /// </summary>
        PCS_NAD_1983_AR_S,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Arizona Central。 
        /// </summary>
        PCS_NAD_1983_AZ_C,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Arizona East。
        /// </summary>
        PCS_NAD_1983_AZ_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Arizona West。 
        /// </summary>
        PCS_NAD_1983_AZ_W,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone California I。 
        /// </summary>
        PCS_NAD_1983_CA_I,                    

        
        /// <summary>
        /// NAD 1983 SPCS Zone California II。
        /// </summary>
        PCS_NAD_1983_CA_II,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone California III。
        /// </summary>
        PCS_NAD_1983_CA_III,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone California IV。 
        /// </summary>
        PCS_NAD_1983_CA_IV,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone California V。
        /// </summary>
        PCS_NAD_1983_CA_V,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone California VI。
        /// </summary>
        PCS_NAD_1983_CA_VI,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Colorado Central。
        /// </summary>
        PCS_NAD_1983_CO_C,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Colorado North。 
        /// </summary>
        PCS_NAD_1983_CO_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Colorado South。 
        /// </summary>
        PCS_NAD_1983_CO_S,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Connecticut。
        /// </summary>
        PCS_NAD_1983_CT,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Delaware。
        /// </summary>
        PCS_NAD_1983_DE,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone Florida East。
        /// </summary>
        PCS_NAD_1983_FL_E,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Florida North。
        /// </summary>
        PCS_NAD_1983_FL_N,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone Florida West。 
        /// </summary>
        PCS_NAD_1983_FL_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Georgia East。
        /// </summary>
        PCS_NAD_1983_GA_E,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone Georgia West。
        /// </summary>
        PCS_NAD_1983_GA_W,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Guam。
        /// </summary>
        PCS_NAD_1983_GU,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Hawaii Zone 1。
        /// </summary>
        PCS_NAD_1983_HI_1,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Hawaii Zone 2。
        /// </summary>
        PCS_NAD_1983_HI_2,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone Hawaii Zone 3。
        /// </summary>
        PCS_NAD_1983_HI_3,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Hawaii Zone 4。
        /// </summary>
        PCS_NAD_1983_HI_4,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Hawaii Zone 5。
        /// </summary>
        PCS_NAD_1983_HI_5,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Iowa North。
        /// </summary>
        PCS_NAD_1983_IA_N,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone Iowa South。
        /// </summary>
        PCS_NAD_1983_IA_S,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Idaho Central。
        /// </summary>
        PCS_NAD_1983_ID_C,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Idaho East。 
        /// </summary>
        PCS_NAD_1983_ID_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Idaho West。
        /// </summary>
        PCS_NAD_1983_ID_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Illinois East。
        /// </summary>
        PCS_NAD_1983_IL_E,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Illinois West。
        /// </summary>
        PCS_NAD_1983_IL_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Indiana East。
        /// </summary>
        PCS_NAD_1983_IN_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Indiana West。 
        /// </summary>
        PCS_NAD_1983_IN_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Kansas North。 
        /// </summary>
        PCS_NAD_1983_KS_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Kansas South。 
        /// </summary>
        PCS_NAD_1983_KS_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Kentucky North。
        /// </summary>
        PCS_NAD_1983_KY_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Kentucky South。
        /// </summary>
        PCS_NAD_1983_KY_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Louisiana North。
        /// </summary>
        PCS_NAD_1983_LA_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Louisiana South。
        /// </summary>
        PCS_NAD_1983_LA_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Mass. 
        /// </summary>
        PCS_NAD_1983_MA_I,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Mass. 
        /// </summary>
        PCS_NAD_1983_MA_M,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Maryland。
        /// </summary>
        PCS_NAD_1983_MD,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Maine East。
        /// </summary>
        PCS_NAD_1983_ME_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Maine West。
        /// </summary>
        PCS_NAD_1983_ME_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Michigan Central。
        /// </summary>
        PCS_NAD_1983_MI_C,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Michigan North。 
        /// </summary>
        PCS_NAD_1983_MI_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Michigan South。 
        /// </summary>
        PCS_NAD_1983_MI_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Minnesota Central。
        /// </summary>
        PCS_NAD_1983_MN_C,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Minnesota North。
        /// </summary>
        PCS_NAD_1983_MN_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Minnesota South。 
        /// </summary>
        PCS_NAD_1983_MN_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Missouri Central。
        /// </summary>
        PCS_NAD_1983_MO_C,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Missouri East。 
        /// </summary>
        PCS_NAD_1983_MO_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Missouri West。 
        /// </summary>
        PCS_NAD_1983_MO_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Mississippi East。
        /// </summary>
        PCS_NAD_1983_MS_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Mississippi West。
        /// </summary>
        PCS_NAD_1983_MS_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Montana。 
        /// </summary>
        PCS_NAD_1983_MT,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone North Carolina。
        /// </summary>
        PCS_NAD_1983_NC,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone North Dakota N。 
        /// </summary>
        PCS_NAD_1983_ND_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone North Dakota S。
        /// </summary>
        PCS_NAD_1983_ND_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Nebraska。 
        /// </summary>
        PCS_NAD_1983_NE,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone New Hampshire。 
        /// </summary>
        PCS_NAD_1983_NH,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone New Jersey。 
        /// </summary>
        PCS_NAD_1983_NJ,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone New Mexico Cent.。 
        /// </summary>
        PCS_NAD_1983_NM_C,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone New Mexico East。
        /// </summary>
        PCS_NAD_1983_NM_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone New Mexico West。 
        /// </summary>
        PCS_NAD_1983_NM_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Nevada Central。 
        /// </summary>
        PCS_NAD_1983_NV_C,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Nevada East。
        /// </summary>
        PCS_NAD_1983_NV_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Nevada West。
        /// </summary>
        PCS_NAD_1983_NV_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone New York Central。
        /// </summary>
        PCS_NAD_1983_NY_C,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone New York East。 
        /// </summary>
        PCS_NAD_1983_NY_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone NY Long Island。
        /// </summary>
        PCS_NAD_1983_NY_LI,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone New York West。 
        /// </summary>
        PCS_NAD_1983_NY_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Ohio North。 
        /// </summary>
        PCS_NAD_1983_OH_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Ohio South。
        /// </summary>
        PCS_NAD_1983_OH_S,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Oklahoma North。
        /// </summary>
        PCS_NAD_1983_OK_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Oklahoma South。 
        /// </summary>
        PCS_NAD_1983_OK_S,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Oregon North。 
        /// </summary>
        PCS_NAD_1983_OR_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Oregon South。
        /// </summary>
        PCS_NAD_1983_OR_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Pennsylvania N。
        /// </summary>
        PCS_NAD_1983_PA_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Pennsylvania S。
        /// </summary>
        PCS_NAD_1983_PA_S,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone PR &amp; St。
        /// </summary>
        PCS_NAD_1983_PR_VI,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Rhode Island。 
        /// </summary>
        PCS_NAD_1983_RI,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone South Carolina。
        /// </summary>
        PCS_NAD_1983_SC,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone South Dakota N。
        /// </summary>
        PCS_NAD_1983_SD_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone South Dakota S。 
        /// </summary>
        PCS_NAD_1983_SD_S,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Tennessee。 
        /// </summary>
        PCS_NAD_1983_TN,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Texas Central。
        /// </summary>
        PCS_NAD_1983_TX_C,           
        
        /// <summary>
        /// NAD 1983 SPCS Zone Texas North。 
        /// </summary>
        PCS_NAD_1983_TX_N,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Texas North Cent.。
        /// </summary>
        PCS_NAD_1983_TX_NC,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Texas South。 
        /// </summary>
        PCS_NAD_1983_TX_S,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Texas South Cent.。 
        /// </summary>
        PCS_NAD_1983_TX_SC,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Utah Central。
        /// </summary>
        PCS_NAD_1983_UT_C,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Utah North。 
        /// </summary>
        PCS_NAD_1983_UT_N,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Utah South。
        /// </summary>
        PCS_NAD_1983_UT_S,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 10N。
        /// </summary>
        PCS_NAD_1983_UTM_10N,                    
        
        /// <summary>
        ///  NAD 1983 UTM Zone 11N。 
        ///  </summary>
        PCS_NAD_1983_UTM_11N,         
        
        /// <summary>
        /// NAD 1983 UTM Zone 12N。
        /// </summary>
        PCS_NAD_1983_UTM_12N,           
        
        /// <summary>
        /// NAD 1983 UTM Zone 13N。
        /// </summary>
        PCS_NAD_1983_UTM_13N,                     
        
        /// <summary>
        /// NAD 1983 UTM Zone 14N。
        /// </summary>
        PCS_NAD_1983_UTM_14N,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 15N。
        /// </summary>
        PCS_NAD_1983_UTM_15N,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 16N。
        /// </summary>
        PCS_NAD_1983_UTM_16N,                     
        
        /// <summary>
        /// NAD 1983 UTM Zone 17N。
        /// </summary>
        PCS_NAD_1983_UTM_17N,           
        
        /// <summary>
        /// NAD 1983 UTM Zone 18N。
        /// </summary>
        PCS_NAD_1983_UTM_18N,                     
        
        /// <summary>
        /// NAD 1983 UTM Zone 19N。 
        /// </summary>
        PCS_NAD_1983_UTM_19N,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 20N。 
        /// </summary>
        PCS_NAD_1983_UTM_20N,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 21N。 
        /// </summary>
        PCS_NAD_1983_UTM_21N,                    
        
        /// <summary>
        /// NAD 1983 UTM Zone 22N。
        /// </summary>
        PCS_NAD_1983_UTM_22N,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 23N。 
        /// </summary>
        PCS_NAD_1983_UTM_23N,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 3N。
        /// </summary>
        PCS_NAD_1983_UTM_3N,                    
        
        /// <summary>
        /// NAD 1983 UTM Zone 4N。 
        /// </summary>
        PCS_NAD_1983_UTM_4N,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 5N。
        /// </summary>
        PCS_NAD_1983_UTM_5N,                    
        
        /// <summary>
        /// NAD 1983 UTM Zone 6N。
        /// </summary>
        PCS_NAD_1983_UTM_6N,                    
        
        /// <summary>
        /// NAD 1983 UTM Zone 7N。 
        /// </summary>
        PCS_NAD_1983_UTM_7N,          
        
        /// <summary>
        /// NAD 1983 UTM Zone 8N。 
        /// </summary>
        PCS_NAD_1983_UTM_8N,                    
        
        /// <summary>
        /// NAD 1983 UTM Zone 9N。
        /// </summary>
        PCS_NAD_1983_UTM_9N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Virginia North。
        /// </summary>
        PCS_NAD_1983_VA_N,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Virginia South。
        /// </summary>
        PCS_NAD_1983_VA_S,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Vermont。 
        /// </summary>
        PCS_NAD_1983_VT,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Washington North。
        /// </summary>
        PCS_NAD_1983_WA_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Washington South。
        /// </summary>
        PCS_NAD_1983_WA_S,                     
        
        /// <summary>
        /// NAD 1983 SPCS Zone Wisconsin Central。
        /// </summary>
        PCS_NAD_1983_WI_C,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Wisconsin North。 
        /// </summary>
        PCS_NAD_1983_WI_N,          
        
        /// <summary>
        /// NAD 1983 SPCS Zone Wisconsin South。 
        /// </summary>
        PCS_NAD_1983_WI_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone West Virginia N。
        /// </summary>
        PCS_NAD_1983_WV_N,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone West Virginia S。
        /// </summary>
        PCS_NAD_1983_WV_S,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Wyoming I East。
        /// </summary>
        PCS_NAD_1983_WY_E,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Wyoming II EC。
        /// </summary>
        PCS_NAD_1983_WY_EC,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Wyoming IV West。
        /// </summary>
        PCS_NAD_1983_WY_W,                    
        
        /// <summary>
        /// NAD 1983 SPCS Zone Wyoming III WC。 
        /// </summary>
        PCS_NAD_1983_WY_WC,          
        
        /// <summary>
        /// Nahrwan 1967 UTM Zone 38N。 
        /// </summary>
        PCS_NAHRWAN_1967_UTM_38N,          
        
        /// <summary>
        /// Nahrwan 1967 UTM Zone 39N。 
        /// </summary>
        PCS_NAHRWAN_1967_UTM_39N,                    
        
        /// <summary>
        /// Nahrwan 1967 UTM Zone 40N。
        /// </summary>
        PCS_NAHRWAN_1967_UTM_40N,                    
        
        /// <summary>
        /// Naparima 1972 UTM Zone 20N。 
        /// </summary>
        PCS_NAPARIMA_1972_UTM_20N,          
        
        /// <summary>
        /// NGN UTM Zone 38N。 
        /// </summary>
        PCS_NGN_UTM_38N,          
        
        /// <summary>
        /// NGN UTM Zone 39N。
        /// </summary>
        PCS_NGN_UTM_39N,          
        
        /// <summary>
        /// 普通平面坐标系。</summary>
        PCS_NON_EARTH,                     
        
        /// <summary>
        /// Nord Sahara 1959 UTM Zone 29N。 
        /// </summary>
        PCS_NORD_SAHARA_UTM_29N,          
        
        /// <summary>
        /// Nord Sahara 1959 UTM Zone 30N。 
        /// </summary>
        PCS_NORD_SAHARA_UTM_30N,                    
        
        /// <summary>
        /// Nord Sahara 1959 UTM Zone 31N。
        /// </summary>
        PCS_NORD_SAHARA_UTM_31N,          
        
        /// <summary>
        /// Nord Sahara 1959 UTM Zone 32N。
        /// </summary>
        PCS_NORD_SAHARA_UTM_32N,          
        
        /// <summary>
        /// Centre France。
        /// </summary>
        PCS_NTF_CENTRE_FRANCE,                    
        
        /// <summary>
        /// Corse。
        /// </summary>
        PCS_NTF_CORSE,          
        
        /// <summary>
        /// France I。
        /// </summary>
        PCS_NTF_FRANCE_I,                    
        
        /// <summary>
        /// France II。 
        /// </summary>
        PCS_NTF_FRANCE_II,                    
        
        /// <summary>
        /// France III。
        /// </summary>
        PCS_NTF_FRANCE_III,                    
        
        /// <summary>
        /// France IV。
        /// </summary>
        PCS_NTF_FRANCE_IV,                    
        
        /// <summary>
        /// Nord France。 
        /// </summary>
        PCS_NTF_NORD_FRANCE,                    
        
        /// <summary>
        /// Sud France。 
        /// </summary>
        PCS_NTF_SUD_FRANCE,          
        
        /// <summary>
        /// New Zealand North Island。 
        /// </summary>
        PCS_NZGD_1949_NORTH_ISLAND,                    
        
        /// <summary>
        /// New Zealand South Island。 
        /// </summary>
        PCS_NZGD_1949_SOUTH_ISLAND,                    
        
        /// <summary>
        /// British National Grid。
        /// </summary>
        PCS_OSGB_1936_BRITISH_GRID,                    
        
        /// <summary>
        /// Pointe Noire UTM Zone 32S。
        /// </summary>
        PCS_POINTE_NOIRE_UTM_32S,          
        
        /// <summary>
        /// Peru Central Zone。
        /// </summary>
        PCS_PSAD_1956_PERU_CENTRAL,                    
        
        /// <summary>
        /// Peru East Zone。
        /// </summary>
        PCS_PSAD_1956_PERU_EAST,                     
        
        /// <summary>
        /// Peru West Zone。
        /// </summary>
        PCS_PSAD_1956_PERU_WEST,          
        
        /// <summary>
        /// Prov. S. Amer. Datum UTM Zone 17S。 
        /// </summary>
        PCS_PSAD_1956_UTM_17S,          
        
        /// <summary>
        /// Prov. S. Amer. Datum UTM Zone 18N。 
        /// </summary>
        PCS_PSAD_1956_UTM_18N,          
        
        /// <summary>
        /// Prov. S. Amer. Datum UTM Zone 18S。 
        /// </summary>
        PCS_PSAD_1956_UTM_18S,          
        
        /// <summary>
        /// Prov. S. Amer. Datum UTM Zone 19N。 
        /// </summary>
        PCS_PSAD_1956_UTM_19N,           
        
        /// <summary>
        /// Prov. S. Amer. Datum UTM Zone 19S。 
        /// </summary>
        PCS_PSAD_1956_UTM_19S,           
        
        /// <summary>
        /// Prov. S. Amer. Datum UTM Zone 20N。 
        /// </summary>
        PCS_PSAD_1956_UTM_20N,           
        
        /// <summary>
        /// Prov. S. Amer. Datum UTM Zone 20S。 
        /// </summary>
        PCS_PSAD_1956_UTM_20S,                     
        
        /// <summary>
        /// Prov. S. Amer. Datum UTM Zone 21N。 
        /// </summary>
        PCS_PSAD_1956_UTM_21N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 10。
        /// </summary>
        PCS_PULKOVO_1942_GK_10,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 10N。
        /// </summary>
        PCS_PULKOVO_1942_GK_10N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 11。 
        /// </summary>
        PCS_PULKOVO_1942_GK_11,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 11N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_11N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 12。 
        /// </summary>
        PCS_PULKOVO_1942_GK_12,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 12N。
        /// </summary>
        PCS_PULKOVO_1942_GK_12N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 13。 
        /// </summary>
        PCS_PULKOVO_1942_GK_13,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 13N。
        /// </summary>
        PCS_PULKOVO_1942_GK_13N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 14。 
        /// </summary>
        PCS_PULKOVO_1942_GK_14,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 14N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_14N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 15。 
        /// </summary>
        PCS_PULKOVO_1942_GK_15,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 15N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_15N,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 16。 
        /// </summary>
        PCS_PULKOVO_1942_GK_16,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 16N。
        /// </summary>
        PCS_PULKOVO_1942_GK_16N,                            
       
        /// <summary>
        /// Pulkovo 1942 GK Zone 17。 
        /// </summary>
        PCS_PULKOVO_1942_GK_17,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 17N。
        /// </summary>
        PCS_PULKOVO_1942_GK_17N,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 18。 
        /// </summary>
        PCS_PULKOVO_1942_GK_18,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 18N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_18N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 19。 
        /// </summary>
        PCS_PULKOVO_1942_GK_19,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 19N。
        /// </summary>
        PCS_PULKOVO_1942_GK_19N,                            
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 20。
        /// </summary>
        PCS_PULKOVO_1942_GK_20,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 20N。
        /// </summary>
        PCS_PULKOVO_1942_GK_20N,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 21。
        /// </summary>
        PCS_PULKOVO_1942_GK_21,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 21N。
        /// </summary>
        PCS_PULKOVO_1942_GK_21N,           
       
        /// <summary>
        /// Pulkovo 1942 GK Zone 22。 
        /// </summary>
        PCS_PULKOVO_1942_GK_22,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 22N。
        /// </summary>
        PCS_PULKOVO_1942_GK_22N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 23。
        /// </summary>
        PCS_PULKOVO_1942_GK_23,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 23N。
        /// </summary>
        PCS_PULKOVO_1942_GK_23N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 24。 
        /// </summary>
        PCS_PULKOVO_1942_GK_24,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 24N。
        /// </summary>
        PCS_PULKOVO_1942_GK_24N,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 25。
        /// </summary>
        PCS_PULKOVO_1942_GK_25,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 25N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_25N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 26。
        /// </summary>
        PCS_PULKOVO_1942_GK_26,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 26N。
        /// </summary>        
        PCS_PULKOVO_1942_GK_26N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 27。
        /// </summary>        
        PCS_PULKOVO_1942_GK_27,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 27N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_27N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 28。
        /// </summary>
        PCS_PULKOVO_1942_GK_28,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 28N。
        /// </summary>
        PCS_PULKOVO_1942_GK_28N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 29。 
        /// </summary>
        PCS_PULKOVO_1942_GK_29,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 29N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_29N,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 30。
        /// </summary>
        PCS_PULKOVO_1942_GK_30,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 30N。
        /// </summary>
        PCS_PULKOVO_1942_GK_30N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 31。 
        /// </summary>
        PCS_PULKOVO_1942_GK_31,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 31N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_31N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 32。
        /// </summary>
        PCS_PULKOVO_1942_GK_32,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 32N。
        /// </summary>
        PCS_PULKOVO_1942_GK_32N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 4。
        /// </summary>
        PCS_PULKOVO_1942_GK_4,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 4N。
        /// </summary>
        PCS_PULKOVO_1942_GK_4N,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 5。
        /// </summary>
        PCS_PULKOVO_1942_GK_5,           
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 5N。
        /// </summary>
        PCS_PULKOVO_1942_GK_5N,                     
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 6。 
        /// </summary>
        PCS_PULKOVO_1942_GK_6,                             
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 6N。
        /// </summary>
        PCS_PULKOVO_1942_GK_6N,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 7。
        /// </summary>
        PCS_PULKOVO_1942_GK_7,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 7N。
        /// </summary>
        PCS_PULKOVO_1942_GK_7N,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 8。
        /// </summary>
        PCS_PULKOVO_1942_GK_8,                    
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 8N。
        /// </summary>
        PCS_PULKOVO_1942_GK_8N,                     
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 9。 
        /// </summary>
        PCS_PULKOVO_1942_GK_9,          
        
        /// <summary>
        /// Pulkovo 1942 GK Zone 9N。 
        /// </summary>
        PCS_PULKOVO_1942_GK_9N,                              
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 10。
        /// </summary>
        PCS_PULKOVO_1995_GK_10,                   
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 10N。
        /// </summary>
        PCS_PULKOVO_1995_GK_10N,                           
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 11。
        /// </summary>
        PCS_PULKOVO_1995_GK_11,           
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 11N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_11N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 12。 
        /// </summary>
        PCS_PULKOVO_1995_GK_12,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 12N。
        /// </summary>
        PCS_PULKOVO_1995_GK_12N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 13。 
        /// </summary>
        PCS_PULKOVO_1995_GK_13,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 13N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_13N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 14。 
        /// </summary>
        PCS_PULKOVO_1995_GK_14,          
        
        /// <summary>
        ///  Pulkovo 1995 GK Zone 14N。 
        ///  </summary>
        PCS_PULKOVO_1995_GK_14N,                   
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 15。 
        /// </summary>
        PCS_PULKOVO_1995_GK_15,          
        
        /// <summary>
        /// ulkovo 1995 GK Zone 15N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_15N,                   
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 16。 
        /// </summary>
        PCS_PULKOVO_1995_GK_16,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 16N。
        /// </summary>
        PCS_PULKOVO_1995_GK_16N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 17。 
        /// </summary>
        PCS_PULKOVO_1995_GK_17,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 17N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_17N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 18。 
        /// </summary>
        PCS_PULKOVO_1995_GK_18,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 18N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_18N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 19。 
        /// </summary>
        PCS_PULKOVO_1995_GK_19,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 19N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_19N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 20N。
        /// </summary>
        PCS_PULKOVO_1995_GK_20,           
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 20N。
        /// </summary>
        PCS_PULKOVO_1995_GK_20N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 21。
        /// </summary>
        PCS_PULKOVO_1995_GK_21,                    
        
        /// <summary>
        ///  Pulkovo 1995 GK Zone 21N。 
        ///  </summary>
        PCS_PULKOVO_1995_GK_21N,         
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 22。
        /// </summary>
        PCS_PULKOVO_1995_GK_22,                     
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 22N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_22N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 23。
        /// </summary>
        PCS_PULKOVO_1995_GK_23,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 23N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_23N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 24。
        /// </summary>
        PCS_PULKOVO_1995_GK_24,                           
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 24N。
        /// </summary>
        PCS_PULKOVO_1995_GK_24N,           
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 25。 
        /// </summary>
        PCS_PULKOVO_1995_GK_25,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 25N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_25N,                              
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 26。 
        /// </summary>
        PCS_PULKOVO_1995_GK_26,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 26N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_26N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 27。 
        /// </summary>
        PCS_PULKOVO_1995_GK_27,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 27N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_27N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 28。
        /// </summary>
        PCS_PULKOVO_1995_GK_28,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 28N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_28N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone。 
        /// </summary>
        PCS_PULKOVO_1995_GK_29,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 29N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_29N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 30。
        /// </summary>
        PCS_PULKOVO_1995_GK_30,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 30N。
        /// </summary>
        PCS_PULKOVO_1995_GK_30N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 31。 
        /// </summary>
        PCS_PULKOVO_1995_GK_31,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 31N。
        /// </summary>
        PCS_PULKOVO_1995_GK_31N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 32。 
        /// </summary>
        PCS_PULKOVO_1995_GK_32,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 32N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_32N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 4。 
        /// </summary>
        PCS_PULKOVO_1995_GK_4,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 4N。
        /// </summary>
        PCS_PULKOVO_1995_GK_4N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 5。
        /// </summary>
        PCS_PULKOVO_1995_GK_5,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 5N。
        /// </summary>
        PCS_PULKOVO_1995_GK_5N,                    
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 6。 
        /// </summary>
        PCS_PULKOVO_1995_GK_6,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 6N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_6N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 7。
        /// </summary>
        PCS_PULKOVO_1995_GK_7,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 7N。
        /// </summary>
        PCS_PULKOVO_1995_GK_7N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 8。 
        /// </summary>
        PCS_PULKOVO_1995_GK_8,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 8N。
        /// </summary>
        PCS_PULKOVO_1995_GK_8N,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 9。 
        /// </summary>
        PCS_PULKOVO_1995_GK_9,          
        
        /// <summary>
        /// Pulkovo 1995 GK Zone 9N。 
        /// </summary>
        PCS_PULKOVO_1995_GK_9N,          
        

        /// <summary>
        /// Qatar National Grid。 
        /// </summary>
        PCS_QATAR_GRID,          
        
        /// <summary>
        /// Swedish National Grid。 
        /// </summary>
        PCS_RT38_STOCKHOLM_SWEDISH_GRID,                    
        
        /// <summary>
        /// South American 1969 UTM Zone 17S。 
        /// </summary>
        PCS_SAD_1969_UTM_17S,                    
        
        /// <summary>
        /// South American 1969 UTM Zone 18N。
        /// </summary>
        PCS_SAD_1969_UTM_18N,                     
        
        /// <summary>
        /// South American 1969 UTM Zone 18S。
        /// </summary>
        PCS_SAD_1969_UTM_18S,                    
        
        /// <summary>
        /// South American 1969 UTM Zone 19N。 
        /// </summary>
        PCS_SAD_1969_UTM_19N,          
        

        /// <summary>
        /// South American 1969 UTM Zone 19S。 
        /// </summary>
        PCS_SAD_1969_UTM_19S,          
        
        /// <summary>
        /// South American 1969 UTM Zone 20N。
        /// </summary>
        PCS_SAD_1969_UTM_20N,                    
        
        /// <summary>
        /// South American 1969 UTM Zone 20S。
        /// </summary>
        PCS_SAD_1969_UTM_20S,          
        
        /// <summary>
        /// South American 1969 UTM Zone 21N。
        /// </summary>
        PCS_SAD_1969_UTM_21N,          
        
        /// <summary>
        /// South American 1969 UTM Zone 21S。
        /// </summary>
        PCS_SAD_1969_UTM_21S,          
        
        /// <summary>
        /// South American 1969 UTM Zone 22N。
        /// </summary>
        PCS_SAD_1969_UTM_22N,          
        
        /// <summary>
        /// South American 1969 UTM Zone 22S。
        /// </summary>
        PCS_SAD_1969_UTM_22S,          
       
        /// <summary>
        /// South American 1969 UTM Zone 23S。
        /// </summary>
        PCS_SAD_1969_UTM_23S,          
        
        /// <summary>
        /// South American 1969 UTM Zone 24S。
        /// </summary>
        PCS_SAD_1969_UTM_24S,          
        
        /// <summary>
        /// South American 1969 UTM Zone 25S。 
        /// </summary>
        PCS_SAD_1969_UTM_25S,          
        
        /// <summary>
        /// Sapper Hill 1943 UTM Zone 20S。
        /// </summary>
        PCS_SAPPER_HILL_UTM_20S,          
        
        /// <summary>
        /// Sapper Hill 1943 UTM Zone 21S。
        /// </summary>
        PCS_SAPPER_HILL_UTM_21S,          
        
        /// <summary>
        /// Schwarzeck UTM Zone 33S。 
        /// </summary>
        PCS_SCHWARZECK_UTM_33S,          
        
        /// <summary>
        /// Behrmann。
        /// </summary>
        PCS_SPHERE_BEHRMANN,           
        
        /// <summary>
        /// Bonne。
        /// </summary>
        PCS_SPHERE_BONNE,           
        
        /// <summary>
        /// Cassini。
        /// </summary>
        PCS_SPHERE_CASSINI,          
        
        /// <summary>
        /// Eckert I。
        /// </summary>
        PCS_SPHERE_ECKERT_I,          
        
        /// <summary>
        /// Eckert II。
        /// </summary>
        PCS_SPHERE_ECKERT_II,          
        
        /// <summary>
        /// Eckert III。
        /// </summary>
        PCS_SPHERE_ECKERT_III,          
        
        /// <summary>
        /// Eckert IV。
        /// </summary>
        PCS_SPHERE_ECKERT_IV,          
        
        /// <summary>
        /// Eckert V。 
        /// </summary>
        PCS_SPHERE_ECKERT_V,          
        
        /// <summary>
        /// Eckert VI。 
        /// </summary>
        PCS_SPHERE_ECKERT_VI,          
        
        /// <summary>
        /// Equidistant Conic。
        /// </summary>
        PCS_SPHERE_EQUIDISTANT_CONIC,          
        
        /// <summary>
        ///  Equidistant Cyl.。
        ///  </summary>
        PCS_SPHERE_EQUIDISTANT_CYLINDRICAL,         
        
        /// <summary>
        /// Gall Stereographic。
        /// </summary>
        PCS_SPHERE_GALL_STEREOGRAPHIC,          
        
        /// <summary>
        /// Hotine。
        /// </summary>
        PCS_SPHERE_HOTINE,          
        
        /// <summary>
        /// Loximuthal。 
        /// </summary>
        PCS_SPHERE_LOXIMUTHAL,          
        
        /// <summary>
        /// Mercator。 
        /// </summary>
        PCS_SPHERE_MERCATOR,          
        
        /// <summary>
        /// Miller Cylindrical。
        /// </summary>
        PCS_SPHERE_MILLER_CYLINDRICAL,          
        
        /// <summary>
        /// Mollweide。
        /// </summary>
        PCS_SPHERE_MOLLWEIDE,          
        
        /// <summary>
        /// Plate Carree。
        /// </summary>
        PCS_SPHERE_PLATE_CARREE,                     
        
        /// <summary>
        /// Polyconic。
        /// </summary>
        PCS_SPHERE_POLYCONIC,           
        
        /// <summary>
        /// Quartic Authalic。
        /// </summary>
        PCS_SPHERE_QUARTIC_AUTHALIC,          
        
        /// <summary>
        /// Robinson。
        /// </summary>
        PCS_SPHERE_ROBINSON,           
        
        /// <summary>
        /// Sinusoidal。
        /// </summary>
        PCS_SPHERE_SINUSOIDAL,                     
        
        /// <summary>
        /// Stereographic。
        /// </summary>
        PCS_SPHERE_STEREOGRAPHIC,                     
        
        /// <summary>
        /// Two-Point Equidistant。
        /// </summary>
        PCS_SPHERE_TWO_POINT_EQUIDISTANT,          
        
        /// <summary>
        /// Van der Grinten I。
        /// </summary>
        PCS_SPHERE_VAN_DER_GRINTEN_I,                    
        
        /// <summary>
        /// Winkel I。
        /// </summary>
        PCS_SPHERE_WINKEL_I,           
        
        /// <summary>
        ///  Winkel II。
        ///  </summary>
        PCS_SPHERE_WINKEL_II,          
        
        /// <summary>
        /// Sudan UTM Zone 35N。
        /// </summary>
        PCS_SUDAN_UTM_35N,          
        
        /// <summary>
        /// Sudan UTM Zone 36N。 
        /// </summary>
        PCS_SUDAN_UTM_36N,                    
        
        /// <summary>
        /// Tananarive 1925 UTM Zone 38S。 
        /// </summary>
        PCS_TANANARIVE_UTM_38S,          
        
        /// <summary>
        /// Tananarive 1925 UTM Zone 39S。
        /// </summary>
        PCS_TANANARIVE_UTM_39S,                              
        
        /// <summary>
        /// Trucial Coast 1948 UTM Zone 39N。
        /// </summary>
        PCS_TC_1948_UTM_39N,                    
        
        /// <summary>
        /// Trucial Coast 1948 UTM Zone 40N。
        /// </summary>
        PCS_TC_1948_UTM_40N,                          
        
        /// <summary>
        /// Timbalai 1948 UTM Zone 49N。
        /// </summary>
        PCS_TIMBALAI_1948_UTM_49N,                    
        
        /// <summary>
        /// Timbalai 1948 UTM Zone 50N。
        /// </summary>
        PCS_TIMBALAI_1948_UTM_50N,           
        
        /// <summary>
        /// Irish National Grid。 
        /// </summary>
        PCS_TM65_IRISH_GRID,                    
        
        /// <summary>
        /// Japanese Zone I。 
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_I,                     
        
        /// <summary>
        /// Japanese Zone II。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_II,                    
        
        /// <summary>
        /// Japanese Zone III。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_III,                     
        
        /// <summary>
        /// Japanese Zone IV。 
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_IV,          
        
        /// <summary>
        /// Japanese Zone IX。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_IX,           
        
        /// <summary>
        /// Japanese Zone V。 
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_V,          
        
        /// <summary>
        /// Japanese Zone VI。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_VI,                     
        
        /// <summary>
        /// Japanese Zone VII。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_VII,                     
        
        /// <summary>
        /// Japanese Zone VIII。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_VIII,                     
        
        /// <summary>
        /// Japanese Zone X。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_X,                     
        
        /// <summary>
        /// Japanese Zone XI。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_XI,                     
        
        /// <summary>
        /// Japanese Zone XII。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_XII,                     
        
        /// <summary>
        /// Japanese Zone XIII。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_XIII,                     
        
        /// <summary>
        /// Japanese Zone XIV。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_XIV,                     
        
        /// <summary>
        /// Japanese Zone XIX。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_XIX,                     
        
        /// <summary>
        /// Japanese Zone XV。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_XV,                     
        
        /// <summary>
        ///  Japanese Zone XVI。
        ///  </summary>
        PCS_TOKYO_PLATE_ZONE_XVI,                    
        
        /// <summary>
        /// Japanese Zone XVII。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_XVII,                     
        
        /// <summary>
        /// Japanese Zone XVIII。
        /// </summary>
        PCS_TOKYO_PLATE_ZONE_XVIII,                     
        
        /// <summary>
        /// 日本东京测地系，UTM投影系51。
        /// </summary>
        PCS_TOKYO_UTM_51,                     
        
        /// <summary>
        /// 日本东京测地系，UTM投影系52。
        /// </summary>
        PCS_TOKYO_UTM_52,                     
        
        /// <summary>
        /// 日本东京测地系，UTM投影系53。 
        /// </summary>
        PCS_TOKYO_UTM_53,                     
        
        /// <summary>
        /// 日本东京测地系，UTM投影系54。 
        /// </summary>
        PCS_TOKYO_UTM_54,          
        
        /// <summary>
        /// 日本东京测地系，UTM投影系55。
        /// </summary>
        PCS_TOKYO_UTM_55,                     
        
        /// <summary>
        /// 日本东京测地系，UTM投影系56。
        /// </summary>
        PCS_TOKYO_UTM_56,                     
        
        /// <summary>
        /// 用户自定义坐标系。
        /// </summary>
        PCS_USER_DEFINED,                    
        
        /// <summary>
        /// Nord Algerie ancienne。 
        /// </summary>
        PCS_VOIROL_N_ALGERIE_ANCIENNE,                    
        
        /// <summary>
        /// Nord Algerie ancienne。
        /// </summary>
        PCS_VOIROL_S_ALGERIE_ANCIENNE,                    
        
        /// <summary>
        /// Nord Algerie。
        /// </summary>
        PCS_VOIROL_UNIFIE_N_ALGERIE,          
        
        /// <summary>
        /// Nord Algerie。
        /// </summary>
        PCS_VOIROL_UNIFIE_S_ALGERIE,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 10N。 
        /// </summary>
        PCS_WGS_1972_UTM_10N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 10S。
        /// </summary>
        PCS_WGS_1972_UTM_10S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 11N。
        /// </summary>
        PCS_WGS_1972_UTM_11N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 11S。
        /// </summary>
        PCS_WGS_1972_UTM_11S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 12N。
        /// </summary>
        PCS_WGS_1972_UTM_12N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 12S。 
        /// </summary>
        PCS_WGS_1972_UTM_12S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 13N。 
        /// </summary>
        PCS_WGS_1972_UTM_13N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 13S。
        /// </summary>
        PCS_WGS_1972_UTM_13S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 14N。
        /// </summary>
        PCS_WGS_1972_UTM_14N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 14S。
        /// </summary>
        PCS_WGS_1972_UTM_14S,                   
        
        /// <summary>
        /// WGS 1972 UTM Zone 15N。
        /// </summary>
        PCS_WGS_1972_UTM_15N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 15S。
        /// </summary>
        PCS_WGS_1972_UTM_15S,                    
        
        /// <summary>
        ///  WGS 1972 UTM Zone 16N。 
        /// </summary>
        PCS_WGS_1972_UTM_16N,         
        
        /// <summary>
        /// WGS 1972 UTM Zone 16S。
        /// </summary>
        PCS_WGS_1972_UTM_16S,          
            
        /// <summary>
        /// WGS 1972 UTM Zone 17N。
        /// </summary>
        PCS_WGS_1972_UTM_17N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 17S。 
        /// </summary>
        PCS_WGS_1972_UTM_17S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 18N。
        /// </summary>
        PCS_WGS_1972_UTM_18N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 18S。
        /// </summary>
        PCS_WGS_1972_UTM_18S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 19N。 
        /// </summary>
        PCS_WGS_1972_UTM_19N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 19S。
        /// </summary>
        PCS_WGS_1972_UTM_19S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 1N。
        /// </summary>
        PCS_WGS_1972_UTM_1N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 1S。
        /// </summary>
        PCS_WGS_1972_UTM_1S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 20N。
        /// </summary>
        PCS_WGS_1972_UTM_20N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 20S。 
        /// </summary>
        PCS_WGS_1972_UTM_20S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 21N。 
        /// </summary>
        PCS_WGS_1972_UTM_21N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 21S。
        /// </summary>
        PCS_WGS_1972_UTM_21S,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 22N。
        /// </summary>
        PCS_WGS_1972_UTM_22N,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 22S。
        /// </summary>
        PCS_WGS_1972_UTM_22S,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 23N。 
        /// </summary>
        PCS_WGS_1972_UTM_23N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 23S。
        /// </summary>
        PCS_WGS_1972_UTM_23S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 24N。
        /// </summary>
        PCS_WGS_1972_UTM_24N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 25N。
        /// </summary>
        PCS_WGS_1972_UTM_25N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 25S。
        /// </summary>
        PCS_WGS_1972_UTM_25S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 26N。
        /// </summary>
        PCS_WGS_1972_UTM_26N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 26S。
        /// </summary>
        PCS_WGS_1972_UTM_26S,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 27N。 
        /// </summary>
        PCS_WGS_1972_UTM_27N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 27S。
        /// </summary>
        PCS_WGS_1972_UTM_27S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 28N。 
        /// </summary>
        PCS_WGS_1972_UTM_28N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 28S。 
        /// </summary>
        PCS_WGS_1972_UTM_28S,                    
       
        /// <summary>
        /// WGS 1972 UTM Zone 29N。
        /// </summary>
        PCS_WGS_1972_UTM_29N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 29S。
        /// </summary>
        PCS_WGS_1972_UTM_29S,           
        /// <summary>
        /// WGS 1972 UTM Zone 2N。 
        /// </summary>
        PCS_WGS_1972_UTM_2N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 2S。
        /// </summary>
        PCS_WGS_1972_UTM_2S,                           
        
        /// <summary>
        /// WGS 1972 UTM Zone 30N。
        /// </summary>
        PCS_WGS_1972_UTM_30N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 30S。
        /// </summary>
        PCS_WGS_1972_UTM_30S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 31N。 
        /// </summary>
        PCS_WGS_1972_UTM_31N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 31S。
        /// </summary>
        PCS_WGS_1972_UTM_31S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 32N。
        /// </summary>
        PCS_WGS_1972_UTM_32N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 32S。
        /// </summary>
        PCS_WGS_1972_UTM_32S,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 33N。
        /// </summary>
        PCS_WGS_1972_UTM_33N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 33S。
        /// </summary>
        PCS_WGS_1972_UTM_33S,                   
        
        /// <summary>
        /// WGS 1972 UTM Zone 34N。
        /// </summary>
        PCS_WGS_1972_UTM_34N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 34S。 
        /// </summary>
        PCS_WGS_1972_UTM_34S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 35N。
        /// </summary>
        PCS_WGS_1972_UTM_35N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 35S。
        /// </summary>
        PCS_WGS_1972_UTM_35S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 36N。
        /// </summary>
        PCS_WGS_1972_UTM_36N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 36S。
        /// </summary>
        PCS_WGS_1972_UTM_36S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 37N。
        /// </summary>
        PCS_WGS_1972_UTM_37N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 37S。
        /// </summary>
        PCS_WGS_1972_UTM_37S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 38N。
        /// </summary> 
        PCS_WGS_1972_UTM_38N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 38S。
        /// </summary>
        PCS_WGS_1972_UTM_38S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 39N。
        /// </summary>
        PCS_WGS_1972_UTM_39N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 39S。
        /// </summary>
        PCS_WGS_1972_UTM_39S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 3N。
        /// </summary>
        PCS_WGS_1972_UTM_3N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 3S。
        /// </summary>
        PCS_WGS_1972_UTM_3S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 40N。
        /// </summary>
        PCS_WGS_1972_UTM_40N,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 40S。
        /// </summary>
        PCS_WGS_1972_UTM_40S,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 41N。
        /// </summary>
        PCS_WGS_1972_UTM_41N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 41S。
        /// </summary>
        PCS_WGS_1972_UTM_41S,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 42N。
        /// </summary>
        PCS_WGS_1972_UTM_42N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 42S。
        /// </summary>
        PCS_WGS_1972_UTM_42S,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 43N。
        /// </summary>
        PCS_WGS_1972_UTM_43N,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 43S。
        /// </summary>
        PCS_WGS_1972_UTM_43S,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 44N。
        /// </summary>
        PCS_WGS_1972_UTM_44N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 44S。
        /// </summary>
        PCS_WGS_1972_UTM_44S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 45N。 
        /// </summary>
        PCS_WGS_1972_UTM_45N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 45S。
        /// </summary>
        PCS_WGS_1972_UTM_45S,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 46N。
        /// </summary>
        PCS_WGS_1972_UTM_46N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 46S。
        /// </summary>
        PCS_WGS_1972_UTM_46S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 47N。
        /// </summary>
        PCS_WGS_1972_UTM_47N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 47S。
        /// </summary>
        PCS_WGS_1972_UTM_47S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 48N。
        /// </summary>
        PCS_WGS_1972_UTM_48N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 48S。
        /// </summary>
        PCS_WGS_1972_UTM_48S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 49N。
        /// </summary>
        PCS_WGS_1972_UTM_49N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 49S。 
        /// </summary>
        PCS_WGS_1972_UTM_49S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 4N。
        /// </summary>
        PCS_WGS_1972_UTM_4N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 4S。 
        /// </summary>
        PCS_WGS_1972_UTM_4S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 50N。
        /// </summary>
        PCS_WGS_1972_UTM_50N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 50S。
        /// </summary>
        PCS_WGS_1972_UTM_50S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 51N。
        /// </summary>
        PCS_WGS_1972_UTM_51N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 51S。 
        /// </summary>
        PCS_WGS_1972_UTM_51S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 52N。
        /// </summary>
        PCS_WGS_1972_UTM_52N,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 52S。
        /// </summary>
        PCS_WGS_1972_UTM_52S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 53N。
        /// </summary>
        PCS_WGS_1972_UTM_53N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 53S。
        /// </summary>
        PCS_WGS_1972_UTM_53S,                     
       
        /// <summary>
        /// WGS 1972 UTM Zone 54N。 
        /// </summary>
        PCS_WGS_1972_UTM_54N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 54S。
        /// </summary>
        PCS_WGS_1972_UTM_54S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 55N。
        /// </summary>
        PCS_WGS_1972_UTM_55N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 55S。
        /// </summary>
        PCS_WGS_1972_UTM_55S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 56N。
        /// </summary>
        PCS_WGS_1972_UTM_56N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 56S。
        /// </summary>
        PCS_WGS_1972_UTM_56S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 57N。
        /// </summary>
        PCS_WGS_1972_UTM_57N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 57S。
        /// </summary>
        PCS_WGS_1972_UTM_57S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 58N。
        /// </summary>
        PCS_WGS_1972_UTM_58N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 58S。
        /// </summary>
        PCS_WGS_1972_UTM_58S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 59N。
        /// </summary>
        PCS_WGS_1972_UTM_59N,                            
       
        /// <summary>
        /// WGS 1972 UTM Zone 59S。
        /// </summary>
        PCS_WGS_1972_UTM_59S,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 5N。
        /// </summary>
        PCS_WGS_1972_UTM_5N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 5S。 
        /// </summary>
        PCS_WGS_1972_UTM_5S,          
        
        /// <summary>
        /// WGS 1972 UTM Zone 60N。
        /// </summary>
        PCS_WGS_1972_UTM_60N,           
        
        /// <summary>
        /// WGS 1972 UTM Zone 60S。
        /// </summary>
        PCS_WGS_1972_UTM_60S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 6N。 
        /// </summary>
        PCS_WGS_1972_UTM_6N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 6S。
        /// </summary>
        PCS_WGS_1972_UTM_6S,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 7N。
        /// </summary>
        PCS_WGS_1972_UTM_7N,                         
        
        /// <summary>
        /// WGS 1972 UTM Zone 7S。
        /// </summary>
        PCS_WGS_1972_UTM_7S,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 8N。
        /// </summary>
        PCS_WGS_1972_UTM_8N,                     
        
        /// <summary>
        /// WGS 1972 UTM Zone 8S。
        /// </summary>
        PCS_WGS_1972_UTM_8S,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 9N。
        /// </summary>
        PCS_WGS_1972_UTM_9N,                    
        
        /// <summary>
        /// WGS 1972 UTM Zone 9S。
        /// </summary>
        PCS_WGS_1972_UTM_9S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 10N。
        /// </summary>
        PCS_WGS_1984_UTM_10N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 10S。
        /// </summary>
        PCS_WGS_1984_UTM_10S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 11N。
        /// </summary>
        PCS_WGS_1984_UTM_11N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 11S。
        /// </summary>
        PCS_WGS_1984_UTM_11S,                     
        
        /// <summary>
        /// WGS 1984 UTM Zone 12N。
        /// </summary>
        PCS_WGS_1984_UTM_12N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 12S。
        /// </summary>
        PCS_WGS_1984_UTM_12S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 13N。
        /// </summary>
        PCS_WGS_1984_UTM_13N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 13S。
        /// </summary>
        PCS_WGS_1984_UTM_13S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 14N。
        /// </summary>
        PCS_WGS_1984_UTM_14N,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 14S。
        /// </summary>
        PCS_WGS_1984_UTM_14S,                     
        
        /// <summary>
        /// WGS 1984 UTM Zone 15N。
        /// </summary>
        PCS_WGS_1984_UTM_15N,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 15S。
        /// </summary>
        PCS_WGS_1984_UTM_15S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 16N。
        /// </summary>
        PCS_WGS_1984_UTM_16N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 16S。
        /// </summary>
        PCS_WGS_1984_UTM_16S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 17N。
        /// </summary>
        PCS_WGS_1984_UTM_17N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 17S。
        /// </summary>
        PCS_WGS_1984_UTM_17S,                     
        
        /// <summary>
        /// WGS 1984 UTM Zone 18N。
        /// </summary>
        PCS_WGS_1984_UTM_18N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 18S。
        /// </summary>
        PCS_WGS_1984_UTM_18S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 19N。
        /// </summary>
        PCS_WGS_1984_UTM_19N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 19S。
        /// </summary>
        PCS_WGS_1984_UTM_19S,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 1N。
        /// </summary>
        PCS_WGS_1984_UTM_1N,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 1S。
        /// </summary>
        PCS_WGS_1984_UTM_1S,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 20N。
        /// </summary>
        PCS_WGS_1984_UTM_20N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 20S。
        /// </summary>
        PCS_WGS_1984_UTM_20S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 21N。
        /// </summary>
        PCS_WGS_1984_UTM_21N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 21S。
        /// </summary>
        PCS_WGS_1984_UTM_21S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 22N。
        /// </summary>
        PCS_WGS_1984_UTM_22N,                     
        
        /// <summary>
        /// WGS 1984 UTM Zone 22S。
        /// </summary>
        PCS_WGS_1984_UTM_22S,                     
        
        /// <summary>
        /// WGS 1984 UTM Zone 23N。 
        /// </summary>
        PCS_WGS_1984_UTM_23N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 23S。 
        /// </summary>
        PCS_WGS_1984_UTM_23S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 24N。
        /// </summary>
        PCS_WGS_1984_UTM_24N,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 24S。
        /// </summary>
        PCS_WGS_1984_UTM_24S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 25N。 
        /// </summary>
        PCS_WGS_1984_UTM_25N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 25S。
        /// </summary>
        PCS_WGS_1984_UTM_25S,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 26N。
        /// </summary>
        PCS_WGS_1984_UTM_26N,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 26S。
        /// </summary>
        PCS_WGS_1984_UTM_26S,                  
        
        /// <summary>
        /// WGS 1984 UTM Zone 27N。 
        /// </summary>
        PCS_WGS_1984_UTM_27N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 27S。 
        /// </summary>
        PCS_WGS_1984_UTM_27S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 28N。 
        /// </summary>
        PCS_WGS_1984_UTM_28N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 28S。 
        /// </summary>
        PCS_WGS_1984_UTM_28S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 29N。 
        /// </summary>
        PCS_WGS_1984_UTM_29N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 29S。
        /// </summary>
        PCS_WGS_1984_UTM_29S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 2N。
        /// </summary>
        PCS_WGS_1984_UTM_2N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 2S。 
        /// </summary>
        PCS_WGS_1984_UTM_2S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 30N。 
        /// </summary>
        PCS_WGS_1984_UTM_30N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 30S。 
        /// </summary>
        PCS_WGS_1984_UTM_30S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 31N。 
        /// </summary>
        PCS_WGS_1984_UTM_31N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 31S。 
        /// </summary>
        PCS_WGS_1984_UTM_31S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 32N。 
        /// </summary>
        PCS_WGS_1984_UTM_32N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 32S。 
        /// </summary>
        PCS_WGS_1984_UTM_32S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 33N。
        /// </summary>
        PCS_WGS_1984_UTM_33N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 33S。
        /// </summary>
        PCS_WGS_1984_UTM_33S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 34N。
        /// </summary>
        PCS_WGS_1984_UTM_34N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 34S。
        /// </summary>
        PCS_WGS_1984_UTM_34S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 35N。 
        /// </summary>
        PCS_WGS_1984_UTM_35N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 35S。
        /// </summary>
        PCS_WGS_1984_UTM_35S,                           
        
        /// <summary>
        /// WGS 1984 UTM Zone 36N。 
        /// </summary>
        PCS_WGS_1984_UTM_36N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 36S。
        /// </summary>
        PCS_WGS_1984_UTM_36S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 37N。 
        /// </summary>
        PCS_WGS_1984_UTM_37N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 37S。 
        /// </summary>
        PCS_WGS_1984_UTM_37S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 38N。 
        /// </summary>
        PCS_WGS_1984_UTM_38N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 38S。 
        /// </summary>
        PCS_WGS_1984_UTM_38S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 39N。
        /// </summary>
        PCS_WGS_1984_UTM_39N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 39S。 
        /// </summary>
        PCS_WGS_1984_UTM_39S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 3N。
        /// </summary>
        PCS_WGS_1984_UTM_3N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 3S。
        /// </summary>
        PCS_WGS_1984_UTM_3S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 40N。 
        /// </summary>
        PCS_WGS_1984_UTM_40N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 40S。
        /// </summary>
        PCS_WGS_1984_UTM_40S,                    
        
        /// <summary>
        /// 1984 UTM Zone 41N。 
        /// </summary>
        PCS_WGS_1984_UTM_41N,                 
        
        /// <summary>
        /// WGS 1984 UTM Zone 41S。 
        /// </summary>
        PCS_WGS_1984_UTM_41S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 42N。
        /// </summary>
        PCS_WGS_1984_UTM_42N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 42S。 
        /// </summary>
        PCS_WGS_1984_UTM_42S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 43N。 
        /// </summary>
        PCS_WGS_1984_UTM_43N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 43S。
        /// </summary>
        PCS_WGS_1984_UTM_43S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 44N。 
        /// </summary>
        PCS_WGS_1984_UTM_44N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 44S。 
        /// </summary>
        PCS_WGS_1984_UTM_44S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 45N。 
        /// </summary>
        PCS_WGS_1984_UTM_45N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 45S。 
        /// </summary>
        PCS_WGS_1984_UTM_45S,                            
        
        /// <summary>
        /// WGS 1984 UTM Zone 46N。 
        /// </summary>
        PCS_WGS_1984_UTM_46N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 46S。
        /// </summary>
        PCS_WGS_1984_UTM_46S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 47N。 
        /// </summary>
        PCS_WGS_1984_UTM_47N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 47S。 
        /// </summary>
        PCS_WGS_1984_UTM_47S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 48N。 
        /// </summary>
        PCS_WGS_1984_UTM_48N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 48S。
        /// </summary>
        PCS_WGS_1984_UTM_48S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 49N。
        /// </summary>
        PCS_WGS_1984_UTM_49N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 49S。
        /// </summary>
        PCS_WGS_1984_UTM_49S,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 4N。 
        /// </summary>
        PCS_WGS_1984_UTM_4N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 4S。 
        /// </summary>
        PCS_WGS_1984_UTM_4S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 50N。 
        /// </summary>
        PCS_WGS_1984_UTM_50N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 50S。
        /// </summary>
        PCS_WGS_1984_UTM_50S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 51N。 
        /// </summary>
        PCS_WGS_1984_UTM_51N,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 51S。
        /// </summary>
        PCS_WGS_1984_UTM_51S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 52N。 
        /// </summary>
        PCS_WGS_1984_UTM_52N,                 
        
        /// <summary>
        /// WGS 1984 UTM Zone 52S。 
        /// </summary>
        PCS_WGS_1984_UTM_52S,          
        
        /// <summary> 
        /// WGS 1984 UTM Zone 53N。
        /// </summary>
        PCS_WGS_1984_UTM_53N,         
      
        /// <summary>
        /// WGS 1984 UTM Zone 53S。
        /// </summary>
        PCS_WGS_1984_UTM_53S,          
       
        /// <summary>
        /// WGS 1984 UTM Zone。 
        /// </summary>
        PCS_WGS_1984_UTM_54N,          
        
        /// <summary> 
        /// WGS 1984 UTM Zone 54S。 
        /// </summary>
        PCS_WGS_1984_UTM_54S,         
       
        /// <summary>
        /// WGS 1984 UTM Zone 55N。 
        /// </summary>
        PCS_WGS_1984_UTM_55N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 55S。
        /// </summary>
        PCS_WGS_1984_UTM_55S,                     
        
        /// <summary>
        /// WGS 1984 UTM Zone 56N。 
        /// </summary>
        PCS_WGS_1984_UTM_56N,          
       
        /// <summary>
        /// WGS 1984 UTM Zone 56S。 
        /// </summary>
        PCS_WGS_1984_UTM_56S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 57N。
        /// </summary>
        PCS_WGS_1984_UTM_57N,                     
        
        /// <summary>  
        /// WGS 1984 UTM Zone 57S。
        /// </summary>
        PCS_WGS_1984_UTM_57S,               
        
        /// <summary>
        /// WGS 1984 UTM Zone 58N。 
        /// </summary>
        PCS_WGS_1984_UTM_58N,                  
        
        /// <summary>
        /// WGS 1984 UTM Zone 58S。 
        /// </summary>
        PCS_WGS_1984_UTM_58S,          
        
        /// <summary> 
        /// WGS 1984 UTM Zone 59N。 
        /// </summary>
        PCS_WGS_1984_UTM_59N,         
        
        /// <summary> 
        /// WGS 1984 UTM Zone 59S。 
        /// </summary>
        PCS_WGS_1984_UTM_59S,         
       
        /// <summary>
        /// WGS 1984 UTM Zone 5N。
        /// </summary>
        PCS_WGS_1984_UTM_5N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 5S。
        /// </summary>
        PCS_WGS_1984_UTM_5S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 60N。 
        /// </summary>
        PCS_WGS_1984_UTM_60N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 60S。
        /// </summary>
        PCS_WGS_1984_UTM_60S,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 6N。
        /// </summary>
        PCS_WGS_1984_UTM_6N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 6S。
        /// </summary>
        PCS_WGS_1984_UTM_6S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 7N。
        /// </summary>
        PCS_WGS_1984_UTM_7N,           
        
        /// <summary>
        /// WGS 1984 UTM Zone 7S。
        /// </summary>
        PCS_WGS_1984_UTM_7S,                    
        
        /// <summary>
        /// WGS 1984 UTM Zone 8N。 
        /// </summary>
        PCS_WGS_1984_UTM_8N,          
        
        /// <summary> 
        /// WGS 1984 UTM Zone 8S。
        /// </summary>
        PCS_WGS_1984_UTM_8S,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 9N。
        /// </summary>
        PCS_WGS_1984_UTM_9N,          
        
        /// <summary>
        /// WGS 1984 UTM Zone 9S。 
        /// </summary>
        PCS_WGS_1984_UTM_9S,          
        
        /// <summary>
        /// Behrmann。 
        /// </summary>
        PCS_WORLD_BEHRMANN,          
        
        /// <summary>
        /// Bonne。
        /// </summary>
        PCS_WORLD_BONNE,           
        
        /// <summary>
        /// Cassini。 
        /// </summary>
        PCS_WORLD_CASSINI,          
        
        /// <summary>
        /// Eckert I。 
        /// </summary>
        PCS_WORLD_ECKERT_I,                    
        
        /// <summary>
        /// Eckert II。
        /// </summary>
        PCS_WORLD_ECKERT_II,           
        
        /// <summary>
        /// Eckert III。 
        /// </summary>
        PCS_WORLD_ECKERT_III,          
       
        /// <summary>
        /// Eckert IV。 
        /// </summary>
        PCS_WORLD_ECKERT_IV,          
        
        /// <summary>
        /// Eckert V。
        /// </summary>
        PCS_WORLD_ECKERT_V,          
        
        /// <summary>
        /// Eckert VI。 
        /// </summary>
        PCS_WORLD_ECKERT_VI,          
        
        /// <summary>
        /// Equidistant Conic。 
        /// </summary>
        PCS_WORLD_EQUIDISTANT_CONIC,          
        
        /// <summary>
        /// Equidistant Cyl.。
        /// </summary>
        PCS_WORLD_EQUIDISTANT_CYLINDRICAL,          
        
        /// <summary>
        /// Gall Stereographic。 
        /// </summary>
        PCS_WORLD_GALL_STEREOGRAPHIC,                 
        
        /// <summary>
        /// Hotine。
        /// </summary>
        PCS_WORLD_HOTINE,                   
        
        /// <summary>
        /// Loximuthal。 
        /// </summary>
        PCS_WORLD_LOXIMUTHAL,                 
       
        /// <summary>
        /// Mercator。 
        /// </summary>
        PCS_WORLD_MERCATOR,          
        
        /// <summary>
        /// Miller Cylindrical。 
        /// </summary>
        PCS_WORLD_MILLER_CYLINDRICAL,          
        
        /// <summary>
        /// Mollweide。 
        /// </summary>
        PCS_WORLD_MOLLWEIDE,          
        
        /// <summary>
        /// Plate Carree。 
        /// </summary>
        PCS_WORLD_PLATE_CARREE,          
        
        /// <summary>
        /// Polyconic。 
        /// </summary>
        PCS_WORLD_POLYCONIC,          
        
        /// <summary>
        /// Quartic Authalic。 
        /// </summary>
        PCS_WORLD_QUARTIC_AUTHALIC,          
        
        /// <summary>
        /// Robinson。
        /// </summary>
        PCS_WORLD_ROBINSON,           
        
        /// <summary>
        /// Sinusoidal。
        /// </summary>
        PCS_WORLD_SINUSOIDAL,          
        
        /// <summary>
        /// Stereographic。
        /// </summary>
        PCS_WORLD_STEREOGRAPHIC,          
        
        /// <summary>
        /// Two-Point Equidistant。
        /// </summary>
        PCS_WORLD_TWO_POINT_EQUIDISTANT,           
        
        /// <summary>
        /// Van der Grinten I。
        /// </summary>
        PCS_WORLD_VAN_DER_GRINTEN_I,          
       
        /// <summary>
        /// Winkel I。 
        /// </summary>
        PCS_WORLD_WINKEL_I,         
        
        /// <summary>
        /// Winkel II。
        /// </summary>
        PCS_WORLD_WINKEL_II,          
       
        /// <summary>
        /// Yoff 1972 UTM Zone 28N。
        /// </summary>
        PCS_YOFF_1972_UTM_28N,         
        
        /// <summary>
        /// Zanderij 1972 UTM Zone 21N。
        /// </summary>
        PCS_ZANDERIJ_1972_UTM_21N,          
    }
}
