// HOW-TO: Convert CMX Files to JPEG with White Background in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.cmx");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
                {
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cmxImage.Width,
                        PageHeight = cmxImage.Height
                    };

                    using (JpegOptions jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        VectorRasterizationOptions = vectorOptions,
                        Quality = 90
                    })
                    {
                        cmxImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate JPEG previews of CorelDRAW CMX drawings for web thumbnails, ensuring transparent areas appear white.
 * 2. When batch‑processing a folder of CMX files to create JPEG assets for email newsletters without unwanted background artifacts.
 * 3. When integrating a .NET service that converts legacy CMX vector graphics to JPEG for storage in a database that only supports raster images.
 * 4. When preparing CMX artwork for printing workflows that require JPEG input and a solid background to avoid color shifts.
 * 5. When automating the migration of old CMX design files to JPEG format in a CI pipeline, setting a consistent background color to maintain visual fidelity.
 */
