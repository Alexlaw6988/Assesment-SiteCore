using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class AssetModel 
    {
        public string AssetId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
