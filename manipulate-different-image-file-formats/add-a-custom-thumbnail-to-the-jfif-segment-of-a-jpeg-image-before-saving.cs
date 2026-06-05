using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string thumbnailPath = "thumb.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage thumbImage = (RasterImage)Image.Load(thumbnailPath))
            {
                using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
                {
                    jpegImage.Jfif = new JFIFData();
                    jpegImage.Jfif.Thumbnail = thumbImage;
                    jpegImage.Save(outputPath);
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
 * 1. When a photo‑sharing website wants to embed a low‑resolution preview in the JPEG’s JFIF segment so mobile browsers can display a thumbnail without downloading the full image.
 * 2. When a digital asset management system needs to attach a custom thumbnail to each JPEG file for faster indexing and visual search in C# applications.
 * 3. When an e‑commerce platform generates product images and wants to store a brand‑specific thumbnail inside the JPEG for use in email newsletters and catalog PDFs.
 * 4. When a desktop publishing tool creates JPEGs from scanned documents and embeds a user‑selected thumbnail to improve preview rendering in Windows Explorer.
 * 5. When a mobile app developer prepares JPEGs for offline galleries and adds a custom thumbnail to the JFIF segment to reduce memory usage during thumbnail loading.
 */