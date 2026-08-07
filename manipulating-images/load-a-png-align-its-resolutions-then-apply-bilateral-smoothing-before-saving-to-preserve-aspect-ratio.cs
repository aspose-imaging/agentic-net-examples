using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

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
                // Cast to PngImage to access resolution properties
                PngImage pngImage = (PngImage)image;

                // Align horizontal and vertical resolutions (e.g., set both to 96 DPI)
                pngImage.SetResolution(96.0, 96.0);

                // Cast to RasterImage for filtering operations
                RasterImage rasterImage = (RasterImage)pngImage;

                // Apply bilateral smoothing filter with a kernel size of 5
                var filterOptions = new BilateralSmoothingFilterOptions(5);
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
 * 1. When a developer needs to standardize the DPI of user‑uploaded PNG icons before displaying them in a Windows desktop application, they can load the PNG, set both horizontal and vertical resolutions to 96 DPI, apply bilateral smoothing to reduce noise, and save the result.
 * 2. When preparing PNG screenshots for inclusion in a PDF report, a developer can align the image resolution to match the document’s DPI, use bilateral smoothing to soften compression artifacts, and preserve the original aspect ratio during saving.
 * 3. When an e‑commerce site processes product photos in PNG format, a developer can ensure consistent print‑ready resolution, apply bilateral smoothing to smooth edges without blurring details, and output the cleaned image for catalog generation.
 * 4. When a medical imaging system receives PNG scans from various devices, a developer can normalize the resolution, apply bilateral smoothing to reduce high‑frequency noise while keeping anatomical structures sharp, and store the processed image for further analysis.
 * 5. When creating a batch job that optimizes PNG assets for a mobile game, a developer can load each image, set a uniform DPI, use bilateral smoothing to improve visual quality on small screens, and save the file while maintaining its original aspect ratio.
 */