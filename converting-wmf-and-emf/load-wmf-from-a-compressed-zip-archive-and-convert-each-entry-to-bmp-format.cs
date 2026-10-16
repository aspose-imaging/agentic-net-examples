// HOW-TO: Convert WMF Files In ZIP Archive To BMP With Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WMFZipToBmp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputZipPath = "input.zip";
                string outputFolder = "output";

                if (!File.Exists(inputZipPath))
                {
                    Console.Error.WriteLine($"File not found: {inputZipPath}");
                    return;
                }

                Directory.CreateDirectory(outputFolder);

                using (FileStream zipStream = new FileStream(inputZipPath, FileMode.Open, FileAccess.Read))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (string.Equals(Path.GetExtension(entry.FullName), ".wmf", StringComparison.OrdinalIgnoreCase))
                        {
                            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(entry.FullName) + ".bmp");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            using (Stream entryStream = entry.Open())
                            using (MemoryStream ms = new MemoryStream())
                            {
                                entryStream.CopyTo(ms);
                                ms.Position = 0;

                                using (Image image = Image.Load(ms))
                                {
                                    BmpOptions options = new BmpOptions();
                                    image.Save(outputPath, options);
                                }
                            }
                        }
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
 * 1. When you receive a batch of WMF drawings packaged in a zip file and need to generate BMP thumbnails for a Windows application.
 * 2. When an automated document processing pipeline must extract vector WMF images from archives and convert them to raster BMP for legacy system compatibility.
 * 3. When you want to batch‑convert archived WMF logos into BMP format to embed them in a report that only supports bitmap images.
 * 4. When a migration tool reads compressed design assets and transforms each WMF into BMP to preserve visual fidelity during a move to a new platform.
 * 5. When a server‑side service processes uploaded zip files containing WMF graphics and stores the resulting BMP files for further image analysis.
 */
