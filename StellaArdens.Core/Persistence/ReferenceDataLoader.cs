using Newtonsoft.Json;
using StellaArdens.Core.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MBCD = StellaArdens.Core.Data;
using MBCR = StellaArdens.Core.Reference;

namespace StellaArdens.Core.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public class ReferenceDataLoader
    {
        public static void LoadReferenceData(MBCD.StellaArdensGame game)
        {
            // move this to seperate JSON files later

            // loads hulls
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_ESCORT,Name = "Escort", HullSize = HullSize.Escort, DesignSize = DesignSize.Escort });
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_CORVETTE, Name = "Escort", HullSize = HullSize.Corvette, DesignSize = DesignSize.Escort });
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_FRIGATE, Name = "Escort", HullSize = HullSize.Frigate, DesignSize = DesignSize.Escort });
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_DESTROYER, Name = "Escort", HullSize = HullSize.Destroyer, DesignSize = DesignSize.Escort });
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_LIGHT_CRUISER, Name = "Escort", HullSize = HullSize.LightCruiser, DesignSize = DesignSize.Escort });


            //CreateHull(StandardIds.ID_HULL_ESCORT, "ES", "Escort", HullClass.Escort, 800, 1200, 2000, 2, 34, 8);
            //CreateHull(StandardIds.ID_HULL_CORVETTE, "CT", "Corvette", HullClass.Escort, 1300, 1600, 2500, 2, 50, 8);
            //CreateHull(StandardIds.ID_HULL_FRIGATE, "FG", "Frigate", HullClass.Escort, 1700, 2000, 3000, 2, 67, 7);
            //CreateHull(StandardIds.ID_HULL_DESTROYER, "DD", "Destroyer", HullClass.Escort, 2100, 3000, 4000, 3, 100, 7);
            //CreateHull(StandardIds.ID_HULL_LIGHT_CRUISER, "CL", "Light Cruiser", HullClass.Crusier, 2100, 3000, 4000, 3, 100, 7);

            // load engines
            /// the module size represents an engine room so essentially the number of engine rooms per ship
            ///
            game.AddEngine(new Engine() { ModuleId = GameStandardIds.ID_NO_ENGINE, Name = "No Engine", ModuleSize = ModuleSize.NoModule });
            game.AddEngine(new Engine() { ModuleId = GameStandardIds.ID_ENGINE_BASIC_MILITARY_SMALL, Name = "Small Basic Military Engine", ModuleSize = ModuleSize.Small });
            game.AddEngine(new Engine() { ModuleId = GameStandardIds.ID_ENGINE_BASIC_MILITARY_MEDIUM, Name = "Medium Basic Military Engine", ModuleSize = ModuleSize.Medium });
            /*
            engines[1] = new Engine()
            {
                Id = StandardIds.ID_ENGINE_BASIC_MILITARY,
                Name = "Basic Ion Engine",
                Tons = 10,
                Cost = 0,
            };
            */

            // load weapons


            // load defences
            game.AddShield(new Shield() { ModuleId = GameStandardIds.ID_NO_SHIELD, Name = "No Shields", ModuleSize = ModuleSize.NoModule, Cost = 0 });
            game.AddShield(new Shield() { ModuleId = GameStandardIds.ID_BASIC_SHIELD, Name = "Basic Shields", ModuleSize = ModuleSize.NoModule, Cost = 20 });

            game.AddArmour(new Armour() { ModuleId = GameStandardIds.ID_NO_ARMOUR, Name = "No Armor", ModuleSize = ModuleSize.NoModule, Cost = 0 });
            game.AddArmour(new Armour() { ModuleId = GameStandardIds.ID_BASIC_ARMOUR, Name = "Basic Armor", ModuleSize = ModuleSize.NoModule, Cost = 10 });

            /*
            armour[1] = new Armour() { Id = 1, Name = "No Armor", Tons = 0, Cost = 0 };
            armour[2] = new Armour() { Id = 2, Name = "Basic Armor", Tons = 10, Cost = 20 };

            shields[1] = new Shield() { Id = 1, Name = "No Shields", Tons = 0, Cost = 0 };
            shields[2] = new Shield() { Id = 2, Name = "Basic Shields", Tons = 10, Cost = 20 };
            */
        }


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
