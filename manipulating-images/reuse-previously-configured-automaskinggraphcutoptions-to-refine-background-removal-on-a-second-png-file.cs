// HOW-TO: Reuse AutoMasking GraphCut Options for Background Removal on Another PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath1 = "input1.png";
        string outputPath1 = "output1.png";
        string inputPath2 = "input2.png";
        string outputPath2 = "output2.png";

        string tempMaskPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        try
        {
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1) ?? ".");

            AutoMaskingGraphCutOptions maskingOptions;
            using (RasterImage image1 = (RasterImage)Image.Load(inputPath1))
            {
                int featheringRadius = (Math.Max(image1.Width, image1.Height) / 500) + 1;

                maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = featheringRadius,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempMaskPath, false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                MaskingResult results1 = new ImageMasking(image1).Decompose(maskingOptions);
                using (RasterImage resultImage1 = (RasterImage)results1[1].GetImage())
                {
                    resultImage1.Save(outputPath1, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            maskingOptions.CalculateDefaultStrokes = false;

            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2) ?? ".");

            using (RasterImage image2 = (RasterImage)Image.Load(inputPath2))
            {
                MaskingResult results2 = new ImageMasking(image2).Decompose(maskingOptions);
                using (RasterImage resultImage2 = (RasterImage)results2[1].GetImage())
                {
                    resultImage2.Save(outputPath2, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            if (File.Exists(tempMaskPath))
            {
                File.Delete(tempMaskPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to apply the same graph‑cut masking settings to multiple PNG images to produce consistent transparent backgrounds.
 * 2. When you want to speed up batch background removal by reusing a previously generated AutoMaskingGraphCutOptions object instead of recalculating strokes for each file.
 * 3. When you are building a C# photo‑editing tool that must replace the background of a second image with transparency using the same feathering radius and segmentation method as the first image.
 * 4. When you need to generate a temporary mask file and then apply it to another picture without losing the original mask configuration.
 * 5. When you are automating product‑photo preparation and require identical background‑extraction parameters for a series of PNG files in a .NET application.
 */
