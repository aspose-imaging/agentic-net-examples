// HOW-TO: Batch Convert JPEGs to Progressive JPEGs in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

namespace ImageProcessingApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputFolder = @"C:\Images\Input";
                string outputFolder = @"C:\Images\Output";

                // Get all JPEG files in the input folder
                string[] jpegFiles = Directory.GetFiles(inputFolder, "*.jpg");
                string[] jpegFilesUpper = Directory.GetFiles(inputFolder, "*.jpeg");
                string[] allFiles = new string[jpegFiles.Length + jpegFilesUpper.Length];
                jpegFiles.CopyTo(allFiles, 0);
                jpegFilesUpper.CopyTo(allFiles, jpegFiles.Length);

                foreach (string inputPath in allFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Prepare output path
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileName + "_progressive.jpg");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load JPEG image
                    using (JpegImage image = (JpegImage)Image.Load(inputPath))
                    {
                        // Set progressive compression options
                        JpegOptions options = new JpegOptions
                        {
                            CompressionType = JpegCompressionMode.Progressive
                        };

                        // Save image with progressive compression
                        image.Save(outputPath, options);
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
 * 1. When you need to reduce page load times by serving progressive JPEGs for a web gallery.
 * 2. When you want to automatically re‑encode a batch of uploaded photos into progressive format before storing them in a CDN.
 * 3. When you are preparing image assets for email newsletters that require progressive JPEGs to display gradually as they download.
 * 4. When you need to standardize a legacy collection of .jpg files by converting them to progressive JPEGs for better compatibility with modern browsers.
 * 5. When you are building a desktop tool that processes user‑selected folders and saves optimized progressive JPEGs to a separate output directory.
 */
