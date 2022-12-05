using Entity.Models;

namespace Core.Services
{
    public interface ITransaction
    {
        Task<List<TransactionModel>> GetAllTransactions();
        bool MakeDeposit(double depositAmount, string description, string walletAddress);
        bool MakeTransfer(double transferAmount, string description, string senderWalletAdress, string receivingWalletAddress);
        bool MakeWithdrawal(double withdrawalAmount, string description, string walletAddress);
    }
}