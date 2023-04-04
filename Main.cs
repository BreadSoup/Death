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
                Player.rigManager.health.curr_Health = 2f;
                Player.rigManager.health._testRagdollOnDeath = true;
                Player.rigManager.health.TAKEDAMAGE(3458543534);


            });
        }

    }

}
