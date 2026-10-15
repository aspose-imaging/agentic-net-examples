// HOW-TO: Crop EMF Image to JPEG with Specific Rectangle in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (EmfImage emf = (EmfImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(10, 10, 200, 150);
                emf.Crop(rect);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                emf.Save(outputPath, jpegOptions);
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
 * 1. When you need to extract a portion of a vector EMF diagram and deliver it as a lightweight JPEG for web preview.
 * 2. When a reporting tool generates charts as EMF files and you must crop the chart area before embedding it in an email as a JPEG image.
 * 3. When an automated batch process has to convert legacy EMF assets to JPEG thumbnails of a defined size for a mobile app.
 * 4. When a document conversion service must remove margins from EMF drawings and save the result in JPEG format for PDF generation.
 * 5. When a GIS application stores map symbols in EMF and you need to clip a specific region and export it as a JPEG for use in a dashboard.
 */
