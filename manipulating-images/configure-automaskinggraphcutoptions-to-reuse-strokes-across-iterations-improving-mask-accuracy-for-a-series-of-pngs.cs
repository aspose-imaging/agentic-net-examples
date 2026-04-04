using System;
using System.IO;
using System.Collections.Generic;
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
        string[] inputPaths = { "input1.png", "input2.png" };
        string[] outputPaths = { "output1.png", "output2.png" };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary file for ExportOptions.Source
            string tempPath = Path.Combine(Path.GetTempPath(), $"mask_temp_{i}.png");

            // First pass – calculate default strokes
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = 3,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempPath, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                using (MaskingResult firstResult = new ImageMasking(image).Decompose(options))
                {
                    // Retrieve the automatically calculated strokes
                    Point[] backgroundStrokes = options.DefaultBackgroundStrokes;
                    Point[] foregroundStrokes = options.DefaultForegroundStrokes;

                    // Second pass – reuse strokes for improved accuracy
                    options.CalculateDefaultStrokes = false;
                    options.Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            backgroundStrokes,
                            foregroundStrokes
                        }
                    };

                    // Re‑load the image for the second decomposition
                    using (RasterImage image2 = (RasterImage)Image.Load(inputPath))
                    {
                        using (MaskingResult secondResult = new ImageMasking(image2).Decompose(options))
                        {
                            using (RasterImage resultImage = (RasterImage)secondResult[1].GetImage())
                            {
                                // Save the final masked image
                                resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                            }
                        }
                    }
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
    }
}