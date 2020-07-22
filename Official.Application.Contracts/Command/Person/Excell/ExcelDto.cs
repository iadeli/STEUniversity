using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Command.Excell
{
    public class ExcelDto
    {
        public string fileName { get; set; }
        public string fileType { get; set; }
        public string fileExtention { get; set; }
        public int fileSize { get; set; }
        public byte[] fileData { get; set; }
        public int status { get; set; }
    }
}
