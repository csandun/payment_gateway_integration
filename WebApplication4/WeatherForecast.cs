using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class Amount
    {
        public int amount { get; set; }
        public string currency { get; set; }
    }

    public class OrderItem
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

    public class Order
    {
        public Amount amount { get; set; }
        public string reference { get; set; }
        //public List<OrderItem> orderItems { get; set; }
    }

    public class CreatedData
    {
        //public Order order { get; set; }
        public string paymentId { get; set; }
    }

    public class CreatedResponse
    {
        public string id { get; set; }
        public int merchantId { get; set; }
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public CreatedData data { get; set; }
    }

    //{"paymentId":"01590000618d49a78c7ed2e6f9488e06","hostedPaymentPageUrl":"https://test.checkout.dibspayment.eu/hostedpaymentpage/?checkoutKey=b27040f040a646609abe50639b2b2b11&pid=01590000618d49a78c7ed2e6f9488e06"}

    public class PaymentCreatedResponse
    {
        public string PaymentId { get; set; }
        public string HostedPaymentPageUrl { get; set; }
    }

   

    public class ReservationCreatedData
    {
        public string paymentMethod { get; set; }
        public string paymentType { get; set; }
        public Amount amount { get; set; }
        public string paymentId { get; set; }
    }

    public class ReservationCreatedResponse
    {
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public int merchantNumber { get; set; }
        public string @event { get; set; }
        public ReservationCreatedData data { get; set; }
    }

}
