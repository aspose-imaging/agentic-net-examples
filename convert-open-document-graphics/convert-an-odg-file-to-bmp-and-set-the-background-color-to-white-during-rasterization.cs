// HOW-TO: Convert ODG to BMP with White Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.odg";
        string outputPath = "output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with a white background
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Set up BMP save options and attach rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as BMP
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a bitmap preview of an OpenDocument graphic for legacy Windows applications that only accept BMP files.
 * 2. When you must embed an ODG illustration into a PDF report that requires a white background to match the document’s page color.
 * 3. When you are creating thumbnails of ODG drawings for a web gallery and need the images saved as BMP with a consistent white canvas.
 * 4. When you are converting user‑uploaded ODG files to BMP for batch processing in a C# image‑processing pipeline that expects raster images.
 * 5. When you need to rasterize vector ODG artwork with a solid white background before performing pixel‑level analysis in .NET.
 */
