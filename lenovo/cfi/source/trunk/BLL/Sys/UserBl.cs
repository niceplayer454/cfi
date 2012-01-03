using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common;
using Lenovo.CFI.Common.Sys;
using Lenovo.CFI.DAL.Sys;
using Lenovo.CFI.DAL;
using Lenovo.CFI.Common.Mail;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System.IO;

namespace Lenovo.CFI.BLL.Sys
{
    public class UserBl
    {
        public User Login(string itcode, string password)
        {
            User user = new User(itcode, Guid.NewGuid());

            return user;
        }

        public User GetUserByUID(Guid uid)
        {
            return UserDa.GetUserByUID(uid);
        }

        public User GetUserByItCode(string itcode)
        {
            return UserDa.GetUserByItCode(itcode);
        }

        public User GetUserByItCodeWithRole(string itcode)
        {
            User user = UserDa.GetUserByItCode(itcode);
            user.Roles.AddRange(UserDa.GetUserRole(user.ItCode, null, null));

            return user;
        }

        public List<User> GetUserByItCodes(params string[] itcodes)
        {
            return UserDa.GetUserByItCode(itcodes);
        }

        public List<User> GetUserByItCodesWithOrganFullTitle(params string[] itcodes)
        {
            // Dictionary<Guid, Organ> organsDic = new OrganBl().GetOrganTreeDic(null);
            List<User> users = UserDa.GetUserByItCode(itcodes);
            //foreach (User user in users)
            //    user.Organ.Title = organsDic[user.Organ.ID].GetFullTitle();

            return users;
        }

        public List<User> GetUserWithBuRole(string bu, int role, string department)
        {
            return UserDa.GetUserWithBuRole(bu, role, department);
        }


        public List<User> GetUserAll()
        {
            return UserDa.GetUserAll();
        }

        public List<User> GetUser(string itcode)
        {
            if (itcode == String.Empty) itcode = null;

            return UserDa.GetUser(itcode, null, null, null);
        }

        public List<User> GetUser(Guid organ)
        {
            return UserDa.GetUser(null, organ, null, null);
        }



        public void UpdateDefaultBu(string itcode, string bu)
        {
            UserDa.UpdateDefaultBu(itcode, bu);
        }

        public void SetDelgate(string itcode, string delegateItcode)
        {
            User user = UserDa.GetUserByItCode(itcode);
            if (user == null)
                throw new BusinessObjectLogicException("Invalid input!");

            if (String.IsNullOrEmpty(delegateItcode)) delegateItcode = itcode;  // 处理输入

            if (user.DelegateUser == delegateItcode) return;  // 无实际操作

            if (itcode != delegateItcode)
            {
                User delegateUser = UserDa.GetUserByItCode(delegateItcode);         // 验证输入
                if (delegateUser == null)
                    throw new BusinessObjectLogicException("Invalid delegate user!");
            }


            user.DelegateUser = delegateItcode;

            string title = null;
            string body = null;
            string toUser = null;
            string ccUsers = null;
            string domain = "@" + Utils.SysDomain();
            if (user.ItCode == delegateItcode)
            {
                // 取消授权

                title = "TQMP Authorization notice";
                body = "The authorization from " + user.ItCode + " is canceled." ;
                toUser = delegateItcode + domain;
            }
            else
            {
                // 设置授权

                title = "TQMP Authorization notice";
                body = "The approval operation is authorized to " + delegateItcode + ".";
                toUser = delegateItcode + domain;
            }
            
            UserDa.UpdateUserDelegate(itcode, delegateItcode);

            new Mail.MailBl().SendMail(toUser, ccUsers, title, body, System.Net.Mail.MailPriority.Normal, null);
        }

        public void AddUser(User user)
        {
            if (user.UID == Guid.Empty) user.UID = Guid.NewGuid();

            if (user.Organ == null) throw new BusinessObjectLogicException("Invalid Organ!");
            //if (user.Superior == null) throw new BusinessObjectLogicException("Invalid Manager!");

            user.CreateTime = DateTime.Now;
            user.Password = RandomString.GetPassword();

            using (TranscationHelper trans = TranscationHelper.GetInstance())
            {
                trans.BeginTrans();
                try
                {
                    UserDa.InsertUser(user, trans);

                    foreach (UserRole role in user.Roles)
                        UserDa.InsertUserRole(role, trans);

                    trans.CommitTrans();
                }
                catch
                {
                    trans.RollTrans();
                    throw;
                }
            }

            if (user.Superior == null)  // 更新为自己
            {
                user.Superior = new UserBase(user.ItCode);
                UserDa.UpdateUser(user);
            }
        }

