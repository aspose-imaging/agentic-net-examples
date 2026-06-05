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
            // Define input and output PNG files
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
                string outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir);

                // Temporary file used by ExportOptions
                string tempFile = Path.Combine(Path.GetTempPath(), $"mask_temp_{i}.png");

                // First masking pass – calculate default strokes
                AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = 3,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempFile, false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Perform initial decomposition to obtain default strokes
                    using (MaskingResult initialResult = new ImageMasking(image).Decompose(options))
                    {
                        // Initial result can be ignored; we only need the strokes
                    }

                    // Retrieve default strokes after first pass
                    Point[] backgroundStrokes = options.DefaultBackgroundStrokes;
                    Point[] foregroundStrokes = options.DefaultForegroundStrokes;
                    Rectangle[] objectRectangles = options.DefaultObjectsRectangles;

                    // Second masking pass – reuse strokes without recalculating
                    options.CalculateDefaultStrokes = false;
                    options.Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            backgroundStrokes,
                            foregroundStrokes
                        },
                        ObjectsRectangles = objectRectangles
                    };

                    using (MaskingResult finalResult = new ImageMasking(image).Decompose(options))
                    {
                        using (RasterImage resultImage = (RasterImage)finalResult[1].GetImage())
                        {
                            // Save the refined masked image
                            resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                        }
                    }
                }

                // Clean up temporary file
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}