// HOW-TO: Merge Multiple JPEG Images Vertically into a PNG Using Parallel Loading in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            var imageBag = new System.Collections.Concurrent.ConcurrentBag<RasterImage>();
            System.Threading.Tasks.Parallel.ForEach(files, file =>
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                var img = (RasterImage)Image.Load(file);
                imageBag.Add(img);
            });

            List<RasterImage> images = imageBag.ToList();

            int totalWidth = images.Max(i => i.Width);
            int totalHeight = images.Sum(i => i.Height);

            string outputPath = Path.Combine(outputDirectory, "merged.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (var img in images)
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
                canvas.Save();
            }

            foreach (var img in images)
            {
                img.Dispose();
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
 * 1. When you need to combine a series of scanned photos stored as JPEGs into a single tall PNG for printing or web display.
 * 2. When you want to speed up loading of many large JPEG files by processing them in parallel on multi‑core machines before creating a composite image.
 * 3. When you have to generate a single PNG sprite sheet from individual JPEG assets for use in UI or game development.
 * 4. When you need to create a vertical timeline or storyboard image by stacking JPEG frames without manually resizing each file.
 * 5. When you must automate batch conversion of JPEG batches into a high‑resolution PNG collage while preserving original dimensions.
 */
