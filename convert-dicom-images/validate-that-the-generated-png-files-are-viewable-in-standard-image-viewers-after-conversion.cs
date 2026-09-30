// HOW-TO: Convert JPEG to PNG and Verify Viewability in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
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
                    PngOptions options = new PngOptions();
                    image.Save(outputPath, options);
                }

                using (Image png = Image.Load(outputPath))
                {
                    Console.WriteLine("PNG file is viewable.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate PNG thumbnails from user‑uploaded JPEG photos and ensure the files open correctly in browsers.
 * 2. When a batch processing script must convert legacy JPEG assets to lossless PNG format for archival while confirming each output is not corrupted.
 * 3. When an e‑commerce platform requires PNG images for product listings and wants to automatically test that the conversion succeeded before publishing.
 * 4. When a desktop utility transforms scanned JPEG documents into PNG for OCR preprocessing and needs to validate the resulting file can be displayed.
 * 5. When a mobile app backend prepares PNG assets from JPEG sources for cross‑platform compatibility and must verify the images are viewable by standard image viewers.
 */
