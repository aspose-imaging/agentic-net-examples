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
        try
        {
            // Hard‑coded input and output file paths
            string inputPath1 = "input1.png";
            string outputPath1 = "output\\output1.png";
            string inputPath2 = "input2.png";
            string outputPath2 = "output\\output2.png";

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

            // First masking operation – calculate default strokes
            Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions options;
            using (RasterImage image1 = (RasterImage)Image.Load(inputPath1))
            {
                options = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image1.Width, image1.Height) / 500) + 1,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult =
                       new Aspose.Imaging.Masking.ImageMasking(image1).Decompose(options))
                {
                    using (RasterImage resultImage = (RasterImage)maskingResult[1].GetImage())
                    {
                        resultImage.Save(outputPath1, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

            // Re‑use the same options for the second image (skip default stroke calculation)
            options.CalculateDefaultStrokes = false;

            using (RasterImage image2 = (RasterImage)Image.Load(inputPath2))
            {
                using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult2 =
                       new Aspose.Imaging.Masking.ImageMasking(image2).Decompose(options))
                {
                    using (RasterImage resultImage2 = (RasterImage)maskingResult2[1].GetImage())
                    {
                        resultImage2.Save(outputPath2, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}