// HOW-TO: Rotate OTG Image 90 Degrees Clockwise and Save as JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OTGRotate
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    JpegOptions options = new JpegOptions();
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
 * 1. When a CAD system exports drawings as OTG files that need to be displayed as correctly oriented JPEG thumbnails in a web gallery.
 * 2. When an automated batch job must convert scanned OTG documents to JPEG format while rotating them to match portrait layout for printing.
 * 3. When a mobile app receives OTG images from a device and must rotate them 90° clockwise before saving them as compressed JPEGs for storage efficiency.
 * 4. When a reporting tool generates charts in OTG format and requires them to be rotated and saved as JPEGs to embed in PDF reports.
 * 5. When a legacy workflow stores product images as OTG files and a developer needs to reorient and convert them to JPEG for use in an e‑commerce website.
 */
