using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStat.Application.Interfaces
{
    public interface IFileService : IDisposable
    {
        string UploadPhotoFile(string base64Str, string folder, string filename);
        void DeleteFile(string path);
    }
}
