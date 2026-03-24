using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source image as RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // First pass: calculate default strokes automatically
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
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

            // Perform initial decomposition to populate default strokes
            using (MaskingResult _ = new ImageMasking(image).Decompose(options))
            {
                // No further action needed; default strokes are now stored in 'options'
            }

            // Add new foreground points (example points)
            options.Args = new AutoMaskingArgs
            {
                ObjectsPoints = new Point[][]
                {
                    new Point[] { new Point(100, 100), new Point(150, 100) }
                }
            };
            // Reuse previously calculated strokes
            options.CalculateDefaultStrokes = false;

            // Second pass: apply new points together with default strokes
            using (MaskingResult finalResult = new ImageMasking(image).Decompose(options))
            {
                // Retrieve the foreground segment (index 1)
                using (RasterImage foreground = (RasterImage)finalResult[1].GetImage())
                {
                    // Save the foreground as an animated PNG (APNG)
                    ApngOptions apngOptions = new ApngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };
                    foreground.Save(outputPath, apngOptions);
                }
            }
        }
    }
}