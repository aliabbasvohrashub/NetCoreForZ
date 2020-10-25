using sage.challenge.data;
using sage.challenge.data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sage.challenge.services
{
    public interface IAccountRepository
    {
        #region Account
        Task<List<Account>> GetAccounts();
        Task<Account> GetAccount(Guid id);
        void AddAccount(AccountRequestModel account);
        void DeleteAccount(Guid accountId);
        #endregion

        #region User
        Task<List<User>> GetUsersByAccountId(Guid accountId);
        Task<User> GetUsersByAccountIdAndUserId(Guid accountId, Guid userId);
        void AddUser(Guid accountId, UserRequestModel user);
        void DeleteUser(Guid accountId, Guid userId);
        #endregion     
       
    }
}
