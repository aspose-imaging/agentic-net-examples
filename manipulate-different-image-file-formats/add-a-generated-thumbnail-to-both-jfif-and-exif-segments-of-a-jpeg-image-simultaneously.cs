using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            if (!jpegImage.IsCached)
                jpegImage.CacheData();

            using (MemoryStream ms = new MemoryStream())
            {
                jpegImage.Save(ms, new JpegOptions());
                ms.Position = 0;

                using (RasterImage thumbnail = (RasterImage)Image.Load(ms))
                {
                    thumbnail.Resize(100, 100);
                    jpegImage.ExifData.Thumbnail = thumbnail;

                    if (jpegImage.Jfif == null)
                        jpegImage.Jfif = new JFIFData();

                    jpegImage.Jfif.Thumbnail = thumbnail;

                    jpegImage.Save(outputPath);
                }
            }
        }
    }
}