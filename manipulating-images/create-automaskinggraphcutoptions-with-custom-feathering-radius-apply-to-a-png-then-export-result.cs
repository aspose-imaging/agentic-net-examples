// HOW-TO: Apply GraphCut Auto Masking with Feathering to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Temporary file for ExportOptions.Source
            string tempPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure AutoMaskingGraphCutOptions with custom feathering radius
                AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = 5, // custom radius
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempPath, false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking
                using (MaskingResult results = new ImageMasking(image).Decompose(options))
                {
                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        // Save the foreground result
                        resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
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
 * 1. When you need to automatically remove a solid background from a PNG image and replace it with transparency while preserving edge smoothness.
 * 2. When you want to generate a mask for a product photo using graph‑cut segmentation with a custom feathering radius to create soft edges.
 * 3. When you are building a batch processor that extracts foreground objects from PNG files and saves the results as PNGs with an alpha channel.
 * 4. When you require a C# solution to export a masked image to a temporary file before further processing or uploading.
 * 5. When you need to fine‑tune the segmentation algorithm’s feathering to avoid jagged borders in UI thumbnails.
 */
