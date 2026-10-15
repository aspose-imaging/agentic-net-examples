// HOW-TO: Flip TGA Image Vertically and Save as JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to correct an upside‑down TGA sprite before embedding it in a game and deliver it as a JPEG for web preview.
 * 2. When a batch process must convert legacy TGA textures to JPEG thumbnails while flipping them vertically for proper orientation.
 * 3. When an automated pipeline requires reading a TGA file, applying a vertical mirror, and saving the result in a compressed JPEG format for email attachment.
 * 4. When a desktop application needs to load a TGA screenshot, flip it along the Y‑axis, and export it as a JPEG for printing or sharing.
 * 5. When a migration script must transform TGA assets to JPEG while ensuring the image is flipped to match the target display’s coordinate system.
 */
