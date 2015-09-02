
using Timber_and_Stone.API;
using Timber_and_Stone.API.Event;
using Timber_and_Stone.Event;

namespace Plugin.KTMBobisback.MapStatsChooser
{
    /// <summary>
    ///     The main plugin for this mod. It is called by the game through predefined functions.
    /// </summary>
    public class MapStatsChooserPlugin : CSharpPlugin, IEventListener
    {
        /// <summary>
        ///     This function is called when the mod loads at startup
        /// </summary>
        public override void OnLoad() {
            GUIManager.getInstance().AddTextLine("KTM & Bobisback Map Stat Chooser Loaded");
            //add all of our GUI's to the game
            GUIManager.getInstance().gameObject.AddComponent(typeof(GUIWindowMapStatsChooser));
        }

        /// <summary>
        ///     This function is also called on mod startup. It is called after OnLoad
        /// </summary>
        public override void OnEnable() {
            GUIManager.getInstance().AddTextLine("KTM & Bobisback Map Stat Chooser Enabled");
            EventManager.getInstance().Register(this);
        }

        /// <summary>
        ///     Becuase OnDisable() is not called at the moment, I use this function to save any settings before my mod gets unloaded. 
        ///     This fucntion is called a deconstructor, it is called when the class is being deallocated from memory.
        /// </summary>
        ~MapStatsChooserPlugin() {
            //SettingsManager.SaveSettings();
        }
    }
}
