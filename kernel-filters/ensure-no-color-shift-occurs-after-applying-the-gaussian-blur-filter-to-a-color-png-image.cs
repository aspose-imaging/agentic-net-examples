using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to gain access to the Filter method
                RasterImage rasterImage = (RasterImage)image;

                // Configure Gaussian blur filter (size = 5, sigma = 4.0)
                // IgnoreAlpha is left false (default) to preserve color information
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);

                // Apply the filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to apply a Gaussian blur to a color PNG image using Aspose.Imaging in C# while ensuring no color shift for a web banner.
 * 2. When an application must preprocess user‑uploaded PNG photos with a Gaussian blur filter in C# and preserve the original hue and saturation before saving them to storage.
 * 3. When a desktop tool generates soft‑focus thumbnails of PNG assets by applying a Gaussian blur via Aspose.Imaging without altering the image’s color palette.
 * 4. When a C# service masks sensitive areas of PNG screenshots with a Gaussian blur but must keep accurate color representation for compliance reporting.
 * 5. When an automated build pipeline adds a subtle blur effect to PNG icons using Aspose.Imaging’s GaussianBlurFilterOptions while preventing any color shift.
 */