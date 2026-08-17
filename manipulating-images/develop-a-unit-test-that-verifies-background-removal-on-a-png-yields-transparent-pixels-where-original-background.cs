// HOW-TO: How To Unit Test PNG Background Removal To Transparent Pixels In C# (Aspose.Imaging for .NET)
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

            // Load the source PNG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure export options for PNG with alpha channel
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Set up masking options to remove background (transparent)
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Perform masking
                var masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                    {
                        // Save the foreground with transparent background
                        foreground.Save(outputPath, exportOptions);
                    }
                }
            }

            // Verify that the resulting image contains transparent pixels
            using (RasterImage resultImage = (RasterImage)Image.Load(outputPath))
            {
                int width = resultImage.Width;
                int height = resultImage.Height;
                var rect = new Rectangle(0, 0, width, height);
                int[] pixels = resultImage.LoadArgb32Pixels(rect);
                bool hasTransparent = false;
                foreach (int argb in pixels)
                {
                    int alpha = (argb >> 24) & 0xFF;
                    if (alpha == 0)
                    {
                        hasTransparent = true;
                        break;
                    }
                }

                if (hasTransparent)
                {
                    Console.WriteLine("Test passed: transparent pixels detected.");
                }
                else
                {
                    Console.Error.WriteLine("Test failed: no transparent pixels found.");
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
 * 1. When you need to ensure that an automated background‑removal process correctly creates transparent areas in PNG files before publishing them on a website.
 * 2. When building a CI pipeline that validates image preprocessing steps, such as converting product photos to transparent PNGs for e‑commerce catalogs.
 * 3. When creating a library that offers background‑masking features and you want a regression test to catch any changes that break the alpha channel output.
 * 4. When integrating Aspose.Imaging into a desktop application that lets users edit images and you must verify that the “remove background” button produces the expected transparent pixels.
 * 5. When developing a batch‑processing tool that prepares PNG assets for game development and you need an automated test to confirm that the masking algorithm preserves transparency.
 */
