using System.Collections.Generic;

namespace tniTestSite.Data.Models
{
    public class Organization : BaseDbObject
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public List<SubsidiaryOrganization> SubsidiaryOrganizations { get; set; }
    }
}
