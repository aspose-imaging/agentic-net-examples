// HOW-TO: Preserve PNG Transparency While Applying Emboss3x3 Filter In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Emboss3x3 convolution filter while preserving alpha channel
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Prepare PNG save options to keep alpha channel
                PngOptions saveOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha
                };

                // Save the processed image
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
 * 1. When you need to add an emboss effect to a logo PNG without losing its transparent background.
 * 2. When generating thumbnails for a web app and must keep the original alpha channel after applying a convolution filter.
 * 3. When processing UI icons in a desktop application and want the emboss style while preserving click‑through transparency.
 * 4. When batch‑editing product images for an e‑commerce site, ensuring the emboss filter does not turn transparent areas opaque.
 * 5. When creating stylized overlays for a game UI and require the PNG’s alpha channel to remain intact after filtering.
 */
