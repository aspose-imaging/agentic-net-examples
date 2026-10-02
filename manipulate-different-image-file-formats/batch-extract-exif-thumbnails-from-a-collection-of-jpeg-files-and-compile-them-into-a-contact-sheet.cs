// HOW-TO: Create a Contact Sheet from EXIF Thumbnails of JPEG Files in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-28
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
            string inputDirectory = "Input";
            string outputPath = Path.Combine("Output", "ContactSheet.jpg");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            List<RasterImage> thumbs = new List<RasterImage>();

            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    var exif = img.ExifData;
                    if (exif != null && exif.Thumbnail != null)
                    {
                        RasterImage thumb = (RasterImage)exif.Thumbnail;
                        thumbs.Add(thumb);
                    }
                }
            }

            if (thumbs.Count == 0)
            {
                Console.WriteLine("No EXIF thumbnails found.");
                return;
            }

            int maxWidth = thumbs.Max(t => t.Width);
            int maxHeight = thumbs.Max(t => t.Height);
            int columns = 5;
            int rows = (int)Math.Ceiling((double)thumbs.Count / columns);
            int canvasWidth = columns * maxWidth;
            int canvasHeight = rows * maxHeight;

            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                for (int i = 0; i < thumbs.Count; i++)
                {
                    RasterImage thumb = thumbs[i];
                    int x = (i % columns) * maxWidth;
                    int y = (i / columns) * maxHeight;
                    Rectangle bounds = new Rectangle(x, y, thumb.Width, thumb.Height);
                    canvas.SaveArgb32Pixels(bounds, thumb.LoadArgb32Pixels(thumb.Bounds));
                }
                canvas.Save();
            }

            foreach (var t in thumbs)
            {
                t.Dispose();
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
 * 1. When you need to generate a quick preview page of all photos in a folder by extracting their embedded EXIF thumbnails and arranging them into a single JPEG contact sheet.
 * 2. When building a digital asset management tool that shows a compact overview of images without loading full‑resolution files, using the EXIF thumbnail data for faster rendering.
 * 3. When creating a printable catalog of product images where each item's small thumbnail is taken from the original JPEG’s EXIF data to keep the file size low.
 * 4. When automating a workflow that validates that uploaded JPEGs contain EXIF thumbnails and compiles the existing ones into a summary image for quality‑control reports.
 * 5. When developing a photo‑sharing website that needs to display a grid of thumbnail previews generated from the source images’ EXIF data without re‑encoding the original pictures.
 */
