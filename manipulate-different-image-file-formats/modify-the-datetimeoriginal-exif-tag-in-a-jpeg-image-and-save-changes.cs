// HOW-TO: Update DateTimeOriginal EXIF Tag in JPEG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    exif.DateTimeOriginal = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");
                }

                image.Save(outputPath);
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
 * 1. When you need to correct the capture timestamp of a JPEG photo after it was imported or edited, you can modify the DateTimeOriginal EXIF tag with Aspose.Imaging in C#.
 * 2. When building a photo‑organizing tool that sorts images by the original shooting date, you may need to update the DateTimeOriginal field to reflect the correct time before indexing.
 * 3. When a digital forensics application requires setting a consistent timestamp across multiple JPEG files, you can programmatically write the current date‑time to the EXIF DateTimeOriginal tag using C#.
 * 4. When generating thumbnails for a web gallery and want the displayed metadata to show the upload time instead of the original capture time, you can replace the EXIF DateTimeOriginal value with Aspose.Imaging.
 * 5. When automating a batch process that renames or archives JPEG images based on their metadata, updating the DateTimeOriginal tag ensures the file’s metadata matches the new naming convention.
 */
