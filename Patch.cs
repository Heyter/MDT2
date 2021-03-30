using HarmonyLib;
using UnityEngine;

namespace mdt2_cheat
{
    class Patch
    {
    }

    [HarmonyPatch(typeof(characterScript), "GetWorkSpeed")]
    internal sealed class GetWorkSpeed_Patch
    {
        [HarmonyPrefix]
        private static bool Prefix(ref float __result)
        {
            __result = 10f;
            return false;
        }
    }

    [HarmonyPatch(typeof(characterScript), "GetSkillCap")]
    internal sealed class GetSkillCap_Patch
    {
        [HarmonyPrefix]
        private static bool Prefix(ref float __result)
        {
            __result = 100f;
            return false;
        }
    }

    [HarmonyPatch(typeof(characterScript), "Learn")]
    internal sealed class Learn_Patch
    {
		static float maxValue = 100f;
		static float num = 2f;

        [HarmonyPrefix]
        private static bool Prefix(characterScript __instance, bool gamedesign_, bool programmieren_, bool grafik_, bool sound_, bool pr_, bool gametests_, bool technik_, bool forschen_)
        {
			if (gamedesign_)
			{
				__instance.s_gamedesign += num;
				if (__instance.beruf != 0 && __instance.s_gamedesign > maxValue)
					__instance.s_gamedesign = maxValue;
				return false;
			}
			if (programmieren_)
			{
				__instance.s_programmieren += num;
				if (__instance.beruf != 1 && __instance.s_programmieren > maxValue)
					__instance.s_programmieren = maxValue;
				return false;
			}
			if (grafik_)
			{
				__instance.s_grafik += num;
				if (__instance.beruf != 2 && __instance.s_grafik > maxValue)
					__instance.s_grafik = maxValue;
				return false;
			}
			if (sound_)
			{
				__instance.s_sound += num;
				if (__instance.beruf != 3 && __instance.s_sound > maxValue)
					__instance.s_sound = maxValue;
				return false;
			}
			if (pr_)
			{
				__instance.s_pr += num;
				if (__instance.beruf != 4 && __instance.s_pr > maxValue)
					__instance.s_pr = maxValue;
				return false;
			}
			if (gametests_)
			{
				__instance.s_gametests += num;
				if (__instance.beruf != 5 && __instance.s_gametests > maxValue)
					__instance.s_gametests = maxValue;
				return false;
			}
			if (technik_)
			{
				__instance.s_technik += num;
				if (__instance.beruf != 6 && __instance.s_technik > maxValue)
					__instance.s_technik = maxValue;
				return false;
			}
			if (forschen_)
			{
				__instance.s_forschen += num;
				if (__instance.beruf != 7 && __instance.s_forschen > maxValue)
					__instance.s_forschen = maxValue;
				return false;
			}

			return true;
        }
    }

    [HarmonyPatch(typeof(characterScript), "AddMotivation")]
    internal sealed class AddMotivation_Patch
    {
        [HarmonyPrefix]
        private static bool Prefix(characterScript __instance)
        {
			__instance.s_motivation = 100f;
			return false;
        }
    }

	[HarmonyPatch(typeof(Menu_NewGameCEO), "BUTTON_Perk")]
	internal sealed class BUTTON_Perk_Patch
    {
		[HarmonyPostfix]
		private static void Postfix(Menu_NewGameCEO __instance)
        {
			Transform obj = __instance.uiObjects[24].transform;

			for (int l = 0; l < obj.childCount; l++)
				if (obj.childCount > l)
					obj.GetChild(l).GetComponent<UnityEngine.UI.Button>().interactable = true;
		}
    }
}
