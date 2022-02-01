using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;
using Logger = BepInEx.Logging.Logger;

namespace SpiderheckModTest;

[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
public class SpiderHeckMod1 : BaseUnityPlugin
{
    public const string pluginGuid = "com.example.spiderheckmod";
    public const string pluginName = "Spiderheck Example Mod";
    public const string pluginVersion = "1.0.0";
    

    public void Awake()
    {
        var logger1 = BepInEx.Logging.Logger.CreateLogSource("main_logger");
        logger1.LogInfo("Loading Spiderheck Mod Example");
        DoPatching();
    }

    public static void DoPatching()
    {
        var harmony = new Harmony("com.example.spiderheckmod.patcher1");
        harmony.PatchAll();
    }
    
}
[HarmonyPatch(typeof(SpiderHealthSystem))]
[HarmonyPatch("ExplodeInDirection")] // if possible use nameof() here
class Patch01
{
    

    static bool Prefix(SpiderHealthSystem __instance)
    {
        var logger = BepInEx.Logging.Logger.CreateLogSource("SpiderheckExampleMod");
        
        logger.LogInfo("Loading SpiderHealthSystem Harmony Init");
        return false;
    }
    
}

