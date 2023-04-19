using System.ComponentModel.DataAnnotations;

namespace Inspection
{
    public class InspectionTypes
    {
        public int Id { get; set; }
        
        [StringLength(20)]
        public string InspectionName { get; set; } = String.Empty;
    }
}
