using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\sample.BilateralSmoothingFilter.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply bilateral smoothing filter with kernel size 5
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce noise in a scanned PNG diagram while preserving sharp edges for a medical imaging web portal.
 * 2. When a C# application must preprocess user‑uploaded PNG avatars to smooth skin tones without blurring facial features before storing them in a cloud database.
 * 3. When an automated batch job processes PNG screenshots from UI tests, applying a bilateral smoothing filter of size 5 to improve visual consistency for reporting dashboards.
 * 4. When a photo‑editing tool built with Aspose.Imaging for .NET offers a “soft‑focus” effect on PNG files, using the BilateralSmoothingFilterOptions to maintain edge detail.
 * 5. When a developer integrates image preprocessing into a machine‑learning pipeline, applying bilateral smoothing to PNG training images to reduce sensor noise while keeping object boundaries intact.
 */