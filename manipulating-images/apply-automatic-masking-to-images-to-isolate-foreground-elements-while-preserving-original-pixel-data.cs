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

        // Temporary file for export options
        string tempExportPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        // Load source image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure automatic GraphCut masking options
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
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
            using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
            {
                // Save the isolated foreground
                foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }

        // Clean up temporary export file
        if (File.Exists(tempExportPath))
        {
            File.Delete(tempExportPath);
        }
    }
}