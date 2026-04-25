using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP.Localization;

namespace ScrapYard
{
    public class SaveSpecificSettings : GameParameters.CustomParameterNode
    {
        /// <summary>Settings: Game Mode</summary>
        public override GameParameters.GameMode GameMode
        { get { return GameParameters.GameMode.ANY; } }

        /// <summary>Settings: Has Presets</summary>
        public override bool HasPresets
        { get { return false; } }  //for now lets not have presets

        /// <summary>Section Heading</summary>
        public override string Section
        { get { return "#SYD-settings-SectionName"; } } // "ScrapYard";

        /// <summary>Section Order</summary>
        public override int SectionOrder
        { get { return 1; } }

        /// <summary>Settings Title</summary>
        public override string Title
        { get { return "#SYD-settings-Title"; } } //"ScrapYard"; 

        /// <summary>Display Section Title</summary>
        public override string DisplaySection
        { get { return "#SYD-settings-DisplaySection"; } } // Title;

        /// <summary>Is this enabled (globally)?</summary>
        [GameParameters.CustomParameterUI("#SYD-settings-ModEnabled", toolTip = "#SYD-settings-ModEnabled-Tip")]
        public bool ModEnabled = true;

        /// <summary>Use the Inventory feature?</summary>
        [GameParameters.CustomParameterUI("#SYD-settings-UseInventory", toolTip = "#SYD-settings-UseInventory-Tip")]
        public bool UseInventory = true;

        /// <summary>Use the tracking feature?</summary>
        [GameParameters.CustomParameterUI("#SYD-settings-UseTracker", toolTip = "#SYD-settings-UseTracker-Tip")]
        public bool UseTracker = true;

        /// <summary>Override funds?</summary>
        [GameParameters.CustomParameterUI("#SYD-settings-OverrideFunds", toolTip = "#SYD-settings-OverrideFunds-Tip")]
        public bool OverrideFunds = false;

        /// <summary>Fuds sale as a percentage</summary>
        [GameParameters.CustomIntParameterUI("#SYD-settings-FundsSalePercent", toolTip = "#SYD-settings-FundsSalePercent-Tip", minValue = 0, maxValue = 100, stepSize = 1)]
        public int FundsSalePercent = 100;

        /// <summary>Cost charged when using an inventory part, as a percentage of dry cost</summary>
        [GameParameters.CustomIntParameterUI("#SYD-settings-InventoryUseCostPercent", toolTip = "#SYD-settings-InventoryUseCostPercent-Tip", minValue = 0, maxValue = 100, stepSize = 1)]
        public int InventoryUseCostPercent = 0;

        /// <summary>Additional debug logging</summary>
        [GameParameters.CustomParameterUI("#SYD-settings-DebugLogging", toolTip = "#SYD-settings-DebugLogging-Tip")]
        public bool DebugLogging = false;

        /// <summary>RefreshTime</summary>
        [GameParameters.CustomIntParameterUI("#SYD-settings-RefreshTime", toolTip = "#SYD-settings-RefreshTime-Tip", minValue = 2, maxValue = 100, stepSize = 2)]
        public int RefreshTime = 10;

        /// <summary>Enable colors in the PAW?</summary>
        [GameParameters.CustomParameterUI("#SYD-settings-CPAW", toolTip = "#SYD-settings-CPAW-Tip")]
        public bool coloredPAW = true;
    }
}
