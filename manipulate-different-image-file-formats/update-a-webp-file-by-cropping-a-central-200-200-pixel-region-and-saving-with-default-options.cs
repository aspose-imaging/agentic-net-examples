// HOW-TO: Crop Center 200x200 Pixels From WebP Image In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.webp";
                string outputPath = "output/output.webp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (WebPImage image = (WebPImage)Image.Load(inputPath))
                {
                    int cropWidth = 200;
                    int cropHeight = 200;
                    int x = (image.Width - cropWidth) / 2;
                    int y = (image.Height - cropHeight) / 2;

                    var cropRect = new Rectangle(x, y, cropWidth, cropHeight);
                    image.Crop(cropRect);
                    image.Save(outputPath);
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
 * 1. When you need to generate a thumbnail of a fixed 200 × 200 size from a larger WebP photo for a web gallery.
 * 2. When you want to extract the central region of a WebP graphic to focus on the main subject before uploading to a CMS.
 * 3. When an e‑commerce site requires a square product preview cut from the middle of high‑resolution WebP images.
 * 4. When you are preprocessing WebP assets for a mobile app and must ensure every image has a consistent 200 × 200 crop.
 * 5. When you need to automate cropping of user‑uploaded WebP avatars to a standard size for profile displays.
 */
