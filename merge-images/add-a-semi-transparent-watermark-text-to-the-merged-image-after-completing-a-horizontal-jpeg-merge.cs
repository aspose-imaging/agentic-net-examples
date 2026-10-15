// HOW-TO: Add Semi Transparent Watermark to Horizontally Merged JPEGs in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "merged_output.jpg";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Collect sizes of all images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string inputPath in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            // Create JPEG canvas with bound source
            Aspose.Imaging.Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                // Merge images horizontally
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Add semi‑transparent watermark text
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                string watermarkText = "Sample Watermark";
                Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 36);
                SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(128, 255, 255, 255));
                Aspose.Imaging.PointF position = new Aspose.Imaging.PointF(10, maxHeight - 50);
                graphics.DrawString(watermarkText, font, brush, position);

                // Save the merged image (source is already bound)
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
 * 1. When you need to combine product photos side‑by‑side and brand the final image with a faint logo for an online catalog.
 * 2. When generating a single panoramic view from multiple camera shots and want to overlay a copyright notice without obscuring details.
 * 3. When creating a composite advertisement banner from several JPEG assets and require a semi‑transparent promotional text across the merged result.
 * 4. When automating batch processing of scanned documents, merging pages horizontally and adding a discreet “Confidential” watermark for internal distribution.
 * 5. When preparing social‑media collages of event images and need to embed a subtle watermark to protect the content while keeping the layout intact.
 */
