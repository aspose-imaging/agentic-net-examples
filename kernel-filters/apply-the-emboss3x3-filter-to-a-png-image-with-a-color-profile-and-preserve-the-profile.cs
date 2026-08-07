using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Apply Emboss3x3 filter
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Save with metadata preservation
                PngOptions pngOptions = new PngOptions
                {
                    KeepMetadata = true
                };

                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to add a subtle 3×3 emboss effect to product photos stored as PNG files while keeping the embedded ICC color profile for accurate color reproduction.
 * 2. When an e‑commerce platform wants to generate stylized thumbnail images with an emboss filter and must preserve the original PNG metadata for SEO and compliance.
 * 3. When a digital publishing workflow requires batch processing of PNG illustrations to apply a texture‑like emboss effect without stripping the embedded color profile needed for print.
 * 4. When a mobile app backend processes user‑uploaded PNG avatars, applying the Emboss3x3 filter for visual flair while retaining the profile information for consistent display across devices.
 * 5. When a scientific imaging tool converts raw PNG scans into embossed visualizations for reports, ensuring the original color calibration data remains intact.
 */