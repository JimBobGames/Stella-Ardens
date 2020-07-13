using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StellaArdens.Core.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace StellaArdens.Test
{
    [TestClass]
    public class UnitTestPersistence
    {
        [TestMethod]
        public void TestBasicPersistence()
        {
            // test reading and writing a basic object to JSON
            JsonSerializer serializer = new JsonSerializer();
            //serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
            serializer.Formatting = Formatting.Indented;

            // simple object
            TestGame testGame = new TestGame();
            TestNation terrans = testGame.AddNation(new TestNation()
            {
                NationId = 1,
                Bank = 100,
                Name = "Terran Empire",
                ShortName = "Terrans"
            });
            TestNation orions = testGame.AddNation(new TestNation()
            {
                NationId = 2,
                Bank = 1020,
                Name = "Orion Khanate",
                ShortName = "Orions"
            });

            testGame.AddFleet(new TestFleet() {FleetId = 1, Name = "1st Fleet", ShortName = "F1" }, terrans);
            testGame.AddFleet(new TestFleet() { FleetId = 2, Name = "2nd Fleet", ShortName = "F2" }, terrans);
            testGame.AddFleet(new TestFleet() { FleetId = 3, Name = "3rd Fleet", ShortName = "F3" }, terrans);

            TestSolarSystem sol = new TestSolarSystem() { Name = "Sol", ShortName = "Sol", SolarSystemId = 100 };
            testGame.AddSolarSystem(sol);
            terrans.HomeSystem = sol;
            sol.Controller = terrans;

            // write the data structure to the disk
            using (StreamWriter sw = new StreamWriter(@"temp.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, testGame);
            }

            // read the data back
            using (StreamReader sr = new StreamReader(@"temp.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                TestGame readGame = serializer.Deserialize<TestGame>(reader);
                Assert.IsNotNull(readGame);
                Assert.IsTrue(readGame.nationList.Count > 0);
            }
        }
    }

  //  string json = JsonConvert.SerializeObject(people, Formatting.Indented,
  //  new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

    public class TestGame
    {
        [JsonProperty]
        private readonly Dictionary<int, TestFleet> fleetDictionary = new Dictionary<int, TestFleet>();
        [JsonProperty]
        private Dictionary<int, TestNation> nationDictionary = new Dictionary<int, TestNation>();

        public ObservableCollection<TestNation> nationList = new ObservableCollection<TestNation>();

        public ObservableCollection<TestSolarSystem> solarSystemList = new ObservableCollection<TestSolarSystem>();

        public TestNation AddNation(TestNation n)
        {
            nationDictionary[n.NationId] = n;
            nationList.Add(n);

            return n;
        }
        public TestFleet AddFleet(TestFleet f, TestNation n)
        {
            fleetDictionary[f.FleetId] = f;
            n.Fleets.Add(f);
            f.Owner = n;

            return f;
        }
        public TestSolarSystem AddSolarSystem(TestSolarSystem ss)
        {
            solarSystemList.Add(ss);

            return ss;
        }

    }

    public class TestNation 
    {
        public int NationId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public int Bank { get; set; }

        public TestSolarSystem HomeSystem { get; set; }

        private ObservableCollection<TestFleet> fleets = new ObservableCollection<TestFleet>();

        public ObservableCollection<TestFleet> Fleets
        {
            get
            {
                return fleets;
            }
        }

    }
    public class TestFleet
    {
        public int FleetId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public TestNation Owner { get; set; }

    }
    public class TestSolarSystem
    {
        public TestNation Controller { get; set; }
        public int SolarSystemId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }

    }
}
