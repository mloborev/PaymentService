using Newtonsoft.Json;

namespace PaymentService.Models.QiwiModels
{
    public class UserBalanceModel
    {
        public List<Accounts> Accounts { get; set; } = new List<Accounts>();
    }

    public class Accounts
    {
        [JsonProperty("alias")]
        public string UserBalanceAlias { get; set; } = "";
        [JsonProperty("fsAlias")]
        public string BankBalanceAlias { get; set; } = "";
        [JsonProperty("bankAlias")]
        public string BankName { get; set; } = "";
        [JsonProperty("title")]
        public string WalletName { get; set; } = "";
        [JsonProperty("hasBalance")]
        public bool HasBalance { get; set; }
        [JsonProperty("currency")]
        public int Currency { get; set; } //643 - российский рубль, 840 - американский доллар, 978 - евро
        [JsonProperty("type")]
        public Type AccountType { get; set; } = new Type { };
        [JsonProperty("balance")]
        public Balance Balance { get; set; } = new Balance { };
    }

    public class Type
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
    }

    public class Balance
    {
        public decimal Amount { get; set; }
        public int Currency { get; set; }
    }
}
