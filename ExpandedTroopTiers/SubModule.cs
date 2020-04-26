using System;
using System.Windows;
using HarmonyLib;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Core;

namespace ExpandedTroopTiers
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            try
            {
                Config config = new Config();
                base.OnSubModuleLoad();
                new Harmony("YoumuuG.ExpandedTroopTiers").PatchAll();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error occured applying Harmony: " + exception.Message);
            }
        }

        public override void OnGameInitializationFinished(Game game)
        {
            try
            {
                InformationManager.DisplayMessage(new InformationMessage("Highest Troop Tier: " + Config.HighestTier));
                InformationManager.DisplayMessage(new InformationMessage("Highest Tier Wage: " + Config.Wages[Config.HighestTier]));
                base.OnGameInitializationFinished(game);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }
    }
}