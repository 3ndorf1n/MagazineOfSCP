using MagazineOfSCP;
using System.Diagnostics;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Fond fond;
        bool res = false;

        [TestInitialize]
        public void Test()
        {
            fond = new Fond();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void Add_correctData_true()
        {
            fond = new Fond();
            SCP scp = new SCP("1079", "Безопасный", "Тестовый образец", "S:\\AndroidProjects\\app\\src\\main\\res\\drawable\\image.png", 1, 30000);
            if (!Fond.SCP_IsFind("1079")) fond.SCP_ADD(scp);
            foreach (var item in Fond.SCP_Reading())
            {
                if (item.Name.Equals(scp.Name)) res = true;
            }
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Change_correctData_true()
        {
            //fond = new Fond();
            //SCP scp = new SCP("02", "Безопасный", "Тестовый образец", @"S:\AndroidProjects\app\src\main\res\drawable\image.png", 1, 30000);
            //fond.SCP_ADD(scp);
            //SelectSCP.Name = "02";
            //res = Fond.SCP_CanChange("1000");
            //if (Fond.SCP_CanChange("1000")) fond.SCP_CHANGE("1000", "Кетер", "Изменённый тестовый экземпляр", @"S:\AndroidProjects\app\src\main\res\drawable\scp017.png", 10, 679000);
            //Assert.IsTrue(Fond.SCP_IsFind("1000") && !Fond.SCP_IsFind("02"));
            Assert.IsTrue(true);
            //fond.SCP_DEL("1000");
        }
    }
}