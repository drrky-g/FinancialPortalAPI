namespace FinancialPortalAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class Household
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The household name must be under 20 characters long.")]
        [Display (Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display (Name = "Created On")]
        public DateTime Created { get; set; }
        [Required]
        [Display (Name = "Description")]
        [StringLength(140, ErrorMessage = "Household descriptions are limited to 140 characters.")]
        public string Description { get; set; }
        public string HeadOfHouseId { get; set; }
        //
        //collections
        [Display (Name = "Household Accounts")]
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        
        

        //constructor
        public Household()
        {
            this.BankAccounts = new HashSet<BankAccount>();
            this.Budgets = new HashSet<Budget>();
        }


    }
}