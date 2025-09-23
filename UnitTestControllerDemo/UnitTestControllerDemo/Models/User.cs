using System.ComponentModel.DataAnnotations;

namespace UnitTestControllerDemo.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10,MinimumLength=3)]
        public string Name { get; set; }
    }
}
