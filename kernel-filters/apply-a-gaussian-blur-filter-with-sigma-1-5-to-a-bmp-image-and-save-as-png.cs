using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.bmp";
        string outputPath = @"c:\temp\output.png";

        try
        {
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
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 1.5 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 1.5));

                // Save the result as PNG
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to soften the edges of a scanned BMP document before converting it to a PNG for web display, they can apply a Gaussian blur with sigma 1.5 using Aspose.Imaging.
 * 2. When an application must generate a blurred thumbnail from a high‑resolution BMP file and save it as a PNG for faster loading, this code provides the required image filtering and format conversion.
 * 3. When a batch‑processing tool has to reduce visual noise in legacy BMP assets while preserving transparency by exporting them as PNG, the Gaussian blur filter with sigma 1.5 can be applied programmatically.
 * 4. When a photo‑editing plugin for a .NET desktop app wants to add a subtle soft‑focus effect to user‑uploaded BMP images before storing them as PNG files, the shown code accomplishes that.
 * 5. When an automated reporting system needs to anonymize sensitive details in BMP screenshots by blurring them slightly and then saving the result as a PNG for inclusion in PDF reports, this approach is appropriate.
 */