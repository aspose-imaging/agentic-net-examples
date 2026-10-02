// HOW-TO: Convert BMP Image to Lossless WebP in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "Input", "sample.bmp");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "sample.webp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (WebPOptions options = new WebPOptions())
                {
                    options.Lossless = true;
                    image.Save(outputPath, options);
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
 * 1. When you need to reduce the file size of legacy BMP graphics while preserving pixel‑perfect quality for web delivery, you can convert them to lossless WebP using C# and Aspose.Imaging.
 * 2. When building an automated pipeline that processes user‑uploaded BMP screenshots and stores them as WebP to save storage costs without sacrificing visual fidelity.
 * 3. When migrating a desktop application’s assets from BMP to a modern web‑friendly format, you can programmatically convert each image to lossless WebP in .NET.
 * 4. When creating a batch job that prepares images for responsive websites, converting BMP files to lossless WebP ensures fast loading times and smaller bandwidth usage.
 * 5. When integrating image conversion into a CI/CD workflow to validate that all BMP resources are correctly transformed to lossless WebP before deployment.
 */
