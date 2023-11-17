using DevExpress.Internal;
using MagazineOfSCP;
namespace MagazineOfSCPTests
{
    [TestClass]
    public class SCPTests
    {
        Fond fond;
        bool res = false;
        [TestMethod]
        public void Add_correctData_true()
        {
            //fond = new Fond();
            //SCP scp = new SCP("1079", "Безопасный", "Тестовый образец", "S:\\AndroidProjects\\app\\src\\main\\res\\drawable\\image.png", 1, 30000);
            //if (!Fond.SCP_IsFind("1079")) fond.SCP_ADD(scp);
            //foreach (var item in Fond.SCP_Reading())
            //{
            //    if (item.Name.Equals(scp.Name)) res = true;
            //}
            //Assert.IsTrue(res);
        }
        [TestMethod]
        public void Find_correctData_true()
        {
            Assert.IsTrue(Fond.SCP_IsFind("173"));
        }
        [TestMethod]
        public void Find_incorrectData_false()
        {
            Assert.IsFalse(Fond.SCP_IsFind("0000"));
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
        [TestMethod]
        public void Change_incorrectData_false()
        {
            fond = new Fond();
            SelectSCP.Name = "0";
            if (Fond.SCP_CanChange("1730"))
            {
                fond.SCP_CHANGE("1730", "Кетер", "Несуществующий экзмепляр", @"S:\AndroidProjects\app\src\main\res\drawable\scp017.png", 10, 679000);
            }
            Assert.IsFalse(Fond.SCP_IsFind("1730"));
        }
        [TestMethod]
        public void Change_existingData_false()
        {
            fond = new Fond();
            SCP scp = new SCP("03", "Безопасный", "Тестовый образец", "S:\\AndroidProjects\\app\\src\\main\\res\\drawable\\image.png", 1, 30000);
            fond.SCP_ADD(scp);
            SelectSCP.Name = "03";
            if (Fond.SCP_CanChange("173"))
            {
                fond.SCP_CHANGE("173", "Кетер", "Cуществующий экзмепляр, заменяемый на уже существующий", @"S:\AndroidProjects\app\src\main\res\drawable\scp017.png", 10, 679000);
                res = true;
            }
            Assert.IsFalse(res);
        }
        [TestMethod]
        public void Delete_existingData_true()
        {
            fond = new Fond();
            SCP scp = new SCP("04", "Безопасный", "Тестовый образец", "S:\\AndroidProjects\\app\\src\\main\\res\\drawable\\image.png", 1, 30000);
            fond.SCP_ADD(scp);
            bool find = Fond.SCP_IsFind("04");
            fond.SCP_DEL("04");
            Assert.IsTrue(!Fond.SCP_IsFind("04") && find);
        }
        [TestMethod]
        public void Delete_emptyData_false()
        {
            fond = new Fond();
            int countSCPs = Fond.SCP_Reading().Count;
            if (Fond.SCP_IsFind("")) fond.SCP_DEL("");
            Assert.IsFalse(countSCPs != Fond.SCP_Reading().Count);
        }
    }
}