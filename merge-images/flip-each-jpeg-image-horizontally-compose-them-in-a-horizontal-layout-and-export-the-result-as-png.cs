// HOW-TO: How To Flip JPEGs Horizontally And Merge Into A PNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputPath = "output.png";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (jpgFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            var imagesInfo = new List<(string Path, int Width, int Height)>();

            foreach (string file in jpgFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    imagesInfo.Add((file, img.Width, img.Height));
                }
            }

            int totalWidth = imagesInfo.Sum(i => i.Width);
            int maxHeight = imagesInfo.Max(i => i.Height);

            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var info in imagesInfo)
                {
                    using (JpegImage img = (JpegImage)Image.Load(info.Path))
                    {
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
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
 * 1. When you need to create a mirrored photo strip from a set of JPEG selfies for a web gallery.
 * 2. When generating a single panoramic PNG by flipping and stitching product photos taken from opposite angles.
 * 3. When preparing printable marketing material that requires all JPEG logos to be mirrored and combined into one PNG banner.
 * 4. When automating batch processing of user‑uploaded JPEG images to produce a horizontally mirrored collage for a mobile app.
 * 5. When converting a collection of scanned JPEG documents into a single PNG file with each page mirrored for right‑to‑left reading.
 */
