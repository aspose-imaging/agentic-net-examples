// HOW-TO: Batch Convert Images to JPEG with Fixed Size in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            const int targetWidth = 800;
            const int targetHeight = 600;

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90,
                        Source = new FileCreateSource(outputPath, false)
                    };

                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate web‑ready thumbnails from a folder of uploaded canvas screenshots by resizing them to 800×600 and saving as JPEGs using C#.
 * 2. When an e‑commerce platform must standardize product photos to a common resolution before storing them in a JPEG archive.
 * 3. When a reporting tool converts dynamically created HTML5 canvas charts saved as image files into compressed JPEG files with consistent dimensions for PDF embedding.
 * 4. When a migration script processes legacy image assets, resizes each to a fixed size, and outputs high‑quality JPEGs for a mobile app.
 * 5. When an automated build pipeline batches conversion of design mockups into JPEGs with uniform width and height to ensure consistent UI previews.
 */
