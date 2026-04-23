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
        try
        {
            // Hard‑coded input and output paths
            string inputPath1 = "input1.png";
            string outputPath1 = "output1.png";
            string inputPath2 = "input2.png";
            string outputPath2 = "output2.png";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

            // First masking – configure options and process the first image
            AutoMaskingGraphCutOptions options;
            using (RasterImage image1 = (RasterImage)Image.Load(inputPath1))
            {
                options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image1.Width, image1.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult result = new ImageMasking(image1).Decompose(options))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Save(outputPath1, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // Re‑use the same options for the second image (skip default stroke calculation)
            options.CalculateDefaultStrokes = false;
            using (RasterImage image2 = (RasterImage)Image.Load(inputPath2))
            {
                using (MaskingResult result = new ImageMasking(image2).Decompose(options))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Save(outputPath2, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}