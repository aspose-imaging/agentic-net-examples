// HOW-TO: Add Custom Thumbnail to Multiple JPEG EXIF Segments in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string thumbnailPath = "thumbnail.jpg";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            byte[] thumbnailBytes = File.ReadAllBytes(thumbnailPath);

            var files = Directory.GetFiles(inputDirectory)
                                 .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                             f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase));

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    if (image.ExifData == null)
                    {
                        image.ExifData = new Aspose.Imaging.Exif.JpegExifData();
                    }

                    using (RasterImage thumbImg = (RasterImage)Image.Load(new MemoryStream(thumbnailBytes)))
                    {
                        image.ExifData.Thumbnail = thumbImg;
                    }

                    image.Save(outputPath);
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
 * 1. When you need to embed a company logo as a thumbnail into the EXIF data of a large set of product photos before uploading them to an e‑commerce platform.
 * 2. When you want to generate consistent preview images for a photo archive by adding the same thumbnail to every JPEG file in a folder.
 * 3. When a digital asset management system requires each image to contain a custom thumbnail for faster browsing on mobile devices.
 * 4. When you must comply with a client’s branding guidelines by programmatically inserting a predefined thumbnail into the EXIF section of all client‑provided JPEGs.
 * 5. When you are preparing a batch of images for a slideshow and need to ensure each file carries the same thumbnail for uniform display in gallery software.
 */
