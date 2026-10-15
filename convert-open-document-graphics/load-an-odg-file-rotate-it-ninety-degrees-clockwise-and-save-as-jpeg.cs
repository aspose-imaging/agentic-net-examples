// HOW-TO: Rotate ODG Image 90 Degrees And Save As JPEG In C# (Aspose.Imaging for .NET)
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

namespace OdgRotateExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output/output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to display an OpenDocument Graphics (ODG) diagram in a web gallery that only supports JPEG, you can rotate it to the correct orientation and convert it to JPEG using C#.
 * 2. When generating printable reports that require landscape‑oriented ODG charts, you can programmatically rotate the chart 90° clockwise and save it as a JPEG for inclusion in PDF documents.
 * 3. When automating batch processing of scanned ODG sketches that were saved upside‑down, you can use Aspose.Imaging to rotate each image and output JPEG files for archival storage.
 * 4. When integrating ODG assets into a mobile app that only handles JPEG images, you can rotate the graphics to match the device’s portrait mode and convert them on the fly with C#.
 * 5. When creating thumbnails of ODG illustrations for a content management system, you can rotate the original image and save a JPEG version to ensure consistent orientation across the site.
 */
