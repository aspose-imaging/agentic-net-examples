// HOW-TO: Scale EPS Image by 1.5 and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                int newWidth = (int)(epsImage.Width * 1.5);
                int newHeight = (int)(epsImage.Height * 1.5);
                epsImage.Resize(newWidth, newHeight);

                var jpegOptions = new JpegOptions
                {
                    Quality = 100
                };

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
 * 1. When a designer needs to enlarge a vector EPS logo to 150% for a print brochure while preserving raster quality as a JPEG.
 * 2. When an e‑commerce platform converts EPS product illustrations to high‑resolution JPEG thumbnails for faster web loading.
 * 3. When a publishing workflow requires scaling EPS artwork before embedding it into a JPEG‑based digital magazine.
 * 4. When a batch process must resize EPS diagrams to a specific factor and output them as lossless‑quality JPEGs for archival.
 * 5. When a C# application needs to programmatically adjust EPS image dimensions and export them as maximum‑quality JPEG files for client delivery.
 */
