using Brixton.Interfaces;
using Brixton.Models;

namespace Brixton.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PRJ301_SE1705Context _context;

        public AccountRepository(PRJ301_SE1705Context context)
        {
            _context = context;
        }

        public AccountModel AddAccount(AccountModel account)
        {
            var _account = new AccountHe161048
            {
                AccId = account.AccId,
                AccPass = account.AccPass,
                UserName = account.UserName,
                UserAddress = account.UserAddress,
                UserPhone = account.UserPhone,
                QuesId = account.QuesId,
                Answer = account.Answer,
                Role = 1
            };
            _context.AccountHe161048s.Add(_account);
            _context.SaveChanges();
            return new AccountModel
            {
                AccId = account.AccId,
                AccPass = account.AccPass,
                UserName = account.UserName,
                UserAddress = account.UserAddress,
                UserPhone = account.UserPhone,
                QuesId = account.QuesId,
                Answer = account.Answer,
                Role = 1
            };

        }

        public AccountModel isExitsAccount(AccountModel accountModel)
        {
            var isExitsAcc = _context.AccountHe161048s.FirstOrDefault(a => a.AccId == accountModel.AccId && a.AccPass == accountModel.AccPass);
            if (isExitsAcc != null)
            {
                return new AccountModel
                {
                    AccId = isExitsAcc.AccId,
                    AccPass = isExitsAcc.AccPass,
                    UserName = isExitsAcc.UserName,
                    UserAddress = isExitsAcc.UserAddress,
                    UserPhone = isExitsAcc.UserPhone,
                    Role = isExitsAcc.Role,
                    QuesId = isExitsAcc.QuesId,
                    Answer = isExitsAcc.Answer
                };
            }
            else
            {
                return null;
            }
        }

        public bool isExits(string id)
        {
            var isExitsEmail = _context.AccountHe161048s.FirstOrDefault(a => a.AccId == id);
            if (isExitsEmail != null)
            {
                return true;
            }
            return false;
        }

        public AccountModel getAccountByAccID(string id)
        {

            var account = new AccountHe161048();
            account = _context.AccountHe161048s.FirstOrDefault(x => x.AccId == id);
            if (account == null)
            {
                return null;
            }
            return new AccountModel
            {
                AccId = account.AccId,
                AccPass = account.AccPass,
                UserName = account.UserName,
                UserAddress = account.UserAddress,
                UserPhone = account.UserPhone,
                Role = account.Role,
                QuesId = account.QuesId,
                Answer = account.Answer
            };
        }

        public void UpdatePassword(string accID, string password)
        {
            var _account = _context.AccountHe161048s.FirstOrDefault(acc => acc.AccId.Equals(accID));
            if (_account != null)
            {
                _account.AccPass = password;
                _context.SaveChanges();
            }
        }



        public void UpdateInfo(string accid, string name, string phone, string address)
        {
            AccountHe161048 account = _context.AccountHe161048s.FirstOrDefault(x => x.AccId.Equals(accid));
            account.UserName = name;
            account.UserAddress = address;
            account.UserPhone = phone;
            _context.AccountHe161048s.Update(account);
            _context.SaveChanges();

        }

        public void UpdateInfoModel(string? accid, AccountModel accountModel)
        {
            AccountHe161048 _account = _context.AccountHe161048s.FirstOrDefault(x => x.AccId.Equals(accid));
            if (accountModel != null)
            {
                _account.UserName = accountModel.UserName;
                _account.UserPhone = accountModel.UserPhone;
                _account.UserAddress = accountModel.UserAddress;
                _context.AccountHe161048s.Update(_account);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Not found");
            }
        }
    }
}
