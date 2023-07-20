using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Plugins;
using OpenMod.API.Plugins;
using SDG.Unturned;
using HarmonyLib;

// For more, visit https://openmod.github.io/openmod-docs/devdoc/guides/getting-started.html

[assembly: PluginMetadata("Blockie.RejectConfOverride", DisplayName = "Reject Config Override")]
namespace MyOpenModPlugin
{
    public class MyOpenModPlugin : OpenModUnturnedPlugin
    {
        private readonly IConfiguration m_Configuration;
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly ILogger<MyOpenModPlugin> m_Logger;

        public MyOpenModPlugin(
            IConfiguration configuration,
            IStringLocalizer stringLocalizer,
            ILogger<MyOpenModPlugin> logger,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Configuration = configuration;
            m_StringLocalizer = stringLocalizer;
            m_Logger = logger;
        }

        protected override async UniTask OnLoadAsync()
        {
            // await UniTask.SwitchToMainThread(); uncomment if you have to access Unturned or UnityEngine APIs
            m_Logger.LogInformation("[RejectConfOverride] I geuss its working now..");

            // await UniTask.SwitchToThreadPool(); // you can switch back to a different thread
        }

        protected override async UniTask OnUnloadAsync()
        {
            // await UniTask.SwitchToMainThread(); uncomment if you have to access Unturned or UnityEngine APIs
            m_Logger.LogInformation("[RejectConfOverride] Unloading...");
        }
    }
}
[HarmonyPatch(typeof(Provider))]
static class SomeTrash {
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Provider.applyLevelModeConfigOverrides))]
        public static bool applyLevelModeConfigOverridesPrefix()
        {
            return false;
        }
}