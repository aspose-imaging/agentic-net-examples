// HOW-TO: Batch Convert EPS Files to PNG with Double Size and Transparency in C# (Aspose.Imaging for .NET)
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

namespace EpsBatchConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "input";
                string outputDirectory = "output";

                // Get all EPS files in the input directory
                string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

                foreach (string inputPath in epsFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output path
                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load EPS image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Prepare PNG options with scaling factor of 2
                        var pngOptions = new PngOptions
                        {
                            // Preserve transparency by default; no extra settings needed
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageWidth = image.Width * 2,
                                PageHeight = image.Height * 2,
                                // Preserve background as transparent
                                BackgroundColor = Color.Transparent
                            }
                        };

                        // Save as PNG
                        image.Save(outputPath, pngOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate high‑resolution PNG thumbnails from a collection of EPS logos for a web catalog while keeping the transparent background.
 * 2. When automating the preparation of print‑ready artwork by scaling vector EPS drawings to twice their original size and exporting them as PNGs for preview in a .NET application.
 * 3. When migrating legacy EPS assets to PNG format for use in mobile apps, and you must preserve the alpha channel during batch processing in C#.
 * 4. When creating a batch pipeline that resizes vector illustrations for a digital signage system, requiring each EPS to be rasterized at double resolution with a transparent background.
 * 5. When integrating Aspose.Imaging into a CI/CD workflow to convert design files from EPS to PNG at build time, ensuring consistent scaling and transparency across all generated images.
 */
