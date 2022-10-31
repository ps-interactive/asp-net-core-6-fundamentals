using BethanysPieShopHRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BethanysPieShopHRM.Tests
{
    public class CH08_Tests
    {
        [Fact]
        [Trait("Category", "Task1")]
        public void CH08_VerifyDbContext()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Models"
                                                       + Path.DirectorySeparatorChar + "BethanysPieShopHRMDbContext.cs";

            Assert.True(File.Exists(filePath), "`BethanysPieShopHRMDbContext.cs` should exist in the `Models` folder.");

            var options = new DbContextOptions<BethanysPieShopHRMDbContext>();
            var context = new BethanysPieShopHRMDbContext(options);
            Assert.IsAssignableFrom<DbContext>(context);
        }

        [Fact]
        [Trait("Category", "Task2")]
        public void CH08_VerifyDbSets()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Models"
                                                       + Path.DirectorySeparatorChar + "BethanysPieShopHRMDbContext.cs";

            Assert.True(File.Exists(filePath), "`BethanysPieShopHRMDbContext.cs` should exist in the `Models` folder.");

            var props = typeof(BethanysPieShopHRMDbContext).GetProperties();

            var employeeDbSet = props.FirstOrDefault(x => x.Name == "Employees");
            var employeeAccessor = employeeDbSet.GetAccessors().FirstOrDefault(x => x.IsPublic);
            Assert.True(employeeDbSet.PropertyType.Name.Contains("DbSet") && employeeAccessor.IsPublic);

            var categoryDbSet = props.FirstOrDefault(x => x.Name == "Categories");
            var ctaegoryAccessor = categoryDbSet.GetAccessors().FirstOrDefault(x => x.IsPublic);
            Assert.True(categoryDbSet.PropertyType.Name.Contains("DbSet") && ctaegoryAccessor.IsPublic);
        }
    }
}