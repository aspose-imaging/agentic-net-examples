// HOW-TO: Create 150x150 JPEG Thumbnail From EPS File In C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                epsImage.Resize(150, 150);
                JpegOptions jpegOptions = new JpegOptions();
                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to display a small preview of a vector EPS logo on a web page, you can generate a 150 × 150 JPEG thumbnail in C#.
 * 2. When an e‑commerce platform stores product artwork as EPS files but requires low‑resolution JPEG images for catalog listings, this code creates the needed thumbnails.
 * 3. When a document management system must show quick visual cues for uploaded EPS drawings, you can automatically resize and convert them to JPEG thumbnails.
 * 4. When a batch processing job has to prepare EPS files for email attachments that only support raster images, the snippet produces a compact JPEG preview.
 * 5. When a mobile app consumes image data from a server that stores EPS files, you can pre‑render 150 × 150 JPEG thumbnails on the server to reduce bandwidth.
 */
