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
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";
        // Temporary file for masking export options
        string tempExportPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        // Load the source image as RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure masking options (GraphCut with automatic strokes)
            var maskingOptions = new Aspose.Imaging.Masking.Options.GraphCutMaskingOptions
            {
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                BackgroundReplacementColor = Aspose.Imaging.Color.Transparent,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempExportPath, false)
                }
            };

            // Perform masking
            var masking = new Aspose.Imaging.Masking.ImageMasking(sourceImage);
            using (Aspose.Imaging.Masking.Result.MaskingResult results = masking.Decompose(maskingOptions))
            {
                // Get the foreground (masked) image
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    // Create APNG image with a single frame (the foreground)
                    var apngCreateOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ColorType = PngColorType.TruecolorWithAlpha,
                        DefaultFrameTime = 200 // milliseconds per frame
                    };

                    using (Aspose.Imaging.FileFormats.Apng.ApngImage apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Create(
                        apngCreateOptions,
                        foreground.Width,
                        foreground.Height))
                    {
                        apng.RemoveAllFrames();
                        apng.AddFrame(foreground);
                        apng.Save();
                    }
                }
            }
        }

        // Clean up temporary export file
        if (File.Exists(tempExportPath))
        {
            File.Delete(tempExportPath);
        }
    }
}