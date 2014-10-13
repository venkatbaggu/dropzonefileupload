using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropZoneFileUpload.Models
{
    public class AttachmentsModel
    {
        public long AttachmentID { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}