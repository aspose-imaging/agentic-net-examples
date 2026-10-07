// HOW-TO: Convert BMP Image to JPEG with Quality 85 in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 85
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce the file size of a BMP screenshot for web upload while keeping the original resolution, you can use this code to save it as a JPEG with quality 85.
 * 2. When a legacy Windows application generates BMP assets that must be displayed in a mobile app, this snippet converts them to JPEG with controlled compression.
 * 3. When automating a batch process that archives scanned documents, you can convert each BMP page to a JPEG using Aspose.Imaging to balance quality and storage.
 * 4. When integrating image handling into a C# service that receives BMP uploads and must return JPEG thumbnails, this example shows how to preserve dimensions and set compression level.
 * 5. When migrating a digital asset library from BMP to a more web‑friendly format, the code provides a simple way to convert each file to JPEG with a specific quality setting.
 */
