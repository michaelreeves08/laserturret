using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwearingIsFun.Library;

namespace SwearingIsFun.Test
{
    [TestClass]
    public class CloudUtilityTests
    {
        [TestMethod]
        public void SwearsCheckDetectsSwear()
        {
            Assert.IsTrue(CloudUtility.CheckForSwear("fuck i hate memes"));
            Assert.IsTrue(CloudUtility.CheckForSwear("oh shit"));
            Assert.IsTrue(CloudUtility.CheckForSwear("im an ass person"));
            Assert.IsTrue(CloudUtility.CheckForSwear("cock"));
        }

        [TestMethod]
        public void SwearsCheckPassesNonSwear()
        {
            Assert.IsFalse(CloudUtility.CheckForSwear("memes are good"));
            Assert.IsFalse(CloudUtility.CheckForSwear("i play my bass pretty crass at mass"));
            Assert.IsFalse(CloudUtility.CheckForSwear("whats good my dude"));
            Assert.IsFalse(CloudUtility.CheckForSwear("hey my guy"));

        }
    }
}
