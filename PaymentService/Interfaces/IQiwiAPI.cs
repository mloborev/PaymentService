using PaymentService.Models.QiwiModels;

namespace PaymentService.Interfaces
{
    public interface IQiwiAPI
    {
        Task<string> IdentificateUser(string baseUrl, string token);
        Task<string> GetUserAccountLimits(string baseUrl, string token, string personId);
        Task<string> UserPaymentsRestrictions(string baseUrl, string token, string personId);
        Task<string> UserListOfPayments(string baseUrl, string token, string personId);
        Task<UserBalanceModel> GetUserBalance(string baseUrl, string token, string personId);
        Task<string> CreatePaymentWindow(string token, int rubles, int kopek, string personId, string comment, int paymentId = 99, int currency = 643);
    }
}
