using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Colossal.IO.AssetDatabase;
using UnityEngine;

namespace AssetNamePacks.Localization
{
	public class Localization
	{
		internal static Dictionary<string, Dictionary<string, string>> localization;

		internal static void AddCustomLocal(LocaleAsset localeAsset)
		{
			if (localization is null) LoadLocalization();

			if (localization is null)
				return;

			string loc = localeAsset.localeId;

			if (!localization.ContainsKey(loc))
				return;

            foreach(string key in localization[loc].Keys)
            {
                if(localeAsset.data.entries.ContainsKey(key))
	                localeAsset.data.entries[key] = localization[loc][key];
                else
	                localeAsset.data.entries.Add(key, localization[loc][key]);

                if(!key.Contains(":")) continue;

                string[] parts = key.Split(":");
                if (int.TryParse(parts[1], out int n))
                {
	                n++;
	                if (localeAsset.data.indexCounts.ContainsKey(parts[0]))
	                {
		                if (localeAsset.data.indexCounts[parts[0]] != n) // Was <
		                {
			                localeAsset.data.indexCounts[parts[0]] = n;
		                }
	                }
	                else localeAsset.data.indexCounts.Add(parts[0], n);
                }
            }
		}

		private static void LoadLocalization()
		{
			var packsDirectory = new DirectoryInfo(Patches.LocalizationManager_AddLocale.AssetPackPath);
			if (!packsDirectory.Exists)
			{
				Debug.LogWarning("[Asset Name Packs] Packs directory not found: " + packsDirectory.FullName);
				return;
			}
			Dictionary<string, string> packs = new();
			foreach(DirectoryInfo pack in packsDirectory.GetDirectories())
			{
				packs.Add(pack.Name, pack.FullName);
			}
			Debug.Log("[Asset Name Packs] Found " + packs.Count + " packs");
			// ContainsKey throws error?
			if (packs.ContainsKey("Default"))
			{
				LoadPack(packs["Default"]);
			}
			else
			{
				Debug.LogWarning("[Asset Name Packs] Default pack not found");
				localization = new();
			}
		}

		private static void LoadPack(string path)
		{
			Dictionary<string, Dictionary<string, string>> dictionary = new();
			DirectoryInfo di = new DirectoryInfo(path);
			foreach (FileInfo file in new DirectoryInfo(path).GetFiles("*.txt"))
			{
				using (StreamReader reader = new StreamReader(file.FullName))
				{
					var parts = file.Name.Split(".");
					var assetName = parts[0];
					var locale = parts[1];
					Dictionary<string, string> strings = new();

					string line = reader.ReadLine();
					int i = 0;
					while (line != null)
					{
						strings.Add("Assets." + assetName.ToUpper() + ":" + i, line);
						i++;
						line = reader.ReadLine();
					}
					dictionary.Add(locale, strings);
				}
			}
			localization = dictionary;
		}
	}

	[Serializable]
	public class LocalizationLocaleJS
	{	
		public Dictionary<string, string> Localization;

	}

	public class LocalizationJS
	{
		public Dictionary<string, Dictionary<string, string>> Localization = [];
	}
}
