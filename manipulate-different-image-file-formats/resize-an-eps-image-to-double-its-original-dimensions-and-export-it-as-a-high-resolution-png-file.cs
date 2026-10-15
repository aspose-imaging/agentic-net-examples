// HOW-TO: Resize EPS to Double Size and Save as High Resolution PNG in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        string inputPath = "input.eps";
        string outputPath = "output/output.png";

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
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight);

                var pngOptions = new PngOptions();
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
 * 1. When a designer provides an EPS logo that must be enlarged for a large‑format print poster, a developer can double its dimensions and export a high‑resolution PNG for the print workflow.
 * 2. When a web application needs to generate crisp PNG thumbnails from vector EPS files at twice the original size for retina displays, this code resizes and rasterizes the image automatically.
 * 3. When a publishing system converts EPS artwork into PNG assets for e‑books, doubling the size ensures the images remain sharp on high‑dpi e‑readers.
 * 4. When an automated build pipeline processes EPS diagrams and requires high‑resolution PNG versions for inclusion in documentation PDFs, the code provides the necessary scaling and format conversion.
 * 5. When a mobile app must display EPS‑based icons at larger sizes without loss of quality, developers can use this routine to resize the vector and save it as a PNG suitable for the app’s asset bundle.
 */
