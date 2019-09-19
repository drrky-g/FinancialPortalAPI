namespace FinancialPortalAPI.Controllers
{
    using FinancialPortalAPI.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    /// <summary>
    /// Built-in Finance API calls
    /// </summary>
    [RoutePrefix("api/Portal")]
    public class PortalController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Retrieves an entire Household record from the database based on the provided Primary Key.
        /// </summary>
        /// <remarks>
        /// (Implimentation notes)
        /// </remarks>
        /// <param name="houseId">Primary key for a specific Household</param>
        /// <returns>Household object</returns>
        [Route("GetHouse")]
        public async Task<Household> GetHousehold(int houseId)
        {
            return await db.GetHousehold(houseId);
        }

        /// <summary>
        /// Retrieves an entire Household record from the database based on the provided Primary Key as JSON.
        /// </summary>
        /// <remarks>
        /// (Implimentation notes)
        /// </remarks>
        /// <param name="houseId">Primary key for a specific Household</param>
        /// <returns>Household object</returns>
        [ResponseType(typeof(Household))]
        [Route("GetHouse-JSON")]
        public async Task<IHttpActionResult> GetHouseholdJson(int houseId)
        {
            var house = await db.GetHousehold(houseId);
            var json = JsonConvert.SerializeObject(house);
            return Ok(json);
        }

        /// <summary>
        /// Retrieves all Household records from database.
        /// </summary>
        /// <remarks>
        /// (Implimentation notes)
        /// </remarks>
        /// <returns>An array of Household objects.</returns>
        [Route("AllHouses")]
        public async Task<List<Household>> GetAllHouseholds()
        {
            return await db.GetAllHouseholds();
        }

        /// <summary>
        /// Retrieves all Household records from database as JSON.
        /// </summary>
        /// <remarks>
        /// (Implimentation notes)
        /// </remarks>
        /// <returns>An array of Household objects.</returns>
        [ResponseType(typeof(List<Household>))]
        [Route("AllHouses-JSON")]
        public async Task<IHttpActionResult> GetAllHouseHoldsJson()
        {
            var houses = await db.GetAllHouseholds();
            var json = JsonConvert.SerializeObject(houses);
            return Ok(json);
        }

        /// <summary>
        /// Retrieves all Bank Account records that are children to a specific Household
        /// </summary>
        /// <param name="houseId">Primary Key for a specific Household</param>
        /// <returns>An array of Bank Account objects.</returns>
        [Route("HouseAccounts")]
        public async Task<List<BankAccount>> GetHouseAccounts(int houseId)
        {
            return await db.GetHouseAccounts(houseId);
        }

        /// <summary>
        /// Retrieves all Bank Account records that are children to a specific Household as JSON.
        /// </summary>
        /// <param name="houseId">Primary Key for a specific Household</param>
        /// <returns>An array of Bank Account objects.</returns>
        [ResponseType(typeof(List<BankAccount>))]
        [Route("HouseAccounts-JSON")]
        public async Task<IHttpActionResult> GetHouseAccountsJson(int houseId)
        {
            var accounts =await db.GetHouseAccounts(houseId);
            var json = JsonConvert.SerializeObject(accounts);
            return Ok(json);
        }

        /// <summary>
        /// Retrieves all Budget records from the database
        /// </summary>
        /// <returns>An array of Budget objects</returns>
        [Route("AllBudgets")]
        public async Task<List<Budget>> GetAllBudgets()
        {
            return await db.GetAllBudgets();
        }

        /// <summary>
        /// Retrieves all Budget records from the database as JSON
        /// </summary>
        /// <returns>An array of Budget objects</returns>
        [ResponseType(typeof(List<Budget>))]
        [Route("AllBudgets-JSON")]
        public async Task<IHttpActionResult> GetAllBudgetsJson()
        {
            var budgets = await db.GetAllBudgets();
            var json = JsonConvert.SerializeObject(budgets);
            return Ok(json);
        }

        /// <summary>
        /// Retrieves an entire BudgetItem record from the database base on the provided Primary Key
        /// </summary>
        /// <param name="budgetItemId">Primary Key for a specific BudgetItem</param>
        /// <returns>BudgetItem object</returns>
        [Route("BudgetItem")]
        public async Task<BudgetItem> GetBudgetItem(int budgetItemId)
        {
            return await db.GetBudgetItem(budgetItemId);
        }

        /// <summary>
        /// Retrieves an entire BudgetItem record from the database base on the provided Primary Key as JSON
        /// </summary>
        /// <param name="budgetItemId">Primary Key for a specific BudgetItem</param>
        /// <returns>BudgetItem object</returns>
        [ResponseType(typeof(BudgetItem))]
        [Route("BudgetItem-JSON")]
        public async Task<IHttpActionResult> GetBudgetItemJson(int budgetItemId)
        {
            var item = await db.GetBudgetItem(budgetItemId);
            var json = JsonConvert.SerializeObject(item);
            return Ok(json);
        }

        /// <summary>
        /// Retrieves all Budget records that are children to a specific Household.
        /// </summary>
        /// <param name="houseId">Primary Key for a specific Household</param>
        /// <returns>An array of Budget objects</returns>
        [Route("HouseBudgets")]
        public async Task<List<Budget>> GetHouseBudgets(int houseId)
        {
            return await db.GetHouseBudgets(houseId);
        }

        /// <summary>
        /// Retrieves all Budget records that are children to a specific Household as JSON.
        /// </summary>
        /// <param name="houseId">Primary Key for a specific Household</param>
        /// <returns>An array of Budget objects</returns>
        [ResponseType(typeof(List<Budget>))]
        [Route("HouseBudgets-JSON")]
        public async Task<IHttpActionResult> GetHouseBudgetsJson(int houseId)
        {
            var budgets = await db.GetHouseBudgets(houseId);
            var json = JsonConvert.SerializeObject(budgets);
            return Ok(json);
        }

        /// <summary>
        /// Retrieves all BudgetItem records that are children to a specific Budget
        /// </summary>
        /// <param name="budgetId">Primary Key for a specific Budget</param>
        /// <returns>An array of BudgetItem objects</returns>
        [Route("ItemsInBudget")]
        public async Task<List<BudgetItem>> GetItemsInBudget(int budgetId)
        {
            return await db.GetItemsInBudget(budgetId);
        }

        /// <summary>
        /// Retrieves all BudgetItem records that are children to a specific Budget as JSON
        /// </summary>
        /// <param name="budgetId">Primary Key for a specific Budget</param>
        /// <returns>An array of BudgetItem objects</returns>
        [ResponseType(typeof(BudgetItem))]
        [Route("ItemsInBudget-JSON")]
        public async Task<IHttpActionResult> GetItemsInBudgetJson(int budgetId)
        {
            var items = await db.GetItemsInBudget(budgetId);
            var json = JsonConvert.SerializeObject(items);
            return Ok(json);
        }

        /// <summary>
        /// Retrieves a specific transaction record based on its Primary Key
        /// </summary>
        /// <param name="id">Primary Key for a specific transaction</param>
        /// <returns>Transaction object</returns>
        [Route("GetTransaction")]
        public async Task<Transaction> GetTransaction(int id)
        {
            return await db.GetTransaction(id);
        }

        /// <summary>
        /// Retrieves a specific transaction record based on its Primary Key as JSON.
        /// </summary>
        /// <param name="id">Primary Key for a specific transaction</param>
        /// <returns>Transaction object</returns>
        [ResponseType(typeof(Transaction))]
        [Route("GetTransaction-JSON")]
        public async Task<IHttpActionResult> GetTransactionJson(int id)
        {
            var t = await db.GetTransaction(id);
            var json = JsonConvert.SerializeObject(t);
            return Ok(json);
        }

        /// <summary>
        /// Retrieves all Transaction records that are children to a specific Bank Account.
        /// </summary>
        /// <param name="accountId">Primary key for a specific Bank Account</param>
        /// <returns>An array of Transaction Objects</returns>
        [Route("GetTransactionsByAcount")]
        public async Task<List<Transaction>> GetAccountTransactions(int accountId)
        {
            return await db.GetAccountTransactions(accountId);
        }

        /// <summary>
        /// Retrieves all Transaction records that are children to a specific Bank Account as JSON.
        /// </summary>
        /// <param name="accountId">Primary key for a specific Bank Account</param>
        /// <returns>An array of Transaction Objects</returns>
        [ResponseType(typeof(Transaction))]
        [Route("GetTransactionsByAccount-JSON")]
        public async Task<IHttpActionResult> GetAccountTransactionsJson(int accountId)
        {
            var list = await db.GetAccountTransactions(accountId);
            var json = JsonConvert.SerializeObject(list);
            return Ok(json);
        }

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
        [Route("CreateAccount")]
        public async Task<int> CreateAccount(string description,
                                             float starting,
                                             float current,
                                             DateTime created,
                                             float lowBalance,
                                             int houseId,
                                             int typeId)
        {
            return await db.CreateAccount(description,
                                          starting,
                                          current,
                                          created,
                                          lowBalance,
                                          houseId,
                                          typeId);
        }

        /// <summary>
        /// Maps a Budget object onto the database
        /// </summary>
        /// <param name="name">The name of the account</param>
        /// <param name="cap">The limit to the budget you set for yourself.</param>
        /// <param name="houseId">Foreign Key to the associated Household</param>
        /// <returns>Primary key of the new Budget Object</returns>
        [Route("CreateBudget")]
        public async Task<int> CreateBudget(string name, float cap, float houseId)
        {
            return await db.CreateBudget(name, cap, houseId);
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
        [Route("CreateTransaction")]
        public async Task<int> CreateTransaction(string name, string description, float amount, DateTime date, int typeId, int accountId, string userId, int budgetId)
        {
            return await db.CreateTransaction(name, description, amount, date, typeId, accountId, userId, budgetId);
        }
    }
}
