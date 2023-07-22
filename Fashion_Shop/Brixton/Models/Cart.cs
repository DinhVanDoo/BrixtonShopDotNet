namespace Brixton.Models
{
    public class Cart
    {

        public List<Item> _items { get; set; } = new List<Item>();


        public void AddItem(ProductModel product, int quantity)
        {
            Item? existingItem = _items.FirstOrDefault(i => i.Product.ProId == product.ProId);
            if (existingItem == null)
            {
                existingItem = new Item
                {
                    Product = product,
                    quantity = quantity,

                };
                _items.Add(existingItem);
            }
            else
            {
                existingItem.quantity += quantity;
            }
        }

        public double getTotalMoney()
        {
            double total = 0;
            foreach (var item in _items)
            {
                total += (item.quantity * item.Product.ProPrice);
            }
            return total;
        }


        private Item getItemById(int id)
        {
            foreach (Item item in _items)
            {
                if (item.Product.ProId == id)
                {
                    return item;
                }
            }
            return null;
        }

        public int getQuantityById(int id)
        {           //1 proid  //item( proid 1, qtt, price )
            return getItemById(id).quantity;

        }

        public void removeItem(int id)
        {
            if (getItemById(id) != null)
            {
                _items.Remove(getItemById(id));
            }
        }



        public void Clear() => _items.Clear();
    }
}
