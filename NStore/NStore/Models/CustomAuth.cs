using NStore.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace NStore.Models
{
    public class CustomAuth : RoleProvider
    {
        private NStoreEntities db = new NStoreEntities();
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username.StartsWith("customer"))
            {
                username = username.Substring(8);
                var user = db.KhachHang.SingleOrDefault(x => x.taiKhoan == username);
                if (user != null)
                {
                    return new string[] { "customer" };
                }
            }
            if (username.StartsWith("staff"))
            {
                username = username.Substring(5);
                var user = db.NhanVien.SingleOrDefault(x => x.taiKhoan == username);
                if (user != null)
                {
                    string role = user.chucVu == 1 ? "admin" : "mod";
                    return new string[] { role };
                }
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}