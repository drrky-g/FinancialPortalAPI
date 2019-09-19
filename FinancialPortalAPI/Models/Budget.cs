

namespace FinancialPortalAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    /// <summary>
    /// Budget Object Model
    /// </summary>
    public class Budget
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
        /// Budget Limit
        /// </summary>
        public float Cap { get; set; }
        //
        //virtual
        /// <summary>
        /// Foreign Key to the associated Household
        /// </summary>
        public int HouseholdId { get; set; }

    }
}