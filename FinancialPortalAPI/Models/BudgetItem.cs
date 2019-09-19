

namespace FinancialPortalAPI.Models
{
    using System.Collections.Generic;
    /// <summary>
    /// BudgetItem Object Model
    /// </summary>
    public class BudgetItem
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        //
        //virtual
        /// <summary>
        /// Foreign Key to associated Budget
        /// </summary>
        public int BudgetId { get; set; }
    }
}