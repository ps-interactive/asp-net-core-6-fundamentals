namespace BethanysPieShopHRM.Models
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly BethanysPieShopHRMDbContext _bethanysPieShopHRMDbContext;

        public QuestionRepository(BethanysPieShopHRMDbContext bethanysPieShopHRMDbContext)
        {
            _bethanysPieShopHRMDbContext = bethanysPieShopHRMDbContext;
        }

        public void AddQuestion(Question question)
        {
            _bethanysPieShopHRMDbContext.Questions.Add(question);
            _bethanysPieShopHRMDbContext.SaveChanges();
        }
    }
}
