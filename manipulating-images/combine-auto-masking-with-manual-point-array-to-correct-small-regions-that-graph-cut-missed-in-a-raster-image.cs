// HOW-TO: Refine Graph Cut Auto-Mask With Manual Points In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                var autoOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(source.Width, source.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult autoResult = new ImageMasking(source).Decompose(autoOptions))
                using (RasterImage autoForeground = (RasterImage)autoResult[1].GetImage())
                {
                    var points = new List<Point>
                    {
                        new Point(30, 30),
                        new Point(100, 100)
                    };

                    using (RasterImage manualCopy = (RasterImage)Image.Load(inputPath))
                    {
                        foreach (var pt in points)
                        {
                            MagicWandTool.Select(manualCopy, new MagicWandSettings(pt.X, pt.Y)).Apply();
                        }

                        autoForeground.Blend(new Point(0, 0), manualCopy, 255);
                    }

                    autoForeground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to automatically remove a background from a PNG photograph but must manually fix small leftover areas that the Graph Cut algorithm missed.
 * 2. When you want to generate a transparent PNG foreground by combining Aspose.Imaging’s auto‑masking with a custom list of points to fine‑tune the mask.
 * 3. When processing product images for e‑commerce, you can use this code to quickly separate items from complex backgrounds and manually correct edge artifacts.
 * 4. When preparing assets for a game engine, the technique lets you create clean alpha‑masked sprites while manually adjusting tiny regions that were incorrectly segmented.
 * 5. When building a batch image‑processing tool, you can apply auto‑masking to each file and supply point coordinates to ensure precise foreground extraction for downstream AI analysis.
 */
