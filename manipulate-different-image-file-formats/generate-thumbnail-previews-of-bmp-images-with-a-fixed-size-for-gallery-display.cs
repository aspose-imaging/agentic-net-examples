// HOW-TO: Create 150x150 BMP Thumbnail for Gallery Display in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output\\thumbnail.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (BmpImage image = (BmpImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Resize(150, 150, Aspose.Imaging.ResizeType.NearestNeighbourResample);

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

/*
 * Real-World Use Cases:
 * 1. When building a photo‑gallery web application that shows quick previews of BMP files, you can generate fixed‑size thumbnails to improve load times.
 * 2. When migrating legacy desktop software that stores images as BMP, you may need to create small preview icons for file explorers or UI lists.
 * 3. When implementing an e‑commerce platform that accepts BMP uploads, generating 150 × 150 thumbnails ensures consistent product image thumbnails across the site.
 * 4. When developing a digital asset management system that caches image data, resizing BMP images to a standard thumbnail size helps reduce storage and bandwidth usage.
 * 5. When creating a Windows Forms application that displays a scrollable image list, using Aspose.Imaging to resize BMPs provides fast, high‑quality thumbnails without external tools.
 */
