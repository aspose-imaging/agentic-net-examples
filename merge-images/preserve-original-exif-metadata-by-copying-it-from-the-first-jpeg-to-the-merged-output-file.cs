// HOW-TO: Merge Multiple JPEGs Horizontally While Preserving EXIF Metadata in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (imageFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            foreach (string path in imageFiles)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in imageFiles)
            {
                using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(path))
                {
                    sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            var source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                using (JpegImage firstJpeg = (JpegImage)Aspose.Imaging.Image.Load(imageFiles[0]))
                {
                    var exif = firstJpeg.ExifData;
                    if (exif != null)
                    {
                        canvas.ExifData = exif;
                    }
                }

                int offsetX = 0;
                foreach (string path in imageFiles)
                {
                    using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                    {
                        var rect = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(rect, img.LoadArgb32Pixels(img.Bounds));
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
 * 1. When you need to combine several product photos into a single wide image for a catalog while keeping the original camera information.
 * 2. When creating a panoramic view from sequential JPEG shots and you want the resulting file to retain the first image’s EXIF data for geotagging.
 * 3. When generating a side‑by‑side comparison image for a web page and you must preserve the original image’s orientation and date metadata.
 * 4. When automating batch processing of scanned documents that must be merged into one JPEG while keeping the first page’s EXIF tags for archival compliance.
 * 5. When building a photo‑sharing app that stitches user‑uploaded JPEGs into a collage and needs to retain the original EXIF for copyright or licensing records.
 */
