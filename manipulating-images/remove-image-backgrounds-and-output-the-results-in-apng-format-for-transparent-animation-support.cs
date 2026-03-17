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
        // Input image path and output APNG path
        string inputPath = "input.jpg";
        string outputPath = "output.apng";

        // Load the source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Prepare export options for masking (in-memory source)
            var exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure auto masking options (GraphCut with default strokes)
            var maskingOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = exportOptions,
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform masking
            var masking = new ImageMasking(sourceImage);
            using (MaskingResult results = masking.Decompose(maskingOptions))
            {
                // Get the foreground (masked object) image
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    // Save the foreground as an animated PNG (APNG)
                    var apngSaveOptions = new ApngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    };
                    foreground.Save(outputPath, apngSaveOptions);
                }
            }
        }
    }
}