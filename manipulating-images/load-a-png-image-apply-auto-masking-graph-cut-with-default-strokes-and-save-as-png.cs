// HOW-TO: Auto Mask PNG Image Using Graph Cut In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

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

            // Load the PNG image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure auto‑masking Graph Cut options with default strokes
                var options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource("tempFile", false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking
                var results = new ImageMasking(image).Decompose(options);

                // Retrieve the foreground (masked) image and save it as PNG
                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Clean up temporary file created by ExportOptions
                if (File.Exists("tempFile"))
                {
                    File.Delete("tempFile");
                }
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
 * 1. When you need to automatically remove the background from a PNG photograph for e‑commerce product listings.
 * 2. When you want to isolate the foreground of a scanned PNG logo to create a transparent version for branding assets.
 * 3. When you are building a C# batch‑processing tool that extracts subjects from PNG screenshots for UI testing.
 * 4. When you require a quick way to generate PNG images with transparent backgrounds for game sprites without manually drawing masks.
 * 5. When you are integrating image preprocessing in a .NET application that must separate foreground objects from PNG files before applying further analysis.
 */
