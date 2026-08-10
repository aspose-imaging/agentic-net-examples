// HOW-TO: Restore Details in Blurred PNG Using Gauss Wiener Deconvolution C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\blurred.png";
            string outputPath = @"C:\Images\restored.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a Gauss-Wiener deconvolution filter (radius 5, sigma 4.0)
                // This filter helps restore details from a blurred image.
                var filterOptions = new GaussWienerFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image
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
 * 1. When a developer needs to sharpen a blurred PNG photo taken with a low‑quality camera by applying a Gauss‑Wiener deconvolution filter in a C# application.
 * 2. When an automated image‑processing pipeline must improve the readability of scanned documents that appear out of focus, using Aspose.Imaging to deblur PNG files.
 * 3. When a web service has to enhance user‑uploaded PNG screenshots that suffer from motion blur before storing them in a database.
 * 4. When a desktop utility program restores details in PNG textures for game assets that were unintentionally blurred during export.
 * 5. When a batch job processes a folder of blurred PNG images to prepare them for OCR or computer‑vision analysis by applying deconvolution in .NET.
 */
