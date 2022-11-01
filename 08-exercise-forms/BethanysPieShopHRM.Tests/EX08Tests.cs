using BethanysPieShopHRM.Controllers;
using BethanysPieShopHRM.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BethanysPieShopHRM.Tests
{
    public class EX08Tests
    {
        [Fact]
        public void EX08_VerifyQuestionController()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Controllers"
                                                       + Path.DirectorySeparatorChar + "QuestionController.cs";

            Assert.True(File.Exists(filePath), "`QuestionController.cs` should exist in the `Controllers` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var options = new DbContextOptionsBuilder<BethanysPieShopHRMDbContext>()
                .UseInMemoryDatabase(databaseName: "BethanysPieShopHRM")
                .Options;


            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                var questionRepository = new Mock<IQuestionRepository>();
                
                var sut = new QuestionController(questionRepository.Object);

                var result = sut.Index();
                Assert.NotNull(result);
                Assert.Equal(typeof(ViewResult), result.GetType());
                questionRepository.Verify(q => q.AddQuestion(It.IsAny<Question>()), Times.Never);

                var question = new Question();
                var result1 = sut.Index(question);
                Assert.NotNull(result1);
                Assert.Equal(typeof(ViewResult), result1.GetType());
                questionRepository.Verify(q => q.AddQuestion(It.IsAny<Question>()), Times.Once);
            }
        }

        [Fact]
        public void EX08_VerifyQuestionView()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Question"
                                                       + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the `Views/Question` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var inputTags = doc.DocumentNode.Descendants("input");

            var submitInputTag = inputTags.Last();
            foreach (var input in inputTags)
            {
                if (input != submitInputTag)
                {
                    Assert.True(input.Attributes["asp-for"] != null,
                        "Every form input should include the `asp-for` attribute with the corresponding model property assigned.");
                }
            }

            var labelTags = doc.DocumentNode.Descendants("label");

            foreach (var label in labelTags)
            {
                Assert.True(label.Attributes["asp-for"] != null,
                    "Every form label element should include the `asp-for` attribute with the corresponding model property assigned.");
            }

            var formTag = doc.DocumentNode.Descendants("form").FirstOrDefault();
            Assert.NotNull(formTag);

            Assert.True(formTag!.Attributes["asp-action"].Value == "Index",
                "The form tag should include the `asp-action` attribute with the Index action.");
        }
    }
}