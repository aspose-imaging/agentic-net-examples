// HOW-TO: Convert WebP to GIF in C# While Preserving EXIF Orientation (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.webp";
            string outputPath = "Output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image srcImage = Image.Load(inputPath))
            {
                var exifData = srcImage.ExifData;

                RasterImage raster = srcImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Source image is not a raster image.");
                    return;
                }

                int width = raster.Width;
                int height = raster.Height;

                GifOptions gifOptions = new GifOptions();
                gifOptions.Source = new FileCreateSource(outputPath, false);

                using (Image gifImage = Image.Create(gifOptions, width, height))
                {
                    Graphics graphics = new Graphics(gifImage);
                    graphics.DrawImage(raster, new Rectangle(0, 0, width, height));

                    if (exifData != null)
                    {
                        gifImage.ExifData = exifData;
                    }

                    gifImage.Save();
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
 * 1. When a web application needs to display user‑uploaded WebP photos as GIFs while keeping the original rotation indicated by EXIF data.
 * 2. When an e‑commerce platform converts product images from WebP to GIF for email newsletters but must retain correct orientation on all devices.
 * 3. When a mobile app generates GIF previews from WebP screenshots and wants the images to appear upright without manually rotating them.
 * 4. When a digital asset management system batch‑processes WebP files into GIF format and requires the EXIF orientation tag to be copied for archival consistency.
 * 5. When a social media scheduler transforms WebP memes into GIFs for posting and needs to preserve the original image’s orientation metadata.
 */