        public void EditUser(User user)
        {
            User existUser = UserDa.GetUserByItCode(user.ItCode);
            existUser.Roles.AddRange(UserDa.GetUserRole(existUser.ItCode, null, null));

            if (user == null) throw new BusinessObjectLogicException("Invalid User!");
            if (user.Organ == null) throw new BusinessObjectLogicException("Invalid Organ!");
            if (user.Superior == null) throw new BusinessObjectLogicException("Invalid Manager!");
            if (user.Disabled && existUser.Disabled) throw new BusinessObjectLogicException("User is disabled!");

            bool updateUser = false;
            if (existUser.FirstName != user.FirstName ||
                existUser.LastName != user.LastName ||
                existUser.AbbrName != user.AbbrName ||
                existUser.Organ.ID != user.Organ.ID ||
                existUser.Superior.ItCode != user.Superior.ItCode ||
                existUser.Phone != user.Phone ||
                existUser.Disabled != user.Disabled ||
                existUser.Department != user.Department)
            {
                existUser.FirstName = user.FirstName;
                existUser.LastName = user.LastName;
                existUser.AbbrName = user.AbbrName;
                existUser.Organ = user.Organ;
                existUser.Superior = user.Superior;
                existUser.Phone = user.Phone;
                existUser.Disabled = user.Disabled;
                existUser.Department = user.Department;

                updateUser = true;
            }

            List<UserRole> rolesAdd = new List<UserRole>();
            List<UserRole> rolesDel = new List<UserRole>();

            //foreach (UserRole role in existUser.Roles)
            //{
            //    if (!user.Roles.Exists(r => (r.Role == role.Role && r.BU == role.BU)))
            //        rolesDel.Add(role);
            //    //if (!user.Roles.Exists(delegate(UserRole r) { return r.Role == role.Role && r.BU == role.BU; }))
            //    //{ }
            //}
            //foreach (UserRole role in user.Roles)
            //{
            //    if (!existUser.Roles.Exists(r => (r.Role == role.Role && r.BU == role.BU)))
            //        rolesAdd.Add(role);
            //}

            // 如果没有实际更改
            if (!updateUser && rolesAdd.Count == 0 && rolesDel.Count == 0) return;

            using (TranscationHelper trans = TranscationHelper.GetInstance())
            {
                trans.BeginTrans();
                try
                {
                    if (updateUser) UserDa.UpdateUser(existUser, trans);

                    foreach (UserRole role in rolesDel) UserDa.DeleteUserRole(role, trans);
                    foreach (UserRole role in rolesAdd) UserDa.InsertUserRole(role, trans);

                    trans.CommitTrans();
                }
                catch
                {
                    trans.RollTrans();
                    throw;
                }
            }
        }

        public void EditUserRole(string itcode, string bu, List<UserRole> roles)
        {
            List<UserRole> existRoles = UserDa.GetUserRole(itcode, null, bu);

            List<UserRole> rolesAdd = new List<UserRole>();
            List<UserRole> rolesDel = new List<UserRole>();

            //foreach (UserRole role in existRoles)
            //{
            //    if (!roles.Exists(r => (r.Role == role.Role && r.BU == role.BU)))
            //        rolesDel.Add(role);
            //    //if (!user.Roles.Exists(delegate(UserRole r) { return r.Role == role.Role && r.BU == role.BU; }))
            //    //{ }
            //}
            //foreach (UserRole role in roles)
            //{
            //    if (!existRoles.Exists(r => (r.Role == role.Role && r.BU == role.BU)))
            //        rolesAdd.Add(role);
            //}

            // 如果没有实际更改
            if (rolesAdd.Count == 0 && rolesDel.Count == 0) return;

            using (TranscationHelper trans = TranscationHelper.GetInstance())
            {
                trans.BeginTrans();
                try
                {
                    foreach (UserRole role in rolesDel) UserDa.DeleteUserRole(role, trans);
                    foreach (UserRole role in rolesAdd) UserDa.InsertUserRole(role, trans);

                    trans.CommitTrans();
                }
                catch
                {
                    trans.RollTrans();
                    throw;
                }
            }
        }

        /// <summary>
        /// 更新用户信息，可以更改用户密码
        /// </summary>
        /// <param name="user"></param>
        public void EditUserInfo(string itcode, string password, string firstname, string lastname, string phone)
        {
            User existUser = UserDa.GetUserByItCode(itcode);

            if (existUser == null) throw new BusinessObjectLogicException("Invalid User!");
            if (existUser.Disabled) throw new BusinessObjectLogicException("User is disabled!");

            if (!String.IsNullOrEmpty(password)) existUser.Password = password;
            existUser.FirstName = firstname;
            existUser.LastName = lastname;
            existUser.Phone = phone;


            UserDa.UpdateUser(existUser);
        }

        public void SendPassword(string itcode)
        {
            User existUser = UserDa.GetUserByItCode(itcode);

            if (existUser == null) throw new BusinessObjectLogicException("Invalid User!");


            new Mail.MailBl().SendMail(Message.ConvertMailAddress(existUser.ItCode), null, "Hi, Your TQMP System Password",
                "Your password is : " + existUser.Password + Utils.GetSysStatement(), System.Net.Mail.MailPriority.Normal);
        }




        public List<UserRole> GetUserRole(string user)
        {
            return UserDa.GetUserRole(user, null, null);
        }

