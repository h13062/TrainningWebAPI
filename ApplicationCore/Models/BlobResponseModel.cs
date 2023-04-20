using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class BlobResponseModel
    {
        public BlobResponseModel(Stream content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }
        public Stream? Content { get; }
        public string ContentType { get; }
    }
}
