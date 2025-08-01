using Comfort.Common;
using EFT;
using SPT.Reflection.Patching;
using System.Reflection;

namespace UnflashbangHideout
{
    public class PatchSuperSampling : ModulePatch
    {
        protected override MethodBase GetTargetMethod() => typeof(CameraClass).GetMethod(nameof(CameraClass.SetSuperSampling), BindingFlags.Public | BindingFlags.Instance);

        [PatchPrefix]
        public static bool PatchPrefix(float sampling)
        {
            try
            {
                GameWorld Gameworld = Singleton<GameWorld>.Instance;

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
