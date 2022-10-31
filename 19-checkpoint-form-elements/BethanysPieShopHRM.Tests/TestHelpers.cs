namespace BethanysPieShopHRM.Tests
{
    public static class TestHelpers
    {
        private static readonly string _projectName = "BethanysPieShopHRM";

        public static Type GetClassType(string fullName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                where assembly.FullName.StartsWith(_projectName)
                from type in assembly.GetTypes()
                where type.FullName == fullName
                select type).FirstOrDefault();
        }

        public static string GetRootString()
        {
            return ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar;
        }
    }
}