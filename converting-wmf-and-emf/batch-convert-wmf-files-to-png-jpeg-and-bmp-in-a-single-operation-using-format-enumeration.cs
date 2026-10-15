// HOW-TO: Batch Convert WMF Files To PNG JPEG And BMP In C# (Aspose.Imaging for .NET)
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

namespace WmfBatchConverter
{
    class Program
    {
        static void Main()
        {
            string inputDirectory = "C:\\InputWMF";
            string outputDirectory = "C:\\OutputImages";

            try
            {
                string[] wmfFiles = Directory.GetFiles(inputDirectory, "*.wmf");
                foreach (string inputPath in wmfFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (Image image = Image.Load(inputPath))
                    {
                        // PNG
                        string pngPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                        Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                        image.Save(pngPath, new PngOptions());

                        // JPEG
                        string jpegPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                        Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));
                        image.Save(jpegPath, new JpegOptions());

                        // BMP
                        string bmpPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");
                        Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
                        image.Save(bmpPath, new BmpOptions());
                    }
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
 * 1. When a legacy application stores diagrams as WMF and you need to generate web‑ready PNG, JPEG, and BMP thumbnails automatically.
 * 2. When migrating a large collection of WMF assets to multiple raster formats for cross‑platform compatibility in a C# batch job.
 * 3. When creating a build step that converts all WMF icons into PNG, JPEG, and BMP files for inclusion in mobile and desktop UI resources.
 * 4. When automating the archival process that requires storing each WMF document in several raster formats to meet different client specifications.
 * 5. When developing a reporting tool that must render WMF charts as PNG, JPEG, and BMP images on the fly using Aspose.Imaging in .NET.
 */
