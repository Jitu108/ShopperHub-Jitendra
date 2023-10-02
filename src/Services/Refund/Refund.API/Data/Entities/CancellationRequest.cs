using Refund.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refund.API.Data.Entities
{
    public class CancellationRequest
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime CancellationDate { get; set; }
        public string CancellationReason { get; set; }
        [NotMapped]
        public OrderCancellationStatus InitialStatus { get; set; } = OrderCancellationStatus.CancellationRequested;
        public OrderCancellationStatus FinalCancellationStatus { get; set; }
        public DateTime CancellationUpdateDate { get; set; }
    }
}
