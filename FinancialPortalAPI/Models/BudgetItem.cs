

namespace FinancialPortalAPI.Models
{
    using System.Collections.Generic;
    public class BudgetItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //
        //virtual
        public int BudgetId { get; set; }
        //------------------------------------------
        public virtual Budget Budget { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}