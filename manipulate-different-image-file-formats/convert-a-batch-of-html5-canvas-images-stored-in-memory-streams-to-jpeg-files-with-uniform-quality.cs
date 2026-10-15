// HOW-TO: Batch Convert Canvas Images to JPEG with Fixed Quality in C# (Aspose.Imaging for .NET)
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

namespace Html5CanvasToJpegBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputFolder = @"C:\InputCanvasImages";
                string outputFolder = @"C:\OutputJpegImages";

                // Ensure the output base directory exists
                Directory.CreateDirectory(outputFolder);

                // Get all files in the input folder
                string[] inputFiles = Directory.GetFiles(inputFolder);

                foreach (string inputPath in inputFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Build output path with .jpg extension
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load image from file stream
                    using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                    {
                        using (Image image = Image.Load(fs))
                        {
                            // Set uniform JPEG quality
                            JpegOptions jpegOptions = new JpegOptions
                            {
                                Quality = 90
                            };

                            // Save as JPEG
                            image.Save(outputPath, jpegOptions);
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to export a collection of HTML5 Canvas drawings saved as files into JPEGs for web publishing while maintaining a consistent compression quality.
 * 2. When an automated server task must read canvas image streams, convert them to JPEG, and store them in a separate folder for downstream reporting.
 * 3. When a desktop utility has to process user‑generated canvas screenshots in bulk, applying a uniform 90 % JPEG quality to reduce file size without manual editing.
 * 4. When migrating legacy canvas assets to a standardized image format for a content‑management system, ensuring each output JPEG uses the same quality setting.
 * 5. When integrating Aspose.Imaging into a C# pipeline that reads image streams, converts them to JPEG, and saves them to a network share for archival purposes.
 */
