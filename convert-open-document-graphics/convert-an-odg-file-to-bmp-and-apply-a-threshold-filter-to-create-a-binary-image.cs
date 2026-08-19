// HOW-TO: Convert ODG to BMP and Apply Otsu Threshold in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.odg";
        string outputBmpPath = @"C:\Images\sample.bmp";
        string outputBinaryPath = @"C:\Images\sample_binary.bmp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load ODG image and rasterize to BMP
            using (Image odgImage = Image.Load(inputPath))
            {
                var rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = odgImage.Size
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

                odgImage.Save(outputBmpPath, bmpOptions);
            }

            // Load the generated BMP, apply Otsu threshold to create binary image
            using (Image bmpImage = Image.Load(outputBmpPath))
            {
                var rasterImage = (RasterImage)bmpImage;
                rasterImage.BinarizeOtsu();

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputBinaryPath));

                rasterImage.Save(outputBinaryPath);
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
 * 1. When you need to turn vector‑based OpenDocument graphics (ODG) into a raster BMP for legacy Windows applications.
 * 2. When you must generate a high‑contrast black‑and‑white version of a BMP using Otsu’s automatic threshold for OCR preprocessing.
 * 3. When an automated pipeline has to convert design files to BMP and then binarize them for printing on monochrome devices.
 * 4. When you are building a C# service that extracts page content from ODG files and stores it as binary images for machine‑learning training.
 * 5. When you require a simple Aspose.Imaging solution to rasterize ODG pages and create binary BMPs without manually handling pixel data.
 */
