using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobotomizedJester.Patches
{
    [HarmonyPatch(typeof(JesterAI))]
    internal class JesterMusicPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void SukunaPossession(JesterAI __instance)
        {
            __instance.popGoesTheWeaselTheme = Plugin.LK[0];
            __instance.screamingSFX = Plugin.ScreamReplacement[0];
            Plugin.Log("************JESTER SUCCESSFULLY LOBOTOMIZED************");
        }
    }
}
