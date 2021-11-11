using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.CheckoutCompletedResponseModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class CheckoutCompletedAmount
    {
        public int amount { get; set; }
        public string currency { get; set; }
    }

    public class CheckoutCompletedOrderItem
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

    public class CheckoutCompletedOrder
    {
        public CheckoutCompletedAmount amount { get; set; }
        public string reference { get; set; }
        //public List<CheckoutCompletedOrderItem> orderItems { get; set; }
    }

    public class CheckoutCompletedBillingAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public string receiverLine { get; set; }
    }

    public class CheckoutCompletedPhoneNumber
    {
        public string prefix { get; set; }
        public string number { get; set; }
    }

    public class CheckoutCompletedShippingAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public string receiverLine { get; set; }
    }

    public class CheckoutCompletedConsumer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public CheckoutCompletedBillingAddress billingAddress { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string ip { get; set; }
        public CheckoutCompletedPhoneNumber phoneNumber { get; set; }
        public CheckoutCompletedShippingAddress shippingAddress { get; set; }
    }

    public class CheckoutCompletedData
    {
       // public CheckoutCompletedOrder order { get; set; }
        public CheckoutCompletedConsumer consumer { get; set; }
        public string paymentId { get; set; }
    }

    public class CheckoutCompletedResponse
    {
        public string id { get; set; }
        public int merchantId { get; set; }
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public CheckoutCompletedData data { get; set; }
    }


}
