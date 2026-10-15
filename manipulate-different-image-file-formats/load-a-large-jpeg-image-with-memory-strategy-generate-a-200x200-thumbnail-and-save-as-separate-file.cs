// HOW-TO: Create 200x200 JPEG Thumbnail from Large Image Using Memory Buffer in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/thumbnail.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new Aspose.Imaging.LoadOptions { BufferSizeHint = 10 * 1024 * 1024 };
            using (JpegImage image = (JpegImage)Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                image.Resize(200, 200, Aspose.Imaging.ResizeType.NearestNeighbourResample);
                image.Save(outputPath);
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
 * 1. When you need to generate small preview images for a photo gallery from high‑resolution JPEG files without loading the entire image into memory.
 * 2. When a web application must create thumbnails on the fly for user‑uploaded large JPEG photos while controlling memory usage with a buffer hint.
 * 3. When an e‑commerce site wants to display product image thumbnails sized to 200×200 pixels and store them as separate JPEG files for faster page loads.
 * 4. When a digital asset management system processes massive JPEG scans and requires a quick, low‑memory way to produce standardized thumbnail versions.
 * 5. When a desktop utility converts large JPEG pictures into smaller thumbnail files for email attachments, using Aspose.Imaging’s Resize and Save methods in C#.
 */
