// HOW-TO: Convert AVIF Image to JPEG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.avif";
                string outputPath = "output/output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
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
 * 1. When you need to display AVIF photos on browsers that only support JPEG, you can convert them on the server using Aspose.Imaging in C#.
 * 2. When a mobile app uploads AVIF files but the backend stores images as JPEG for compatibility, this code handles the conversion automatically.
 * 3. When generating thumbnails for an e‑commerce catalog, converting high‑efficiency AVIF product images to JPEG ensures fast loading on all devices.
 * 4. When processing user‑submitted avatars that arrive in AVIF format, you can standardize them to JPEG before saving to a database.
 * 5. When creating a batch job that migrates an archive of AVIF assets to JPEG for legacy systems, this snippet demonstrates the core conversion logic.
 */
