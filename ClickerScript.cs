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
using Photon.Realtime;
using TMPro;
using HarmonyLib;
using System.Threading.Tasks;

namespace Clicker
{
    // PURPOSE OF SCRIPT: Allows the player to click when pressing RightTrigger

    public class ClickerScript : MonoBehaviour
    {

        public float Clicks;

        public static TMP_Text ClickText;

        public static GameObject Button;

        public static ParticleSystem Milestone1;


        private bool CanClick = true;

        
        void Milestone(float MilestoneNum)
        {
            Milestone1 = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHand Controller/Clicker(Clone)/clicker/Milestone1Particle").GetComponent<ParticleSystem>();
            if (MilestoneNum == 1)
            {
                Milestone1.Play();
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(255, false, 0.1f);
                GorillaTagger.Instance.StartVibration(false, 0.1f, 0.01f);
            }
        }

        void Update()
        {
            ClickText = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHand Controller/Clicker(Clone)/clicker/MainObject/ClickerText").GetComponent<TMP_Text>();
            ClickText.text = Clicks.ToString();

            Button = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHand Controller/Clicker(Clone)/clicker/Button");

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f && CanClick)
            {
                CanClick = false;
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.1f);
                GorillaTagger.Instance.StartVibration(false, 0.06f, 0.001f);
                Button.transform.localPosition = new Vector3(0.0473f, -0.0151f, 0.1945f);
                Clicks += 1;
                if (Clicks == 69)
                {
                    Milestone(1);
                }
                if (Clicks == 100)
                {
                    Milestone(1);
                }
                if (Clicks == 200)
                {
                    Milestone(1);
                }
                if (Clicks == 300)
                {
                    Milestone(1);
                }
                if (Clicks == 400)
                {
                    Milestone(1);
                }
                if (Clicks == 500)
                {
                    Milestone(1);
                }
                if (Clicks == 1000)
                {
                    Milestone(1);
                }
                if (Clicks == 2000)
                {
                    Milestone(1);
                }
                if (Clicks == 3000)
                {
                    Milestone(1);
                }
                if (Clicks == 4000)
                {
                    Milestone(1);
                }
                if (Clicks == 5000)
                {
                    Milestone(1);
                }
                if (Clicks == 10000)
                {
                    Milestone(1);
                }
            }
            if (ControllerInputPoller.instance.rightControllerIndexFloat == 0f && !CanClick)
            {
                CanClick = true;

                Button.transform.localPosition = new Vector3(0.0473f, -0.0151f, 0.4945f);
            }
        }
    }
}
