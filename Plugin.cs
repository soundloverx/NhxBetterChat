using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace NhxBetterChat
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    // NhxQualityPack contains this same chat code, so with both installed every message would be sent twice and stamped twice
    [BepInIncompatibility("NhxQualityPack")]
    // BetterChat changes the same chat code (talk distance, shout pings, the chat window), so combined the two would fight over it
    [BepInIncompatibility("dev.crystal.betterchat")]
    public class Plugin : BaseUnityPlugin
    {
        private const string PluginGuid = "NhxBetterChat";
        private const string PluginName = "NhxBetterChat";
        private const string PluginVersion = "1.0.1";

        internal static Plugin Instance { get; private set; }
        internal static ManualLogSource Log { get; private set; }

        private ConfigEntry<bool> _worldChat;
        private ConfigEntry<bool> _chatSoundAlert;
        private Harmony _harmonyInstance;

        internal static bool WorldChatEnabled => Instance?._worldChat != null ? Instance._worldChat.Value : true;

        internal static bool ChatSoundAlertEnabled => Instance?._chatSoundAlert != null ? Instance._chatSoundAlert.Value : true;

        private void Awake()
        {
            Instance = this;
            Log = Logger;

            // Everything this mod does happens on the players' clients. A dedicated server still has a Chat object, and
            // it handles each chat message before passing it on to the other players, so a failure in a patch there
            // would stop the message from reaching anyone. On a server the mod therefore leaves the game untouched.
            if (Paths.ProcessName == "valheim_server")
            {
                Log.LogInfo($"{PluginName} v{PluginVersion} is client-side only and does nothing on a dedicated server.");
                return;
            }

            _worldChat = Config.Bind(
                "Chat",
                "World Chat",
                true,
                "Send normal chat messages (and /s shouts) to every player in the world instead of only nearby players. They're shown like normal chat, without a marker on the map, and the sender's name is added when they're far away or out of view. Chat messages also get a [HH:mm:ss] timestamp in the chat window. Turning this off leaves chat exactly as in the unmodded game."
            );

            _chatSoundAlert = Config.Bind(
                "Chat",
                "Chat Sound Alert",
                true,
                "Play a short sound when another player's chat message appears in the chat window (your own messages are silent). It follows the game's sound effects volume. Only works while World Chat is on."
            );

            Assembly assembly = Assembly.GetExecutingAssembly();
            _harmonyInstance = new Harmony(PluginGuid);
            _harmonyInstance.PatchAll(assembly);

            Log.LogInfo($"{PluginName} v{PluginVersion} loaded.");
        }

        private void OnDestroy()
        {
            _harmonyInstance?.UnpatchSelf();

            Log?.LogInfo($"{PluginName} v{PluginVersion} unloaded.");

            Instance = null;
        }
    }
}
