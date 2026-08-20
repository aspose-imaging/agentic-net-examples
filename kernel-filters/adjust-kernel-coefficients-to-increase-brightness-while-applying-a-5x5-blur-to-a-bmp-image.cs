// HOW-TO: Apply 5x5 Gaussian Blur and Increase Brightness of BMP in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Apply a 5x5 Gaussian blur (size=5, sigma=1.0)
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);

                // Increase brightness (value range -255 to 255)
                raster.AdjustBrightness(30);

                // Save the result as BMP using BmpOptions
                BmpOptions saveOptions = new BmpOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to soften a scanned BMP photograph and make it slightly brighter before embedding it in a report.
 * 2. When preprocessing BMP textures for a game engine to reduce harsh edges and improve visual consistency.
 * 3. When preparing BMP scans of documents for OCR by applying a blur to reduce noise and adjusting brightness for better contrast.
 * 4. When batch‑processing legacy BMP assets to create a uniform look across a UI by applying a 5x5 Gaussian blur and brightening them.
 * 5. When converting raw camera BMP captures into a more viewable form by smoothing details and lifting overall luminance using Aspose.Imaging in C#.
 */
