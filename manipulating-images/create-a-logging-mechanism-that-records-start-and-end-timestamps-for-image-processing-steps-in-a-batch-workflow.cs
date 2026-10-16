// HOW-TO: Log Start and End Timestamps for Batch Image Conversion to PNG in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Console.WriteLine($"Processing started: {inputPath} at {DateTime.Now:O}");

                using (Image image = Image.Load(inputPath))
                {
                    using (PngOptions options = new PngOptions())
                    {
                        image.Save(outputPath, options);
                    }
                }

                Console.WriteLine($"Processing finished: {inputPath} at {DateTime.Now:O}");
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
 * 1. When you need to audit how long each file takes to convert from various formats to PNG in an automated batch job.
 * 2. When you want to generate a processing log for compliance, recording exact timestamps for each image loaded and saved in a .NET service.
 * 3. When you are building a command‑line tool that processes thousands of images and need to track start and finish times for troubleshooting performance bottlenecks.
 * 4. When you integrate Aspose.Imaging into a CI pipeline and require timestamped logs to verify that image conversion steps complete within expected windows.
 * 5. When you create a scheduled Windows service that converts user‑uploaded pictures to PNG and need a simple console log to monitor processing duration for each file.
 */
