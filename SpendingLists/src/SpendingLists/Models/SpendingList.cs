using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingLists.Models
{
    public class SpendingList
    {

        public int Id { get; set; }
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public float Funds { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }

        //takes the guid as a string from MS Identity
        [Required]
        public string Owner { get; set; }
    }
}
