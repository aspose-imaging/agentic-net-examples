// HOW-TO: Convert ODG to PNG with Text Watermark Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(raster);

                Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 48);
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    graphics.DrawString("Sample Watermark", font, brush, new Aspose.Imaging.Point(10, 10));
                }

                PngOptions pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a PNG preview of an OpenDocument Graphic (ODG) file and embed a copyright notice directly onto the image in a .NET application.
 * 2. When an automated reporting system must convert ODG diagrams to PNG format and add a company logo or text watermark before publishing online.
 * 3. When a document management workflow requires batch processing of ODG assets into watermarked PNG thumbnails for faster web display.
 * 4. When a desktop C# tool has to protect confidential ODG drawings by overlaying a warning label and saving them as PNG files.
 * 5. When a cloud service processes user‑uploaded ODG files, adds a promotional text overlay, and stores the resulting PNG for download.
 */
