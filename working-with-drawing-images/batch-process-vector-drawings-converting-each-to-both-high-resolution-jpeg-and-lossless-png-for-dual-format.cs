// HOW-TO: Batch Convert Vector Drawings to High-Resolution JPEG and PNG in C# (Aspose.Imaging for .NET)
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

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string jpegPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
                string pngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));
                Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100,
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };
                    image.Save(jpegPath, jpegOptions);

                    var pngOptions = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };
                    image.Save(pngPath, pngOptions);
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
 * 1. When a publishing company needs to generate both web‑ready JPEG previews and print‑ready PNG files from a collection of vector artwork.
 * 2. When an e‑commerce platform must create high‑resolution product images in JPEG for thumbnails and lossless PNG for zoom‑in features from designer files.
 * 3. When a marketing team wants to automate the conversion of SVG or AI files into dual‑format assets for email campaigns and print brochures.
 * 4. When a software that archives technical drawings requires batch conversion to JPEG for quick viewing and PNG for archival quality.
 * 5. When a digital asset management system needs to process incoming vector files and store them in both compressed JPEG and lossless PNG for different distribution channels.
 */
