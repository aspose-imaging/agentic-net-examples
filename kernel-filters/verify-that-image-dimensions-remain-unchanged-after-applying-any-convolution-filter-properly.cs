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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load image as RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Store original dimensions
                int originalWidth = raster.Width;
                int originalHeight = raster.Height;

                // Apply a convolution filter (Sharpen)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Verify dimensions remain unchanged
                if (raster.Width == originalWidth && raster.Height == originalHeight)
                {
                    Console.WriteLine("Dimensions unchanged after applying the filter.");
                }
                else
                {
                    Console.WriteLine($"Dimensions changed: original {originalWidth}x{originalHeight}, after {raster.Width}x{raster.Height}");
                }

                // Save the filtered image
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to sharpen a PNG image without altering its original width and height, they can use this code to apply a convolution Sharpen filter and verify dimensions stay the same.
 * 2. When building an automated image‑processing pipeline that must preserve layout constraints, the code ensures that applying any Aspose.Imaging convolution filter (e.g., Sharpen) does not resize the raster image.
 * 3. When validating that a batch job which reads, filters, and saves images keeps the original resolution for downstream GIS or printing workflows, this example demonstrates the dimension check after filtering.
 * 4. When creating a C# utility that accepts user‑provided PNG files, applies a custom filter, and writes the result to a specific folder while guaranteeing the output file matches the input dimensions, the code provides the necessary logic.
 * 5. When troubleshooting a bug where applying Aspose.Imaging image filters unexpectedly changes image size, this snippet can be used to reproduce the issue and confirm that dimensions remain unchanged after the filter operation.
 */