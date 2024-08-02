using BepInEx;

namespace UnflashbangHideout
{
    [BepInPlugin("spt.unflashbang.hideout", "Un-flashbang Hideout", "1.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            new PatchSuperSampling().Enable();
        }
    }
}
