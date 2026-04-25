using System;
using System.Linq;
using System.Reflection;

namespace ScrapYard.Utilities
{
    public class InventoryDisplayMetadata
    {
        public int? Generation { get; private set; }
        public int PreviousUses { get; private set; }
        public int? SafetyRating { get; private set; }

        public string GroupKey
        {
            get
            {
                return string.Format("gen:{0}|uses:{1}|sr:{2}",
                    Generation.HasValue ? Generation.Value.ToString() : "",
                    PreviousUses,
                    SafetyRating.HasValue ? SafetyRating.Value.ToString() : "");
            }
        }

        public string Label
        {
            get
            {
                string label = Generation.HasValue
                    ? string.Format("Gen {0} | Uses {1}", Generation.Value, PreviousUses)
                    : string.Format("Uses {0}", PreviousUses);

                if (SafetyRating.HasValue)
                {
                    label += string.Format(" | SR {0}", SafetyRating.Value);
                }

                return label;
            }
        }

        public static InventoryDisplayMetadata For(InventoryPart part)
        {
            InventoryDisplayMetadata metadata = new InventoryDisplayMetadata
            {
                PreviousUses = part?.TrackerModule?.TimesRecovered ?? 0
            };

            ConfigNode ohScrapNode = OhScrapInventoryMetadataProvider.GetMetadata(part);
            if (ohScrapNode == null)
            {
                return metadata;
            }

            int value = 0;
            if (ohScrapNode.TryGetValue("Generation", ref value))
            {
                metadata.Generation = value;
            }

            value = metadata.PreviousUses;
            if (ohScrapNode.TryGetValue("PreviousUses", ref value))
            {
                metadata.PreviousUses = value;
            }

            value = 0;
            if (ohScrapNode.TryGetValue("SafetyRating", ref value))
            {
                metadata.SafetyRating = value;
            }

            return metadata;
        }
    }

    internal static class OhScrapInventoryMetadataProvider
    {
        private static MethodInfo metadataMethod;
        private static bool lookupAttempted;

        public static ConfigNode GetMetadata(InventoryPart part)
        {
            if (part == null)
            {
                return null;
            }

            try
            {
                MethodInfo method = GetMetadataMethod();
                if (method == null)
                {
                    return null;
                }

                return method.Invoke(null, new object[] { part.State }) as ConfigNode;
            }
            catch (Exception ex)
            {
                Logging.DebugLog("OhScrap inventory metadata unavailable: " + ex.Message);
                return null;
            }
        }

        private static MethodInfo GetMetadataMethod()
        {
            if (lookupAttempted)
            {
                return metadataMethod;
            }

            lookupAttempted = true;
            Assembly ohScrap = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => string.Equals(a.GetName().Name, "OhScrap", StringComparison.OrdinalIgnoreCase));
            Type metadataType = ohScrap?.GetType("OhScrap.InventoryMetadata");
            metadataMethod = metadataType?.GetMethod("GetForInventoryPart", BindingFlags.Public | BindingFlags.Static);
            return metadataMethod;
        }
    }
}
