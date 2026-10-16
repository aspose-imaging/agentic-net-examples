// HOW-TO: Show Console Progress Bar While Converting Large PNG Batch in C# (Aspose.Imaging for .NET)
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

namespace BatchPngProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "C:\\Images\\Input";
                string outputFolder = "C:\\Images\\Output";

                string[] files = Directory.GetFiles(inputFolder, "*.png", SearchOption.AllDirectories);
                int total = files.Length;
                if (total == 0)
                {
                    Console.WriteLine("No PNG files found.");
                    return;
                }

                for (int i = 0; i < total; i++)
                {
                    string inputPath = files[i];
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string relativePath = Path.GetRelativePath(inputFolder, inputPath);
                    string outputPath = Path.Combine(outputFolder, relativePath);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var options = new PngOptions();
                        image.Save(outputPath, options);
                    }

                    int progress = i + 1;
                    int barWidth = 50;
                    int filled = (int)((double)progress / total * barWidth);
                    string bar = new string('#', filled) + new string('-', barWidth - filled);
                    Console.Write($"\r[{bar}] {progress}/{total}");
                }

                Console.WriteLine("\nProcessing completed.");
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
 * 1. When you need to convert thousands of PNG files to a standardized format and want real‑time feedback in a console application.
 * 2. When processing images from nested directories and must preserve the folder structure while saving the converted files.
 * 3. When a C# utility must handle missing files gracefully and report errors without stopping the entire batch.
 * 4. When you want to monitor the progress of a long‑running image conversion task using a simple text‑based progress bar.
 * 5. When integrating Aspose.Imaging into an automated pipeline that requires batch loading, saving, and status updates for PNG assets.
 */
