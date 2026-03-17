using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "foreground.png";

        // Load the source image as a RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure automatic GraphCut masking options
            var maskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform the masking operation
            var imageMasking = new Aspose.Imaging.Masking.ImageMasking(sourceImage);
            using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult = imageMasking.Decompose(maskingOptions))
            {
                // Retrieve the foreground image (index 1)
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the isolated foreground with transparent background
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }
    }
}