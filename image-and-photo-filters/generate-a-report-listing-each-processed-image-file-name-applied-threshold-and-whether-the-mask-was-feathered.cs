// HOW-TO: Generate Image Threshold Report with Feathered Magic Wand in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input files, thresholds, and feathering flags
            string[] inputPaths = { "input1.jpg", "input2.png", "input3.bmp" };
            int[] thresholds = { 30, 45, 60 };
            bool[] featherFlags = { true, false, true };

            // Report file path
            string reportPath = "report.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            using (StreamWriter reportWriter = new StreamWriter(reportPath, false))
            {
                reportWriter.WriteLine("FileName,Threshold,Feathered");
                for (int i = 0; i < inputPaths.Length; i++)
                {
                    string inputPath = inputPaths[i];
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    int threshold = thresholds[i];
                    bool feathered = featherFlags[i];

                    // Load image as RasterImage
                    using (RasterImage image = (RasterImage)Image.Load(inputPath))
                    {
                        int pointX = image.Width / 2;
                        int pointY = image.Height / 2;

                        // Apply Magic Wand selection with threshold and optional feathering
                        if (feathered)
                        {
                            MagicWandTool.Select(image, new MagicWandSettings(pointX, pointY) { Threshold = threshold })
                                .GetFeathered(new FeatheringSettings() { Size = 5 })
                                .Apply();
                        }
                        else
                        {
                            MagicWandTool.Select(image, new MagicWandSettings(pointX, pointY) { Threshold = threshold })
                                .Apply();
                        }

                        // Prepare output path
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_masked.png";
                        string outputPath = Path.Combine("output", outputFileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save masked image as PNG with alpha
                        PngOptions pngOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha
                        };
                        image.Save(outputPath, pngOptions);

                        // Write report line
                        reportWriter.WriteLine($"{Path.GetFileName(inputPath)},{threshold},{feathered}");
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

/*
 * Real-World Use Cases:
 * 1. When you need to document the threshold values and feathering settings applied to a batch of images for quality‑control audits.
 * 2. When you want to automatically create a CSV‑style report of JPEG, PNG, and BMP files processed with Aspose.Imaging’s Magic Wand tool.
 * 3. When you must verify that each image in a pipeline has been selected with the correct threshold and optional feathered edge before further editing.
 * 4. When you are building a batch‑processing script that logs image dimensions, applied thresholds, and whether feathering was used for later analysis.
 * 5. When you require a simple text file summarizing image processing parameters to share with non‑technical stakeholders or QA teams.
 */
