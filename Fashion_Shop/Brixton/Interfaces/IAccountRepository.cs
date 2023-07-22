using Brixton.Models;

namespace Brixton.Interfaces
{
    public interface IAccountRepository
    {
        public AccountModel isExitsAccount(AccountModel accountModel);
        public Boolean isExits(string id);
        public AccountModel AddAccount(AccountModel account);

        public AccountModel getAccountByAccID(string id);

        public void UpdatePassword(string accID, string password);

        public void UpdateInfo(string accid, string name, string phone, string address);

        public void UpdateInfoModel(string accid, AccountModel accountModel);

    }
}
