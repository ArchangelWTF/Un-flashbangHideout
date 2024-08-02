using System;
using System.Reflection;
using SPT.Reflection.Patching;
using Comfort.Common;
using EFT;

namespace UnflashbangHideout
{
    internal class PatchSuperSampling : ModulePatch
    {
        protected override MethodBase GetTargetMethod() => typeof(CameraClass).GetMethod("SetSuperSampling", BindingFlags.Public | BindingFlags.Instance);

        [PatchPrefix]
        private static bool PatchPrefix(float sampling)
        {
            try
            {
                var Gameworld = Singleton<GameWorld>.Instance;

                if (Gameworld.MainPlayer.Location == "hideout")
                {
                    Logger.LogInfo("Overriding the usage of SuperSampling in the hideout");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogInfo($"Caught Exception: {ex}");

                return true;
            }
        }
    }
}
