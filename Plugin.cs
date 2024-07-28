using System;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using Utilla;
using GorillaNetworking;

namespace Clicker
{
    // PURPOSE OF SCRIPT: Adds the clicker asset bundle onto the players hands and defines some varibles


    [ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
        public bool inRoom;

        public static Plugin instance;
        public static AssetBundle bundle;
        public static GameObject assetBundleParent;
        public static string bundleName = "clickerbundle";
        public static string parentName = "Clicker";


        void Start()
		{
			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnEnable()
		{
            assetBundleParent.SetActive(true);
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			assetBundleParent.SetActive(false);
			/* Undo mod setup here */
			/* This provides support for toggling mods with ComputerInterface, please implement it :) */
			/* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
            instance = this;

            Transform rightHand = GorillaLocomotion.Player.Instance.rightControllerTransform;

            bundle = LoadAssetBundle("Clicker.AssetBundles." + bundleName);

            assetBundleParent = Instantiate(bundle.LoadAsset<GameObject>(parentName));

            assetBundleParent.transform.SetParent(rightHand);
            assetBundleParent.transform.localPosition = new Vector3(-0.02f, 0.01f, -0.035f);
			assetBundleParent.transform.localEulerAngles = new Vector3(0, 273, 210);
			assetBundleParent.AddComponent<ClickerScript>();

        }


		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			inRoom = true;
        }

		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			inRoom = false;
        }
       

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
