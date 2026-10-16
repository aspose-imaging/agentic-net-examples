// HOW-TO: Batch Convert CDR Files to JPG with Timestamped Filenames in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchCdrToJpg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\Input";
                string outputDirectory = @"C:\Output";

                // Get all CDR files in the input directory
                string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in cdrFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Build output file path with timestamp
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_{timestamp}.jpg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load CDR and save as JPG
                    using (Image image = Image.Load(inputPath))
                    {
                        var jpegOptions = new JpegOptions();
                        image.Save(outputPath, jpegOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to automatically convert a folder of CorelDRAW (.cdr) designs into web‑ready JPEG images for a website launch.
 * 2. When you must generate uniquely named JPEG copies of legacy CDR assets by appending a timestamp to avoid filename collisions during nightly builds.
 * 3. When a digital asset management system requires batch conversion of CDR drawings to JPG format while preserving the original file name for traceability.
 * 4. When an automated reporting tool has to export CDR diagrams as JPEG snapshots with a timestamp for audit logs.
 * 5. When a migration script moves old CDR artwork to a new platform and needs to create timestamped JPG previews for quick visual verification.
 */
