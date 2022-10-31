using System.ComponentModel.DataAnnotations;
using BethanysPieShopHRM.Models;

namespace BethanysPieShopHRM.Tests
{
    public class CH20Tests
    {
        [Fact]
        public void CH20_CheckAttributes()
        {
            var employeeType = typeof(Employee);
            Assert.NotNull(employeeType);

            var firstNameAttributes = employeeType.GetProperty("FirstName").GetCustomAttributesData();
            var requiredFirstNameAttribute =
                firstNameAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            var stringLengthFirstNameAttribute = firstNameAttributes.FirstOrDefault(x => x.AttributeType == typeof(StringLengthAttribute));

            Assert.NotNull(requiredFirstNameAttribute);
            Assert.NotNull(stringLengthFirstNameAttribute);
            Assert.Equal(50, int.Parse(stringLengthFirstNameAttribute.ConstructorArguments.FirstOrDefault().Value.ToString()));

            var lastNameAttributes = employeeType.GetProperty("LastName").GetCustomAttributesData();
            var requiredLastNameAttribute =
                lastNameAttributes.FirstOrDefault(x => x.AttributeType == typeof(RequiredAttribute));
            var stringLengthLastNameAttribute = lastNameAttributes.FirstOrDefault(x => x.AttributeType == typeof(StringLengthAttribute));

            Assert.NotNull(requiredLastNameAttribute);
            Assert.NotNull(stringLengthLastNameAttribute);
            Assert.Equal(75, int.Parse(stringLengthLastNameAttribute.ConstructorArguments.FirstOrDefault().Value.ToString()));

        }
    }
}