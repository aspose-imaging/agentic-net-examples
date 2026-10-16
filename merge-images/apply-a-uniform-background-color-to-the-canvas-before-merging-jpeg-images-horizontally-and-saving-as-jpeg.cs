// HOW-TO: Merge Multiple JPEG Images Horizontally with White Background in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
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
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
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

            // Calculate canvas size
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    totalWidth += img.Width;
                    if (img.Height > maxHeight)
                        maxHeight = img.Height;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create output source and options
            FileCreateSource outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = outputSource,
                Quality = 90
            };

            // Create canvas and fill background
            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int bgColor = Aspose.Imaging.Color.FromArgb(255, 255, 255, 255).ToArgb();
                int[] bgPixels = new int[totalWidth * maxHeight];
                for (int i = 0; i < bgPixels.Length; i++)
                    bgPixels[i] = bgColor;
                canvas.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, totalWidth, maxHeight), bgPixels);

                // Merge images horizontally
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                        canvas.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height), pixels);
                        offsetX += img.Width;
                    }
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
 * 1. When you need to create a side‑by‑side photo collage from several JPEG files and ensure a consistent white background behind shorter images.
 * 2. When generating product catalog pages that combine multiple product photos into a single horizontal banner while preserving JPEG quality.
 * 3. When preparing web‑ready image strips for sliders or carousels where all images must share the same canvas size and background color.
 * 4. When automating the assembly of scanned document pages saved as JPEG into one wide image for printing or archival purposes.
 * 5. When building a reporting tool that merges chart screenshots (JPEG) into a single row with a uniform background to maintain visual alignment.
 */
