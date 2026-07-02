using System.Reflection;

using VShop.SharedKernel.Infrastructure.Modules;
using Xunit;

namespace VShop.Modules.Sales.Tests.UnitTests
{
    public class ModuleLoaderUnitTests
    {
        [Theory]
        [InlineData("VShop.Modules.Sales.API.dll", true)]
        [InlineData("VShop.Modules.Sales.Infrastructure.dll", true)]
        [InlineData("xunit.runner.utility.netcoreapp10.dll", false)]
        [InlineData("AutoFixture.dll", false)]
        public void Identifies_only_module_assemblies_as_loadable(string fileName, bool expected)
        {
            MethodInfo method = typeof(ModuleLoader).GetMethod
            (
                "IsLoadableModuleAssembly",
                BindingFlags.NonPublic | BindingFlags.Static
            );

            Assert.NotNull(method);
            Assert.Equal(expected, method.Invoke(null, new object[] { fileName }));
        }
    }
}
