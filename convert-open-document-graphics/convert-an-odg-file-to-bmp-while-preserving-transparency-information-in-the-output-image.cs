// HOW-TO: Convert ODG to 32‑Bit BMP With Alpha Channel In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)image)
                {
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 32 // Preserve alpha channel
                    };
                    raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to display OpenDocument graphics in a Windows application that only supports BMP files while keeping the original transparent areas.
 * 2. When exporting vector drawings from LibreOffice to a 32‑bit BMP for use in legacy reporting tools that require raster images with alpha channels.
 * 3. When automating batch conversion of ODG assets to BMP thumbnails for a game engine that reads BMP textures and respects transparency.
 * 4. When integrating Aspose.Imaging into a C# service that converts user‑uploaded ODG diagrams to BMP for email attachments without losing the overlay transparency.
 * 5. When preparing printable previews of ODG illustrations in a .NET workflow that saves them as BMP files while preserving semi‑transparent layers for accurate visual fidelity.
 */
