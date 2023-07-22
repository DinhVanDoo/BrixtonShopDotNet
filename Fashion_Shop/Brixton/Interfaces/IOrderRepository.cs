using Brixton.Models;

namespace Brixton.Interfaces
{
    public interface IOrderRepository
    {
        public void Checkout(Cart cart, AccountModel accountModel);

        public List<OrderHe161048> GetOrder(string accid);

        public List<OrderDetailHe161048> GetOrderDetail(int orId);
    }
}
