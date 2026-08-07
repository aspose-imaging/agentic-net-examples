using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
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
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Prepare PNG save options to keep transparency
                PngOptions saveOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    FilterType = PngFilterType.Adaptive,
                    CompressionLevel = 9
                };

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
 * 1. When a web developer wants to add a subtle emboss effect to UI icons stored as PNG files while keeping their transparent backgrounds intact, they can use this Aspose.Imaging C# code.
 * 2. When a game asset pipeline requires batch processing of sprite sheets to apply a 3‑x‑3 emboss convolution without losing per‑pixel alpha information, the example demonstrates the needed steps.
 * 3. When an e‑commerce platform needs to generate watermarked product thumbnails with an embossed look while preserving the PNG’s alpha channel for overlay on different backgrounds, this code provides a reliable solution.
 * 4. When a mobile app designer wants to programmatically enhance PNG logos with an emboss filter in a .NET backend service and ensure the resulting images remain fully transparent where required, the snippet shows how to configure PngOptions accordingly.
 * 5. When an automated image‑processing workflow must convert transparent PNG graphics to a stylized embossed version for print‑ready PDFs, the code illustrates how to maintain truecolor with alpha during filtering and saving.
 */