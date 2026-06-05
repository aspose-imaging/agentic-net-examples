using System;
using System.IO;
using System.Linq;
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
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // ---------- First pass: automatic GraphCut masking ----------
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var autoOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult autoResult = new ImageMasking(image).Decompose(autoOptions))
                {
                    // Retrieve automatically calculated strokes
                    Point[] backgroundStrokes = autoOptions.DefaultBackgroundStrokes;
                    Point[] foregroundStrokes = autoOptions.DefaultForegroundStrokes;

                    // ---------- Manual correction: add extra points ----------
                    // Example additional points (adjust as needed)
                    var extraBackgroundPoints = new[] { new Point(50, 50), new Point(60, 60) };
                    var extraForegroundPoints = new[] { new Point(200, 200), new Point(210, 210) };

                    Point[] correctedBackground = backgroundStrokes.Concat(extraBackgroundPoints).ToArray();
                    Point[] correctedForeground = foregroundStrokes.Concat(extraForegroundPoints).ToArray();

                    // ---------- Second pass: GraphCut with combined points ----------
                    var manualOptions = new GraphCutMaskingOptions
                    {
                        FeatheringRadius = 3,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new StreamSource(new MemoryStream())
                        },
                        BackgroundReplacementColor = Color.Transparent,
                        Args = new AutoMaskingArgs
                        {
                            ObjectsPoints = new Point[][]
                            {
                                correctedBackground, // background points
                                correctedForeground  // foreground points
                            }
                        }
                    };

                    using (RasterImage image2 = (RasterImage)Image.Load(inputPath))
                    using (MaskingResult finalResult = new ImageMasking(image2).Decompose(manualOptions))
                    using (RasterImage finalImage = (RasterImage)finalResult[1].GetImage())
                    {
                        // Save the final masked image
                        finalImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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