using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.Localization;
using ScrapYard.Utilities;

namespace ScrapYard.UI
{
    public class PartInstance
    {
        private InventoryPart _backingPart;
        private PartInventory _backingInventory;
        private Part _toApply;
        private bool _selling;
        private InstanceModulesVM _moduleVM;
        private InstanceModulesUI _moduleUI;
        private InventoryDisplayMetadata _displayMetadata;

        //private string _sellOrDiscard = "Discard";
        private string _sellOrDiscard = Localizer.Format("#SYD-GUI-11");

        public event EventHandler Updated;
        public InventoryPart BackingPart { get { return _backingPart; } }
        public InventoryDisplayMetadata DisplayMetadata
        {
            get
            {
                if (_displayMetadata == null)
                {
                    _displayMetadata = InventoryDisplayMetadata.For(_backingPart);
                }
                return _displayMetadata;
            }
        }

        public PartInstance(PartInventory inventory, InventoryPart iPart, bool selling, Part toApply)
        {
            _backingPart = iPart;
            _backingInventory = inventory;
            _selling = selling;
            if (selling)
            {
                //_sellOrDiscard = "Sell";
                _sellOrDiscard = Localizer.Format("#SYD-GUI-12");
            }
            _toApply = toApply;
            _moduleVM = new InstanceModulesVM(_backingPart);
        }

        public void Draw()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button(_sellOrDiscard))
            {
                sellPart();
            }
            //if (_moduleVM.GetModules().Count > 0 && GUILayout.Button("Modules"))
            if (_moduleVM.GetModules().Count > 0 && GUILayout.Button(Localizer.Format("#SYD-GUI-13")))
            {
                //show module window
                _moduleUI = ScrapYard.Instance.InstanceModulesUI;
                _moduleUI.SetUp(_moduleVM);
                _moduleUI.Show();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            //if (GUILayout.Button("Select"))
            if (GUILayout.Button(Localizer.Format("#SYD-GUI-14")))
            {
                selectPart(null);
            }
            //if (_toApply != null && GUILayout.Button("Apply"))
            if (_toApply != null && GUILayout.Button(Localizer.Format("#SYD-GUI-15")))
            {
                selectPart(_toApply);
            }
            GUILayout.EndHorizontal();
        }

        private void sellPart()
        {
            //confirm with user
            //string msg = "Are you sure you want to discard the part?";
            string msg = Localizer.Format("#SYD-GUI-16");
            if (_selling)
            {
                //msg = $"Are you sure you want to sell the part for {_backingPart.DryCost} funds?";
                double saleValue = _backingPart.DryCost * ScrapYard.Instance.Settings.CurrentSaveSettings.FundsSalePercent / 100.0;
                msg = Localizer.Format("#SYD-GUI-17", saleValue);
            }

            //MultiOptionDialog diag = new MultiOptionDialog("confirmDiscard",
            MultiOptionDialog diag = new MultiOptionDialog(Localizer.Format("confirmDiscard"),
                msg,
                //_sellOrDiscard + " Part",
                _sellOrDiscard + Localizer.Format("#SYD-GUI-18"),
                HighLogic.UISkin,
                new DialogGUIButton(_sellOrDiscard, () =>
                {
                    InventoryPart removed = _backingInventory.RemovePart(_backingPart, ComparisonStrength.STRICT);
                    if (removed != null)
                    {
                        Logging.Log($"Sold/Discarded {removed.Name}:{removed.ID}");
                        if (_selling)
                        {
                            double saleValue = removed.DryCost * ScrapYard.Instance.Settings.CurrentSaveSettings.FundsSalePercent / 100.0;
                            Funding.Instance?.AddFunds(saleValue, TransactionReasons.Vessels);
                        }
                        Updated?.Invoke(this, EventArgs.Empty);
                    }
                }),
                //new DialogGUIButton("Cancel", () => { }));
                new DialogGUIButton(Localizer.Format("#SYD-GUI-19"), () => { }));
            PopupDialog.SpawnPopupDialog(diag, false, HighLogic.UISkin);
        }

        private void selectPart(Part selectedPart)
        {
            //If a part is already selected, apply to it. Otherwise spawn a new one and apply to that.
            if (selectedPart == null)
            {
                EditorLogic.fetch.SpawnPart(Utilities.Utils.AvailablePartFromName(_backingPart.Name));
                selectedPart = EditorLogic.SelectedPart;
                if (selectedPart == null && EditorLogic.fetch?.ship?.Count == 1)
                {
                    selectedPart = EditorLogic.fetch.ship[0];
                }
            }
            _backingPart.FullyApplyToPart(selectedPart);
            ScrapYard.Instance.EditorVerificationRequired = true;
            EditorHandling.UpdateEditorCost();
            Updated?.Invoke(this, EventArgs.Empty);
        }
    }
}
