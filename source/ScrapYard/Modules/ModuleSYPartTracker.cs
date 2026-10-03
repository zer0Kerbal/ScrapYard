using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP.Localization;

namespace ScrapYard.Modules
{
    /// <summary>
    /// Applied to individual parts, it tracks how often that part has been used. Added and/or incremented by one each recovery.
    /// Strict comparisons between parts with different values will fail, but semi-soft comparisons will ignore this
    /// </summary>
    public class ModuleSYPartTracker : PartModule
    {
        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)]
        private uint id = 0;
        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)]
        public int TimesRecovered = 0;
        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)]
        public bool Inventoried = false;

        [KSPField(isPersistant = false, guiActive = true, guiActiveEditor = true)]
        public string ScrapYard = string.Empty;

        public uint ID
        {
            get { return id; }
            set
            {
                id = value;
                updateDisplay();
            }
        }

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            if (state == StartState.Editor && id == 0)
            {
                id = part.persistentId;
            }
            updateDisplay();
        }
        public override void OnInitialize()
        {
            base.OnInitialize();
            if (id == 0)
            {
                id = part.persistentId;
            }
            updateDisplay();
        }

        public override void OnCopy(PartModule fromModule)
        {
            base.OnCopy(fromModule);
            MakeFresh();
        }

        public void MakeFresh()
        {
            ID = FlightGlobals.GetUniquepersistentId();
            TimesRecovered = 0;
            Inventoried = false;
            updateDisplay();
        }

        public void ApplyInventoryState(uint inventoryId, int timesRecovered, bool inventoried)
        {
            id = inventoryId;
            TimesRecovered = timesRecovered;
            Inventoried = inventoried;
            updateDisplay();
        }

        private void updateDisplay()
        {
            if (Inventoried)
            {

                string _0 = Localizer.Format("#SYD-GUI-0");
                string _1 = Localizer.Format("#SYD-GUI-1");
                //string use = TimesRecovered != 1 ? Localizer.Format("#SYD-GUI-0") : Localizer.Format("#SYD-GUI-1");
                string use = TimesRecovered != 1 ? _0 : _1;
                //ScrapYard = $"{TimesRecovered} Previous {use}";
                ScrapYard = Localizer.Format("#SYD-GUI-2", TimesRecovered, use);
            }
            else
            {
                ScrapYard = Localizer.Format("#SYD-GUI-3");
            }
            //ScrapYard += $" {ID}";
        }
    }
}
