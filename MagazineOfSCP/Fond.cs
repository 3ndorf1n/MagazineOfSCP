using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Windows;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace MagazineOfSCP
{
    public class Fond
    {

        string jsonscps = @"S:\AProjects\CSharp\MagazineOfSCP\MagazineOfSCP\SCP.json";
        string usersJson = @"S:\AProjects\CSharp\MagazineOfSCP\MagazineOfSCP\Users.json";

        public static List<User> User_Reading()
        {
            string usersjson = @"S:\AProjects\CSharp\MagazineOfSCP\MagazineOfSCP\Users.json";
            return JsonSerializer.Deserialize<List<User>>(File.ReadAllText(usersjson));
        }
        public static bool User_Verification(string login)
        {
            List<User> users = User_Reading();
            if (users != null)
            {
                foreach (User user in users)
                {
                    if (user.Login.Equals(login))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool User_Verification(string login, string p)
        {
            List<User> users = User_Reading();
            if (users != null)
            {
                foreach (User user in users)
                {
                    if (user.Login == login && user.Password.Equals(p))
                    {
                        UserAccess.login = user.Login;
                        UserAccess.access_lvl = user.Access_lvl;
                        return true;
                    }
                }
            }
            return false;
        }

        public void User_Add(User user)
        {
            List<User> users = User_Reading();
            users.Add(user);    
            File.WriteAllText(usersJson, JsonSerializer.Serialize(users));
            UserAccess.login = user.Login;
            UserAccess.access_lvl = user.Access_lvl;
        }
        public static List<SCP> SCP_Reading()
        {
            string jsonscps = @"S:\AProjects\CSharp\MagazineOfSCP\MagazineOfSCP\SCP.json";
            return JsonSerializer.Deserialize<List<SCP>>(File.ReadAllText(jsonscps));
        }
        public static bool SCP_IsFind(string name)
        {
            return SCP_Reading().Where(s => s.Name.Equals(name)).ToList().Count == 0 ? false : true;  
        }
        public static bool SCP_CanChange(string name)
        {
            return SCP_Reading().Where(s => s.Name.Equals(name) && s.Name.Equals(SelectSCP.Name) == false).ToList().Count == 0 ? true : false;
        }
        public void SCP_ADD(SCP scp)
        {
            List<SCP> scps = SCP_Reading();
            //scps.AddRange(SCP_Reading());
            scps.Add(scp);
            File.WriteAllText(jsonscps, JsonSerializer.Serialize(scps));
        }
        public void SCP_CHANGE(string name, string class_, string description, string image, int count, double price)
        {
            List<SCP> scps = SCP_Reading();
            //scps.Where(s => s.Name.Equals(SelectSCP.Name)).Select(s => (s.Name = name, s.Class_ = class_, s.Description = description, s.Image = image, s.Count = count, s.Price = price));
            foreach (var scp in scps)
            {
                if (scp.Name == SelectSCP.Name)
                {
                    scp.Name = name;
                    scp.Class_ = class_;
                    scp.Description = description;
                    scp.Image = image;
                    scp.Count = count;
                    scp.Price = price;
                }
            }
            File.WriteAllText(jsonscps, JsonSerializer.Serialize(scps));
        }
        public void SCP_DEL(string name)
        {
            List<SCP> scps = SCP_Reading();
            scps.Remove(scps.Where(s => s.Name.Equals(name)).Select(s => s).ToList()[0]);
            var data = JsonSerializer.Serialize(scps);
            File.WriteAllText(jsonscps, data);
        }
    }
    static class BuyedSCP
    {
        public static List<SCP> scps {get; set;}
    }
    static class ChangeORAdd
    {
        public static bool coa { get;  set; }
    }
}
