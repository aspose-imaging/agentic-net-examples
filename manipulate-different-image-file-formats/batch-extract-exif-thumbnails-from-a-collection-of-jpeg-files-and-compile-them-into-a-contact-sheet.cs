// HOW-TO: Create a JPEG Contact Sheet from EXIF Thumbnails in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
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
            string outputPath = "Output/ContactSheet.jpg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] allFiles = Directory.GetFiles(inputDirectory);
            List<RasterImage> thumbnails = new List<RasterImage>();

            foreach (string filePath in allFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string ext = Path.GetExtension(filePath).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg")
                    continue;

                using (JpegImage img = (JpegImage)Image.Load(filePath))
                {
                    var exif = img.ExifData;
                    if (exif?.Thumbnail != null)
                    {
                        RasterImage thumb = (RasterImage)exif.Thumbnail;
                        thumbnails.Add(thumb);
                    }
                }
            }

            if (thumbnails.Count == 0)
            {
                Console.WriteLine("No thumbnails found.");
                return;
            }

            int totalWidth = thumbnails.Sum(t => t.Width);
            int maxHeight = thumbnails.Max(t => t.Height);

            Source outSource = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = outSource, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(options, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var thumb in thumbnails)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, thumb.Width, thumb.Height);
                    canvas.SaveArgb32Pixels(bounds, thumb.LoadArgb32Pixels(thumb.Bounds));
                    offsetX += thumb.Width;
                }
                canvas.Save();
            }

            foreach (var thumb in thumbnails)
            {
                thumb.Dispose();
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
 * 1. When you need to generate a quick visual index of many photos by extracting their embedded EXIF thumbnails and stitching them into a single JPEG contact sheet.
 * 2. When building a photo management tool that shows preview thumbnails without loading full‑size images, using the EXIF thumbnail extraction to improve performance.
 * 3. When creating a printable catalog of product images stored as JPEGs, and you want to compile the small embedded previews into one sheet for review.
 * 4. When automating a workflow that validates that JPEG files contain EXIF thumbnails and produces a summary image for quality‑control auditors.
 * 5. When developing a web service that receives a batch of uploaded JPEGs and returns a single thumbnail collage for quick browsing in a gallery UI.
 */
