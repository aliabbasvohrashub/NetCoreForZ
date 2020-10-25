using sage.challenge.data;
using sage.challenge.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sage.challenge.business
{
    public static class BaseAccounts
    {
        public static List<Account> _accounts;
        #region Account
        public static List<Account> GetAllAccounts()
        {
            if (_accounts == null)
            {
                _accounts = new List<Account>(){
                    new Account()
                        {
                            Id = Guid.NewGuid(),
                            CompanyName = "a",
                            Users = new List<User> {
                                new User{
                                    AccountId = Guid.NewGuid(),
                                    Id = Guid.NewGuid(),
                                    Email = "test@gmail.com",
                                    FirstName = "first name",
                                    LastName = "last name"
                                }
                            },
                            Website = "https://www.test.com"
                        }
                };
            }
            return _accounts;
        }
        public static void AddAccount(AccountRequestModel account)
        {
            if (_accounts == null)
                _accounts = new List<Account>();
            _accounts.Add(new Account
            {
                CompanyName = account.CompanyName,
                Website = account.Website
            });
        }
        public static Account GetAccount(Guid id)
        {
            return _accounts.FirstOrDefault(x => x.Id == id);
        }
        public static void RemoveAccount(Account account)
        {
            if (_accounts == null)
            {
                _accounts = new List<Account>();
            }
            _accounts.Remove(account);
        }
        public static void DeleteAccount(Guid accountId)
        {
            Account account = _accounts.FirstOrDefault(a => a.Id == accountId);
            _accounts.Remove(account);
        }
        #endregion

        #region User
        public static List<User> GetUsersByAccountId(Guid accountId)
        {
            return _accounts.FirstOrDefault(a => a.Id == accountId).Users;
        }
        public static User GetUsersByAccountIdAndUserId(Guid accountId, Guid userId)
        {
            List<User> userList = _accounts.FirstOrDefault(a => a.Id == accountId).Users;
            return userList.FirstOrDefault(u => u.Id == userId);
        }
        public static void AddUser(Guid accountId, UserRequestModel user)
        {
            Account account = _accounts.FirstOrDefault(a => a.Id == accountId);
            account.Users.Add(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AccountId = accountId
            });
        }
        public static void DeleteUser(Guid accountId, Guid userId)
        {
            List<User> userList = _accounts.FirstOrDefault(a => a.Id == accountId).Users;
            User user = userList.FirstOrDefault(u => u.Id == userId);
            userList.Remove(user);
        }
        #endregion
    }
}
