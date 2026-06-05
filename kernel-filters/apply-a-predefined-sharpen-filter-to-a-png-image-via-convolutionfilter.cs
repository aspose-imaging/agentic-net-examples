using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.png";

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

                // Apply Sharpen filter with kernel size 5 and sigma 4.0
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the filtered image
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
 * 1. When a developer needs to enhance the details of a scanned PNG document before OCR by applying a sharpen filter with a 5‑pixel kernel and sigma 4.0.
 * 2. When an e‑commerce platform wants to automatically improve product photo clarity by sharpening PNG images during upload using Aspose.Imaging’s ConvolutionFilter.
 * 3. When a desktop application processes user‑generated PNG screenshots and requires a quick C# routine to sharpen edges for better visual inspection.
 * 4. When a batch image‑processing service must ensure consistent sharpness across PNG assets by programmatically loading, filtering, and saving them with Aspose.Imaging.
 * 5. When a game developer prepares PNG texture atlases and needs to apply a predefined sharpen filter to enhance texture details before packaging.
 */