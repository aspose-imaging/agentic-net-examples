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
            // Hard‑coded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";
            string tempMaskPath = "tempMask.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
            // Ensure temporary file directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(tempMaskPath) ?? string.Empty);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure AutoMaskingGraphCutOptions with a custom feathering radius
                AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = 5, // custom radius
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempMaskPath, false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking
                MaskingResult results = new ImageMasking(image).Decompose(options);

                // Retrieve the foreground image (index 1) and save it as PNG
                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // Clean up temporary mask file
            if (File.Exists(tempMaskPath))
            {
                File.Delete(tempMaskPath);
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
 * 1. When a developer needs to automatically remove the background from product photos stored as PNG files and export a transparent‑background image for an e‑commerce catalog, they can use AutoMaskingGraphCutOptions with a custom FeatheringRadius to achieve smooth edges.
 * 2. When building a web‑based avatar creator that lets users upload PNG portraits and requires precise foreground extraction for overlaying accessories, the code can apply GraphCut segmentation with a configurable feather radius to generate clean masks.
 * 3. When preparing UI icons for a mobile app where each icon must have a consistent transparent background and anti‑aliased edges, developers can employ the shown C# routine to mask the original PNG and export a TruecolorWithAlpha PNG.
 * 4. When automating the creation of composite marketing banners that combine product images with background graphics, the code enables batch processing of PNG assets to isolate foreground objects using the GraphCut method and custom feathering.
 * 5. When integrating an image‑processing pipeline that needs to generate temporary mask files for further analysis (e.g., color‑based segmentation or object detection), the example demonstrates how to export the mask as a separate PNG using Aspose.Imaging’s FileCreateSource.
 */