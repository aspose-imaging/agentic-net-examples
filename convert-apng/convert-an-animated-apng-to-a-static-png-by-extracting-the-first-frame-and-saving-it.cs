// HOW-TO: Extract First Frame From Animated APNG and Save As PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\animation.apng";
        string outputPath = "Output\\firstframe.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var apngImage = image as Aspose.Imaging.FileFormats.Apng.ApngImage;
                if (apngImage == null)
                {
                    Console.Error.WriteLine("Input file is not an APNG image.");
                    return;
                }

                if (apngImage.PageCount == 0)
                {
                    Console.Error.WriteLine("APNG contains no frames.");
                    return;
                }

                var firstFrame = (Aspose.Imaging.FileFormats.Apng.ApngFrame)apngImage.Pages[0];
                firstFrame.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a thumbnail for an animated PNG by using its first frame as a static PNG preview in a C# web application.
 * 2. When you want to extract the initial frame of an APNG to use as a fallback image for browsers that do not support animation.
 * 3. When you are creating a PDF or report that requires a non‑animated PNG representation of an APNG asset and need to programmatically save the first frame.
 * 4. When you need to compare the first frame of multiple APNG files for quality control by converting each to a static PNG with Aspose.Imaging in C#.
 * 5. When you are building a content‑management system that stores only a single preview image for each animated PNG and must extract and save that preview automatically.
 */
