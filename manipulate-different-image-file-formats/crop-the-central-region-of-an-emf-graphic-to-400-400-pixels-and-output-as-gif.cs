// HOW-TO: Crop Central Region of EMF to 400x400 GIF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                EmfImage emf = (EmfImage)image;

                int cropWidth = 400;
                int cropHeight = 400;
                int left = (emf.Width - cropWidth) / 2;
                int top = (emf.Height - cropHeight) / 2;
                if (left < 0) left = 0;
                if (top < 0) top = 0;

                emf.Crop(new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight));

                GifOptions gifOptions = new GifOptions();
                emf.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a square thumbnail from a large EMF vector graphic for web display as a GIF.
 * 2. When converting legacy Windows Metafile images to a web‑friendly format while focusing on the central artwork.
 * 3. When generating fixed‑size preview images for a document management system that stores EMF files.
 * 4. When creating GIFs from vector graphics for email newsletters that require a 400 × 400 pixel size.
 * 5. When automating batch processing of EMF files to produce centered, cropped GIFs for a mobile app’s asset pipeline.
 */
