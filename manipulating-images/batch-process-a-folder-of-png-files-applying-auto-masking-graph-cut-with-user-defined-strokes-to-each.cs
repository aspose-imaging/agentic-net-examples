// HOW-TO: Batch Auto-Mask PNG Images with Graph Cut Strokes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
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
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Validate output directory
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_masked.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
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
                            Source = new StreamSource(new MemoryStream())
                        },
                        BackgroundReplacementColor = Color.Transparent,
                        Args = new AutoMaskingArgs
                        {
                            // First array = background points, second = foreground points
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
                        // Retrieve the foreground (masked) image (index 1)
                        using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                        {
                            // Save the result as PNG with transparency
                            resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                        }
                    }
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

/*
 * Real-World Use Cases:
 * 1. When you need to automatically remove backgrounds from a large collection of PNG photos by applying user‑drawn strokes, this code batch‑processes them with Aspose.Imaging’s Graph Cut auto‑masking.
 * 2. When preparing product images for an e‑commerce site, you can use this script to generate masked PNGs for all items in a folder without manually editing each file.
 * 3. When building a desktop application that lets users outline foreground objects once and then apply the same masking logic to dozens of PNG assets, this example shows the required C# workflow.
 * 4. When migrating legacy PNG assets to a transparent‑background format, the code automates the creation of masked versions using Aspose.Imaging’s masking engine.
 * 5. When integrating image preprocessing into a CI/CD pipeline, you can run this batch routine to ensure every PNG in the repository is auto‑masked before deployment.
 */
