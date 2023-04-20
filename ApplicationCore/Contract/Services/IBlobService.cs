using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface IBlobService
    {
        // To use Blob storage, you need Azure.Storage.Blobs nuget package
        public Task<BlobResponseModel> GetBlobAsync(string name);
        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadFileBlobAsync(string filePath, string fileName);

        public Task DeleteBlobAsync(string blobName);
    }
}
