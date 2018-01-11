using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RetailStore.Shared.Contracts.Constants;

namespace RetailStore.Shared.Contracts.DataContracts
{
    public class User
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string MobileNo { get; set; }

        [DataMember]
        public UserType Type { get; set; }

        [DataMember]
        public DateTime RegistrationDate { get; set; }

    }
}
