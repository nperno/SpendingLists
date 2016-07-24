using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingLists.ViewModels
{
    public class SpendingListSummary
    {

        public int ListId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public float Funds { get; set; }

        [DataType(DataType.Currency)]
        public float ItemTotal { get; set; }


        [DataType(DataType.Currency)]
        public float Remaining { get; set; }

        public int ItemCount { get; set; }
    }
}
