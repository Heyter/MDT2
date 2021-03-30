using System;
using BepInEx;
using HarmonyLib;

namespace hCheat
{
    [BepInPlugin(MOD_GUID, MOD_NAME, MOD_VERSION)]
    public class ModEntryPoint : BaseUnityPlugin
    {
        private const string MOD_NAME = "hCheat";
        private const string MOD_GUID = "org.bepinex.plugins." + MOD_NAME;
        private const string MOD_VERSION = "1.0.0";

        internal new static BepInEx.Logging.ManualLogSource Logger;

        private ModEntryPoint() {
            Logger = base.Logger;
            Logger.LogInfo("ModEntryPoint loaded");
        }

        internal void Awake()
        {
            try
            {
                if (FindObjectsOfType<ModEntryPoint>().Length > 1)
                {
                    Logger.LogWarning(string.Format("Another instance of {0} was instantiated. Will destroy this: {1}",
                        typeof(ModEntryPoint),
                        gameObject.GetInstanceID()
                    ));
                    DestroyImmediate(this);
                }
                else
                {
                    new Harmony(MOD_GUID).PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
                    Logger.LogInfo("Successfully patched via Harmony.");
                }
            }
            catch (Exception arg)
            {
                Logger.LogError(string.Format("Failed to patch via Harmony. Error: {0}", arg));
            }
        }
    }
}
