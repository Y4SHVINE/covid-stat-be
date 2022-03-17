using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidStat.Application.Interfaces;
using Microsoft.Extensions.FileProviders;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CovidStat.Application.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Statics"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public string UploadPhotoFile(string base64Str, string folder, string filename)
        {
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Statics", folder));

            base64Str = base64Str.Substring(base64Str.LastIndexOf(',') + 1);

            string storagePath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Statics", folder)).Root;
            string fullPath = Path.Combine(storagePath, filename);

            File.WriteAllBytes($"{fullPath}.png", Convert.FromBase64String(base64Str));

            List<int> widthHeight = new List<int>();
            widthHeight.Add(1500); widthHeight.Add(1500);

            using (Image image = Image.Load($"{fullPath}.png"))
            {
                image.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.Crop,
                        Position = AnchorPositionMode.Center,
                        Size = new Size(widthHeight[0], widthHeight[1])
                    }));
                image.SaveAsPng($"{fullPath}_crop.png");
            }

            return Path.Combine(folder, $"{filename}_crop.png");
        }

        public void DeleteFile(string path)
        {
            string storagePath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Statics")).Root;
            File.Delete(Path.Combine(storagePath, path));
            File.Delete(Path.Combine(storagePath, path.Replace("_crop", "")));
        }
    }
}
