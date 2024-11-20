using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class ToDos
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        public string Status { get; set; }
    }
}
