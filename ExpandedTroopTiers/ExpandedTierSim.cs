using System;
using HarmonyLib;
using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace ExpandedTroopTiers
{
	[HarmonyPatch(typeof(CharacterHelper), "GetCharacterTier")]
	internal class ExpandedTierSim
	{
		public static bool Prefix(CharacterObject character, ref int __result)
		{

			if (character.IsHero)
			{
				__result = 0;
			}
			__result = Math.Min(Math.Max(MathF.Ceiling(((float)character.Level - 5f) / 5f), 0), Config.HighestTier);
			return false;
		}
	}
}