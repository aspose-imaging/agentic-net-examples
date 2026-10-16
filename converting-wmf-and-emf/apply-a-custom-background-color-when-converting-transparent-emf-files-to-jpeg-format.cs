// HOW-TO: Convert Transparent EMF to JPEG with Custom Background Color in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    Quality = 90
                };

                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.FromArgb(255, 255, 0, 0),
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                jpegOptions.VectorRasterizationOptions = vectorOptions;

                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to embed a vector EMF logo with a corporate red background into a PDF that only supports JPEG images.
 * 2. When generating web‑ready product photos from transparent EMF drawings and you want a solid background to avoid white gaps.
 * 3. When batch‑processing engineering diagrams saved as EMF and converting them to JPEG for email attachments while enforcing a specific background color.
 * 4. When creating thumbnails for a gallery where the original EMF files have transparency and you must replace it with a chosen color to match the site theme.
 * 5. When converting legacy EMF icons to JPEG for use in a mobile app that does not support transparency, and you need to set the background to a custom ARGB value.
 */
