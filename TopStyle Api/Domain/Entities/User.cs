using System.ComponentModel.DataAnnotations;

namespace TopStyle_Api.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(512)]
        public string Password { get; set; }
    }
}
