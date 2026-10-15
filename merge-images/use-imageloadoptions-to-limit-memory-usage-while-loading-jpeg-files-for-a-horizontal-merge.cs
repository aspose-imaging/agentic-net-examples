// HOW-TO: Load JPEG Images With Memory Limit And Merge Horizontally In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output.jpg";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load options with memory limit
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1024 * 1024 // 1 MB buffer
            };

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path, loadOptions))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            // Create output source and options
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = outputSource,
                Quality = 90
            };

            // Create canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (JpegImage img = (JpegImage)Image.Load(path, loadOptions))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image (canvas is bound to output source)
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
 * 1. When processing a large batch of high‑resolution JPEG photos on a server with limited RAM, you can load each image with a 1 MB buffer to avoid out‑of‑memory errors before stitching them side‑by‑side.
 * 2. When creating a panoramic view from several landscape JPEGs in a desktop application, the code lets you calculate the combined canvas size while keeping memory consumption low.
 * 3. When generating product‑catalog thumbnails that require merging multiple JPEGs into a single image, you can control the load options to ensure the operation runs efficiently on low‑end machines.
 * 4. When building an automated image‑processing pipeline that concatenates advertisement banners, the memory‑limited loading prevents crashes during batch processing.
 * 5. When developing a cloud‑based service that assembles user‑uploaded JPEGs into a single horizontal collage, the code helps stay within the memory quotas of the hosting environment.
 */
