using GoFive_CRM.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoFive_CRM.Application.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {
             
        }

        public CustomerModel(Customers customer)
        {
            // Constructor that takes a Customers object and performs property assignments
            if (customer != null)
            {
                ID = customer.ID;
                Name = customer.Name;
                Email = customer.Email;
                Phone = customer.Phone;
                Address = customer.Address;
                Notes = customer.Notes;
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\S+@gmail\.com$", ErrorMessage = "Email must be in the format example@gmail.com")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone must be a numeric value")]
        public string Phone { get; set; }

        public string Address { get; set; }
        public string Notes { get; set; }
    }
}
