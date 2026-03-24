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
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Seed point for segmentation and feathering radius (configurable)
        int seedX = 100;
        int seedY = 100;
        int featherRadius = 5;

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure GraphCut masking options
            var options = new GraphCutMaskingOptions
            {
                FeatheringRadius = featherRadius,
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
                        new Point[] { new Point(seedX, seedY) }
                    }
                }
            };

            // Perform segmentation
            using (MaskingResult results = new ImageMasking(image).Decompose(options))
            {
                // Retrieve the foreground (masked object) image
                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    // Save the result as PNG
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }
    }
}