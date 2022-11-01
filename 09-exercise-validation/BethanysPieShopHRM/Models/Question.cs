using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopHRM.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
