using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.RepositoryLayer.repositories;
using Ecommerce.DomainLayer.models;
using ServiceLayer.ViewModels;
using System.IO;
using System.Collections;
using Microsoft.AspNetCore.Http;

namespace ServiceLayer
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _ProductRepository;

        public ProductService(IRepository<Product> repository)
        {
            _ProductRepository = repository;
        }
        #region GetAllProducts
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var result = await _ProductRepository.GetAll();

            return result.Select(x => new ProductViewModel()
            {
                id = x.id,
                name = x.name,
                price = x.price,
                pictures = x.pictures,
                maincategoryid = x.maincategoryid,
                quantity = x.quantity

            });

        }
        #endregion

        #region GetById
        public async Task<ProductViewModel> GetById(int id)
        {
            var result = await _ProductRepository.GetById(id);
            ProductViewModel productViewModel = new()
            {
                id = result.id,
                name = result.name,
                price = result.price,
                pictures = result.pictures,
                maincategoryid = result.maincategoryid,
                quantity = result.quantity
            };
            return productViewModel;
        }
        #endregion

        #region createProduct
        public async Task<int> AddProduct(CreateProductViewModel newproduct)
        {
            var datastream = new MemoryStream();
            picture p = new() {
                picture1 = await ToArryOfByte(newproduct.FormFile1),
                picture2 = await ToArryOfByte(newproduct.FormFile2),
                picture3 = await ToArryOfByte(newproduct.FormFile3),
                picture4 = await ToArryOfByte(newproduct.FormFile4)
            };


            Product product = new()
            {
                name = newproduct.name,
                description = newproduct.description,
                maincategoryid = newproduct.maincategoryid,
                price = newproduct.price,
                quantity = newproduct.quantity,
                sellername = newproduct.sellername,
                supcategoryid = newproduct.supCategoryid,
                pictures = p,
                brandname = newproduct.brandname

            };

            return await _ProductRepository.add(product);

        }
        #endregion

        #region Remove Product 
        public async Task RemoveProduct(int id)
        {
             await _ProductRepository.Delete(id);
        }
        #endregion
        #region Extention methode
        public async Task<byte[]> ToArryOfByte(IFormFile file)
        {
            var datastream = new MemoryStream();
            await file.CopyToAsync(datastream);
            return  datastream.ToArray();
            
        }
        #endregion
    }
}
