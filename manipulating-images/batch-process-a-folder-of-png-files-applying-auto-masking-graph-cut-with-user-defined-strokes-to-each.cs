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
        try
        {
            // Hardcoded input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Process each PNG file in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.png");
            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_masked.png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Configure auto-masking with user-defined strokes
                    var maskingOptions = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = false,
                        FeatheringRadius = 3,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource("temp.png", false)
                        },
                        BackgroundReplacementColor = Color.Transparent,
                        Args = new AutoMaskingArgs
                        {
                            // Example user-defined strokes:
                            // First array = background points, second array = foreground points
                            ObjectsPoints = new Point[][]
                            {
                                new Point[] { new Point(10, 10), new Point(20, 20) }, // background strokes
                                new Point[] { new Point(30, 30) }                     // foreground strokes
                            }
                        }
                    };

                    // Perform masking
                    using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                    {
                        // Retrieve the foreground (masked) image
                        using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                        {
                            // Save the result as PNG with transparency
                            resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                        }
                    }
                }

                // Clean up temporary file used by ExportOptions
                if (File.Exists("temp.png"))
                {
                    File.Delete("temp.png");
                }

                Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}