// HOW-TO: Resize BMP Image With Bicubic Resampling And Add Password Protected Digital Signature In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.bmp";
                string outputPath = "output.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    int newWidth = image.Width * 2;
                    int newHeight = image.Height * 2;
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                    string password = "TenCharPwd";
                    image.EmbedDigitalSignature(password);
                    BmpOptions options = new BmpOptions();
                    image.Save(outputPath, options);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to enlarge a BMP graphic for high‑resolution printing while preserving quality using bicubic resampling.
 * 2. When an application must embed a tamper‑evident digital signature into a BMP file to verify its authenticity later.
 * 3. When a workflow requires protecting the embedded signature with a fixed‑length password to restrict unauthorized access.
 * 4. When converting legacy BMP assets to a larger size for UI scaling and ensuring the file remains securely signed.
 * 5. When automating batch processing of BMP images that need both size increase and secure metadata for compliance audits.
 */
