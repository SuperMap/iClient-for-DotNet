using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary> 
    /// <para>地理坐标系类型枚举。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CoordSysType
    {
        /// <summary>
        /// Adindan。
        /// </summary>
        GCS_ADINDAN,

        /// <summary>
        ///  Afgooye。
        /// </summary>
        GCS_AFGOOYE,
        /// <summary>
        /// Agadez。
        /// </summary>
        GCS_AGADEZ,

        /// <summary>
        ///  Australian Geodetic Datum 1966。
        /// </summary>
        GCS_AGD_1966,

        /// <summary>
        ///  Australian Geodetic Datum 1984。
        /// </summary>
        GCS_AGD_1984,

        /// <summary>
        /// Ain el Abd 1970。
        /// </summary>
        GCS_AIN_EL_ABD_1970,

        /// <summary>
        /// Airy 1830。
        /// </summary>
        GCS_AIRY_1830,

        /// <summary>
        /// Airy modified。
        /// </summary>
        GCS_AIRY_MOD,

        /// <summary>
        ///  Alaskan Islands。
        /// </summary>
        GCS_ALASKAN_ISLANDS,

        /// <summary>
        /// Amersfoort。
        /// </summary>
        GCS_AMERSFOORT,

        /// <summary>
        /// Anna 1 Astro 1965。
        /// </summary>
        GCS_ANNA_1_1965,

        /// <summary>
        ///  Antigua Island Astro 1943。
        /// </summary>
        GCS_ANTIGUA_ISLAND_1943,

        /// <summary>
        /// Aratu。
        /// </summary>
        GCS_ARATU,

        /// <summary>
        /// Arc 1950。
        /// </summary>
        GCS_ARC_1950,

        /// <summary>
        ///  Arc 1960。
        /// </summary>
        GCS_ARC_1960,

        /// <summary>
        ///  Ascension Island 1958。
        /// </summary>
        GCS_ASCENSION_ISLAND_1958,

        /// <summary>
        ///  Astronomical Station 1952。
        /// </summary>
        GCS_ASTRO_1952,

        /// <summary>
        ///  ATF (Paris)。
        /// </summary>
        GCS_ATF_PARIS,

        /// <summary>
        /// Average Terrestrial System 1977。
        /// </summary>
        GCS_ATS_1977,

        /// <summary>
        /// Australian National。
        /// </summary>
        GCS_AUSTRALIAN,

        /// <summary>
        /// Ayabelle Lighthouse。
        /// </summary>
        GCS_AYABELLE,

        /// <summary>
        /// Barbados
        /// </summary>
        GCS_BARBADOS,

        /// <summary>
        /// Batavia
        /// </summary>
        GCS_BATAVIA,

        /// <summary>
        ///   Batavia (Jakarta)。
        /// </summary>
        GCS_BATAVIA_JAKARTA,

        /// <summary>
        /// Astro Beacon E 1945。
        /// </summary>
        GCS_BEACON_E_1945,

        /// <summary>
        ///  Beduaram。
        /// </summary>
        GCS_BEDUARAM,

        /// <summary>
        ///  Beijing 1954。
        /// </summary>
        GCS_BEIJING_1954,

        /// <summary>
        /// Reseau National Belge 1950。
        /// </summary>
        GCS_BELGE_1950,

        /// <summary>
        ///  Belge 1950 (Brussels)。
        /// </summary>
        GCS_BELGE_1950_BRUSSELS,

        /// <summary>
        /// Reseau National Belge 1972。
        /// </summary>
        GCS_BELGE_1972,

        /// <summary>
        ///  Bellevue IG。
        /// </summary>
        GCS_BELLEVUE,

        /// <summary>
        ///  Bermuda 1957。
        /// </summary>
        GCS_BERMUDA_1957,

        /// <summary>
        ///  Bern 1898。
        /// </summary>
        GCS_BERN_1898,

        /// <summary>
        /// Bern 1898 (Bern)。
        /// </summary>
        GCS_BERN_1898_BERN,

        /// <summary>
        ///  Bern 1938。
        /// </summary>
        GCS_BERN_1938,

        /// <summary>
        ///  Bessel 1841。
        /// </summary>
        GCS_BESSEL_1841,

        /// <summary>
        /// Bessel modified。
        /// </summary>
        GCS_BESSEL_MOD,

        /// <summary>
        /// Bessel Namibia。
        /// </summary>
        GCS_BESSEL_NAMIBIA,

        /// <summary>
        /// Bissau
        /// </summary>
        GCS_BISSAU,

        /// <summary>
        /// Bogota.
        /// </summary>
        GCS_BOGOTA,

        /// <summary>
        /// Bogota (Bogota)。
        /// </summary>
        GCS_BOGOTA_BOGOTA,

        /// <summary>
        ///  Bukit Rimpah。
        /// </summary>
        GCS_BUKIT_RIMPAH,

        /// <summary>
        /// Cape Canaveral。
        /// </summary>
        GCS_CACANAVERAL,

        /// <summary> 
        /// Camacupa。
        /// </summary>
        GCS_CAMACUPA,

        /// <summary>
        /// Camp Area Astro。
        /// </summary>
        GCS_CAMP_AREA,

        /// <summary>
        /// Campo Inchauspe。
        /// </summary>
        GCS_CAMPO_INCHAUSPE,

        /// <summary>
        /// Canton Astro 1966。
        /// </summary>
        GCS_CANTON_1966,

        /// <summary>
        ///  Cape。
        /// </summary>
        GCS_CAPE,

        /// <summary>
        /// Carthage。
        /// </summary>
        GCS_CARTHAGE,

        /// <summary>
        /// Carthage (degrees)。
        ///</summary>
        GCS_CARTHAGE_DEGREE,

        /// <summary>
        ///  Chatham Island Astro 1971。
        /// </summary>
        GCS_CHATHAM_ISLAND_1971,

        /// <summary>
        /// 2000国家大地坐标系（地心坐标系），简称 CGCS2000 （China Geodetic Coordinate System 2000）。
        /// </summary>
        GCS_CHINA_2000,

        /// <summary>
        ///  Chua。
        /// </summary>
        GCS_CHUA,

        /// <summary>
        ///  Clarke 1858。
        /// </summary>
        GCS_CLARKE_1858,

        /// <summary>
        ///  Clarke 1866。
        /// </summary>
        GCS_CLARKE_1866,

        /// <summary>
        /// Clarke 1866 Michigan。
        /// </summary>
        GCS_CLARKE_1866_MICH,

        /// <summary>
        ///  Clarke 1880。
        /// </summary>
        GCS_CLARKE_1880,

        /// <summary>
        ///  Clarke 1880 (Arc)。
        ///</summary>
        GCS_CLARKE_1880_ARC,

        /// <summary>
        /// Clarke 1880 (Benoit)。
        /// </summary>
        GCS_CLARKE_1880_BENOIT,

        /// <summary>
        ///  Clarke 1880 (IGN)。
        /// </summary>
        GCS_CLARKE_1880_IGN,

        /// <summary>
        /// Clarke 1880 (RGS)。
        /// </summary>
        GCS_CLARKE_1880_RGS,

        /// <summary> 
        /// Clarke 1880 (SGA)。
        /// </summary>
        GCS_CLARKE_1880_SGA,

        /// <summary> 
        /// Conakry 1905。
        /// </summary>
        GCS_CONAKRY_1905,

        /// <summary> 
        /// Corrego Alegre。
        /// </summary>
        GCS_CORREGO_ALEGRE,

        /// <summary> 
        ///  Cote d'Ivoire。
        /// </summary>
        GCS_COTE_D_IVOIRE,

        /// <summary> 
        ///  Dabola。
        /// </summary>
        GCS_DABOLA,

        /// <summary> 
        /// Datum 73。
        /// </summary>
        GCS_DATUM_73,

        /// <summary>
        /// Dealul Piscului 1933 (Romania)。
        /// </summary>
        GCS_DEALUL_PISCULUI_1933,

        /// <summary> 
        /// Dealul Piscului 1970 (Romania)。
        /// </summary>
        GCS_DEALUL_PISCULUI_1970,

        /// <summary> 
        ///  Deception Island。
        /// </summary>
        GCS_DECEPTION_ISLAND,

        /// <summary> 
        ///  Deir ez Zor。
        /// </summary>
        GCS_DEIR_EZ_ZOR,

        /// <summary> 
        ///  Deutsche Hauptdreiecksnetz。
        /// </summary>
        GCS_DHDNB,

        /// <summary> 
        ///  DOS 1968。
        /// </summary>
        GCS_DOS_1968,

        /// <summary> 
        ///  Astro DOS 71/4。
        /// </summary>
        GCS_DOS_71_4,

        /// <summary> 
        /// Douala。
        /// </summary>
        GCS_DOUALA,

        /// <summary> 
        /// Easter Island 1967。
        /// </summary>
        GCS_EASTER_ISLAND_1967,

        /// <summary> 
        ///  European Datum 1950。
        /// </summary>
        GCS_ED_1950,

        /// <summary> 
        ///  European Datum 1987。
        /// </summary>
        GCS_ED_1987,

        /// <summary> 
        ///  Egypt 1907。
        /// </summary>
        GCS_EGYPT_1907,

        /// <summary> 
        /// European Terrestrial Ref。
        /// </summary>
        GCS_ETRS_1989,

        /// <summary> 
        ///  European 1979。
        /// </summary>
        GCS_EUROPEAN_1979,

        /// <summary> 
        ///  Everest 1830。
        /// </summary>
        GCS_EVEREST_1830,

        /// <summary> 
        ///  Everest - Bangladesh。
        /// </summary>
        GCS_EVEREST_BANGLADESH,

        /// <summary> 
        /// Everest (definition 1967)。
        /// </summary>
        GCS_EVEREST_DEF_1967,

        /// <summary> 
        ///  Everest (definition 1975)。
        /// </summary>
        GCS_EVEREST_DEF_1975,

        /// <summary> 
        /// Everest - India and Nepal。
        /// </summary>
        GCS_EVEREST_INDIA_NEPAL,

        /// <summary> 
        /// Everest modified。
        /// </summary>
        GCS_EVEREST_MOD,

        /// <summary> 
        /// Everest modified 1969。
        /// </summary>
        GCS_EVEREST_MOD_1969,

        /// <summary> 
        ///  Fahud。
        /// </summary>
        GCS_FAHUD,

        /// <summary> 
        /// Fischer 1960。
        /// </summary>
        GCS_FISCHER_1960,

        /// <summary> 
        /// Fischer 1968。
        /// </summary>
        GCS_FISCHER_1968,

        /// <summary> 
        /// Fischer modified。
        /// </summary>
        GCS_FISCHER_MOD,

        /// <summary> 
        ///  Fort Thomas 1955。
        /// </summary>
        GCS_FORT_THOMAS_1955,

        /// <summary> 
        ///  Gan 1970。
        /// </summary>
        GCS_GAN_1970,

        /// <summary> 
        /// Gandajika 1970。
        /// </summary>
        GCS_GANDAJIKA_1970,
        
        /// <summary> 
        ///  Garoua。
        /// </summary>
        GCS_GAROUA,

        /// <summary> 
        /// Geocentric Datum of Australia 1994。
        /// </summary>
        GCS_GDA_1994,

        /// <summary> 
        /// GEM gravity potential model。
        /// </summary>
        GCS_GEM_10C,

        /// <summary> 
        ///  Greek Geodetic Ref。
        /// </summary>
        GCS_GGRS_1987,

        /// <summary> 
        ///  Graciosa Base SW 1948。
        /// </summary>
        GCS_GRACIOSA_1948,

        /// <summary> 
        ///  Greek。
        /// </summary>
        GCS_GREEK,

        /// <summary> 
        ///  Greek (Athens)。
        /// </summary>
        GCS_GREEK_ATHENS,

        /// <summary> 
        ///  GRS 1967。
        /// </summary>
        GCS_GRS_1967,

        /// <summary> 
        /// GRS 1980。
        /// </summary>
        GCS_GRS_1980,

        /// <summary> 
        ///  Guam 1963。
        /// </summary>
        GCS_GUAM_1963,

        /// <summary> 
        /// Gunung Segara。
        /// </summary>
        GCS_GUNUNG_SEGARA,

        /// <summary> 
        /// GUX 1 Astro。
        /// </summary>
        GCS_GUX_1,

        /// <summary> 
        /// Guyane Francaise。
        /// </summary>
        GCS_GUYANE_FRANCAISE,

        /// <summary> 
        /// Helmert 1906。
        /// </summary>
        GCS_HELMERT_1906,

        /// <summary> 
        ///  Herat North。
        /// </summary>
        GCS_HERAT_NORTH,

        /// <summary> 
        ///  Hito XVIII 1963。
        /// </summary>
        GCS_HITO_XVIII_1963,

        /// <summary> 
        ///  Hjorsey 1955。
        /// </summary>
        GCS_HJORSEY_1955,

        /// <summary> 
        /// Hong Kong 1963。
        /// </summary>
        GCS_HONG_KONG_1963,

        /// <summary> 
        ///   Hough 1960。
        /// </summary>
        GCS_HOUGH_1960,

        /// <summary> 
        ///  Hu Tzu Shan。
        /// </summary>
        GCS_HU_TZU_SHAN,

        /// <summary> 
        /// Hungarian Datum 1972。
        /// </summary>
        GCS_HUNGARIAN_1972,

        /// <summary> 
        ///  Indian 1954。
        /// </summary>
        GCS_INDIAN_1954,

        /// <summary> 
        /// Indian 1960。
        /// </summary>
        GCS_INDIAN_1960,
        /// <summary> 
        ///  Indian 1975。
        /// </summary>
        GCS_INDIAN_1975,

        /// <summary> 
        /// Indonesian National。
        /// </summary>
        GCS_INDONESIAN,

        /// <summary> 
        ///  Indonesian Datum 1974。
        /// </summary>
        GCS_INDONESIAN_1974,

        /// <summary> 
        /// International 1924。
        /// </summary>
        GCS_INTERNATIONAL_1924,

        /// <summary> 
        /// International 1967。
        /// </summary>
        GCS_INTERNATIONAL_1967,

        /// <summary> 
        ///   ISTS 061 Astro 1968。
        /// </summary>
        GCS_ISTS_061_1968,

        /// <summary> 
        ///  ISTS 073 Astro 1969。
        /// </summary>
        GCS_ISTS_073_1969,

        /// <summary> 
        ///  Jamaica 1875。
        /// </summary>
        GCS_JAMAICA_1875,

        /// <summary> 
        ///   Jamaica 1969。
        /// </summary>
        GCS_JAMAICA_1969,

        /// <summary> 
        /// 日本JGD2000坐标系。
        /// </summary>
        GCS_JAPAN_2000,

        /// <summary> 
        /// Johnston Island 1961。
        /// </summary>
        GCS_JOHNSTON_ISLAND_1961,

        /// <summary> 
        /// Kalianpur。
        /// </summary>
        GCS_KALIANPUR,

        /// <summary> 
        ///  Kandawala。
        /// </summary>
        GCS_KANDAWALA,

        /// <summary> 
        ///  Kerguelen Island 1949。
        /// </summary>
        GCS_KERGUELEN_ISLAND_1949,

        /// <summary> 
        ///  Kertau。
        /// </summary>
        GCS_KERTAU,

        /// <summary> 
        /// Kartastokoordinaattijarjestelma。
        /// </summary>
        GCS_KKJ,

        /// <summary> 
        /// Kuwait Oil Company。
        /// </summary>
        GCS_KOC_,

        /// <summary>
        ///  Krasovsky 1940。
        /// </summary>
        GCS_KRASOVSKY_1940,

        /// <summary> 
        /// Kuwait Utility。
        /// </summary>
        GCS_KUDAMS,

        /// <summary> 
        /// Kusaie Astro 1951。
        /// </summary>
        GCS_KUSAIE_1951,

        /// <summary> 
        ///  La Canoa。
        /// </summary>
        GCS_LA_CANOA,

        /// <summary> 
        ///   Lake。
        /// </summary>
        GCS_LAKE,

        /// <summary> 
        /// L.C. 5 Astro 1961。
        /// </summary>
        GCS_LC5_1961,

        /// <summary> 
        ///  Leigon。
        /// </summary>
        GCS_LEIGON,

        /// <summary> 
        ///  Liberia 1964。
        /// </summary>
        GCS_LIBERIA_1964,

        /// <summary> 
        /// Lisbon。
        /// </summary>
        GCS_LISBON,

        /// <summary> 
        ///  Lisbon (Lisbon)。
        /// </summary>
        GCS_LISBON_LISBO,

        /// <summary> 
        ///  Loma Quintana。
        /// </summary>
        GCS_LOMA_QUINTANA,

        /// <summary> 
        ///  Lome。
        /// </summary>
        GCS_LOME,

        /// <summary> 
        ///  Luzon 1911。
        /// </summary>
        GCS_LUZON_1911,

        /// <summary> 
        ///  Mahe 1971。
        /// </summary>
        GCS_MAHE_1971,

        /// <summary> 
        /// Makassar。
        /// </summary>
        GCS_MAKASSAR,

        /// <summary> 
        ///  Makassar (Jakarta)。
        /// </summary>
        GCS_MAKASSAR_JAKARTA,

        /// <summary> 
        ///  Malongo 1987。
        /// </summary>
        GCS_MALONGO_1987,

        /// <summary> 
        ///  Manoca。
        /// </summary>
        GCS_MANOCA,

        /// <summary> 
        /// Massawa。
        /// </summary>
        GCS_MASSAWA,

        /// <summary> 
        /// Merchich。
        /// </summary>
        GCS_MERCHICH,

        /// <summary> 
        ///  Militar-Geographische Institut。
        /// </summary>
        GCS_MGI_,

        /// <summary> 
        /// MGI (Ferro)。
        /// </summary>
        GCS_MGI_FERRO,

        /// <summary> 
        ///  Mhast。
        /// </summary>
        GCS_MHAST,

        /// <summary> 
        /// Midway Astro 1961。
        /// </summary>
        GCS_MIDWAY_1961,

        /// <summary> 
        ///  Minna。
        /// </summary>
        GCS_MINNA,

        /// <summary> 
        /// Monte Mario。
        /// </summary>
        GCS_MONTE_MARIO,

        /// <summary> 
        ///  Monte Mario (Rome)。
        /// </summary>
        GCS_MONTE_MARIO_ROME,

        /// <summary> 
        /// Montserrat Astro 1958。
        /// </summary>
        GCS_MONTSERRAT_ISLAND_1958,

        /// <summary> 
        /// M'poraloko。
        /// </summary>
        GCS_MPORALOKO,

        /// <summary> 
        /// North American Datum 1927。
        /// </summary>
        GCS_NAD_1927,


        /// <summary> 
        /// North American Datum 1983。
        /// </summary>
        GCS_NAD_1983,

        /// <summary> 
        /// NAD Michigan。
        /// </summary>
        GCS_NAD_MICH,

        /// <summary> 
        /// Nahrwan 1967。
        /// </summary>
        GCS_NAHRWAN_1967,

        /// <summary> 
        ///  Naparima 1972。
        /// </summary>
        GCS_NAPARIMA_1972,

        /// <summary> 
        ///  Nord de Guerre (Paris)。
        /// </summary>
        GCS_NDG_PARIS,

        /// <summary> 
        /// National Geodetic Network (Kuwait)。
        /// </summary>
        GCS_NGN,

        /// <summary> 
        /// NGO 1948。
        /// </summary>
        GCS_NGO_1948_,

        /// <summary> 
        /// Nord Sahara 1959。
        /// </summary>
        GCS_NORD_SAHARA_1959,

        /// <summary> 
        ///  NSWC 9Z-2。
        /// </summary>
        GCS_NSWC_9Z_2_,

        /// <summary> 
        ///  Nouvelle Triangulation Francaise。
        /// </summary>
        GCS_NTF_,

        /// <summary> 
        ///  NTF (Paris)。
        /// </summary>
        GCS_NTF_PARIS,

        /// <summary> 
        /// Transit precise ephemeris。
        /// </summary>
        GCS_NWL_9D,

        /// <summary> 
        /// New Zealand Geodetic Datum 1949。
        /// </summary>
        GCS_NZGD_1949,

        /// <summary> 
        /// Observ。
        /// </summary>
        GCS_OBSERV_METEOR_1939,

        /// <summary> 
        ///  Old Hawaiian。
        /// </summary>
        GCS_OLD_HAWAIIAN,

        /// <summary> 
        /// Oman。
        /// </summary>
        GCS_OMAN,

        /// <summary> 
        /// OS (SN) 1980。
        /// </summary>
        GCS_OS_SN_1980,

        /// <summary> 
        ///  OSGB 1936。
        /// </summary>
        GCS_OSGB_1936,

        /// <summary> 
        /// OSGB 1970 (SN)。
        /// </summary>
        GCS_OSGB_1970_SN,

        /// <summary> 
        /// OSU 1986 geoidal model。
        /// </summary>
        GCS_OSU_86F,

        /// <summary> 
        /// OSU 1991 geoidal model。
        /// </summary>
        GCS_OSU_91A,

        /// <summary> 
        /// Padang 1884。
        /// </summary>
        GCS_PADANG_1884,

        /// <summary> 
        /// Padang 1884 (Jakarta)。
        /// </summary>
        GCS_PADANG_1884_JAKARTA,

        /// <summary> 
        ///  Palestine 1923。
        /// </summary>
        GCS_PALESTINE_1923,

        /// <summary> 
        /// Pico de Las Nieves。
        /// </summary>
        GCS_PICO_DE_LAS_NIEVES,

        /// <summary> 
        /// Pitcairn Astro 1967。
        /// </summary>
        GCS_PITCAIRN_1967,

        /// <summary> 
        /// Plessis 1817。
        /// </summary>
        GCS_PLESSIS_1817,

        /// <summary> 
        /// Point 58。
        /// </summary>
        GCS_POINT58,

        /// <summary> 
        /// Pointe Noire。
        /// </summary>
        GCS_POINTE_NOIRE,

        /// <summary> 
        /// Porto Santo 1936。
        /// </summary>
        GCS_PORTO_SANTO_1936,

        /// <summary> 
        /// Provisional South Amer。
        /// </summary>
        GCS_PSAD_1956,

        /// <summary> 
        /// Puerto Rico。
        /// </summary>
        GCS_PUERTO_RICO,

        /// <summary>
        ///  Pulkovo 1942。
        /// </summary>
        GCS_PULKOVO_1942,

        /// <summary> 
        /// Pulkovo 1995。
        /// </summary>
        GCS_PULKOVO_1995,

        /// <summary> 
        ///  Qatar。
        /// </summary>
        GCS_QATAR,

        /// <summary> 
        /// Qatar 1948。
        /// </summary>
        GCS_QATAR_1948,

        /// <summary> 
        /// Qornoq。
        /// </summary>
        GCS_QORNOQ,

        /// <summary> 
        /// Reunion。
        /// </summary>
        GCS_REUNION,

        /// <summary> 
        /// RT38。
        /// </summary>
        GCS_RT38,

        /// <summary> 
        /// RT38 (Stockholm)。
        /// </summary>
        GCS_RT38_STOCKHOLM,

        /// <summary> 
        /// South Asia Singapore。
        /// </summary>
        GCS_S_ASIA_SINGAPORE,

        /// <summary> 
        /// S-JTSK。
        /// </summary>
        GCS_S_JTSK,

        /// <summary> 
        ///  S-42 Hungary。
        /// </summary>
        GCS_S42_HUNGARY,

        /// <summary> 
        ///  South American Datum 1969。
        /// </summary>
        GCS_SAD_1969,

        /// <summary> 
        /// American Samoa 1962。
        /// </summary>
        GCS_SAMOA_1962,

        /// <summary> 
        /// Santo DOS 1965。
        /// </summary>
        GCS_SANTO_DOS_1965,

        /// <summary> 
        /// Sao Braz。
        /// </summary>
        GCS_SAO_BRAZ,

        /// <summary> 
        /// Sapper Hill 1943。
        /// </summary>
        GCS_SAPPER_HILL_1943,

        /// <summary> 
        /// Schwarzeck。
        /// </summary>
        GCS_SCHWARZECK,

        /// <summary> 
        /// Segora。
        /// </summary>
        GCS_SEGORA,

        /// <summary> 
        /// Selvagem Grande 1938。
        /// </summary>
        GCS_SELVAGEM_GRANDE_1938,

        /// <summary> 
        /// Serindung。
        /// </summary>
        GCS_SERINDUNG,

        /// <summary> 
        /// Authalic sphere。
        /// </summary>
        GCS_SPHERE,

        /// <summary> 
        ///  Authalic sphere (ARC/INFO)。
        /// </summary>
        GCS_SPHERE_AI,

        /// <summary> 
        ///  Struve 1860。
        /// </summary>
        GCS_STRUVE_1860,

        /// <summary> 
        ///  Sudan。
        /// </summary>
        GCS_SUDAN,

        /// <summary> 
        /// Tananarive 1925。
        /// </summary>
        GCS_TANANARIVE_1925,

        /// <summary> 
        /// Tananarive 1925 (Paris)。
        /// </summary>
        GCS_TANANARIVE_1925_PARIS,

        /// <summary> 
        /// Tern Island Astro 1961。
        /// </summary>
        GCS_TERN_ISLAND_1961,

        /// <summary> 
        /// Timbalai 1948。
        /// </summary>
        GCS_TIMBALAI_1948,

        /// <summary> 
        /// TM65。
        /// </summary>
        GCS_TM65,

        /// <summary> 
        /// TM75。
        /// </summary>
        GCS_TM75,

        /// <summary> 
        /// Tokyo。
        /// </summary>
        GCS_TOKYO,

        /// <summary> 
        /// Trinidad 1903。
        /// </summary>
        GCS_TRINIDAD_1903,

        /// <summary> 
        /// Tristan Astro 1968。
        /// </summary>
        GCS_TRISTAN_1968,

        /// <summary> 
        /// Trucial Coast 1948。
        /// </summary>
        GCS_TRUCIAL_COAST_1948,

        /// <summary> 
        /// 用户自定义的地理坐标系。
        /// </summary>
        GCS_USER_DEFINE,

        /// <summary> 
        /// Viti Levu 1916。
        /// </summary>
        GCS_VITI_LEVU_1916,

        /// <summary> 
        /// Voirol 1875。
        /// </summary>
        GCS_VOIROL_1875,

        /// <summary> 
        /// Voirol 1875 (Paris)。
        /// </summary>
        GCS_VOIROL_1875_PARIS,

        /// <summary> 
        ///  Voirol Unifie 1960。
        /// </summary>
        GCS_VOIROL_UNIFIE_1960,

        /// <summary> 
        ///  Voirol Unifie 1960 (Paris)。
        /// </summary>
        GCS_VOIROL_UNIFIE_1960_PARIS,

        /// <summary> 
        /// Wake-Eniwetok 1960。
        /// </summary>
        GCS_WAKE_ENIWETOK_1960,

        /// <summary> 
        /// Wake Island Astro 1952。
        /// </summary>
        GCS_WAKE_ISLAND_1952,

        /// <summary> 
        /// Walbeck。
        /// </summary>
        GCS_WALBECK,

        /// <summary> 
        /// War Office。
        /// </summary>
        GCS_WAR_OFFICE,

        /// <summary> 
        /// WGS 1966。
        /// </summary>
        GCS_WGS_1966,

        /// <summary> 
        ///  WGS 1972。
        /// </summary>
        GCS_WGS_1972,

        /// <summary> 
        /// WGS 1972 Transit Broadcast Ephemer。
        /// </summary>
        GCS_WGS_1972_BE,

        /// <summary> 
        /// WGS 1984。
        /// </summary>
        GCS_WGS_1984,

        /// <summary> 
        /// 西安80坐标系。
        /// </summary>
        GCS_XIAN_1980,

        /// <summary> 
        /// Yacare。
        /// </summary>
        GCS_YACARE,

        /// <summary>
        ///  Yoff。
        /// </summary>
        GCS_YOFF,

        /// <summary>
        /// Zanderij。
        /// </summary>
        GCS_ZANDERIJ
    }
}
