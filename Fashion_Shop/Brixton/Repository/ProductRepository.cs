using Brixton.Models;
using Brixton.Repository;

namespace Brixton.Interface
{
    public class ProductRepository : IProductRepository
    {
        private readonly PRJ301_SE1705Context _context = new PRJ301_SE1705Context();
        public ProductModel AddProduct(ProductModel product)
        {
            var _product = new ProductHe161048
            {
                ProId = product.ProId,
                ProImg = "img/" + product.ProImg,
                ProName = product.ProName,
                ProDetail = product.ProDetail,
                ProPrice = product.ProPrice,
                CaId = product.CaId,
                CoId = product.CoId
            };
            _context.ProductHe161048s.Add(_product);
            _context.SaveChanges();
            return new ProductModel
            {
                ProId = _product.ProId,
                ProImg = _product.ProImg,
                ProName = _product.ProName,
                ProDetail = _product.ProDetail,
                ProPrice = _product.ProPrice,
                CaId = _product.CaId,
                CoId = _product.CoId
            };
        }

        public void DeleteProduct(int id)
        {
            var _product = _context.ProductHe161048s.FirstOrDefault(p => p.ProId == id);
            if (_product != null)
            {
                _context.Remove(_product);
                _context.SaveChanges();
            }
        }

        public List<ProductModel> getAllProduct()
        {
            var products = _context.ProductHe161048s.Select(x => new ProductModel
            {
                ProId = x.ProId,
                ProImg = x.ProImg,
                ProName = x.ProName,
                ProDetail = x.ProDetail,
                ProPrice = x.ProPrice,
                CaId = x.CaId,
                CoId = x.CoId

            });
            return products.ToList();
        }

        public List<ProductModel> getAllProductByCaId(int? caId, string? key)
        {

            List<ProductModel> list = new List<ProductModel>();

            var query = _context.ProductHe161048s.AsQueryable();

            if (caId != null)
            {
                query = query.Where(x => x.CaId == caId);
            }
            if (key != null)
            {
                query = query.Where(x => x.ProName.Contains(key));
            }
            list = query.Select(x => new ProductModel
            {
                ProId = x.ProId,
                ProImg = x.ProImg,
                ProName = x.ProName,
                ProDetail = x.ProDetail,
                ProPrice = x.ProPrice,
                CaId = x.CaId,
                CoId = x.CoId
            }).ToList();


            return list;
        }

        public ProductModel getProductById(int id)
        {
            var getProductById = _context.ProductHe161048s.SingleOrDefault(x => x.ProId == id);
            if (getProductById == null)
            {
                throw new InvalidOperationException("Not Found Product");
            }
            return new ProductModel
            {
                ProId = getProductById.ProId,
                ProImg = getProductById.ProImg,
                ProName = getProductById.ProName,
                ProDetail = getProductById.ProDetail,
                ProPrice = getProductById.ProPrice,
                CaId = getProductById.CaId,
                CoId = getProductById.CoId
            };
        }

        public void UpdateProduct(ProductModel product, int Pid)
        {
            var _product = _context.ProductHe161048s.FirstOrDefault(p => p.ProId == Pid);
            if (_product == null)
            {
                throw new Exception();
            }
            else
            {
                _product.ProName = product.ProName;
                _product.ProImg = "img/" + product.ProImg;
                _product.ProPrice = product.ProPrice;
                _product.ProDetail = product.ProDetail;
                _product.CaId = product.CaId;
                _product.CoId = product.CoId;

                _context.SaveChanges();
            }
        }
    }
}
