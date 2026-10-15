// HOW-TO: Batch Convert BMP Images to Lossless WebP in C# (Aspose.Imaging for .NET)
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

namespace BatchBmpToWebp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputImages";
                string outputDirectory = @"C:\OutputImages";

                // Get all BMP files in the input directory
                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                foreach (string bmpFilePath in bmpFiles)
                {
                    // Validate input file existence
                    if (!File.Exists(bmpFilePath))
                    {
                        Console.Error.WriteLine($"File not found: {bmpFilePath}");
                        return;
                    }

                    // Determine output file path with .webp extension
                    string outputFilePath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(bmpFilePath) + ".webp");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                    // Load BMP image and save as WebP with lossless compression
                    using (Image image = Image.Load(bmpFilePath))
                    {
                        WebPOptions options = new WebPOptions
                        {
                            Lossless = true
                        };
                        image.Save(outputFilePath, options);
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
 * 1. When you need to shrink a large collection of legacy BMP assets for a web site while preserving pixel‑perfect quality, you can batch convert them to lossless WebP using C# and Aspose.Imaging.
 * 2. When automating a build pipeline that generates thumbnails from BMP source files, converting them to WebP reduces file size without visual loss, speeding up page loads.
 * 3. When migrating a desktop application’s image resources from BMP to a modern web‑friendly format, this code lets you process an entire folder in one run.
 * 4. When preparing images for a mobile app that only supports WebP, you can quickly convert all BMP files on a server to lossless WebP before deployment.
 * 5. When archiving design assets and you want to keep the original detail while minimizing storage, batch converting BMPs to lossless WebP with C# provides efficient compression.
 */
