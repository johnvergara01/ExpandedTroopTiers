using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace ExpandedTroopTiers
{
	[HarmonyPatch(typeof(CharacterObject), "get_TroopWage")]
	internal class WageEdits
	{
		public static bool Prefix(ref int __result, CharacterObject __instance)
		{
			if (__instance.IsHero)
			{
				__result = 2 + __instance.Level * 2;
			}
			else
			{
				__result = Config.Wages[__instance.Tier];
			}
			return false;
		}
	}
}
