using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.CancelCreatedResponseModels
{
    public class CancelCreatedOrderItem
    {
        public string reference { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string unit { get; set; }
        public int unitPrice { get; set; }
        public int taxRate { get; set; }
        public int taxAmount { get; set; }
        public int netTotalAmount { get; set; }
        public int grossTotalAmount { get; set; }
    }

    public class CancelCreatedAmount
    {
        public int amount { get; set; }
        public string currency { get; set; }
    }

    public class CancelCreatedData
    {
        public string cancelId { get; set; }
        //public List<CancelCreatedOrderItem> orderItems { get; set; }
        public CancelCreatedAmount amount { get; set; }
        public string paymentId { get; set; }
    }

    public class CancelCreatedResponse
    {
        public string id { get; set; }
        public int merchantId { get; set; }
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public CancelCreatedData data { get; set; }
    }


}
