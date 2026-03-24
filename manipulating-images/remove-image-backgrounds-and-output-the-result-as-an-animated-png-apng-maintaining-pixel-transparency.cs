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

        // Load source image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure masking options for transparent background
            var maskingOptions = new AutoMaskingGraphCutOptions
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

            // Perform masking
            using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
            {
                // Get the foreground (object) image
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    // Save as animated PNG with transparency
                    foreground.Save(outputPath, new ApngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
            }
        }
    }
}