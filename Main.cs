using System;
using System.Threading;
using System.Runtime.InteropServices;

using HarmonyLib;

using MelonLoader;

using UnityEngine;

using System.Collections;

using SLZ.AI;
using SLZ.Rig;
using SLZ.Marrow.Data;
using BoneLib;
using BoneLib.BoneMenu;
using SLZ.Interaction;

using SLZ.SaveData;


namespace bonelab_template
{

    internal partial class Main : MelonMod
    {

        public override void OnInitializeMelon()
        {
            CreateBoneMenu();
        }

        public static void CreateBoneMenu() //creates bonemenu
        {

            var category = MenuManager.CreateCategory("Death", "#e33e32"); //this just makes it so I dont have to add all of this to the begining of every element
                                                                           // category.CreateBoolElement("Mod Toggle", Color.yellow, Main.IsEnabled, new Action<bool>(Main.OnSetEnabled)); later


            category.CreateFunctionElement("DIE", Color.red, delegate () //This gets the barcode of the avatar to switch and also sets a button to the name of the avatar
            {
                Player.rigManager.health.SetHealthMode(1); //1 is normal 2 is fast 0 is unkillable || I would set it to 2 but it brakes the mod after 1st use
                Player.rigManager.health._testRagdollOnDeath = true;
                Player.rigManager.health.TAKEDAMAGE(3458543534);

            });
        }
        private void death()
        {
            this.hand = base.GetComponent<Hand>();
        }

        [HarmonyPatch(typeof(RigManager), "Awake")]
        public class RigmanagerMortalityPatch
        {
            public static void Postfix(RigManager __instance)
            {
                Player_Health componentInChildren = __instance.GetComponentInChildren<Player_Health>();
                componentInChildren.reloadLevelOnDeath = false;
                
            }
        }
        private Hand hand;
    }
}
// I dont want to do this anymore feel free to do wahtever you want with this