using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
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
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur filter
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Apply Sharpen filter
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a developer needs to reduce noise in a high‑resolution PNG screenshot before enhancing edge details for a UI mockup, they can apply Gaussian blur followed by a sharpen filter using Aspose.Imaging in C#.
 * 2. When preparing product photos for an e‑commerce website, a developer can smooth out background artifacts in PNG files with a Gaussian blur and then restore crispness to the product edges by sharpening, all in a single C# routine.
 * 3. When generating thumbnails for a digital asset management system, a developer may first blur a PNG image to even out color variations and then sharpen it to maintain visual clarity at smaller sizes using Aspose.Imaging filters.
 * 4. When cleaning scanned PNG documents that contain speckles, a developer can use a Gaussian blur to suppress the speckles and a subsequent sharpen filter to keep text readability sharp in a C# processing pipeline.
 * 5. When creating stylized graphics for a game UI, a developer can apply a Gaussian blur to soften the PNG texture and then sharpen it to emphasize key features, ensuring the final asset looks polished after processing with Aspose.Imaging in .NET.
 */