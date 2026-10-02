// HOW-TO: Convert JPEG to PNG and Save File Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.Source = new FileCreateSource(outputPath, false);
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
 * 1. When a web application needs to generate PNG thumbnails from user‑uploaded JPEG photos for consistent display across browsers.
 * 2. When a desktop utility must batch‑convert image assets from JPEG to lossless PNG before publishing them to a content management system.
 * 3. When an e‑commerce platform wants to store product images in PNG format to preserve transparency after processing JPEG uploads.
 * 4. When a reporting service creates PNG charts from JPEG sources to embed them in PDF documents generated with Aspose libraries.
 * 5. When a migration script moves legacy JPEG files to PNG to reduce compression artifacts and improve image quality for archival storage.
 */
