using sage.challenge.data;
using sage.challenge.data.Models;
using sage.challenge.services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sage.challenge.business
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository()
        {
        }

        #region Account
        public Task<Account> GetAccount(Guid id)
        {
            return Task.FromResult(BaseAccounts.GetAccount(id));
        }
        public Task<List<Account>> GetAccounts()
        {
            return Task.FromResult(BaseAccounts.GetAllAccounts());
        }
        public void AddAccount(AccountRequestModel account)
        {
            BaseAccounts.AddAccount(account);
        }
        public void DeleteAccount(Guid accountId)
        {
            BaseAccounts.DeleteAccount(accountId);
        }
        #endregion

        #region User
        public Task<List<User>> GetUsersByAccountId(Guid accountId)
        {
            return Task.FromResult(BaseAccounts.GetUsersByAccountId(accountId));
        }
        public Task<User> GetUsersByAccountIdAndUserId(Guid accountId, Guid userId)
        {
            return Task.FromResult(BaseAccounts.GetUsersByAccountIdAndUserId(accountId, userId));
        }
        public void AddUser(Guid accountId, UserRequestModel user)
        {
            BaseAccounts.AddUser(accountId, user);
        }
        public void DeleteUser(Guid accountId, Guid userId)
        {
            BaseAccounts.DeleteUser(accountId, userId);
        }

        #endregion

    }
}
