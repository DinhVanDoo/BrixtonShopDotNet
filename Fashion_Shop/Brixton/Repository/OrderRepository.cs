using Brixton.Interfaces;
using Brixton.Models;

namespace Brixton.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PRJ301_SE1705Context _context;

        public OrderRepository(PRJ301_SE1705Context context)
        {
            _context = context;
        }

        public void Checkout(Cart cart, AccountModel accountModel)
        {
            DateTime date = DateTime.Now;
            try
            {
                OrderHe161048 order = new OrderHe161048();
                order.OrDate = date;
                order.TotalMoney = cart.getTotalMoney();
                order.AccId = accountModel.AccId;
                _context.OrderHe161048s.Add(order);
                _context.SaveChanges();

                OrderHe161048 orId = _context.OrderHe161048s.OrderByDescending(x => x.OrId).FirstOrDefault();

                int orderID = orId.OrId;

                foreach (Item i in cart._items)
                {
                    OrderDetailHe161048 orderDetail = new OrderDetailHe161048();
                    orderDetail.OrId = orderID;
                    orderDetail.ProId = i.Product.ProId;
                    orderDetail.Quantity = i.quantity;
                    orderDetail.Price = (i.Product.ProPrice * i.quantity);
                    _context.OrderDetailHe161048s.Add(orderDetail);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<OrderHe161048> GetOrder(string accid)
        {
            List<OrderHe161048> list = new List<OrderHe161048>();
            if (accid != null)
            {
                list = _context.OrderHe161048s.Where(x => x.AccId.Equals(accid)).OrderByDescending(x => x.OrId).ToList();
            }
            return list;
        }

        public List<OrderDetailHe161048> GetOrderDetail(int orId)
        {
            List<OrderDetailHe161048> list = new List<OrderDetailHe161048>();
            list = _context.OrderDetailHe161048s.Where(x => x.OrId == orId).ToList();
            return list;
        }
    }
}
