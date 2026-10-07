// HOW-TO: Auto Mask PNG With User Strokes And Preserve DPI In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                Point[][] userStrokes = new Point[][]
                {
                    new Point[]
                    {
                        new Point(10, 10),
                        new Point(200, 10),
                        new Point(200, 200),
                        new Point(10, 200)
                    }
                };

                var maskingOptions = new GraphCutMaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    FeatheringRadius = 3,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent,
                    Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = userStrokes
                    }
                };

                ImageMasking masking = new ImageMasking(raster);
                using (MaskingResult results = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        ResolutionSettings = new ResolutionSetting(raster.HorizontalResolution, raster.VerticalResolution)
                    };

                    foreground.Save(outputPath, saveOptions);
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
 * 1. When you need to isolate an object in a PNG using hand‑drawn strokes and keep the original image resolution for printing or further editing.
 * 2. When a web application must remove backgrounds from user‑uploaded PNGs while maintaining the same DPI to ensure consistent layout across devices.
 * 3. When generating product thumbnails that require precise auto‑masking based on designer‑provided points and need the output PNG to retain the source image’s pixel density.
 * 4. When integrating a C# service that processes scanned PNG documents, applies graph‑cut segmentation, and saves the result with a transparent background without altering the document’s resolution.
 * 5. When creating a batch tool that aligns the DPI of masked PNG assets with a target resolution to avoid scaling artifacts in downstream graphics pipelines.
 */
