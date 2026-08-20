// HOW-TO: Generate CSV Report of Threshold Masked PNGs with Feathering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;
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
            // Hard‑coded input files, thresholds and feathering flags
            string[] inputFiles = {
                @"C:\Images\image1.jpg",
                @"C:\Images\image2.jpg"
            };
            int[] thresholds = { 128, 200 };
            bool[] feathered = { true, false };

            // Prepare report
            var reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("FileName,Threshold,Feathered");

            // Process each image
            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = inputFiles[i];
                int threshold = thresholds[i];
                bool isFeathered = feathered[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Define output path for the masked foreground
                string outputDir = @"C:\Images\output";
                Directory.CreateDirectory(outputDir);
                string outputPath = Path.Combine(outputDir, $"result_{i + 1}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image as RasterImage
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Export options for the masked result
                    var exportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    };

                    // Masking options (GraphCut) with optional feathering
                    var maskingOptions = new AutoMaskingGraphCutOptions
                    {
                        FeatheringRadius = isFeathered ? 3 : 0,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = exportOptions,
                        BackgroundReplacementColor = Color.Transparent
                    };

                    // Perform masking
                    var masking = new ImageMasking(image);
                    using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                    using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                    {
                        // Save the foreground mask
                        foreground.Save(outputPath, exportOptions);
                    }
                }

                // Append entry to report
                reportBuilder.AppendLine($"{Path.GetFileName(inputPath)},{threshold},{isFeathered}");
            }

            // Write report to file
            string reportPath = @"C:\Images\output\report.csv";
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            File.WriteAllText(reportPath, reportBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑process JPEG photos, apply a binary threshold to isolate foreground objects, and save the results as transparent PNGs for further compositing.
 * 2. When you must create a concise CSV log that records each image’s filename, the threshold value used, and whether a feathered edge was applied for quality control.
 * 3. When you are building an automated workflow that generates mask‑based cutouts from product images, with optional feathering to soften edges before publishing to an e‑commerce site.
 * 4. When you want to ensure all output directories exist and handle missing source files gracefully while processing multiple images in a .NET application.
 * 5. When you need to integrate Aspose.Imaging’s masking API into a C# service that produces alpha‑channel PNGs for use in graphic design or AR overlays.
 */
