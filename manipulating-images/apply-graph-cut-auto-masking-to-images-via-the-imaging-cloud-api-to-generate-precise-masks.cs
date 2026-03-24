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
        string outputPath = "output.png";

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
            // Temporary file for export options source
            string tempExportPath = Path.GetTempFileName();

            // Configure AutoMaskingGraphCutOptions
            var options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempExportPath, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform masking
            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(options))
            {
                // Retrieve foreground image (index 1)
                using (RasterImage resultImage = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save result as PNG with proper options
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // Clean up temporary export file
            if (File.Exists(tempExportPath))
            {
                File.Delete(tempExportPath);
            }
        }
    }
}