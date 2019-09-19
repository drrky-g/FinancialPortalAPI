namespace FinancialPortalAPI.Models
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Bank Account Object Model
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Starting Balance
        /// </summary>
        public float StartingBalance { get; set; }
        /// <summary>
        /// Current Balance
        /// </summary>
        public float CurrentBalance { get; set; }
        /// <summary>
        /// Create Date and Time
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Low Balance Threshold
        /// </summary>
        public float LowBalanceThreshold { get; set; }
        //
        //virtual
        /// <summary>
        /// Household Foreign Key
        /// </summary>
        public int HouseholdId { get; set; }
        /// <summary>
        /// Bank Account Foreign Key
        /// </summary>
        public int AccountTypeId { get; set; }

    }
}