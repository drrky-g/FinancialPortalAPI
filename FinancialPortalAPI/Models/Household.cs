namespace FinancialPortalAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Household Object Model
    /// </summary>
    public class Household
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(20, ErrorMessage = "The household name must be under 20 characters long.")]
        [Display (Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Date and Time the Household is created
        /// </summary>
        [Required]
        [Display (Name = "Created On")]
        public DateTime Created { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [Display (Name = "Description")]
        [StringLength(140, ErrorMessage = "Household descriptions are limited to 140 characters.")]
        public string Description { get; set; }
        /// <summary>
        /// UserId of the person who made the house
        /// </summary>
        /// <remarks>
        /// In applications, this can programmatically be passed to other users. It doesn't have to always be the person who made it.
        /// </remarks>
        public string HeadOfHouseId { get; set; }


    }
}