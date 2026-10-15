// HOW-TO: Merge Multiple JPEG Images Side By Side Aligning Top Left In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "input";
            string outputPath = "output/merged.jpg";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (imageFiles.Length == 0)
            {
                Console.Error.WriteLine("No JPEG images found in the input directory.");
                return;
            }

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string file in imageFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(file))
                {
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FileCreateSource source = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(options, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string file in imageFiles)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(file))
                    {
                        var bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                canvas.Save();
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
 * 1. When you need to create a single panoramic JPEG from a series of product photos for an e‑commerce catalog.
 * 2. When you want to combine scanned receipts into one image to simplify archival and printing.
 * 3. When generating a side‑by‑side comparison chart of before‑and‑after screenshots for documentation.
 * 4. When assembling multiple camera captures into a single banner image for a web page layout.
 * 5. When batch‑processing a folder of JPEGs to produce a composite image with consistent top‑left alignment for automated reporting.
 */
