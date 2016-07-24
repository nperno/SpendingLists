using System.ComponentModel.DataAnnotations;

namespace SpendingLists.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }
        [Url]
        public string Link { get; set; }
        [DataType(DataType.Currency)]
        public float Cost { get; set; }

        //Relationships
        public int SpendingListId { get; set; }
        public SpendingList SpendingList { get; set; }
    }
}