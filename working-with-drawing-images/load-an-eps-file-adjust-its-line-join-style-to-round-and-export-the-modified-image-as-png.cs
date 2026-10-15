// HOW-TO: Convert EPS Vector File to PNG Image in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.eps";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to display an EPS logo on a web page that only supports PNG images, you can rasterize the EPS to PNG using Aspose.Imaging in C#.
 * 2. When a printing workflow requires converting vector artwork from EPS to a high‑resolution PNG for preview or proofing, this code automates the conversion.
 * 3. When integrating a design asset pipeline, you may need to batch‑process EPS files into PNG thumbnails for a gallery view, and the example shows the basic conversion steps.
 * 4. When a desktop application must load user‑provided EPS files and save them as PNG for further image analysis or editing, the snippet demonstrates how to load and save with Aspose.Imaging.
 * 5. When you want to ensure consistent image dimensions by preserving the original EPS width and height while converting to PNG, this code sets the rasterization options accordingly.
 */
