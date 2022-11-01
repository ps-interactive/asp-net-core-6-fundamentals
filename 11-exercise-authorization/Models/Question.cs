using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopHRM.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [StringLength(200)]
        public string Message { get; set; } = string.Empty;

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; } = string.Empty;
    }
}
