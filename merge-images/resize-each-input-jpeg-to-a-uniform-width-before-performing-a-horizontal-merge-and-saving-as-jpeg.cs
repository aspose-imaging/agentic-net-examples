// HOW-TO: Resize Multiple JPEGs to Same Width and Merge Horizontally in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            // Gather JPEG files
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (inputFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            const int uniformWidth = 200; // Desired width for each image

            List<Aspose.Imaging.RasterImage> resizedImages = new List<Aspose.Imaging.RasterImage>();
            List<(int width, int height)> sizes = new List<(int, int)>();

            // Load, resize, and store images
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath);
                double scale = (double)uniformWidth / img.Width;
                int targetHeight = (int)(img.Height * scale);
                img.Resize(uniformWidth, targetHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                resizedImages.Add(img);
                sizes.Add((img.Width, img.Height));
            }

            // Calculate canvas size
            int totalWidth = sizes.Sum(s => s.width);
            int maxHeight = sizes.Max(s => s.height);

            // Create output JPEG canvas
            FileCreateSource outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                for (int i = 0; i < resizedImages.Count; i++)
                {
                    var img = resizedImages[i];
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }

                // Save the merged image (source is already bound)
                canvas.Save();
            }

            // Dispose loaded images
            foreach (var img in resizedImages)
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
 * 1. When you need to create a single panoramic JPEG from several photos that must share a consistent width for a web gallery.
 * 2. When generating product catalog thumbnails where each JPEG is resized to a uniform width before being combined into a single strip for printing.
 * 3. When preparing a side‑by‑side comparison chart of screenshots, ensuring each JPEG has the same width for accurate visual alignment.
 * 4. When automating the creation of a banner composed of multiple JPEG advertisements that need identical widths to maintain layout consistency.
 * 5. When consolidating scanned document pages into one JPEG file while standardizing their width to simplify downstream processing.
 */
