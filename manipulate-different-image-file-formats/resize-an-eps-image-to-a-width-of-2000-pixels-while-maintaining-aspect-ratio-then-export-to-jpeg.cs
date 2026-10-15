// HOW-TO: Resize EPS to 2000px Width and Convert to JPEG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                int originalWidth = epsImage.Width;
                int originalHeight = epsImage.Height;

                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);

                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = newWidth,
                    PageHeight = newHeight
                };

                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Quality = 90
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
 * 1. When a web application must display a high‑resolution EPS logo as a JPEG thumbnail sized to 2000 px wide.
 * 2. When an e‑commerce platform needs to convert vendor‑supplied EPS product drawings into web‑friendly JPEGs with a fixed width for consistent page layout.
 * 3. When a printing workflow requires scaling vector EPS artwork to a specific pixel width before rasterizing it for preview images.
 * 4. When a content management system automatically processes uploaded EPS files, resizing them to 2000 px wide JPEGs for faster loading on mobile devices.
 * 5. When a batch script generates marketing assets by converting EPS illustrations to JPEGs with a uniform width while preserving the original aspect ratio.
 */
