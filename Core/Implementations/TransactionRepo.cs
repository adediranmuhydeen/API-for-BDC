using Entity.Models;
using Infrastructure.Context;

namespace Core.Implementations
{
    internal class TransactionRepo : ITransaction
    {
        private readonly WalletModel wallet;
        private readonly ApplicationContext context;
        public TransactionRepo(WalletModel _wallet, ApplicationContext _context)
        {
            context = _context;
            wallet = _wallet;
        }
        public async Task<List<TransactionModel>> GetAllTransactions()
        {
            var transactionList = context.Transactions.Select(x =>
            new TransactionModel
            {
                Id = x.Id,
                TransactionAmount = x.TransactionAmount,
                TransactionDate = x.TransactionDate,
                TransactionType = x.TransactionType,
                Description = x.Description,
                WalletAddressId = x.WalletAddressId,
            }).ToList();
            return transactionList;
        }

        public bool MakeDeposit(double depositAmount, string description, string walletAddress)
        {
            var myWallet = context.Wallets.FirstOrDefault(x => x.WalletAddress == walletAddress);
            if (myWallet == null)
            {
                return false;
            }
            myWallet.WalletBalance += depositAmount;
            var transaction = new TransactionModel
            {
                TransactionAmount = depositAmount,
                Description = description,
                TransactionDate = DateTime.Now.ToString("g"),
                TransactionType = 0
            };
            context.Update(transaction);
            context.Update(myWallet);
            return true;
        }

        public bool MakeTransfer(double transferAmount, string description, string senderWalletAdress, string receivingWalletAddress)
        {
            var senderWallet = context.Wallets.FirstOrDefault(x => x.WalletAddress == senderWalletAdress);
            var receiverWallet = context.Wallets.FirstOrDefault(x => x.WalletAddress == receivingWalletAddress);
            if (senderWallet == null || receiverWallet == null)
            {
                return false;
            }
            if (senderWallet.WalletBalance < transferAmount)
            {
                return false;
            }
            senderWallet.WalletBalance -= transferAmount;
            receiverWallet.WalletBalance += transferAmount;
            var transaction = new TransactionModel
            {
                TransactionAmount = transferAmount,
                Description = description,
                TransactionDate = DateTime.Now.ToString("g"),
                TransactionType = 2
            };
            return true;
        }

        public bool MakeWithdrawal(double withdrawalAmount, string description, string walletAddress)
        {
            var myWallet = context.Wallets.FirstOrDefault(x => x.WalletAddress == walletAddress);

            if (myWallet == null)
            {
                return false;
            }
            if (myWallet.WalletBalance < withdrawalAmount)
            {
                return false;
            }
            myWallet.WalletBalance -= withdrawalAmount;
            var transaction = new TransactionModel
            {
                TransactionAmount = withdrawalAmount,
                Description = description,
                TransactionDate = DateTime.Now.ToString("g"),
                TransactionType = 1
            };
            context.Update(transaction);
            context.Update(myWallet);
            return true;
        }
    }
}
