using BepInEx;
using CreatureManager;
using HarmonyLib;

namespace TestFlyingMob
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin
    {
        #region values
        private const string ModName = "TestFlyingMob", ModVersion = "1.0.0", ModGUID = "com.Frogger." + ModName;
        private static readonly Harmony harmony = new(ModGUID);
        public static Plugin _self;
        #endregion

        private void Awake()
        {
            _self = this;

            Creature droneRed = new("testflyingmob", "DroneRed")
            {
                Biome = Heightmap.Biome.Meadows,
                GroupSize = new Range(1, 2),
                CheckSpawnInterval = 600,
                RequiredWeather = Weather.ClearSkies | Weather.Fog,
                Maximum = 2,
                ConfigurationEnabled = true,
                CanHaveStars = true,
                SpawnChance = 15,
                CanBeTamed = false,
                CanSpawn = true
            };

            droneRed.Localize()
                .English("Red drone")
                .Russian("Красный дрон");
            droneRed.Drops["Coins"].Amount = new Range(55, 70);
            droneRed.Drops["Coins"].MultiplyDropByLevel = true;
            droneRed.Drops["Coins"].DropChance = 85;

            Creature droneOrange = new("testflyingmob", "DroneOrange")
            {
                Biome = Heightmap.Biome.Meadows,
                GroupSize = new Range(1, 2),
                CheckSpawnInterval = 600,
                RequiredWeather = Weather.ClearSkies | Weather.Fog,
                Maximum = 2,
                ConfigurationEnabled = true,
                CanHaveStars = true,
                SpawnChance = 15,
                CanBeTamed = false,
                CanSpawn = true
            };

            droneOrange.Localize()
                .English("Orange drone")
                .Russian("Оранжевый дрон");

            droneOrange.Drops["Coins"].Amount = new Range(55, 70);
            droneOrange.Drops["Coins"].MultiplyDropByLevel = true;
            droneOrange.Drops["Coins"].DropChance = 85;

            harmony.PatchAll();
        }

        #region Patch
        [HarmonyPatch]
        public static class Pacth
        {
            /*[HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake)), HarmonyPostfix]
            public static void ZNetPatch(ZNetScene __instance)
            {
                if (SceneManager.GetActiveScene().name != "main") return;

            }*/
        }
        #endregion
        #region tools
        public void Debug(string msg)
        {
            Logger.LogInfo(msg);
        }
        public void DebugError(string msg)
        {
            Logger.LogError($"{msg} Write to the developer and moderator if this happens often.");
        }
        #endregion
    }
}