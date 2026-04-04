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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary file for ExportOptions.Source
        string tempExportPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        // Load the source PNG as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure AutoMaskingGraphCutOptions with a custom feathering radius
            var options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = 5, // custom radius
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
            MaskingResult[] results = new ImageMasking(image).Decompose(options);

            // Retrieve the foreground image (index 1) and save it as PNG
            using (RasterImage resultImage = (RasterImage)results[1].GetImage())
            {
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