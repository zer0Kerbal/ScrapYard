using System;
using System.Collections.Generic;

namespace ScrapYard
{
    /// <summary>
    /// Remembers the inventory parts whose use was refunded (OverrideFunds) while they are out of the inventory.
    /// A part that comes back to the inventory without being recovered (KCT edits and scrapping) pays that refund back,
    /// and a part is never refunded twice for the same trip out of the inventory.
    /// </summary>
    public class RefundLedger
    {
        private Dictionary<uint, double> refunds = new Dictionary<uint, double>();

        /// <summary>
        /// Checks if the use of the part with the given ID was already refunded
        /// </summary>
        public bool Contains(uint id)
        {
            return refunds.ContainsKey(id);
        }

        /// <summary>
        /// Records the refund given for the use of the part with the given ID
        /// </summary>
        public void Record(uint id, double amount)
        {
            refunds[id] = amount;
        }

        /// <summary>
        /// Forgets the refund of the part with the given ID
        /// </summary>
        /// <returns>The amount that was refunded, or 0 if none</returns>
        public double Take(uint id)
        {
            if (refunds.TryGetValue(id, out double amount))
            {
                refunds.Remove(id);
                return amount;
            }
            return 0;
        }

        public ConfigNode State
        {
            get
            {
                ConfigNode node = new ConfigNode("RefundLedger");
                foreach (KeyValuePair<uint, double> kvp in refunds)
                {
                    node.AddValue(kvp.Key.ToString(), kvp.Value);
                }
                return node;
            }
            internal set
            {
                try
                {
                    refunds.Clear();
                    if (value == null)
                    {
                        return;
                    }
                    foreach (ConfigNode.Value val in value.values)
                    {
                        if (uint.TryParse(val.name, out uint id) && double.TryParse(val.value, out double amount))
                        {
                            refunds[id] = amount;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "RefundLedger");
                }
            }
        }
    }
}
