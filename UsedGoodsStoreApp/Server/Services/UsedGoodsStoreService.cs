using AutoMapper;
using DatabaseSchemaManager.Models;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Linq.Dynamic.Core;
using System.Net;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;
using Attribute1 = DatabaseSchemaManager.Models.Attribute1;

namespace UsedGoodsStoreApp.Server.Services
{
    public class UsedGoodsStoreService : IUsedGoodsStoreService
    {
        private readonly UsedGoodsStoreDbContext _db;
        private readonly IMapper _mapper;

        public UsedGoodsStoreService(UsedGoodsStoreDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RequestResult> AddAttribute(AddAttributeRequest request)
        {
            Attribute1 attribute = new Attribute1();
            attribute.Name = request.Name;
            attribute.Type = request.Type;
            if (_db.Attributes.Where(a => a.Name == attribute.Name).Any())
            {
                throw new Exception("Instnieje atrybut o takiej nazwie");
            }
            else
            {
                _db.Attributes.Add(attribute);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> UpdateAttribute(UpdateAttributeRequest request)
        {
            var item = await _db.Attributes.Where(a => a.AttributeId == request.AttributeId).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new Exception("Nie instnieje taki atrybut w bazie danych");
            }
            else
            {
                item.Name = request.Name;
                item.Type = request.Type;
                _db.Attributes.Update(item);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> DeleteAttribute(int idAttribute)
        {
            var item = await _db.Attributes.Where(a => a.AttributeId == idAttribute).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new Exception("Nie instnieje taki atrybut w bazie danych");
            }
            else
            {
                _db.Attributes.Remove(item);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<List<AttributeDTO>> GetAttributesList()
        {
            var attributesList = await _db.Attributes.ToListAsync();
            return _mapper.Map<List<AttributeDTO>>(attributesList);
        }
        public async Task<List<ProductDTO>> GetProductsList()
        {
            var productsList = await _db.Products.Include(x => x.Category).Include(x => x.AttributeProducts).Include(x => x.ProductImages).ToListAsync();
            return _mapper.Map<List<ProductDTO>>(productsList);
        }
        public async Task<List<CategoryDTO>> GetCategoriesList()
        {
            var categoriesList = await _db.Categories.Include(x => x.ParentCategory).ToListAsync();
            var test = _mapper.Map<List<CategoryDTO>>(categoriesList);
            return test;
        }
        public async Task<List<AttributeProductDTO>> GetAttributesProduct(int productId)
        {
            var categoriesList = await _db.AttributeProducts.Where(x => x.ProductId == productId).Include(x => x.AttributeValue).ThenInclude(x => x.Attribute1).ToListAsync();
            var list = _mapper.Map<List<AttributeProductDTO>>(categoriesList);
            return list;
        }
        public async Task<List<ProductDTO>> GetProductsInCategory(int categoryId)
        {
            var categoriesList = await _db.Products.Where(x => x.CategoryId == categoryId).Include(x => x.Category).Include(x => x.AttributeProducts).ThenInclude(x => x.AttributeValue).ThenInclude(x => x.Attribute1).Include(x => x.ProductImages).ToListAsync();
            var list = _mapper.Map<List<ProductDTO>>(categoriesList);
            return list;
        }
        public async Task<List<ProductDTO>> GetLastProducts(int quantity = 10)
        {
            var categoriesList = await _db.Products.OrderByDescending(x => x.ProductId).Take(quantity).Include(x => x.Category).Include(x => x.AttributeProducts).ThenInclude(x => x.AttributeValue).ThenInclude(x => x.Attribute1).Include(x => x.ProductImages).ToListAsync();
            var list = _mapper.Map<List<ProductDTO>>(categoriesList);
            return list;
        }
        public async Task<List<OrderDTO>> GetOrders()
        {
            var categoriesList = await _db.Orders.Include(x => x.User).Include(x => x.OrderStatus).Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.ProductImages).Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.Category).ToListAsync();
            var list = _mapper.Map<List<OrderDTO>>(categoriesList);
            return list;
        }
        public async Task<List<OrderDTO>> GetUserOrders(int userId)
        {
            var categoriesList = await _db.Orders.Where(x => x.UserId == userId).Include(x => x.OrderStatus).Include(x => x.User).Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.ProductImages).Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.Category).ToListAsync();
            var list = _mapper.Map<List<OrderDTO>>(categoriesList);
            return list;
        }
        public async Task<RequestResult> CreateAttributeProduct(AttributeProductRequest request)
        {
            var product = await _db.Products.Where(x => x.ProductId == request.ProductId).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new Exception("Nie istnieje taki produkt");
            }
            else
            {
                foreach (var attribute in request.attributeValues.OrderBy(x => x.DisplayOrder))
                {
                    var attributeProduct = await _db.AttributeProducts.Where(x => x.ProductId == product.ProductId && x.AttributeId == attribute.AttributeId).Include(x => x.AttributeValue).FirstOrDefaultAsync();
                    if (attributeProduct == null)
                    {
                        AttributeProduct attributeProduct1 = new AttributeProduct();
                        attributeProduct1.AttributeId = attribute.AttributeId;
                        attributeProduct1.ProductId = product.ProductId;
                        attributeProduct1.AttributeValue = new AttributeValue();
                        attributeProduct1.AttributeValue.Value = attribute.Value;
                        attributeProduct1.AttributeValue.DisplayOrder = attribute.DisplayOrder;
                        attributeProduct1.AttributeValue.AttributeId = attribute.AttributeId;
                        await _db.AttributeProducts.AddAsync(attributeProduct1);

                    }
                    else
                    {
                        attributeProduct.AttributeValue.Value = attribute.Value;
                        attributeProduct.AttributeValue.DisplayOrder = attribute.DisplayOrder;
                        _db.AttributeProducts.Update(attributeProduct);
                    }
                }
                await _db.SaveChangesAsync();
            }
            return RequestResult.Success();
        }
        public async Task<RequestResult> UpdateCategory(UpdateCategoryRequest request)
        {
            var item = await _db.Categories.Where(a => a.CategoryId == request.CategoryId).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new Exception("Nie instnieje taka kategoria w bazie danych");
            }
            else
            {
                item.Name = request.Name;
                item.ParentCategoryId = request.ParentCategoryId == 0 ? null : request.ParentCategoryId;
                _db.Categories.Update(item);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> UpdateOrder(UpdateOrderRequest request)
        {
            var item = await _db.Orders.Include(x => x.User).Where(a => a.OrderId == request.Order.OrderId).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new Exception("Nie instnieje takie zamówienie w bazie danych");
            }
            else
            {
                item.OrderStatusId = request.Order.OrderStatusId;
                //if(request.Order.OrderStatusId == (int)Statuses.Accepted)
                //{
                //    new EmailReporting().Send(item.User.Email , "Zamówienie zaakceptowane - proszę czekać na dalsze inforamcję");
                //}
                _db.Orders.Update(item);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> UpdateProduct(UpdateProductRequest request)
        {
            var item = await _db.Products.Where(a => a.ProductId == request.ProductId).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new Exception("Nie instnieje taki produkt w bazie danych");
            }
            else
            {
                item.Name = request.Name;
                item.Price = request.Price;
                item.CategoryId = request.CategoryId;
                _db.Products.Update(item);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> AddCategory(AddCategoryRequest request)
        {
            Category category = new Category();
            category.Name = request.Name;
            category.ParentCategoryId = request.ParentCategoryId == 0 ? null : request.ParentCategoryId;
            if (_db.Categories.Where(a => a.Name == category.Name).Any())
            {
                throw new Exception("Instnieje atrybut o takiej nazwie");
            }
            else
            {
                _db.Categories.Add(category);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> CreateOrder(OrderDTO request)
        {
            Order order = _mapper.Map<Order>(request);
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> AddProduct(AddProductRequest request)
        {
            Product product = new Product();
            product.Name = request.Name;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> UpdateProductImages(IEnumerable<IFormFile> files)
        {
            var maxAllowedFiles = 1020;
            long maxFileSize = 9999999999;
            var filesProcessed = 0;
            if (files.Count() > 0) 
            {
                string[] parts1 = files.First().FileName.Split(';');
                var productId1 = int.Parse(parts1[0]);
                var product = _db.Products.Where(x => x.ProductId == productId1).FirstOrDefault();
            if (product != null)
            {
                _db.ProductImages.RemoveRange(_db.ProductImages.Where(x => x.ProductId == product.ProductId));
                    await _db.SaveChangesAsync();
                foreach (var file in files)
                {
                        string[] parts = file.FileName.Split(';');
                        var productId = parts[0];
                        var main = bool.Parse(parts[1]);
                        var untrustedFileName = file.FileName;
                    var trustedFileNameForDisplay =
                        WebUtility.HtmlEncode(untrustedFileName);

                    if (filesProcessed < maxAllowedFiles)
                    {
                        if (file.Length == 0)
                        {
                        }
                        else if (file.Length > maxFileSize)
                        {
                        }
                        else
                        {
                            using var ms = new MemoryStream();
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            string s = Convert.ToBase64String(fileBytes);
                            var b = Resize2Max50Kbytes(fileBytes);
                            ProductImages image = new ProductImages();
                            image.ProductId = product.ProductId;
                            //image.Image = fileBytes;
                            image.Image = b;
                                image.IsMainImage = main;
                            await _db.ProductImages.AddAsync(image);

                        }

                        filesProcessed++;
                    }
                    else
                    {
                    }
                }
                }
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public byte[] Resize2Max50Kbytes(byte[] byteImageIn)
        {
            using (var image = SixLabors.ImageSharp.Image.Load(byteImageIn))
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new SixLabors.ImageSharp.Size(1000, 1000),
                    Mode = ResizeMode.Max
                }));
                using (var outputStream = new MemoryStream())
                {
                    image.Save(outputStream, new JpegEncoder());
                    return outputStream.ToArray();
                }
            }
        }
        public async Task<RequestResult> DeleteCategory(int idCattegory)
        {
            var item = await _db.Categories.Where(a => a.CategoryId == idCattegory).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new Exception("Nie instnieje taka kategoria w bazie danych");
            }
            else
            {
                _db.Categories.Remove(item);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
        public async Task<RequestResult> DeleteProduct(int idProduct)
        {
            var item = await _db.Products.Where(a => a.ProductId == idProduct).FirstOrDefaultAsync();
            if (item == null)
            {
                throw new Exception("Nie instnieje taki produkt w bazie danych");
            }
            else
            {
                _db.Products.Remove(item);
            }
            await _db.SaveChangesAsync();
            return RequestResult.Success();
        }
    }
}
