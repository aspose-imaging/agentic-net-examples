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
            string inputPath = @"C:\Images\texture.tga";
            string outputPath = @"C:\Images\texture_sharpened.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply sharpen filter with kernel size 3 and sigma 1.0 (strength three)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 1.0));

                // Save as BMP using default BMP options
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
 * 1. When a game developer needs to enhance the visual clarity of a TGA texture before converting it to BMP for use in a Windows‑based texture viewer.
 * 2. When a CAD application pipeline requires sharpening of high‑resolution TGA renderings and exporting them as BMP files for legacy documentation tools.
 * 3. When an e‑learning platform processes TGA screenshots of 3‑D models, applies a strength‑three sharpen filter, and saves them as BMP to embed in course materials.
 * 4. When a medical imaging system converts TGA scans of tissue samples, sharpens details to improve diagnostic visibility, and stores the result as BMP for integration with Windows analysis software.
 * 5. When an automated asset‑management script batch‑processes TGA assets, applies a moderate sharpening effect, and outputs BMP files for quick preview generation in a .NET environment.
 */