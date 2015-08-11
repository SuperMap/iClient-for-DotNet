using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 	<para>大地参照系类型。</para>
    /// 	<para>根据给定的大地参照系类型构造一个新的大地参照系对象。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DatumType
    {
        /// <summary>
        /// Adindan。
        /// </summary>
        DATUM_ADINDAN,

        /// <summary>
        ///  Afgooye。
        /// </summary>
        DATUM_AFGOOYE,

        /// <summary>
        /// Agadez。
        /// </summary>
        DATUM_AGADEZ,

        /// <summary>
        /// Australian Geodetic Datum 1966。
        /// </summary>
        DATUM_AGD_1966,

        /// <summary>
        /// Australian Geodetic Datum 1984。
        /// </summary>
        DATUM_AGD_1984,

        /// <summary>
        /// Ain el Abd 1970。
        /// </summary>
        DATUM_AIN_EL_ABD_1970,

        /// <summary>
        /// Airy 1830。
        /// </summary>
        DATUM_AIRY_1830,

        /// <summary>
        /// Airy modified。
        /// </summary>
        DATUM_AIRY_MOD,

        /// <summary>
        /// Alaskan Islands。
        /// </summary>
        DATUM_ALASKAN_ISLANDS,

        /// <summary>
        ///  Amersfoort。
        /// </summary>
        DATUM_AMERSFOORT,

        /// <summary>
        ///  Anna 1 Astro 1965。
        /// </summary>
        DATUM_ANNA_1_1965,

        /// <summary>
        ///  Antigua Island Astro 1943。
        /// </summary>
        DATUM_ANTIGUA_ISLAND_1943,

        /// <summary>
        /// Aratu。
        /// </summary>
        DATUM_ARATU,

        /// <summary>
        /// Arc 1950。
        /// </summary>
        DATUM_ARC_1950,

        /// <summary>
        /// Arc 1960。
        /// </summary>
        DATUM_ARC_1960,

        /// <summary>
        /// Ascension Island 1958。
        /// </summary>
        DATUM_ASCENSION_ISLAND_1958,

        /// <summary>
        /// Astronomical Station 1952。
        /// </summary>
        DATUM_ASTRO_1952,

        /// <summary>
        ///  Ancienne Triangulation Francaise。
        /// </summary>
        DATUM_ATF,

        /// <summary>
        /// Average Terrestrial System 1977。
        /// </summary>
        DATUM_ATS_1977,

        /// <summary>
        /// Australian National。
        /// </summary>
        DATUM_AUSTRALIAN,

        /// <summary>
        /// Ayabelle Lighthouse。
        /// </summary>
        DATUM_AYABELLE,

        /// <summary>
        /// Barbados。
        /// </summary>
        DATUM_BARBADOS,

        /// <summary>
        /// Batavia。
        /// </summary>
        DATUM_BATAVIA,

        /// <summary>
        ///  Astro Beacon E 1945。
        /// </summary>
        DATUM_BEACON_E_1945,

        /// <summary>
        ///  Beduaram。
        /// </summary>
        DATUM_BEDUARAM,

        /// <summary>
        /// Beijing 1954。
        /// </summary>
        DATUM_BEIJING_1954,

        /// <summary>
        /// Reseau National Belge 1950。
        /// </summary>
        DATUM_BELGE_1950,

        /// <summary>
        /// Reseau National Belge 1972。
        /// </summary>
        DATUM_BELGE_1972,

        /// <summary>
        ///  Bellevue IGN。
        /// </summary>
        DATUM_BELLEVUE,

        /// <summary>
        ///  Bermuda 1957。
        /// </summary>
        DATUM_BERMUDA_1957,

        /// <summary>
        /// Bern 1898。
        /// </summary>
        DATUM_BERN_1898,

        /// <summary>
        /// Bern 1938。
        /// </summary>
        DATUM_BERN_1938,

        /// <summary>
        /// Bessel 1841。
        /// </summary>
        DATUM_BESSEL_1841,

        /// <summary>
        ///  Bessel modified。
        /// </summary>
        DATUM_BESSEL_MOD,

        /// <summary>
        /// Bessel Namibia。
        /// </summary>
        DATUM_BESSEL_NAMIBIA,

        /// <summary>
        /// Bissau。
        /// </summary>
        DATUM_BISSAU,

        /// <summary>
        /// Bogota。
        /// </summary>
        DATUM_BOGOTA,

        /// <summary>
        /// Bukit Rimpah。
        /// </summary>
        DATUM_BUKIT_RIMPAH,

        /// <summary>
        /// Cape Canaveral。
        /// </summary>
        DATUM_CACANAVERAL,

        /// <summary>
        ///  Camacupa。
        /// </summary>
        DATUM_CAMACUPA,

        /// <summary>
        /// Camp Area Astro。
        /// </summary>
        DATUM_CAMP_AREA,

        /// <summary>
        /// Campo Inchauspe。
        /// </summary>
        DATUM_CAMPO_INCHAUSPE,

        /// <summary>
        /// Canton Astro 1966。
        /// </summary>
        DATUM_CANTON_1966,

        /// <summary>
        /// Cape。
        /// </summary>
        DATUM_CAPE,

        /// <summary>
        ///  Carthage。
        /// </summary>
        DATUM_CARTHAGE,

        /// <summary>
        /// Chatham Island Astro 1971。
        /// </summary>
        DATUM_CHATHAM_ISLAND_1971,

        /// <summary>
        ///  China 2000。
        /// </summary>
        DATUM_CHINA_2000,

        /// <summary>
        /// Chua。
        /// </summary>
        DATUM_CHUA,

        /// <summary>
        /// Clarke 1858。
        /// </summary>
        DATUM_CLARKE_1858,

        /// <summary>
        /// Clarke 1866。
        /// </summary>
        DATUM_CLARKE_1866,

        /// <summary>
        ///  Clarke 1866 Michigan。
        /// </summary>
        DATUM_CLARKE_1866_MICH,

        /// <summary>
        ///  Clarke 1880。
        /// </summary>
 
        DATUM_CLARKE_1880,

        /// <summary>
        ///  Clarke 1880 (Arc)。
        /// </summary>
        DATUM_CLARKE_1880_ARC,

        /// <summary>
        /// Clarke 1880 (Benoit)。
        /// </summary>
        DATUM_CLARKE_1880_BENOIT,

        /// <summary>
        ///  Clarke 1880 (IGN)。
        /// </summary>
        DATUM_CLARKE_1880_IGN,

        /// <summary>
        ///  Clarke 1880 (RGS)。
        /// </summary>
        DATUM_CLARKE_1880_RGS,

        /// <summary>
        /// Clarke 1880 (SGA)。
        /// </summary>
        DATUM_CLARKE_1880_SGA,

        /// <summary>
        ///  Conakry 1905。
        /// </summary>
        DATUM_CONAKRY_1905,

        /// <summary>
        /// Corrego Alegre。
        /// </summary>
        DATUM_CORREGO_ALEGRE,

        /// <summary>
        /// Cote d'Ivoire。
        /// </summary>
        DATUM_COTE_D_IVOIRE,

        /// <summary>
        /// Dabola。
        /// </summary>
        DATUM_DABOLA,

        /// <summary>
        /// Datum 73。
        /// </summary>
        DATUM_DATUM_73,

        /// <summary>
        /// Dealul Piscului 1933。
        /// </summary>
        DATUM_DEALUL_PISCULUI_1933,

        /// <summary>
        /// Dealul Piscului 1970。
        /// </summary>
        DATUM_DEALUL_PISCULUI_1970,

        /// <summary>
        ///  Deception Island。
        /// </summary>
        DATUM_DECEPTION_ISLAND,

        /// <summary>
        ///  Deir ez Zor。
        /// </summary>
        DATUM_DEIR_EZ_ZOR,

        /// <summary>
        /// Deutsche Hauptdreiecksnetz。
        /// </summary>
        DATUM_DHDN,

        /// <summary>
        ///  Astro DOS 71/4。
        /// </summary>
        DATUM_DOS_71_4,

        /// <summary>
        ///  Douala。
        /// </summary>
        DATUM_DOUALA,

        /// <summary>
        /// Easter Island 1967。
        /// </summary>
        DATUM_EASTER_ISLAND_1967,

        /// <summary>
        /// European Datum 1950。
        /// </summary>
        DATUM_ED_1950,

        /// <summary>
        /// European Datum 1987。
        /// </summary>
        DATUM_ED_1987,

        /// <summary>
        /// Egypt 1907。
        /// </summary>
        DATUM_EGYPT_1907,

        /// <summary>
        /// European Terrestrial Ref.
        /// </summary>
        DATUM_ETRS_1989,

        /// <summary>
        /// European 1979。
        /// </summary>
        DATUM_EUROPEAN_1979,

        /// <summary>
        /// Everest 1830。
        /// </summary>
        DATUM_EVEREST_1830,

        /// <summary>
        /// Everest - Bangladesh。
        /// </summary>
        DATUM_EVEREST_BANGLADESH,

        /// <summary>
        /// Everest (definition 1967)。
        /// </summary>
        DATUM_EVEREST_DEF_1967,

        /// <summary>
        /// Everest (definition 1975)。
        /// </summary>
        DATUM_EVEREST_DEF_1975,

        /// <summary>
        /// Everest - India and Nepal。
        /// </summary>
        DATUM_EVEREST_INDIA_NEPAL,

        /// <summary>
        /// Everest modified。
        /// </summary>
        DATUM_EVEREST_MOD,

        /// <summary>
        /// Everest modified 1969。
        /// </summary>
        DATUM_EVEREST_MOD_1969,

        /// <summary>
        ///  Fahud。
        /// </summary>
        DATUM_FAHUD,

        /// <summary>
        ///  Fischer 1960。
        /// </summary>
        DATUM_FISCHER_1960,

        /// <summary>
        /// Fischer 1968。
        /// </summary>
        DATUM_FISCHER_1968,

        /// <summary>
        ///  Fischer modified。
        /// </summary>
        DATUM_FISCHER_MOD,

        /// <summary>
        /// Fort Thomas 1955。
        /// </summary>
        DATUM_FORT_THOMAS_1955,

        /// <summary>
        /// Gan 1970。
        /// </summary>
        DATUM_GAN_1970,

        /// <summary>
        /// Gandajika 1970。
        /// </summary>
        DATUM_GANDAJIKA_1970,

        /// <summary>
        ///  Garoua。
        /// </summary>
        DATUM_GAROUA,

        /// <summary>
        /// Geocentric Datum of Australia 1994。
        /// </summary>
        DATUM_GDA_1994,

        /// <summary>
        ///  GEM gravity potential model。
        /// </summary>
        DATUM_GEM_10C,

        /// <summary>
        ///  Greek Geodetic Reference System 1987。
        /// </summary>
        DATUM_GGRS_1987,
        
        /// <summary>
        /// Graciosa Base SW 1948。
        /// </summary>
        DATUM_GRACIOSA_1948,

        /// <summary>
        /// Greek。
        /// </summary>
        DATUM_GREEK,

        /// <summary>
        /// GRS 1967。
        /// </summary>
        DATUM_GRS_1967,

        /// <summary>
        /// GRS 1980。
        /// </summary>
        DATUM_GRS_1980,

        /// <summary>
        /// Guam 1963。
        /// </summary>
        DATUM_GUAM_1963,
        
        /// <summary>
        ///  Gunung Segara。
        /// </summary>
        DATUM_GUNUNG_SEGARA,
        
        /// <summary>
        /// GUX 1 Astro。
        /// </summary>
        DATUM_GUX_1,

        /// <summary>
        /// Guyane Francaise。
        /// </summary>
        DATUM_GUYANE_FRANCAISE,
        
        /// <summary>
        ///  Helmert 1906。
        /// </summary>
        DATUM_HELMERT_1906,
        
        /// <summary>
        /// Herat North。
        /// </summary>
        DATUM_HERAT_NORTH,
        
        /// <summary>
        /// Hito XVIII 1963。
        /// </summary>
        DATUM_HITO_XVIII_1963,
        
        /// <summary>
        ///  Hjorsey 1955。
        /// </summary>
        DATUM_HJORSEY_1955,
        
        /// <summary>
        ///  Hong Kong 1963。   
        /// </summary>
        DATUM_HONG_KONG_1963,

        /// <summary>
        ///  Hough 1960。
        /// </summary> 
        DATUM_HOUGH_1960,
        
        /// <summary>
        /// Hu Tzu Shan。
        /// </summary>
        DATUM_HU_TZU_SHAN,
        
        /// <summary>
        ///  Hungarian Datum 1972。
        /// </summary>
        DATUM_HUNGARIAN_1972,
        
        /// <summary>
        /// Indian 1954。
        /// </summary>
        DATUM_INDIAN_1954,
        
        /// <summary>
        /// Indian 1960。
        /// </summary>
        DATUM_INDIAN_1960,
        
        /// <summary>
        ///  Indian 1975。
        /// </summary>
        DATUM_INDIAN_1975,
        
        /// <summary>
        /// Indonesian National。
        /// </summary>
        DATUM_INDONESIAN,
        
        /// <summary>
        /// Indonesian Datum 1974。
        /// </summary>
        DATUM_INDONESIAN_1974,
        
        /// <summary>
        ///  International 1924。
        /// </summary>
        DATUM_INTERNATIONAL_1924,
        
        /// <summary>
        /// International 1967。
        /// </summary>
        DATUM_INTERNATIONAL_1967,
        
        /// <summary>
        /// ISTS 061 Astro 1968。
        /// </summary>
        DATUM_ISTS_061_1968,
        
        /// <summary>
        /// ISTS 073 Astro 1969。
        /// </summary>
        DATUM_ISTS_073_1969,
        
        /// <summary>
        /// Jamaica 1875。
        /// </summary>
        DATUM_JAMAICA_1875,
        
        /// <summary>
        /// Jamaica 1969。
        /// </summary>
        DATUM_JAMAICA_1969,
        
        /// <summary>
        /// 日本JGD2000大地参照系(ITRF84)。
        /// </summary>
        DATUM_JAPAN_2000,
        
        /// <summary>
        ///  Johnston Island 1961。
        /// </summary>
        DATUM_JOHNSTON_ISLAND_1961,
        
        /// <summary>
        ///  Kalianpur。
        /// </summary>
        DATUM_KALIANPUR,
        
        /// <summary>
        /// Kandawala。
        /// </summary>
        DATUM_KANDAWALA,
        
        /// <summary>
        ///  Kerguelen Island 1949。
        /// </summary>
        DATUM_KERGUELEN_ISLAND_1949,
        
        /// <summary>
        ///  Kertau。
        /// </summary>
        DATUM_KERTAU,
        
        /// <summary>
        /// Kartastokoordinaattijarjestelma。
        /// </summary>
        DATUM_KKJ,
        
        /// <summary>
        /// Kuwait Oil Company。
        /// </summary>
        DATUM_KOC,
        
        /// <summary>
        /// Krasovsky 1940。
        /// </summary>
        DATUM_KRASOVSKY_1940,
        
        /// <summary>
        /// Kuwait Utility。
        /// </summary>
        DATUM_KUDAMS,
        
        /// <summary>
        ///  Kusaie Astro 1951。
        /// </summary>
        DATUM_KUSAIE_1951,
        
        /// <summary>
        /// La Canoa。
        /// </summary>
        DATUM_LA_CANOA,
        
        /// <summary>
        /// Lake。
        /// </summary>
        DATUM_LAKE,
        
        /// <summary>
        ///  L.C. 5 Astro 1961。
        /// </summary>
        DATUM_LC5_1961,

        /// <summary> 
        /// Leigon。
        /// </summary>
        DATUM_LEIGON,
        
        /// <summary>
        /// Liberia 1964。
        /// </summary>
        DATUM_LIBERIA_1964,
        
        /// <summary>
        /// Lisbon。
        /// </summary>
        DATUM_LISBON,
        
        /// <summary>
        /// Loma Quintana。
        /// </summary>
        DATUM_LOMA_QUINTANA,
        
        /// <summary>
        /// Lome。
        /// </summary>
        DATUM_LOME,
        
        /// <summary>
        /// Luzon 1911。
        /// </summary>
        DATUM_LUZON_1911,
        
        /// <summary>
        ///  Mahe 1971。
        /// </summary>
        DATUM_MAHE_1971,
         
        /// <summary>
        /// Makassar。
        /// </summary>
        DATUM_MAKASSAR,
        
        /// <summary>
        /// Malongo 1987。
        /// </summary>
        DATUM_MALONGO_1987,
        
        /// <summary>
        /// Manoca。
        /// </summary>
        DATUM_MANOCA,
        
        /// <summary>
        /// Massawa。
        /// </summary>
        DATUM_MASSAWA,
        
        /// <summary>
        /// Merchich。
        /// </summary>
        DATUM_MERCHICH,
        
        /// <summary>
        /// Militar-Geographische Institut。
        /// </summary>
        DATUM_MGI,
        
        /// <summary>
        ///   Mhast。
        /// </summary>
        DATUM_MHAST,
        
        /// <summary>
        /// Midway Astro 1961。
        /// </summary>
        DATUM_MIDWAY_1961,
        
        /// <summary>
        ///  Minna。
        /// </summary>
        DATUM_MINNA,
        
        /// <summary>
        /// Monte Mario。
        /// </summary>
        DATUM_MONTE_MARIO,
        
        /// <summary>
        /// Montserrat Isl Astro 1958。
        /// </summary>
        DATUM_MONTSERRAT_ISLAND_1958,
        
        /// <summary>
        /// M'poraloko。
        /// </summary>
        DATUM_MPORALOKO,
        
        /// <summary>
        /// North American Datum 1927。
        /// </summary>
        DATUM_NAD_1927,
        
        /// <summary>
        /// North American Datum 1983。
        /// </summary>
        DATUM_NAD_1983,
        
        /// <summary>
        /// NAD Michigan。
        /// </summary>
        DATUM_NAD_MICH,
        
        /// <summary>
        /// Nahrwan 1967。
        /// </summary>
        DATUM_NAHRWAN_1967,
        
        /// <summary>
        /// Naparima 1972。
        /// </summary>
        DATUM_NAPARIMA_1972,
        
        /// <summary>
        /// Nord de Guerre。
        /// </summary>
        DATUM_NDG,
        
        /// <summary>
        /// National Geodetic Network (Kuwait)。
        /// </summary>
        DATUM_NGN,
        
        /// <summary>
        /// NGO 1948。
        /// </summary>
        DATUM_NGO_1948,
        
        /// <summary>
        /// Nord Sahara 1959。
        /// </summary>
        DATUM_NORD_SAHARA_1959,
        
        /// <summary>
        /// NSWC 9Z-2。
        /// </summary>
        DATUM_NSWC_9Z_2,
        
        /// <summary>
        /// Nouvelle Triangulation Francaise。
        /// </summary>
        DATUM_NTF,
        
        /// <summary>
        /// Transit precise ephemeris。
        /// </summary>
        DATUM_NWL_9D,
        
        /// <summary>
        ///  New Zealand Geodetic Datum 1949。
        /// </summary>
        DATUM_NZGD_1949,
        
        /// <summary>
        /// Observ.
        /// </summary>
        DATUM_OBSERV_METEOR_1939,
        
        /// <summary>
        /// Old Hawaiian。
        /// </summary>
        DATUM_OLD_HAWAIIAN,
         
        /// <summary>
        /// Oman。
        /// </summary>
        DATUM_OMAN,
        
        /// <summary>
        /// OS (SN) 1980。
        /// </summary>
        DATUM_OS_SN_1980,

        /// <summary>
        /// OSGB 1936。
        /// </summary>
        DATUM_OSGB_1936,

        /// <summary>
        /// OSGB 1970 (SN)。
        /// </summary>
        DATUM_OSGB_1970_SN,

        
        /// <summary>
        /// OSU 1986 geoidal model。
        /// </summary>
        DATUM_OSU_86F,

        /// <summary>
        /// OSU 1991 geoidal model。
        /// </summary>
        DATUM_OSU_91A,

        /// <summary>
        ///  Padang 1884。
        /// </summary>
        DATUM_PADANG_1884,

        /// <summary>
        /// Palestine 1923。
        /// </summary>
        DATUM_PALESTINE_1923,

        /// <summary>
        /// Pico de Las Nieves。
        /// </summary>
        DATUM_PICO_DE_LAS_NIEVES,

        /// <summary>
        /// Pitcairn Astro 1967。
        /// </summary>
        DATUM_PITCAIRN_1967,

        /// <summary>
        /// Plessis 1817。
        /// </summary>
        DATUM_PLESSIS_1817,

        /// <summary>
        ///  Point 58。
        /// </summary>
        DATUM_POINT58,

        /// <summary>
        /// Pointe Noire。
        /// </summary>
 
        DATUM_POINTE_NOIRE,

        /// <summary>
        /// Porto Santo 1936。
        /// </summary>
        DATUM_PORTO_SANTO_1936,

        /// <summary>
        /// Provisional South Amer。
        /// </summary>
        DATUM_PSAD_1956,

        /// <summary>
        /// Puerto Rico。
        /// </summary>
        DATUM_PUERTO_RICO,

        /// <summary>
        /// Pulkovo 1942。
        /// </summary>
        DATUM_PULKOVO_1942,

        /// <summary>
        /// Pulkovo 1995。
        /// </summary>
        DATUM_PULKOVO_1995,

        /// <summary>
        /// Qatar。
        /// </summary>
        DATUM_QATAR,

        /// <summary>
        ///  Qatar 1948。
        /// </summary>
        DATUM_QATAR_1948,

        /// <summary>
        /// Qornoq。
        /// </summary>
        DATUM_QORNOQ,

        /// <summary>
        /// Reunion。
        /// </summary>
        DATUM_REUNION,

        /// <summary>
        /// South Asia Singapore。
        /// </summary>
        DATUM_S_ASIA_SINGAPORE,

        /// <summary>
        ///   S-JTSK。
        /// </summary>
        DATUM_S_JTSK,

        /// <summary>
        /// S-42 Hungary。
        /// </summary>
        DATUM_S42_HUNGARY,

        /// <summary>
        /// South American Datum 1969
        /// </summary>
        DATUM_SAD_1969,

        /// <summary>
        /// American Samoa 1962。
        /// </summary>
        DATUM_SAMOA_1962,

        /// <summary>
        /// Santo DOS 1965。
        /// </summary>
        DATUM_SANTO_DOS_1965,

        /// <summary>
        /// Sao Braz。
        /// </summary>
        DATUM_SAO_BRAZ,

        /// <summary>
        /// Sapper Hill 1943。
        /// </summary>
        DATUM_SAPPER_HILL_1943,

        /// <summary>
        /// Schwarzeck。
        /// </summary>
        DATUM_SCHWARZECK,

         /// <summary>
        /// Segora。
         /// </summary>
        DATUM_SEGORA,

        /// <summary>
        /// Selvagem Grande 1938。
        /// </summary>
        DATUM_SELVAGEM_GRANDE_1938,
        
        /// <summary>
        ///  Serindung。
        /// </summary>
        DATUM_SERINDUNG,

        /// <summary>
        /// Authalic sphere。
        /// </summary>
        DATUM_SPHERE,

        /// <summary>
        /// Authalic sphere (ARC/INFO)。
        /// </summary>
        DATUM_SPHERE_AI,

        /// <summary>
        ///  Stockholm 1938。
        /// </summary>
        DATUM_STOCKHOLM_1938,

        /// <summary>
        /// Struve 1860。
        /// </summary>
        DATUM_STRUVE_1860,

        /// <summary>
        /// Sudan。
        /// </summary>
        DATUM_SUDAN,

        /// <summary>
        /// Tananarive 1925。
        /// </summary>
        DATUM_TANANARIVE_1925,

        /// <summary>
        /// Tern Island Astro 1961。
        /// </summary>
        DATUM_TERN_ISLAND_1961,

        /// <summary>
        /// Timbalai 1948。
        /// </summary>
        DATUM_TIMBALAI_1948,

        /// <summary>
        /// TM65。
        /// </summary>
        DATUM_TM65,

        /// <summary>
        ///  TM75。
        /// </summary>
        DATUM_TM75,
        
        /// <summary>
        ///  Tokyo。
        /// </summary>
        DATUM_TOKYO,

        /// <summary>
        /// Trinidad 1903。
        /// </summary>
        DATUM_TRINIDAD_1903,

        /// <summary>
        /// Tristan Astro 1968。
        /// </summary>
        DATUM_TRISTAN_1968,

        /// <summary>
        /// Trucial Coast 1948。
        /// </summary>
        DATUM_TRUCIAL_COAST_1948,

        /// <summary>
        /// 用户自定义大地参照系。
        /// </summary>
        DATUM_USER_DEFINED,
        
        /// <summary>
        ///  Viti Levu 1916。
        /// </summary>
        DATUM_VITI_LEVU_1916,

        /// <summary>
        /// Voirol 1875。
        /// </summary>
        DATUM_VOIROL_1875,

        /// <summary>
        /// Voirol Unifie 1960。
        /// </summary>
        DATUM_VOIROL_UNIFIE_1960,

        
        /// <summary>
        /// Wake-Eniwetok 1960。
        /// </summary>
        DATUM_WAKE_ENIWETOK_1960,

        /// <summary>
        /// Wake Island Astro 1952。
        /// </summary>
        DATUM_WAKE_ISLAND_1952,

        /// <summary>
        /// Walbeck。
        /// </summary>
        DATUM_WALBECK,

        /// <summary>
        /// War Office。
        /// </summary>
        DATUM_WAR_OFFICE,

        /// <summary>
        /// WGS 1966。
        /// </summary>
        DATUM_WGS_1966,

        /// <summary>
        /// WGS 1972。
        /// </summary>
        DATUM_WGS_1972,

        /// <summary>
        /// WGS 1972 Transit Broadcast Ephemeris。
        /// </summary>
        DATUM_WGS_1972_BE,

        /// <summary>
        /// WGS 1984。
        /// </summary>
        DATUM_WGS_1984,

        /// <summary>
        /// 中国西安80大地参照系。
        /// </summary>
        DATUM_XIAN_1980,

        /// <summary>
        /// Yacare。
        /// </summary>
        DATUM_YACARE,

        /// <summary>
        /// Yoff。
        /// </summary>
        DATUM_YOFF,

        /// <summary>
        ///   Zanderij。
        /// </summary>
        DATUM_ZANDERIJ
    }
}
