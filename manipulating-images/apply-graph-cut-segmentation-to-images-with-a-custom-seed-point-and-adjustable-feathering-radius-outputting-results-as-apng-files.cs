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
    static void Main(string[] args)
    {
        // Input image path
        string inputPath = "input.jpg";
        // Output APNG path
        string outputPath = "output.apng";

        // Adjustable feathering radius
        int featheringRadius = 5;

        // Custom seed point for foreground (example coordinates)
        int seedX = 150;
        int seedY = 120;

        // Prepare masking arguments with a foreground seed point.
        // First array = background points (empty), second array = foreground points.
        AutoMaskingArgs maskingArgs = new AutoMaskingArgs
        {
            ObjectsPoints = new Point[][]
            {
                new Point[] { },                     // No background points
                new Point[] { new Point(seedX, seedY) } // Foreground seed point
            }
        };

        // Export options for intermediate PNG (used by the masking engine)
        PngOptions pngExport = new PngOptions
        {
            ColorType = PngColorType.TruecolorWithAlpha,
            Source = new StreamSource(new MemoryStream())
        };

        // Configure GraphCut masking options
        GraphCutMaskingOptions maskingOptions = new GraphCutMaskingOptions
        {
            FeatheringRadius = featheringRadius,
            Method = SegmentationMethod.GraphCut,
            Decompose = false,
            ExportOptions = pngExport,
            BackgroundReplacementColor = Color.Transparent,
            Args = maskingArgs
        };

        // Load the source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Perform graph cut segmentation
            using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                // Retrieve the foreground (object) image
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the result as an animated PNG (APNG)
                    foreground.Save(outputPath, new ApngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        DefaultFrameTime = 200, // milliseconds per frame
                        NumPlays = 0            // 0 = infinite loop
                    });
                }
            }
        }
    }
}