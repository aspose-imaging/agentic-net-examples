using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter with strength three (kernel size 3, sigma 1.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 1.0));

                // Save the result as BMP
                rasterImage.Save(outputPath, new BmpOptions());
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
 * 1. When a game developer needs to enhance the details of a TGA texture before converting it to BMP for use in a Windows desktop application.
 * 2. When a graphics pipeline requires sharpening of high‑resolution TGA assets with a strength‑three filter before exporting them to BMP for legacy hardware compatibility.
 * 3. When an e‑learning platform processes uploaded TGA screenshots, applies a moderate sharpen filter, and saves them as BMP files for consistent rendering across browsers.
 * 4. When a CAD software plugin converts TGA renderings into BMP format while improving edge definition using a three‑level sharpen filter.
 * 5. When an automated build script prepares game assets by loading TGA files, applying a strength‑three sharpen filter, and outputting BMP files for texture atlases.
 */