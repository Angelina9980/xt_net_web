using System;
using Controllers;
using System.Web.Security;
using Epam.Common;
using Epam.User.Common;

namespace Web.MyRoleProvider
{
    public class MyRoleProvider : RoleProvider
    {
        private static Epam.Nodes.BLL.Abstract.IAccountLogic accountLogic = AccountResolver.accountLogic;
        AccountController accountController = new AccountController(accountLogic);
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string[] GetRolesForUser(string username)
        {
            return accountController.GetRole(username);
        } 
        public override bool IsUserInRole(string username, string roleName)
        {
            if (GetRolesForUser(roleName).Equals("admin") || GetRolesForUser(roleName).Equals("user"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
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

       

        public override string[] GetUsersInRole(string roleName)
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