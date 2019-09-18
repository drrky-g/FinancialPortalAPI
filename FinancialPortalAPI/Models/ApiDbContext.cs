namespace FinancialPortalAPI.Models
{
    using System.Data.Entity;
    //this class was made to make calls to the database that exists for my previous financialPortal project
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
            //this means call my parent and pass the parameter 'DefaultConnection'
            : base("DefaultConnection"){ }
        public static ApiDbContext Create()
        {
            return new ApiDbContext();
        }
        public DbSet<BankAccount> Accounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}