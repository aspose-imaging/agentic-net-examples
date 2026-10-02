// HOW-TO: Segment Complex Image with Graph Cut Using AutoMasking in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = false,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Aspose.Imaging.Color.Transparent,
                    Args = new Aspose.Imaging.Masking.Options.AutoMaskingArgs
                    {
                        ObjectsPoints = new Aspose.Imaging.Point[][]
                        {
                            new Aspose.Imaging.Point[]
                            {
                                new Aspose.Imaging.Point(50, 50),
                                new Aspose.Imaging.Point(60, 60),
                                new Aspose.Imaging.Point(70, 70)
                            }
                        }
                    }
                };

                using (Aspose.Imaging.Masking.Result.MaskingResult results = new Aspose.Imaging.Masking.ImageMasking(image).Decompose(maskingOptions))
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a foreground object from a photo with irregular edges and save it as a transparent PNG in a .NET application.
 * 2. When you want to improve segmentation accuracy on a cluttered scene by providing custom foreground strokes to the graph‑cut algorithm.
 * 3. When you are building an image‑editing tool that replaces the background of JPEG images with transparency without manual masking.
 * 4. When you need to programmatically generate masks for product photos to isolate items for e‑commerce catalogs.
 * 5. When you are automating batch processing of complex images where default stroke detection is insufficient and you must define explicit points for object segmentation.
 */
