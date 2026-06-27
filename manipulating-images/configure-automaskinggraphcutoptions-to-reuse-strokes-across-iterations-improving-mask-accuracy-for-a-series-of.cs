using System;
using System.IO;
using System.Collections.Generic;
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
            string[] inputFiles = {
                "image1.png",
                "image2.png",
                "image3.png"
            };

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(
                    Path.GetDirectoryName(inputPath) ?? string.Empty,
                    Path.GetFileNameWithoutExtension(inputPath) + "_masked.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = true,
                        FeatheringRadius = 3,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new StreamSource(new MemoryStream())
                        },
                        BackgroundReplacementColor = Color.Transparent
                    };

                    using (MaskingResult results = new ImageMasking(image).Decompose(options))
                    using (RasterImage foreground = (RasterImage)results[1].GetImage())
                    {
                        foreground.Save(outputPath, new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(outputPath, false)
                        });
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
 * 1. When an e‑commerce platform needs to automatically remove product backgrounds from dozens of PNG photos in a single batch, developers can use this code to apply GraphCut auto‑masking with reusable strokes for consistent edge precision.
 * 2. When a game studio prepares sprite sheets where each character PNG must have a clean transparent background, the AutoMaskingGraphCutOptions configuration lets developers iterate over the images while preserving stroke data to improve mask accuracy across frames.
 * 3. When a marketing team wants to generate web‑ready PNG banners with smooth feathered edges around logos, developers can run this C# routine to batch‑process the files, using the GraphCut method and a 3‑pixel feathering radius for professional‑grade cutouts.
 * 4. When a document‑digitization workflow must extract foreground illustrations from scanned PNG pages and replace the background with transparency, the code reuses calculated strokes to maintain detail while processing multiple pages efficiently.
 * 5. When a social‑media automation tool needs to create transparent PNG stickers from user‑uploaded images, developers can employ this AutoMaskingGraphCutOptions setup to quickly mask each image in a loop, ensuring consistent results without manually redefining strokes for each file.
 */