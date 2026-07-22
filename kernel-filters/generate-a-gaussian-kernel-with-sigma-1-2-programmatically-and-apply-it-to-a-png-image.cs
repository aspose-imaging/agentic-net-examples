using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with kernel size 5 and sigma 1.2
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.2));

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
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
 * 1. When a developer needs to reduce noise in a PNG screenshot before OCR by applying a Gaussian blur with sigma 1.2 using Aspose.Imaging in C#.
 * 2. When a web application must automatically soften product photos stored as PNG files to improve visual appeal, the code can generate a Gaussian kernel and filter the images programmatically.
 * 3. When a desktop utility processes scanned documents in PNG format and requires a consistent blur effect for background smoothing, the GaussianBlurFilterOptions with sigma 1.2 provides a repeatable solution.
 * 4. When an automated build pipeline generates thumbnail PNGs and wants to apply a subtle blur to hide sensitive details, the C# raster filter applies the Gaussian kernel efficiently.
 * 5. When a game developer prepares sprite sheets in PNG format and needs to pre‑blur edges to prevent aliasing during scaling, the code creates the Gaussian kernel and saves the filtered image.
 */