using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentService.Models.QiwiModels;
using System.Diagnostics;

namespace PaymentService.Controllers
{
    public class QiwiAPIController : Controller
    {
        [HttpGet("id-user")]
        public async Task<ActionResult<string>> IdentificateUser(string token)
        {
            string baseUrl = "https://edge.qiwi.com";

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = await client.GetAsync($"{baseUrl}/person-profile/v1/profile/current");
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        [HttpGet("short-user-profile")]
        public async Task<ActionResult<ShortUserProfileModel>> ShortUserProfile(string token, string wallet)
        {
            string baseUrl = "https://edge.qiwi.com";

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = await client.GetAsync($"{baseUrl}/identification/v1/persons/{wallet}/identification");
            var content = await result.Content.ReadAsStringAsync();

            var userProfile = JsonConvert.DeserializeObject<ShortUserProfileModel>(content);

            return userProfile!;
        }

        [HttpGet("get-user-account-limits")]
        public async Task<string> GetUserAccountLimits(string token, string personId)
        {
            string baseUrl = "https://edge.qiwi.com";

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = await client.GetAsync($"{baseUrl}/qw-limits/v1/persons/{personId}/actual-limits?" +
                $"types[0]=REFILL&" +
                $"types[1]=TURNOVER&" +
                $"types[2]=PAYMENTS_P2P&" +
                $"types[3]=PAYMENTS_PROVIDER_INTERNATIONALS&" +
                $"types[4]=PAYMENTS_PROVIDER_PAYOUT&" +
                $"types[5]=WITHDRAW_CASH");
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        [HttpGet("get-user-payment-restrictions")]
        public async Task<string> UserPaymentsRestrictions(string token, string personId)
        {
            string baseUrl = "https://edge.qiwi.com";

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = await client.GetAsync($"{baseUrl}/person-profile/v1/persons/{personId}/status/restrictions");
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        [HttpGet("get-user-list-of-payments")]
        public async Task<string> UserListOfPayments(string token, string personId)
        {
            string baseUrl = "https://edge.qiwi.com";

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = await client.GetAsync($"{baseUrl}/payment-history/v2/persons/{personId}/payments?rows=50&operation=ALL&sources%5B0%5D=QW_RUB");
            var content = await result.Content.ReadAsStringAsync();

            return content;
        }

        [HttpGet("get-user-balance")]
        public async Task<UserBalanceModel> GetUserBalance(string token, string personId)
        {
            string baseUrl = "https://edge.qiwi.com";

            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = await client.GetAsync($"{baseUrl}/funding-sources/v2/persons/{personId}/accounts");
            var content = await result.Content.ReadAsStringAsync();

            var userAccounts = JsonConvert.DeserializeObject<UserBalanceModel>(content);

            return userAccounts!;
        }

        [HttpGet("create-payment-window")]
        public IActionResult CreatePaymentWindow(string token, int rubles, int kopek, string personId, string comment, int paymentId = 99, int currency = 643)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var url = $"https://qiwi.com/payment/form/{paymentId}?extra['comment']=Хочу%20быть%20грязно%20богатым&extra['account']={personId}&blocked=account&amountInteger={rubles}&amountFraction={kopek}&currency={currency}";

            return Redirect(url);
        }
    }
}
