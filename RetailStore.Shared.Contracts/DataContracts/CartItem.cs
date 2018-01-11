using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RetailStore.Shared.Contracts.DataContracts;

namespace RetailStore.Shared.Contracts.DataContracts
{
    public class CartItem
    {
        public CartItem()
        {
            Item = new Item();
        }
        [DataMember]
        public Item Item { get; set; }

        [DataMember]
        public double Quantity { get; set; }
    }
}
