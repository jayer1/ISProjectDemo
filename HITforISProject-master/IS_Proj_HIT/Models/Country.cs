using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
