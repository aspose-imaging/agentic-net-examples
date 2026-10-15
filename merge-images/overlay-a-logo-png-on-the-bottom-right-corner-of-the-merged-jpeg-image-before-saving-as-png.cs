// HOW-TO: Merge Multiple JPEGs Horizontally and Add Bottom Right Logo in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string[] inputPaths = new string[] { "image1.jpg", "image2.jpg" };
            string logoPath = "logo.png";
            string outputPath = "output/merged.png";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            // Create PNG canvas
            var src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };
            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, totalWidth, maxHeight))
            {
                // Merge input images horizontally
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Load logo image
                using (Aspose.Imaging.RasterImage logo = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(logoPath))
                {
                    int posX = canvas.Width - logo.Width;
                    int posY = canvas.Height - logo.Height;
                    if (posX < 0) posX = 0;
                    if (posY < 0) posY = 0;
                    Aspose.Imaging.Rectangle logoBounds = new Aspose.Imaging.Rectangle(posX, posY, logo.Width, logo.Height);
                    canvas.SaveArgb32Pixels(logoBounds, logo.LoadArgb32Pixels(logo.Bounds));
                }

                // Save the final image
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
 * 1. When you need to combine several product photos into a single banner and brand it with a company logo at the corner.
 * 2. When generating a composite image for an email newsletter that merges customer‑uploaded JPEGs and adds a trademark watermark before converting to PNG.
 * 3. When creating a printable catalog page where multiple high‑resolution JPEGs are stitched side‑by‑side and a logo is overlaid to protect intellectual property.
 * 4. When automating the preparation of social‑media graphics that require merging screenshots and appending a logo in the bottom‑right corner for consistent branding.
 * 5. When developing a web service that receives multiple JPEG uploads, merges them into one image and returns a PNG with a logo overlay for downstream processing.
 */
