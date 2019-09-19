namespace FinancialPortalAPI.Models
{
    using System;
    /// <summary>
    /// Transaction Object Model
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// Date and Time the Transaction was made
        /// </summary>
        public DateTime Date { get; set; }
        //
        //virtual
        /// <summary>
        /// Foreign Key to Transaction Type
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// Foreign Key to Bank Account
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// Foreign Key to User
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Foreign Key to Budget Item
        /// </summary>
        public int? BudgetItemId { get; set; }
    }
}