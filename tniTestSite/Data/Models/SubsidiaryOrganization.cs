using System.Collections.Generic;

namespace tniTestSite.Data.Models
{
    /// <summary>
    /// Дочерняя организация
    /// </summary>
    public class SubsidiaryOrganization : BaseDbObject
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int HeadOrganizationId { get; set; }

        public Organization HeadOrganization { get; set; }

        public List<ConsumptionObject> ConsumptionObjects { get; set; }
    }
}
