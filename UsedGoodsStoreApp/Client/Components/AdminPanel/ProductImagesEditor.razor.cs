using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Collections;
using System.Net.Http.Headers;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class ProductImagesEditor
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public ProductDTO Product { get; set; }
        public async Task EditProductImages()
        {
            long maxFileSize = 9999999999;
            using var content = new MultipartFormDataContent();
            foreach (var image in Product.ProductImages)
            {
                var fileContent =
                    new StreamContent(new MemoryStream(image.Image));

                fileContent.Headers.ContentType =
                    new MediaTypeHeaderValue("image/jpg");

                content.Add(
                    content: fileContent,
                    name: $"\"files\"",
                    fileName: $"{Product.ProductId};{image.IsMainImage}");
            }
            var result = await UsedGoodsStoreService.UpdateProductImages(content);
            if (!result.Failed)
                MudDialog.Close(DialogResult.Ok(true));
        }
        IList<IBrowserFile> files = new List<IBrowserFile>();
        private async void UploadFiles(IReadOnlyList<IBrowserFile> files)
        {
            foreach (var file in files)
            {
                this.files.Add(file);
                Product.ProductImages.Add(new ProductImagesDTO { ProductId = Product.ProductId , IsMainImage = false, Image = await ConvertToByteArrayAsync(file) });
            }
            StateHasChanged();
            //TODO upload the files to the server
        }
        public async Task<byte[]> ConvertToByteArrayAsync(IBrowserFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream(99999999).CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public void SetMainImage(ProductImagesDTO product)
        {
            Product.ProductImages.ForEach(x => x.IsMainImage = false);
            product.IsMainImage = true;
        }
        public void DeleteImage(ProductImagesDTO product)
        {
            Product.ProductImages.Remove(product);
        }
    }
}
