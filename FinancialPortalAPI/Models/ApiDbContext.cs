namespace FinancialPortalAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Custom DbContext
    /// </summary>
    public class ApiDbContext : DbContext
    {
        /// <summary>
        /// Pass ConnectionString label to DbContext
        /// </summary>
        public ApiDbContext()
            
            : base("DefaultConnection"){ }
        /// <summary>
        /// Create new DbContext
        /// </summary>
        /// <returns></returns>
        public static ApiDbContext Create()
        {
            return new ApiDbContext();
        }
        /// <summary>
        /// Bank Accounts DbSet
        /// </summary>
        public DbSet<BankAccount> Accounts { get; set; }
        /// <summary>
        /// Budgets DbSet
        /// </summary>
        public DbSet<Budget> Budgets { get; set; }
        /// <summary>
        /// BudgetItems DbSet
        /// </summary>
        public DbSet<BudgetItem> BudgetItems { get; set; }
        /// <summary>
        /// Households DbSet
        /// </summary>
        public DbSet<Household> Households { get; set; }
        /// <summary>
        /// Transactions DbSet
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }
        

        //SQL
        //--------------------

        //GETS

        /// <summary>
        /// Retrieves an entire Household record from the database based on the provided Primary Key.
        /// </summary>
        /// <remarks>
        /// (Implimentation notes)
        /// </remarks>
        /// <param name="houseId">Primary key for a specific Household</param>
        /// <returns>Household object</returns>
        public async Task<Household> GetHousehold(int houseId)
        {
            return await Database.SqlQuery<Household>("GetThisHouseholdRecord @houseId",
                new SqlParameter("houseId", houseId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retrieves all Household records from database
        /// </summary>
        /// <remarks>
        /// (Implimentation notes)
        /// </remarks>
        /// <returns>An array of Household objects.</returns>
        public async Task<List<Household>> GetAllHouseholds()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholds").ToListAsync();
        }

        /// <summary>
        /// Retrieves all Bank Account records that are children to a specific Household
        /// </summary>
        /// <param name="houseId">Primary Key for a specific Household</param>
        /// <returns>An array of Bank Account objects.</returns>
        public async Task<List<BankAccount>> GetHouseAccounts(int houseId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountsInHouse @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }
        /// <summary>
        /// Retrieves all Budget records from the database
        /// </summary>
        /// <returns>An array of Budget objects</returns>
        public async Task<List<Budget>> GetAllBudgets()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetRecords").ToListAsync();
        }

        /// <summary>
        /// Retrieves an entire BudgetItem record from the database base on the provided Primary Key
        /// </summary>
        /// <param name="budgetItemId">Primary Key for a specific BudgetItem</param>
        /// <returns>BudgetItem object</returns>
        public async Task<BudgetItem> GetBudgetItem(int budgetItemId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItem @budgetItemId",
                new SqlParameter("@budgetItemId", budgetItemId)).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Retrieves all Budget records that are children to a specific Household.
        /// </summary>
        /// <param name="houseId">Primary Key for a specific Household</param>
        /// <returns>An array of Budget objects</returns>
        public async Task<List<Budget>> GetHouseBudgets(int houseId)
        {
            return await Database.SqlQuery<Budget>("GetHouseBudgets @houseId",
                new SqlParameter("@houseId", houseId)).ToListAsync();
        }
        /// <summary>
        /// Retrieves all BudgetItem records that are children to a specific Budget
        /// </summary>
        /// <param name="budgetId">Primary Key for a specific Budget</param>
        /// <returns>An array of BudgetItem objects</returns>
        public async Task<List<BudgetItem>> GetItemsInBudget(int budgetId)
        {
            return await Database.SqlQuery<BudgetItem>("GetItemsInBudget @budgetId",
                new SqlParameter("@budgetId", budgetId)).ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific transaction record based on its Primary Key
        /// </summary>
        /// <param name="id">Primary Key for a specific transaction</param>
        /// <returns>Transaction object</returns>
        public async Task<Transaction> GetTransaction(int id)
        {
            return await Database.SqlQuery<Transaction>("GetThisTransaction @id",
                new SqlParameter("@id", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retrieves all Transaction records that are children to a specific Bank Account.
        /// </summary>
        /// <param name="accountId">Primary key for a specific Bank Account</param>
        /// <returns>An array of Transaction Objects</returns>
        public async Task<List<Transaction>> GetAccountTransactions(int accountId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionsForAccount @accountId",
                new SqlParameter("@accountId", accountId)).ToListAsync();
        }

        //POSTS

        /// <summary>
        /// Maps a BankAccount object onto the database.
        /// </summary>
        /// <remarks>
        /// Low Balance is a nullable property. Starting Balance and Current Balance should match when the account is created.
        /// </remarks>
        /// <param name="description">Description for the Account (Usually serves as a naming convention)</param>
        /// <param name="starting">Starting balance of the account</param>
        /// <param name="current">Current balance of the account</param>
        /// <param name="created">Date and Time of account creation</param>
        /// <param name="lowBalance">Low balance threshold, will send an alert if the balance gets below this level.</param>
        /// <param name="houseId">Foreign key to the associated house</param>
        /// <param name="typeId">Foreign key to the associated account type.</param>
        /// <returns>Primary key of the new Bank Account object.</returns>
        public async Task<int> CreateAccount(string description,
                                        float starting,
                                        float current,
                                        DateTime created,
                                        float lowBalance,
                                        int houseId,
                                        int typeId)
        {
            return await Database.ExecuteSqlCommandAsync("CreateAccountForSpecificHouse @description, @startingBalance, @currentBalance, @created, @lowBalance, @houseId, @accountTypeId",
                new SqlParameter("@description", description),
                new SqlParameter("@startingBalance", starting),
                new SqlParameter("@currentBalance", current),
                new SqlParameter("@created", created),
                new SqlParameter("@lowBalance", lowBalance),
                new SqlParameter("@houseId", houseId),
                new SqlParameter("@accountTypeId", typeId));
        }

        /// <summary>
        /// Maps a Budget object onto the database
        /// </summary>
        /// <param name="name">The name of the account</param>
        /// <param name="cap">The limit to the budget you set for yourself.</param>
        /// <param name="houseId">Foreign Key to the associated Household</param>
        /// <returns>Primary key of the new Budget Object</returns>
        public async Task<int> CreateBudget(string name, float cap, float houseId)
        {
            return await Database.ExecuteSqlCommandAsync("CreateBudget @name, @cap, @houseId",
                new SqlParameter("@name", name),
                new SqlParameter("@cap", cap),
                new SqlParameter("@houseId", houseId));
        }

        /// <summary>
        /// Maps a Transaction object onto the database
        /// </summary>
        /// <remarks>
        /// The parameter "budgetId" is not actually for a Budget object, but a BudgetItem object that will link it to the related budget that Item is under.
        /// </remarks>
        /// <param name="name">Name for transaction</param>
        /// <param name="description">Description for transaction</param>
        /// <param name="amount">Amount of transaction</param>
        /// <param name="date">Date transaction occured</param>
        /// <param name="typeId">Foreign Key to the associated transaction type</param>
        /// <param name="accountId">Foreign Key to the associated Bank Account</param>
        /// <param name="userId">Foreign Key to the User that created the entry</param>
        /// <param name="budgetId">Foreign Key to the Budget Item</param>
        /// <returns>Primary key of the new Transaction object.</returns>
        public async Task<int> CreateTransaction(string name,
                                                 string description,
                                                 float amount,
                                                 DateTime date,
                                                 int typeId,
                                                 int accountId,
                                                 string userId,
                                                 int budgetId)
        {
            return await Database.ExecuteSqlCommandAsync("CreateTransaction @name, @description, @amount, @date, @typeId, @accountId, @userId, @budgetId",
                new SqlParameter("@name", name),
                new SqlParameter("@description", description),
                new SqlParameter("@amount", amount),
                new SqlParameter("@date", date),
                new SqlParameter("@typeId", typeId),
                new SqlParameter("@accountId", accountId),
                new SqlParameter("@userId", userId),
                new SqlParameter("@budgetId", budgetId));
        }

    }
}