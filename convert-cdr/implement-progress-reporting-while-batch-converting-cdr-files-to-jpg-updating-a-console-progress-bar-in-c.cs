// HOW-TO: Batch Convert CDR Files to JPG with Console Progress Bar in C# (Aspose.Imaging for .NET)
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
                string inputDirectory = @"C:\InputCdr";
                string outputDirectory = @"C:\OutputJpg";

                // Get all CDR files in the input directory
                string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr", SearchOption.TopDirectoryOnly);
                int totalFiles = cdrFiles.Length;
                if (totalFiles == 0)
                {
                    Console.WriteLine("No CDR files found to process.");
                    return;
                }

                for (int i = 0; i < totalFiles; i++)
                {
                    string inputPath = cdrFiles[i];
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load CDR and save as JPG
                    using (Image image = Image.Load(inputPath))
                    {
                        var jpegOptions = new JpegOptions();
                        image.Save(outputPath, jpegOptions);
                    }

                    // Update progress bar
                    int progress = (i + 1) * 100 / totalFiles;
                    int barWidth = 50;
                    int filled = progress * barWidth / 100;
                    string bar = new string('#', filled) + new string('-', barWidth - filled);
                    Console.Write($"\rProgress: [{bar}] {progress}%");
                }

                // Move to next line after completion
                Console.WriteLine();
                Console.WriteLine("Batch conversion completed.");
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
 * 1. When you need to automatically convert a large collection of CorelDRAW (.cdr) drawings to JPEG images for web publishing.
 * 2. When you want to monitor conversion status in a console application while processing many files.
 * 3. When you must ensure the output folder is created on the fly during batch image conversion.
 * 4. When you require a simple progress bar to give users visual feedback during long‑running image transformations.
 * 5. When you are building a .NET tool that integrates Aspose.Imaging to handle CDR to JPG conversion without manual intervention.
 */
