using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    //public class ProductRepository : Repository<Product>, IProductRepository
    //{
    //    private ApplicationDbContext _db;
    //    public ProductRepository(ApplicationDbContext db) : base(db)
    //    {
    //        _db = db;
    //    }

    //    public void Update(Product obj)
    //    {
    //        var objFromDb = _db.Product.FirstOrDefault(x => x.Id == obj.Id);
    //        if (objFromDb != null)
    //        {
    //            objFromDb.Title = objFromDb.Title;
    //            objFromDb.Description = objFromDb.Description;
    //            objFromDb.Author = objFromDb.Author;
    //            objFromDb.CategoryId = objFromDb.CategoryId;
    //            objFromDb.ISBN = objFromDb.ISBN;
    //            objFromDb.Price = objFromDb.Price;
    //            objFromDb.ListPrice = objFromDb.ListPrice;
    //            objFromDb.Price100 = objFromDb.Price100;
    //            objFromDb.Price50 = objFromDb.Price50;
    //            objFromDb.CoverTypeId = objFromDb.CoverTypeId;
    //            if(objFromDb.ImageUrl!= null)
    //            {
    //                objFromDb.ImageUrl = objFromDb.ImageUrl;
    //            }
    //        }
    //    }
    //}

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product obj)
        {
            var objFromDb = _db.Product.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
