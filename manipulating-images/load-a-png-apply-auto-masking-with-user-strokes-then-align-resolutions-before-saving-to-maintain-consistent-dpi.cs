// HOW-TO: Auto Mask PNG With User Strokes And Preserve DPI In C# (Aspose.Imaging for .NET)
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

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PNG as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // User‑defined strokes for auto‑masking (background then foreground points)
                AutoMaskingArgs maskArgs = new AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        new Point[] { new Point(50, 50), new Point(60, 50) },   // background points
                        new Point[] { new Point(120, 120), new Point(130, 130) } // foreground points
                    }
                };

                // Export options for the masking operation (in‑memory PNG)
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure auto‑masking with GraphCut and the user strokes
                AutoMaskingGraphCutOptions maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = false, // use provided strokes only
                    FeatheringRadius = 3,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = exportOptions,
                    BackgroundReplacementColor = Color.Transparent,
                    Args = maskArgs
                };

                // Perform the masking operation
                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                {
                    // The foreground (object) is at index 1
                    using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                    {
                        // Align DPI: make vertical resolution equal to horizontal resolution of the original
                        foreground.HorizontalResolution = image.HorizontalResolution;
                        foreground.VerticalResolution = image.HorizontalResolution;

                        // Save the masked foreground as PNG
                        foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to remove a background from a PNG image based on manually drawn points and keep the original image resolution for printing or UI display.
 * 2. When you want to generate a transparent PNG mask using Aspose.Imaging’s GraphCut algorithm after a user selects foreground and background strokes in a C# application.
 * 3. When you must ensure that a processed PNG retains the same DPI as the source file so that layout dimensions remain consistent across devices.
 * 4. When building an automated image‑preparation pipeline that extracts objects from photos and saves the result as a high‑quality PNG with alpha channel in .NET.
 * 5. When integrating user‑guided image segmentation into a desktop tool and need to export the masked image without altering its size or metadata.
 */
