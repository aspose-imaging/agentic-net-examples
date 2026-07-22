using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
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

            // Load the image and apply emboss filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Create emboss filter options using the predefined kernel
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

                // Apply the filter to the whole image
                raster.Filter(raster.Bounds, embossOptions);

                // Save the result as PNG
                var saveOptions = new PngOptions();
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
 * 1. When a developer needs to add a classic emboss effect to user‑uploaded PNG files in a desktop .NET application, they can use this code to load, filter, and save the image with Aspose.Imaging.
 * 2. When a photo‑editing tool requires real‑time preview of a 3×3 emboss convolution filter on raster images, the snippet shows how to apply the filter to the entire bitmap and write the result back to disk.
 * 3. When an automated batch‑processing service must verify the existence of source images, create missing output folders, and apply a predefined emboss kernel before exporting PNG assets, this example provides the necessary file‑system checks and filter call.
 * 4. When a WPF application needs to demonstrate C# image‑processing operations such as loading an image, casting to RasterImage, and using Aspose.Imaging’s ConvolutionFilterOptions to achieve a raised‑relief look, the code illustrates the complete workflow.
 * 5. When a developer wants to ensure exception handling around image loading, filtering, and saving while working with PNG format and Aspose.Imaging’s PngOptions, the sample shows the try‑catch pattern for robust error reporting.
 */