        public List<UserRole> GetUserRole(string user, string bu)
        {
            return UserDa.GetUserRole(user, null, bu);
        }
        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="createNewOrgan">如果组织名称不匹配，那么是否创建；否且有新组织，那么会会终止新组织下用户的导入</param>
        public void Import(string filePath, bool createNewOrgan)
        {
            // 读取待导入的数据
            HSSFWorkbook wb = new HSSFWorkbook(new FileStream(filePath, FileMode.Open));

            Sheet sheet = wb.GetSheetAt(0);
            if (sheet == null) throw new BusinessObjectLogicException("The Sheet1 does not exist!");

            Dictionary<string, string[]> datas = new Dictionary<string, string[]>();
            Row row = null;
            for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                row = sheet.GetRow(rowIndex);

                if (row == null) continue;

                string itcode = NPOIHelper.GetCellStringValue(row.GetCell(0)); if (itcode == null) continue; itcode = itcode.ToLower();
                string firstName = NPOIHelper.GetCellStringValue(row.GetCell(1)); if (firstName == null) continue;
                string lastName = NPOIHelper.GetCellStringValue(row.GetCell(2)); if (lastName == null) continue;
                string organ = NPOIHelper.GetCellStringValue(row.GetCell(3)); if (organ == null) continue;
                string team = NPOIHelper.GetCellStringValue(row.GetCell(4)); if (team == null) continue;
                string manager = NPOIHelper.GetCellStringValue(row.GetCell(5)); if (manager == null) continue;manager = manager.ToLower();
                string phnoe = NPOIHelper.GetCellStringValue(row.GetCell(6)); if (phnoe == null) continue;

                if (!datas.ContainsKey(itcode))
                    datas.Add(itcode, new string[] { itcode, firstName, lastName, organ, team, manager, phnoe });
            }


            /*
            // 已存在的用户和组织
            OrganBl organBl = new OrganBl();

            List<User> existUsers = UserDa.GetUserAll();
            Dictionary<string, User> existUsersDic = new Dictionary<string, User>();
            foreach (User user in existUsers) existUsersDic.Add(user.ItCode, user);
            List<Organ> existOrgans = organBl.GetOrganTreePreOrder();
            Organ rootOrgan = existOrgans[0];       // root organ
            Dictionary<string, Organ> existOrgansDic = new Dictionary<string, Organ>();
            foreach (Organ organ in existOrgans) existOrgansDic.Add(organ.GetFullTitle(false), organ);


            // 分析并创建新的组织
            Dictionary<string, string[]> newOrgans = new Dictionary<string, string[]>();
            foreach (string[] data in datas.Values)
            {
                string organTitle = data[3] + data[4];
                if (!newOrgans.ContainsKey(organTitle))
                {
                    if (!existOrgansDic.ContainsKey(organTitle))
                    {
                        newOrgans.Add(organTitle, new string[] { data[3], data[4] });  // 记录
                    }
                }
            }
            if (newOrgans.Count > 0)
            {
                if (!createNewOrgan)
                {
                    string message = "";
                    foreach (string[] newOrgan in newOrgans.Values)
                    {
                        message += (newOrgan[0] + " =" + newOrgan[1] + "\r\n");
                    }

                    throw new BusinessObjectLogicException("Please add below organs first:\r\n" + message);
                }
                else
                {
                    List<string[]> newOrgansList = new List<string[]>(newOrgans.Values);
                    newOrgansList.Sort((x,y)=>(x[0].CompareTo(y[0])));      // 排序，以便父节点先被创建

                    foreach (string[] organData in newOrgansList)
                    {
                        Organ organ = new Organ();
                        organ.Title = organData[1];

                        if (existOrgansDic.ContainsKey(organData[0]))
                        {
                            organ.Parent = existOrgansDic[organData[0]];
                        }
                        else
                        {
                            organ.Parent = rootOrgan;
                        }

                        organ.BU = organ.Parent.BU;
                        organBl.AddOrgan(organ);

                        existOrgansDic.Add(organ.GetFullTitle(false), organ);        // 增加
                    }
                }
            }

            // 分析并创建新的用户，更新已有的用户信息
            foreach (string[] data in datas.Values)
            {
                if (!existUsersDic.ContainsKey(data[0]))
                {
                    User user = new User(data[0], Guid.NewGuid());
                    user.FirstName = data[1];
                    user.LastName = data[2];
                    user.Password = RandomString.GetPassword();
                    user.Organ = existOrgansDic[data[3] + data[4]];
                    user.Superior = null;
                    user.CreateTime = DateTime.Now;

                    UserDa.InsertUser(user);

                    existUsersDic.Add(user.ItCode, user);
                }
            }

            foreach (string[] data in datas.Values)
            {
                User existUser = existUsersDic[data[0]];
                if (existUser.FirstName != data[1] ||
                    existUser.LastName != data[2] ||
                    existUser.Organ.GetFullTitle(false) != data[3] + data[4] ||
                    existUser.SuperiorItCode != data[5] ||
                    existUser.Phone != data[6])
                {
                    existUser.FirstName = data[1];
                    existUser.LastName = data[2];
                    existUser.Organ = existOrgansDic[data[3] + data[4]];
                    existUser.Superior = existUsersDic[data[5]];
                    existUser.Phone = data[6];

                    UserDa.UpdateUser(existUser);
                }
            }
             * 
             * */
        }
    }
}
