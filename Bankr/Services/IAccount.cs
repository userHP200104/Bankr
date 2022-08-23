
using System;
namespace Bankr.Services
{
	public interface IAccount
	{
        Task<List<Account>> GetAccountList();
        Task<int> AddAccount(Account account);
        Task<int> DeleteAccount(Account account);
        Task<int> UpdateAccount(Account account);
    }
}

