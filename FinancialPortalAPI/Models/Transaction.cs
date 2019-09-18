namespace FinancialPortalAPI.Models
{
    using System;

    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        //
        //virtual
        public int TypeId { get; set; }
        public int AccountId { get; set; }
        public string UserId { get; set; }
        public int? BudgetItemId { get; set; }
        //------------------------------------------
        public virtual BankAccount Account { get; set; }
        public virtual BudgetItem BudgetItem { get; set; }
    }
}