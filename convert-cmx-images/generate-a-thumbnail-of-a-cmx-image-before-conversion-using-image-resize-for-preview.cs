// HOW-TO: Create PNG Thumbnail of CMX Image and Convert to JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string thumbnailPath = "preview/thumbnail.png";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(thumbnailPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create thumbnail preview
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int thumbWidth = 200;
                int thumbHeight = 200;
                cmx.Resize(thumbWidth, thumbHeight);
                cmx.Save(thumbnailPath, new PngOptions());
            }

            // Convert original CMX to JPEG
            using (CmxImage original = (CmxImage)Image.Load(inputPath))
            {
                original.Save(outputPath, new JpegOptions());
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
 * 1. When you need to display a small PNG preview of a large CMX drawing in a web gallery before users download the full file.
 * 2. When a document management system must generate 200 × 200 pixel thumbnails for CMX files to show alongside other image formats.
 * 3. When converting legacy CMX drawings to JPEG for compatibility with standard viewers while also providing a quick PNG preview.
 * 4. When building a desktop application that lets users browse CMX files and see a low‑resolution thumbnail without loading the full‑resolution image.
 * 5. When automating a batch job that creates PNG thumbnails for CMX assets and then archives the original drawings as JPEGs.
 */
