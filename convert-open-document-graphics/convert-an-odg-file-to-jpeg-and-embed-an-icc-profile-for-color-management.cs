// HOW-TO: Convert ODG to JPEG in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions jpegOptions = new JpegOptions())
                {
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
 * 1. When you need to generate web‑ready JPEG thumbnails from OpenDocument graphics (ODG) files in a C# application.
 * 2. When automating batch conversion of ODG drawings to JPEG for archival or reporting purposes using Aspose.Imaging.
 * 3. When integrating ODG to JPEG conversion into a document‑management system that stores images as JPEG for faster preview loading.
 * 4. When creating a server‑side service that receives ODG uploads and returns JPEG images for mobile devices.
 * 5. When migrating legacy ODG assets to JPEG format to ensure compatibility with standard image viewers and browsers.
 */
