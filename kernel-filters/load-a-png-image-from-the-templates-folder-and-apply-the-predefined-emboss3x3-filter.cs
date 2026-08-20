// HOW-TO: Apply Emboss3x3 Filter To PNG Image Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "templates/input.png";
        string outputPath = "output/embossed.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply the predefined Emboss3x3 convolution filter
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

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
 * 1. When you need to add a three‑dimensional embossed effect to a PNG graphic in a C# application, this code shows how to apply the built‑in Emboss3x3 convolution filter with Aspose.Imaging.
 * 2. When generating product catalogs, you can use this snippet to enhance product photos by embossing PNG thumbnails before embedding them in PDF or HTML pages.
 * 3. When building an automated image‑processing pipeline, the example demonstrates how to load PNG files, apply a predefined filter, and save the result without manual editing tools.
 * 4. When creating a custom UI theme, developers can emboss PNG icons programmatically to give a tactile look while keeping the original file size unchanged.
 * 5. When preparing assets for a game, this code lets you apply a fast emboss filter to PNG textures directly in C# so they can be uploaded to the game engine with the desired visual style.
 */
