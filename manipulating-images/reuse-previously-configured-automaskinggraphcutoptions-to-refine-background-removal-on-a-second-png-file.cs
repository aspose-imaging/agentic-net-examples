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
        // Hard‑coded input and output file paths
        string inputPath1 = "input1.png";
        string inputPath2 = "input2.png";
        string outputPath1 = "output1.png";
        string outputPath2 = "output2.png";

        // Verify that the input files exist
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath1) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath2) ?? ".");

        // Temporary file used by ExportOptions.Source
        string tempFile = Path.GetTempFileName();

        // First image – create and configure AutoMaskingGraphCutOptions
        using (RasterImage image1 = (RasterImage)Image.Load(inputPath1))
        {
            var options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image1.Width, image1.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempFile, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform masking on the first image
            using (MaskingResult results1 = new ImageMasking(image1).Decompose(options))
            {
                using (RasterImage resultImage1 = (RasterImage)results1[1].GetImage())
                {
                    resultImage1.Save(outputPath1, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // Re‑use the same options for the second image (skip default stroke calculation)
            options.CalculateDefaultStrokes = false;

            // Second image – apply the same options
            using (RasterImage image2 = (RasterImage)Image.Load(inputPath2))
            {
                using (MaskingResult results2 = new ImageMasking(image2).Decompose(options))
                {
                    using (RasterImage resultImage2 = (RasterImage)results2[1].GetImage())
                    {
                        resultImage2.Save(outputPath2, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }
        }

        // Clean up the temporary file used for ExportOptions.Source
        if (File.Exists(tempFile))
        {
            File.Delete(tempFile);
        }
    }
}