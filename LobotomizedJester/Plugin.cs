using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LobotomizedJester
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "KurisuBot.LobotomizedJester";
        private const string modName = "LobotomizedJester";
        private const string modVersion = "1.0.0";
        public static Plugin instance;
        private readonly Harmony harmony = new Harmony(modGUID);
        internal ManualLogSource mls;
        internal static List<AudioClip> LK;
        internal static List<AudioClip> ScreamReplacement;
        internal static AssetBundle Bundle;
        internal static AssetBundle Bundle2;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource("KurisuBot.LobotomizedJester");
            mls.LogInfo("LobotomizedJester Loading . . . ");
            string text = instance.Info.Location;
            text = text.TrimEnd("LobotomizedJester.dll".ToCharArray());
            mls.LogInfo(text);

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);

            LK = new List<AudioClip>();
            ScreamReplacement = new List<AudioClip>();
            Bundle = AssetBundle.LoadFromFile(text + "lobotomykaisen");
            Bundle2 = AssetBundle.LoadFromFile(text + "chase");
            if (Bundle != null)
            {
                LK = Bundle.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                this.mls.LogError("Failed to load asset bundle (lobotomykaisen)");
            }
            if (Bundle2 != null)
            {
                this.mls.LogInfo("Sucessfully loaded asset bundle (chase)");
                ScreamReplacement = Bundle2.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                this.mls.LogError("Failed to load asset bundle (chase)");
            }
            mls.LogInfo("LobotomizedJester Loaded!");

        }
        public static void Log(string message)
        {
            Plugin.instance.Logger.LogInfo(message);
        }
    }
}