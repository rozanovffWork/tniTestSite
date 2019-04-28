using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tniTestSite.Api.ElectricityMeasurementPoints
{
    public class ElectricApplianceInputModel
    {

        public int? Id { get; set; }

        [DisplayName("Номер")]
        public string Number { get; set; }

        [DisplayName("Дата поверки"), DataType(DataType.Date)]
        public DateTime? VerificationDate { get; set; }

        internal bool IsEmpty()
        {
            return string.IsNullOrEmpty(Number) && VerificationDate == null;
        }
    }


}
