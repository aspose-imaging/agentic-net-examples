using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input\\image.jpg";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // First pass – calculate default strokes
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

                using (MaskingResult firstResult = new ImageMasking(image).Decompose(options))
                {
                    // Retrieve automatically calculated strokes
                    Point[] backgroundStrokes = options.DefaultBackgroundStrokes;
                    Point[] foregroundStrokes = options.DefaultForegroundStrokes;

                    // Second pass – use explicit foreground/background strokes
                    options.CalculateDefaultStrokes = false;
                    options.Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            backgroundStrokes,   // background points
                            foregroundStrokes    // foreground points
                        }
                    };

                    using (MaskingResult secondResult = new ImageMasking(image).Decompose(options))
                    {
                        // Save the foreground (masked object) image
                        using (RasterImage finalImage = (RasterImage)secondResult[1].GetImage())
                        {
                            finalImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                        }
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