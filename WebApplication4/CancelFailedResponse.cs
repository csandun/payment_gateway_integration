using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.CancelFailedResponseModels
{
    public class CancelFailedError
    {
        public string code { get; set; }
        public string message { get; set; }
        public string source { get; set; }
    }

    public class CancelFailedOrderItem
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

    public class CancelFailedAmount
    {
        public int amount { get; set; }
        public string currency { get; set; }
    }

    public class CancelFailedData
    {
        public CancelFailedError error { get; set; }
        public string cancelId { get; set; }
        //public List<CancelFailedOrderItem> orderItems { get; set; }
        public CancelFailedAmount amount { get; set; }
        public string paymentId { get; set; }
    }

    public class CancelFailedResponse
    {
        public string id { get; set; }
        public int merchantId { get; set; }
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public CancelFailedData data { get; set; }
    }
}
