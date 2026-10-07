// HOW-TO: Convert Base64 Image to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUA..."; // placeholder base64 string
            string outputPath = "output/output.jpg";

            byte[] imageBytes = Convert.FromBase64String(base64);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (Image image = Image.Load(ms))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    JpegOptions jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a canvas snapshot as a Base64 string from a web page and need to store it as a JPEG file on the server.
 * 2. When an API returns image data encoded in Base64 and you must convert it to a standard JPEG format for further processing or archiving.
 * 3. When you want to generate thumbnails from HTML5 Canvas output by decoding the Base64 data and saving it as a JPEG using Aspose.Imaging in a .NET application.
 * 4. When migrating legacy image storage that uses Base64 strings to a file‑system based JPEG repository without losing image quality.
 * 5. When building a C# service that ingests user‑uploaded Base64 images and saves them as JPEG files for compatibility with downstream image‑processing pipelines.
 */
