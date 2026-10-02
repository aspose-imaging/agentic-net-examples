// HOW-TO: Add Custom EXIF Thumbnail to Multiple JPEGs in C# With Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Exif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");
            string thumbnailPath = Path.Combine(baseDir, "thumbnail.jpg");

            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            byte[] thumbnailBytes;
            using (Image thumbImg = Image.Load(thumbnailPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (JpegOptions thumbOptions = new JpegOptions())
                    {
                        thumbImg.Save(ms, thumbOptions);
                    }
                    thumbnailBytes = ms.ToArray();
                }
            }

            string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
            var files = jpgFiles.Concat(jpegFiles).ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    var exif = image.ExifData;
                    if (exif == null)
                    {
                        exif = new JpegExifData();
                        image.ExifData = exif;
                    }

                    using (RasterImage thumbRaster = (RasterImage)Image.Load(new MemoryStream(thumbnailBytes)))
                    {
                        exif.Thumbnail = thumbRaster;
                    }

                    using (JpegOptions saveOptions = new JpegOptions())
                    {
                        image.Save(outputPath, saveOptions);
                    }
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
 * 1. When you need to embed a company logo as a thumbnail into a batch of product photos for consistent branding in their EXIF data.
 * 2. When you want to generate preview thumbnails for a large collection of JPEG images before uploading them to a digital asset management system.
 * 3. When you must replace missing or low‑resolution thumbnails in archived JPEG files with a high‑quality placeholder image.
 * 4. When you are preparing images for a mobile app that reads EXIF thumbnails to display quick previews without loading full‑size files.
 * 5. When you automate the addition of a custom thumbnail to user‑submitted JPEGs to meet a client’s metadata standards before publishing.
 */
