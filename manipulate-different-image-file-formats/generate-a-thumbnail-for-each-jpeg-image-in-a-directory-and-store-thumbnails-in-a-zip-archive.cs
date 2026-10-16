// HOW-TO: Create JPEG Thumbnails and Save Them to a Zip File in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputZipPath = "thumbnails.zip";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath) ?? ".");

            string[] imageFiles = Directory.GetFiles(inputDirectory)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            using (FileStream zipStream = new FileStream(outputZipPath, FileMode.Create))
            using (var archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create, true))
            {
                foreach (string inputPath in imageFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (Image image = Image.Load(inputPath))
                    using (RasterImage raster = (RasterImage)image)
                    {
                        int thumbWidth = 100;
                        int thumbHeight = 100;
                        raster.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            JpegOptions jpegOptions = new JpegOptions
                            {
                                Quality = 80
                            };
                            raster.Save(ms, jpegOptions);
                            ms.Position = 0;

                            string entryName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.jpg";
                            var entry = archive.CreateEntry(entryName);
                            using (var entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
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

/*
 * Real-World Use Cases:
 * 1. When you need to generate small preview images for a large collection of JPEG photos and package them for quick download or distribution.
 * 2. When an e‑commerce site wants to create product thumbnail galleries from high‑resolution JPEG uploads and deliver them as a single archive to reduce HTTP requests.
 * 3. When a digital asset management system must batch‑process user‑submitted JPEG files, resize them to a uniform thumbnail size, and store the results in a zip for backup or archival.
 * 4. When a mobile app backend has to prepare lightweight thumbnail bundles from user‑uploaded JPEG images for offline viewing on devices with limited storage.
 * 5. When a reporting tool requires extracting thumbnail snapshots of JPEG charts, resizing them, and bundling them into a zip file to attach to email summaries.
 */
