using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MBCD = StellaArdens.Core.Data;
using MBCR = StellaArdens.Core.Reference;

namespace StellaArdens.Core.Persistence
{
    /// <summary>
    /// Gun data sources
    /// 
    /// http://www.navweaps.com/index_nathan/Penetration_Germany.php
    /// </summary>
    public class ReferenceDataLoader
    {
        public static void LoadGunData(MBCD.StellaArdensGame game)
        {

            JsonSerializer serializer = new JsonSerializer();
            //serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamReader sr = new StreamReader(@".\Reference\gundata.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                MBCR.GunData[] guns = serializer.Deserialize<MBCR.GunData[]>(reader);
                foreach(MBCR.GunData gun in guns)
                {
                    game.GunData[gun.GunId] = gun;
                }
            }

            /*
            List<MBCR.GunData> gundata = new List<MBCR.GunData>();
            gundata.Add(
                new MBCR.GunData()
                {
                    Name = "6 In L77",
                    BarrelLength = 77,
                    CaliberInInches = 6f,
                    GunId = 1,

                }
                );
            gundata.Add(
                new MBCR.GunData()
                {
                    Name = "4 In L45",
                    BarrelLength = 45,
                    CaliberInInches = 4f,
                    GunId = 2,

                }
                );
            using (StreamWriter sw = new StreamWriter(@"d:\json.txt", false))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, gundata);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }
            */
        }
    }
}
