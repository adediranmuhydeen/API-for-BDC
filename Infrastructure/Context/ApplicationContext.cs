using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<WalletModel> Wallets { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }

    }
}