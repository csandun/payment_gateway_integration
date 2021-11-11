using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using WebApplication4.CancelCreatedResponseModels;
using WebApplication4.CancelFailedResponseModels;
using WebApplication4.CheckoutCompletedResponseModels;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
       private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            const string secretKey = "[*******SECREAT-KEY********]";
            //const string payload = "{\"order\":{\"items\":[{\"reference\":\"Sneaky\",\"name\":\"Sneaky\",\"quantity\":1,\"unit\":\"pcs\",\"unitPrice\":2500,\"taxRate\":1000,\"taxAmount\":250,\"netTotalAmount\":2500,\"grossTotalAmount\":2750}],\"amount\":2750,\"currency\":\"SEK\",\"reference\":\"NetsEasyshop\"},\"checkout\":{\"termsUrl\":\"https://example.com/terms\",\"publicDevice\":false,\"charge\":false,\"integrationType\":\"HostedPaymentPage\",\"merchantHandlesConsumerData\":false,\"consumerType\":{\"supportedTypes\":[\"B2C\",\"B2B\"],\"default\":\"B2C\"},\"returnUrl\":\"https://[*******HOSTED-URL********]/swagger\"},\"notifications\":{\"webhooks\":[{\"eventName\":\"payment.created\",\"url\":\"https://[*******HOSTED-URL********]/Payments\",\"authorization\":\"myAuthorizationKey\"},{\"eventName\":\"payment.checkout.completed\",\"url\":\"https://[*******HOSTED-URL********]/Payments\",\"authorization\":\"myAuthorizationKey\"}]}}";
            const string payload =  "{\"order\":{\"items\":[{\"reference\":\"Sneaky\",\"name\":\"Sneaky\",\"quantity\":1,\"unit\":\"pcs\",\"unitPrice\":2500,\"taxRate\":1000,\"taxAmount\":250,\"netTotalAmount\":2500,\"grossTotalAmount\":2750}],\"amount\":2750,\"currency\":\"SEK\",\"reference\":\"NetsEasyshop\"},\"checkout\":{\"termsUrl\":\"https://[*******HOSTED-URL********]\",\"publicDevice\":false,\"charge\":false,\"integrationType\":\"HostedPaymentPage\",\"merchantHandlesConsumerData\":false,\"consumerType\":{\"supportedTypes\":[\"B2C\",\"B2B\"],\"default\":\"B2C\"},\"returnUrl\":\"https://[*******HOSTED-URL********]\"},\"notifications\":{\"webhooks\":[{\"eventName\":\"payment.created\",\"url\":\"https://[*******HOSTED-URL********]/Created\",\"authorization\":\"[*******SECREAT-KEY********]\"},{\"eventName\":\"payment.reservation.created.v2\",\"url\":\"https://[*******HOSTED-URL********]/ReservationCreated\",\"authorization\":\"[*******SECREAT-KEY********]\"},{\"eventName\":\"payment.checkout.completed\",\"url\":\"https://[*******HOSTED-URL********]/CheckoutCompleted\",\"authorization\":\"[*******SECREAT-KEY********]\"},{\"eventName\":\"payment.cancel.created\",\"url\":\"https://[*******HOSTED-URL********]/CancelCreated\",\"authorization\":\"[*******SECREAT-KEY********]\"},{\"eventName\":\"payment.cancel.failed\",\"url\":\"https://[*******HOSTED-URL********]/CancelFailed\",\"authorization\":\"[*******SECREAT-KEY********]\"}]}}";
            
            _logger.LogInformation("Payment request started");
            var client = new RestClient("https://test.api.dibspayment.eu/v1/payments");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/*+json");
            request.AddHeader("CommercePlatformTag", "SOME_STRING_VALUE");
            request.AddHeader("Authorization", secretKey);
            request.AddParameter("application/*+json", payload, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var paymentCreatedResponse = JsonConvert.DeserializeObject<PaymentCreatedResponse>(response.Content);

            _logger.LogTrace("response " + response.StatusCode);

            return Ok(paymentCreatedResponse);
        }

        [HttpPost]
        [Route("/Created")]
        public IActionResult Created([FromBody] CreatedResponse response)
        {
            _logger.LogInformation("Created Hook triggered");
            _logger.LogInformation(response.data.paymentId);
            return Ok();
        }

        [HttpPost]
        [Route("/ReservationCreated")]
        public IActionResult ReservationCreated([FromBody] ReservationCreatedResponse response)
        {
            _logger.LogInformation("ReservationCreated Hook triggered");
            _logger.LogInformation(response.data.paymentId);
            return Ok();
        }

        [HttpPost]
        [Route("/CheckoutCompleted")]
        public IActionResult CheckoutCompleted([FromBody] CheckoutCompletedResponse response)
        {
            _logger.LogInformation("CheckoutCompleted Hook triggered");
            _logger.LogInformation(response.data.paymentId);
            return Ok();
        }

        [HttpPost]
        [Route("/CancelCreated")]
        public IActionResult CancelCreated([FromBody] CancelCreatedResponse response)
        {
            _logger.LogInformation("CancelCreated Hook triggered");
            _logger.LogInformation(response.data.paymentId);
            return Ok();
        }

        [HttpPost]
        [Route("/CancelFailed")]
        public IActionResult CancelFailed([FromBody] CancelFailedResponse response)
        {
            _logger.LogInformation("CancelFailed Hook triggered");
            _logger.LogInformation(response.data.paymentId);
            return Ok();
        }
    }
}
