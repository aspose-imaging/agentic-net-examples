// HOW-TO: Convert ODG to BMP with Transparency Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP options (default Bitfields compression supports transparency)
                BmpOptions bmpOptions = new BmpOptions
                {
                    Compression = BitmapCompression.Bitfields
                };

                // Set rasterization options to preserve transparency
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as BMP
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
 * 1. When you need to display OpenDocument graphics in a Windows application that only supports BMP files while keeping the original transparent background.
 * 2. When you are batch‑processing ODG illustrations for a legacy system that requires BMP images with alpha channel support.
 * 3. When you want to generate thumbnails of ODG drawings for a web gallery and need the thumbnails saved as BMP with transparent areas preserved.
 * 4. When you are migrating design assets from LibreOffice to a game engine that imports BMP textures and must retain transparency.
 * 5. When you need to programmatically convert ODG vector diagrams to BMP for printing workflows that require a raster format but still need the background to remain invisible.
 */
