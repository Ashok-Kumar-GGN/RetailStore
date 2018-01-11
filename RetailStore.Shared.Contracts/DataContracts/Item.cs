using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RetailStore.Shared.Contracts.Constants;
namespace RetailStore.Shared.Contracts.DataContracts
{
    public class Item
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Rate { get; set; }

        [DataMember]
        public ItemType ItemType { get; set; }
    }
}
