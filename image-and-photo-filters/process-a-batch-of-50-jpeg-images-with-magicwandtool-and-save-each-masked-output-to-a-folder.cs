// HOW-TO: Batch Apply Magic Wand Mask to JPEGs and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputFolder = "InputImages";
            string outputFolder = "OutputImages";

            Directory.CreateDirectory(outputFolder);

            string[] files = Directory.GetFiles(inputFolder, "*.jpg");
            int count = 0;
            foreach (string inputPath in files)
            {
                if (count >= 50) break;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + "_masked.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool.Select(image, new MagicWandSettings(10, 10)).Apply();

                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    };
                    image.Save(outputPath, pngOptions);
                }

                count++;
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
 * 1. When you need to automatically remove backgrounds from a large set of JPEG photos and store the results as PNG files with transparency for web publishing.
 * 2. When you want to preprocess product images for an e‑commerce catalog by applying Aspose.Imaging’s MagicWandTool and exporting them as PNGs with an alpha channel.
 * 3. When you are building a batch image‑processing pipeline that limits the operation to the first 50 files to control memory usage.
 * 4. When you require a C# solution that creates a separate output folder and preserves original filenames with a “_masked” suffix for easy identification.
 * 5. When you need to integrate Aspose.Imaging into a Windows service that processes incoming JPEG uploads and generates masked PNG thumbnails for downstream applications.
 */
