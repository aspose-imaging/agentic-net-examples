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
    static void Main(string[] args)
    {
        // Input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.apng";

        // Load the source image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // First pass: auto masking with default strokes
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform the first decomposition
            using (MaskingResult firstResult = new ImageMasking(sourceImage).Decompose(options))
            {
                // Obtain the foreground image (object)
                using (RasterImage foreground = (RasterImage)firstResult[1].GetImage())
                {
                    // Second pass: reuse options, add new points, skip default stroke calculation
                    options.CalculateDefaultStrokes = false;
                    options.Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            new Point[] { new Point(50, 50) } // example additional point
                        }
                    };

                    // Reload the source image for the second pass
                    using (RasterImage sourceForSecondPass = (RasterImage)Image.Load(inputPath))
                    {
                        using (MaskingResult secondResult = new ImageMasking(sourceForSecondPass).Decompose(options))
                        {
                            using (RasterImage finalForeground = (RasterImage)secondResult[1].GetImage())
                            {
                                // Save the final result as an animated PNG (APNG)
                                finalForeground.Save(outputPath, new ApngOptions
                                {
                                    ColorType = PngColorType.TruecolorWithAlpha,
                                    DefaultFrameTime = 200,
                                    NumPlays = 0 // infinite loop
                                });
                            }
                        }
                    }
                }
            }
        }
    }
}