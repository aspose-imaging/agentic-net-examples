using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
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

        while (true)
        {
            Console.Write("Enter feather radius (or press Enter to exit): ");
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                break;

            if (!int.TryParse(line, out int featherRadius) || featherRadius < 0)
            {
                Console.WriteLine("Invalid radius. Please enter a non‑negative integer.");
                continue;
            }

            // Temporary file for export options source
            string tempMaskPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");
            // Ensure temp directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(tempMaskPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var options = new GraphCutMaskingOptions
                {
                    FeatheringRadius = featherRadius,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempMaskPath, false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(options))
                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // Clean up temporary file
            if (File.Exists(tempMaskPath))
                File.Delete(tempMaskPath);

            Console.WriteLine($"Mask preview saved to {outputPath} with feather radius {featherRadius}.");
        }
    }
}