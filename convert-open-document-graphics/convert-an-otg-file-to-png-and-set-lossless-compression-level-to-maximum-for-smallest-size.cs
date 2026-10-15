// HOW-TO: Convert OTG to PNG with Maximum Lossless Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.PngCompressionLevel = PngCompressionLevel.ZipLevel9;
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

/*
 * Real-World Use Cases:
 * 1. When you need to shrink vector‑based OTG graphics for web pages while keeping them losslessly encoded as PNG.
 * 2. When a batch conversion tool must read OTG files and output PNGs with the smallest possible file size for mobile apps.
 * 3. When integrating Aspose.Imaging into a C# service that archives design assets by converting them to PNG with maximum zip compression.
 * 4. When preparing print‑ready artwork stored as OTG for distribution as PNG files without quality loss and with optimal compression.
 * 5. When automating a workflow that validates the existence of OTG files, creates output folders, and saves the images as highly compressed PNGs using .NET.
 */
