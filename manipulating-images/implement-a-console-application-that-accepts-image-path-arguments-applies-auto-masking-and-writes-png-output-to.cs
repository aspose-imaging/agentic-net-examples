// HOW-TO: Auto Mask Background From Image And Save As PNG In C# (Aspose.Imaging for .NET)
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
        // Hardcoded input image and output folder
        string inputPath = "input.jpg";
        string outputFolder = "output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputPath = Path.Combine(outputFolder, "masked.png");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load source image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Auto-masking arguments (default strokes)
                var autoArgs = new AutoMaskingArgs();

                // Export options for PNG with transparency
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = autoArgs,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Perform masking
                var masking = new ImageMasking(image);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                {
                    // Get the foreground (masked object) image
                    using (RasterImage foreground = (RasterImage)result[1].GetImage())
                    {
                        // Save the masked image as PNG
                        foreground.Save(outputPath, exportOptions);
                    }
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
 * 1. When you need to automatically remove the background from photos and generate transparent PNGs for e‑commerce product listings.
 * 2. When you want to integrate a lightweight C# console tool that processes user‑provided image paths and outputs masked images without manual editing.
 * 3. When you are building a batch pipeline that extracts foreground objects from JPEGs using GraphCut segmentation for later compositing in design software.
 * 4. When you require a programmatic way to replace the original background with transparency and save the result in a specific output folder for web publishing.
 * 5. When you need to automate image preparation for machine‑learning datasets by creating PNG masks that isolate objects from varied source images.
 */
