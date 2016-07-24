using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingLists.Models
{
    public class SpendingList
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public float Funds { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }

        //takes the guid as a string from MS Identity
        public string Owner { get; set; }
    }
}
