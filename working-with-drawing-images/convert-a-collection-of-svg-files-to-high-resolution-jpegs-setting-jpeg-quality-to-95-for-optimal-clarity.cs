// HOW-TO: Batch Convert SVG Files to High-Resolution JPEGs with 95% Quality in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 95,
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };

                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = (image as SvgImage)?.Width ?? 800,
                        PageHeight = (image as SvgImage)?.Height ?? 600
                    };

                    jpegOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate print‑ready JPEG images from a folder of SVG logos while preserving sharpness at 300 dpi.
 * 2. When an e‑commerce platform requires bulk conversion of vector product illustrations to compressed JPEG thumbnails with consistent 95% quality.
 * 3. When a reporting tool must transform SVG charts into high‑resolution JPEGs for inclusion in PDF documents.
 * 4. When migrating legacy SVG assets to a JPEG‑based web gallery and you want to automate the process using C# and Aspose.Imaging.
 * 5. When a desktop application needs to rasterize multiple SVG icons into JPEG files with a white background and specific resolution settings.
 */
