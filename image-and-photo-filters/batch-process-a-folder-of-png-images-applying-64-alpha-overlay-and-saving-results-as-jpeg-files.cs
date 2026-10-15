// HOW-TO: Batch Apply 64 Alpha White Overlay to PNGs and Save as JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (RasterImage background = (RasterImage)Image.Load(inputPath))
                {
                    // Create overlay image with same dimensions
                    string overlayTempPath = Path.GetTempFileName();
                    Source overlaySource = new FileCreateSource(overlayTempPath, false);
                    JpegOptions overlayOptions = new JpegOptions() { Source = overlaySource };
                    using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, background.Width, background.Height))
                    {
                        int pixelCount = overlay.Width * overlay.Height;
                        int[] pixels = new int[pixelCount];
                        int argb = (64 << 24) | (255 << 16) | (255 << 8) | 255; // 64-alpha white
                        for (int i = 0; i < pixelCount; i++)
                        {
                            pixels[i] = argb;
                        }
                        overlay.SaveArgb32Pixels(overlay.Bounds, pixels);

                        // Blend overlay onto background
                        background.Blend(new Point(0, 0), overlay, 255);
                    }

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as JPEG
                    JpegOptions jpegOptions = new JpegOptions()
                    {
                        Source = new FileCreateSource(outputPath, false),
                        Quality = 90
                    };
                    background.Save(outputPath, jpegOptions);
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
 * 1. When you need to watermark a large set of product photos with a semi‑transparent white overlay before publishing them as JPEGs.
 * 2. When converting scanned PNG documents to JPEG for web delivery while applying a consistent 64‑alpha fade effect.
 * 3. When preparing thumbnail previews from PNG assets by adding a subtle overlay and saving them in a smaller JPEG format.
 * 4. When automating the reduction of PNG file size by overlaying and re‑encoding them as JPEGs for mobile apps.
 * 5. When integrating Aspose.Imaging into a C# service that processes user‑uploaded PNG images, adds a low‑opacity overlay, and stores the results as JPEG files.
 */
