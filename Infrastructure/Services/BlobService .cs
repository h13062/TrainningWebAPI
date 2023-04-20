using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient _clientContainer;
        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            _clientContainer = _blobServiceClient.GetBlobContainerClient("resumes");
        }

        public async Task DeleteBlobAsync(string blobName)
        {
            var blobClient = _clientContainer.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<BlobResponseModel> GetBlobAsync(string name)
        {
            var blobClient = _clientContainer.GetBlobClient(name);
            var blobDownloadResult = await blobClient.DownloadAsync();

            return new BlobResponseModel(blobDownloadResult.Value.Content, blobDownloadResult.Value.Details.ContentType);
        }

        public async Task<IEnumerable<string>> ListBlobsAsync()
        {
            var items = new List<string>();

            await foreach (var blobItem in _clientContainer.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }

            return items;
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName)
        {
            var blobClient = _clientContainer.GetBlobClient(fileName);
            await blobClient.UploadAsync(filePath);
        }
    }
}
