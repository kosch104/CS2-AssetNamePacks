using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AssetNamePacks.Localization;
using HarmonyLib;
using Colossal.Localization;
using Colossal.IO.AssetDatabase;
using UnityEngine;

namespace AssetNamePacks.Patches
{
    [HarmonyPatch(typeof(LocalizationManager), "AddLocale", typeof(LocaleAsset))]
    internal class LocalizationManager_AddLocale
    {
        static readonly LocalizationJS localizationJS = new();
        static public readonly string AssetPackPath =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "packs");
        static void Prefix(LocaleAsset asset)
        {
            Localization.Localization.AddCustomLocal(asset);

            if (localizationJS == null)
                return;
            if (localizationJS.Localization == null)
                return;

            foreach(string key in asset.data.entries.Keys)
            {
                if(!localizationJS.Localization.ContainsKey(asset.localeId))
                {
                    localizationJS.Localization.Add(asset.localeId, []);
                }
                if(!localizationJS.Localization[asset.localeId].ContainsKey(key)) localizationJS.Localization[asset.localeId].Add(key, asset.data.entries[key]);
            }

            Dictionary<string, Dictionary<string, int>> localeIndex = [];

            foreach(string key in asset.data.indexCounts.Keys)
            {
                if(!localeIndex.ContainsKey(asset.localeId))
                {
                    localeIndex.Add(asset.localeId, []);
                }
                if(!localeIndex[asset.localeId].ContainsKey(key)) localeIndex[asset.localeId].Add(key, asset.data.indexCounts[key]);
            }
        }
    }
}
