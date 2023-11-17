using MagazineOfSCP;
namespace MagazineOfSCPTests
{
    [TestClass]
    public class AuthoReg
    {
        Fond fond;
        bool res = false;
        [TestMethod]
        public void Reg_AddData_true()
        {
            fond = new Fond();
            User user = new User("New", "123", 1);
            fond.User_Add(user);
            List<User> users = Fond.User_Reading();
            foreach (User item in users)
            {
                if (item.Login.Equals(user.Login)) res = true;
            }
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void RegVerification_correctData_true()
        {
            fond = new Fond();
            User user = new User("New2", "123", 1);
            Assert.IsTrue(Fond.User_Verification(user.Login));
        }
        [TestMethod]
        public void RegVerification_existingData_false()
        {
            fond = new Fond();
            User user = new User("123", "1234", 1);
            Assert.IsFalse(Fond.User_Verification(user.Login));
        }
        [TestMethod]
        public void AuhtVerification_correctData_true()
        {
            fond = new Fond();
            User user = new User("123", "1234", 1);
            Assert.IsTrue(Fond.User_Verification(user.Login, user.Password));
        }
        [TestMethod]
        public void AuhtVerification_incorrectData_false()
        {
            fond = new Fond();
            User user = new User("New3", "123", 1);
            Assert.IsFalse(Fond.User_Verification(user.Login, user.Password));
        }
    }
}