using UnityEngine.Analytics;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.XRContent.Interaction.Analytics
{
    /// <summary>
    /// The entry point class to send XRContent analytics data.
    /// Stores all events usd by XRContent.
    /// </summary>
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    static class XrcAnalytics
    {
        internal const string k_VendorKey = "unity.xrcontent.interaction";

        internal static bool Quitting { get; private set; }
        internal static bool Disabled { get; }

        internal static InteractionEvent InteractionEvent { get; } = new InteractionEvent();

        static XrcAnalytics()
        {
            var result = InteractionEvent.Register();

            // if the user has analytics disabled, respect that and make sure that no code actually tries to send events
            if (result == AnalyticsResult.AnalyticsDisabled)
            {
                Disabled = true;
                return;
            }

#if UNITY_EDITOR
            EditorApplication.quitting += SetQuitting;
#endif
        }

        static void SetQuitting()
        {
            // we set the Quitting variable so that we don't record window close events when the editor quits
            Quitting = true;
        }
    }
}
