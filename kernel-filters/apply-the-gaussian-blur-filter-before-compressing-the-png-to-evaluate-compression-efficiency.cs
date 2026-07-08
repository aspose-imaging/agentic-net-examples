using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.png";
            string outputPath = "C:\\temp\\sample_blurred_compressed.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (size 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Configure PNG compression options
                PngOptions pngOptions = new PngOptions
                {
                    CompressionLevel = 9,                                   // Max compression
                    FilterType = PngFilterType.Adaptive,                     // Best filter for compression
                    Progressive = true,                                      // Enable progressive loading
                    ColorType = PngColorType.TruecolorWithAlpha,             // Preserve alpha channel
                    BitDepth = 8                                             // Standard bit depth
                };

                // Save the processed image with the specified options
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to evaluate how applying a Gaussian blur filter to a PNG image influences the file size after saving with maximum compression (level 9) using Aspose.Imaging in C#.
 * 2. When creating web‑ready thumbnails that require a smooth blur effect before being saved as progressive, true‑color PNGs with adaptive filtering for optimal bandwidth usage.
 * 3. When testing the impact of image preprocessing on lossless PNG compression efficiency for a mobile application that must minimize data transfer.
 * 4. When preparing confidential medical or satellite images for secure transmission by obscuring details with a Gaussian blur while preserving alpha transparency in a true‑color PNG.
 * 5. When benchmarking Aspose.Imaging’s filter‑and‑save pipeline by applying a 5‑pixel Gaussian blur (sigma 4.0) and measuring the resulting PNG compression ratio in a C# automation script.
 */