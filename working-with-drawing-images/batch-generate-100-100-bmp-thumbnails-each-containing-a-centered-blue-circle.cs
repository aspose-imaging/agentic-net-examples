// HOW-TO: Create 100x100 BMP Thumbnails With Blue Circle Overlay In C# (Aspose.Imaging for .NET)
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

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.Resize(100, 100, ResizeType.NearestNeighbourResample);

                    Graphics graphics = new Graphics(image);
                    Pen bluePen = new Pen(Color.Blue);
                    graphics.DrawEllipse(bluePen, new Rectangle(0, 0, 100, 100));

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (BmpOptions bmpOptions = new BmpOptions() { Source = new FileCreateSource(outputPath, false) })
                    {
                        image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate small BMP preview images for a gallery of user‑uploaded photos, adding a blue circle watermark to each thumbnail.
 * 2. When a desktop application must create uniform 100 × 100 icons from various source formats and mark them with a centered blue circle for visual identification.
 * 3. When an automated pipeline processes a folder of images and outputs BMP thumbnails that include a simple graphic element for testing rendering pipelines.
 * 4. When you want to batch‑convert a collection of pictures into BMP files of exact size while drawing a blue ellipse to verify drawing APIs in Aspose.Imaging.
 * 5. When a reporting tool requires fixed‑size BMP thumbnails with a blue circle overlay to represent status symbols across multiple input images.
 */
