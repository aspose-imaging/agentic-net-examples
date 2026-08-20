// HOW-TO: Apply Emboss3x3 Filter to PNG While Preserving Color Profile in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Preserve metadata (including color profile)
                PngOptions saveOptions = new PngOptions
                {
                    KeepMetadata = true
                };

                // Apply Emboss3x3 filter
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    raster.Filter(
                        raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                }

                // Save the processed image
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to add a subtle 3‑D emboss effect to product photos stored as PNGs without losing their embedded ICC color profile.
 * 2. When generating web‑ready thumbnails that require an artistic emboss filter while keeping original color accuracy for brand consistency.
 * 3. When processing scanned documents in PNG format and you want to enhance edge details with an emboss filter without stripping metadata needed for downstream workflows.
 * 4. When building a C# batch‑processing tool that applies the Emboss3x3 convolution to a collection of PNG images while preserving all metadata for archival purposes.
 * 5. When integrating Aspose.Imaging into a .NET application to create stylized PNG assets for UI themes, ensuring the embedded color profile remains intact after filtering.
 */
