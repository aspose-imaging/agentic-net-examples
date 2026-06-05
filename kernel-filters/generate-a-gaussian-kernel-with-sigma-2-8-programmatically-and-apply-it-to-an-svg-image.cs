using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to enable filtering
                RasterImage rasterImage = (RasterImage)image;

                // Generate Gaussian kernel size (odd) and sigma 2.8
                // Here we use size 5 (odd) which is suitable for sigma 2.8
                int kernelSize = 5;
                double sigma = 2.8;

                // Apply Gaussian blur filter using the generated parameters
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(kernelSize, sigma));

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
 * 1. When a developer needs to convert an SVG vector graphic to a PNG raster image while applying a Gaussian blur with sigma 2.8 to soften edges for web thumbnails.
 * 2. When a C# application must preprocess SVG icons by blurring them to create a subtle background effect before embedding them in a PDF report.
 * 3. When an automated build pipeline generates blurred PNG previews of SVG diagrams for faster loading in documentation portals.
 * 4. When a desktop tool programmatically applies a Gaussian blur to SVG logos to produce stylized watermarked images for marketing materials.
 * 5. When a developer wants to ensure consistent image filtering by generating a 5×5 Gaussian kernel with sigma 2.8 and applying it to SVG assets during batch image processing.
 */