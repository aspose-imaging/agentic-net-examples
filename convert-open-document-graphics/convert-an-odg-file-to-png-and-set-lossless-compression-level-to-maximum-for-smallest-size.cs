// HOW-TO: Convert ODG to PNG with Maximum Lossless Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.png");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to embed an OpenDocument graphic in a web page and require a small, lossless PNG file.
 * 2. When automating a batch conversion of ODG diagrams to PNG for inclusion in mobile apps where bandwidth is limited.
 * 3. When preserving the exact visual quality of a vector drawing while converting it to a raster format for PDF generation.
 * 4. When generating thumbnails of ODG files with maximum compression to store in a content‑management system.
 * 5. When integrating Aspose.Imaging into a C# service that converts user‑uploaded ODG files to PNG with the smallest possible file size.
 */
