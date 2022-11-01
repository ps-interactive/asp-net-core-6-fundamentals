using System.ComponentModel.DataAnnotations;
using BethanysPieShopHRM.Models;
using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class EX09Tests
    {
        [Fact]
        [Trait("Category", "Task1")]
        public void EX09_VerifyValidationAttributes()
        {
            var questionType = typeof(Question);
            Assert.NotNull(questionType);

            var titleAttributes = questionType.GetProperty("Title").GetCustomAttributesData();
            var requiredTitleAttribute =
                titleAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            var stringLengthTitleAttribute = titleAttributes.FirstOrDefault(x => x.AttributeType == typeof(StringLengthAttribute));

            Assert.NotNull(requiredTitleAttribute);
            Assert.NotNull(stringLengthTitleAttribute);
            Assert.Equal(50, int.Parse(stringLengthTitleAttribute!.ConstructorArguments.FirstOrDefault().Value.ToString()));

            var messageAttributes = questionType.GetProperty("Message").GetCustomAttributesData();
            var requiredMessageAttribute =
                messageAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            var stringLengthMessageAttribute = messageAttributes.FirstOrDefault(x => x.AttributeType == typeof(StringLengthAttribute));

            Assert.Null(requiredMessageAttribute);
            Assert.NotNull(stringLengthMessageAttribute);
            Assert.Equal(200, int.Parse(stringLengthMessageAttribute.ConstructorArguments.FirstOrDefault().Value.ToString()));

            var emailAttributes = questionType.GetProperty("Title").GetCustomAttributesData();
            var requiredEmailAttribute =
                emailAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            var stringLengthEmailAttribute = emailAttributes.FirstOrDefault(x => x.AttributeType == typeof(StringLengthAttribute));

            Assert.NotNull(requiredEmailAttribute);
            var question = new Question() { Title = "title" };
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(question, new ValidationContext(question), validationResultList);
            var errorMessage = validationResultList[0].ErrorMessage;
            Assert.Equal("Please enter your email", errorMessage);
            Assert.NotNull(stringLengthEmailAttribute);
            Assert.Equal(50, int.Parse(stringLengthEmailAttribute!.ConstructorArguments.FirstOrDefault().Value.ToString()));
        }

        [Fact]
        [Trait("Category", "Task2")]
        public void EX09_VerifyValidationSummary()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Question"
                                                       + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the Views/Question folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var divTags = doc.DocumentNode.Descendants("div").Where(x => x.Attributes["asp-validation-summary"] != null);

            Assert.True(divTags.Count() > 0, "The question form should contain a div with the `asp-validation-summary` attribute.");
        }
    }
}