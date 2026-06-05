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
            // Hard‑coded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PNG as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure auto‑masking options with default strokes
                AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource("tempMask.png")
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform the masking operation
                MaskingResult results = new ImageMasking(image).Decompose(options);

                // The foreground (masked object) is at index 1
                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    // Save the result as PNG with alpha channel
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Clean up the temporary file used by ExportOptions
                if (File.Exists("tempMask.png"))
                {
                    File.Delete("tempMask.png");
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
 * 1. When an e‑commerce platform needs to automatically remove the background from product PNG photos to create transparent images for catalog listings.
 * 2. When a mobile app generates custom stickers by extracting the foreground of user‑uploaded PNGs and saving them with an alpha channel for sharing.
 * 3. When a game developer prepares sprite assets by isolating characters from their original PNG backgrounds using graph‑cut segmentation before importing them into the engine.
 * 4. When a digital marketing tool batch‑processes PNG logos to create clean, transparent versions for overlaying on promotional videos.
 * 5. When a machine‑learning pipeline requires pre‑segmented PNG samples, using auto‑masking to separate objects from the background for training image classification models.
 */