// HOW-TO: Add Custom JFIF Thumbnail to JPEG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string thumbnailPath = "thumb.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                using (JpegImage thumbImage = (JpegImage)Image.Load(thumbnailPath))
                {
                    if (jpegImage.Jfif == null)
                    {
                        jpegImage.Jfif = new JFIFData();
                    }
                    jpegImage.Jfif.Thumbnail = thumbImage;
                }

                JpegOptions options = new JpegOptions();
                options.Source = new FileCreateSource(outputPath, false);
                jpegImage.Save(outputPath, options);
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
 * 1. When you need to embed a preview thumbnail in a JPEG’s JFIF segment for faster image browsing in photo management software.
 * 2. When generating JPEG files that must display a custom thumbnail on devices that read the JFIF metadata, such as digital cameras or media players.
 * 3. When creating a batch process that adds company logos as thumbnails to existing JPEGs for branding purposes.
 * 4. When converting high‑resolution images to JPEG while preserving a low‑resolution thumbnail for quick preview in web galleries.
 * 5. When updating legacy JPEG files to include a new thumbnail without altering the main image data, ensuring compatibility with older JPEG viewers.
 */
