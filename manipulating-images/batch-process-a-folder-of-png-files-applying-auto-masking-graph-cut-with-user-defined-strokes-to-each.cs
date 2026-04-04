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
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = "Input";
        string outputDir = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Get all PNG files in the input directory
        string[] files = Directory.GetFiles(inputDir, "*.png");

        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileName + "_masked.png");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Define user‑defined strokes (example points)
                AutoMaskingArgs args = new AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        // Background points
                        new Point[] { new Point(10, 10), new Point(20, 10) },
                        // Foreground points
                        new Point[] { new Point(50, 50) }
                    }
                };

                // Configure auto‑masking options with Graph Cut
                AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = false,
                    FeatheringRadius = 3,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent,
                    Args = args
                };

                // Perform masking
                using (MaskingResult result = new ImageMasking(image).Decompose(options))
                using (RasterImage masked = (RasterImage)result[1].GetImage())
                {
                    // Save the masked foreground image
                    masked.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }
    }
}