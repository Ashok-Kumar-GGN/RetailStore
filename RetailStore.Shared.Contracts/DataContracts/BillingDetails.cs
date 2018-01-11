using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RetailStore.Shared.Contracts.DataContracts;

namespace RetailStore.Shared.Contracts.DataContracts
{
    public class BillingDetails
    {
        public BillingDetails()
        {
            UserDetails = new User();
            ItemList = new List<CartItem>();
        }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public User UserDetails { get; set; }

        [DataMember]
        public List<CartItem> ItemList { get; set; }

        [DataMember]
        public double BillingAmount { get; set; }

        [DataMember]
        public double DiscountRate { get; set; }

        [DataMember]
        public double NetDiscount { get; set; }

        [DataMember]
        public double NetPayableAmount { get; set; }

    }
}
