using Microsoft.AspNetCore.Mvc;
using Stripe;
using Microsoft.Extensions.Configuration;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public PaymentController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // POST: api/payment/create-intent
    [HttpPost("create-intent")]
    public IActionResult CreatePaymentIntent([FromBody] PaymentRequest paymentRequest)
    {
        var secretKey = _configuration["Stripe:SecretKey"];
        StripeConfiguration.ApiKey = secretKey;

        try
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = paymentRequest.AmountInCents, // e.g., 5000 for $50.00
                Currency = "usd",
                // Add any additional options you need (e.g., automatic payment methods)
            };

            var service = new PaymentIntentService();
            PaymentIntent intent = service.Create(options);

            return Ok(new { clientSecret = intent.ClientSecret });
        }
        catch (StripeException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}

public class PaymentRequest
{
    public long AmountInCents { get; set; }
}

