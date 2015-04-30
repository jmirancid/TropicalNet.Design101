using Design101.Business.Definitions;
using Design101.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design101.Test.Business
{
    [TestClass]
    public class RoleBusinessTest : BusinessTest<Role, RoleBusiness>
    {
        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            Startup();
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            TearDown();
        }

        [TestMethod]
        public void Can_GetAll_User()
        {
            var list = bizEntity.Value.All();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void Can_GetAllByText_User()
        {
            var list = bizEntity.Value.AllBy(e => e.Name.Contains("admin"));

            Assert.IsNotNull(list);
        }
    }
}
