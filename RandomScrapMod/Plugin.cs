using BepInEx;
using HarmonyLib;
using LethalLib.Modules;
using System.IO;
using System.Reflection;
using UnityEngine;


namespace RandomScrapMod
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        const string GUID = "bocon.randomscrapmod";
        const string NAME = "Random Scrap Mod";
        const string VERSION = "1.0.1";

        public static Plugin instance;

        void Awake()
        {
            instance = this;

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "RandomScrapMod");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

            Item barrelOLuck = bundle.LoadAsset<Item>("Assets/RandomScrapMod/Barrel.asset");
            NetworkPrefabs.RegisterNetworkPrefab(barrelOLuck.spawnPrefab);
            Utilities.FixMixerGroups(barrelOLuck.spawnPrefab);
            Items.RegisterScrap(barrelOLuck,1000,Levels.LevelTypes.All);

            Logger.LogInfo("Patched Item Tutorial");
        }
    }
}
