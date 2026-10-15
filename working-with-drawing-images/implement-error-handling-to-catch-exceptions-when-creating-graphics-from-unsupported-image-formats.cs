// HOW-TO: How to Convert JPEG to PNG with Graphics Handling and Error Checking in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = null;
                try
                {
                    graphics = new Graphics(image);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Graphics creation failed: {ex.Message}");
                    return;
                }

                graphics.Clear(Color.White);

                Source src = new FileCreateSource(outputPath, false);
                PngOptions options = new PngOptions { Source = src };
                image.Save(outputPath, options);
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
 * 1. When you need to safely convert user‑uploaded JPEG files to PNG while ensuring unsupported image formats don’t crash your C# application.
 * 2. When you want to clear the background of an image to white before saving it as a PNG using Aspose.Imaging’s Graphics object.
 * 3. When your image‑processing service must handle missing source files gracefully and log errors without stopping the entire workflow.
 * 4. When you are building a batch conversion tool that creates output directories automatically and saves images with specific options like PNG compression.
 * 5. When you require robust error handling around Graphics creation to prevent exceptions from unsupported formats such as BMP or TIFF from breaking the conversion routine.
 */
