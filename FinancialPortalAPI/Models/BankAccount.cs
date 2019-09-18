namespace FinancialPortalAPI.Models
{
    using System;
    using System.Collections.Generic;
    public class BankAccount
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float StartingBalance { get; set; }
        public float CurrentBalance { get; set; }
        public DateTime Created { get; set; }
        public float LowBalanceThreshold { get; set; }
        //
        //virtual
        public int HouseholdId { get; set; }
        public int AccountTypeId { get; set; }
        //------------------------------------------
        public virtual Household Household { get; set; }
        //
        //collections
        public virtual ICollection<Transaction> Transactions { get; set; }
        //
        //constructor
        public BankAccount()
        {
            this.Transactions = new HashSet<Transaction>();
        }

    }
}