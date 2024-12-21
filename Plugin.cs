using BepInEx;

namespace UnflashbangHideout
{
    [BepInPlugin("com.archangelwtf.unflashbanghideout", "Un-flashbang Hideout", "1.0.2")]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            new PatchSuperSampling().Enable();
        }
    }
}
