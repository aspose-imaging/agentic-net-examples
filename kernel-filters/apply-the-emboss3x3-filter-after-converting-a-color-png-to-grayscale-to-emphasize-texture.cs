// HOW-TO: Apply Emboss3x3 Filter to Grayscale PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.png";
            string outputPath = "Output/sample_embossed.png";

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
                // Cast to RasterImage for pixel operations
                RasterImage raster = (RasterImage)image;

                // Convert to grayscale
                raster.Grayscale();

                // Apply Emboss3x3 convolution filter
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                raster.Filter(raster.Bounds, embossOptions);

                // Save the result as PNG
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
 * 1. When you need to highlight surface texture in a PNG by converting it to grayscale and applying an emboss effect for a stylized visual in a .NET application.
 * 2. When preparing product photos for a catalog where a subtle 3‑D relief is required, using Aspose.Imaging to grayscale the image and add an Emboss3x3 filter in C#.
 * 3. When generating game assets that need a hand‑drawn embossed look, you can convert color PNG sprites to grayscale and apply the Emboss3x3 convolution filter programmatically.
 * 4. When creating printable brochures and want to emphasize fine details of a grayscale diagram, the code lets you apply a texture‑enhancing emboss filter before saving the PNG.
 * 5. When automating batch processing of images to produce artistic black‑and‑white versions with highlighted edges, this C# routine uses Aspose.Imaging to grayscale and emboss each PNG file.
 */
