// HOW-TO: Convert PNG to JPEG with Aspose.Imaging in C# and Dispose Image (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.png");
            string outputPath = Path.Combine("Output", "sample_converted.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.Save(outputPath, new JpegOptions());
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
 * 1. When you need to batch‑convert user‑uploaded PNG screenshots to JPEG for web‑friendly delivery while ensuring the image object is properly disposed.
 * 2. When an automated report generator must transform high‑resolution PNG charts into smaller JPEG files to reduce email attachment size.
 * 3. When a desktop application processes scanned PNG documents and saves them as JPEGs to save disk space without leaking unmanaged resources.
 * 4. When a cloud service ingests PNG assets and stores them as JPEG thumbnails, using Aspose.Imaging to manage memory efficiently.
 * 5. When migrating legacy PNG assets to JPEG format in a C# migration script, you must release the image handle after saving to avoid file‑lock issues.
 */
