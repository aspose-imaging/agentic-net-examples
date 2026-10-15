// HOW-TO: How To Add One Hour To JPEG EXIF DateTimeOriginal In C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

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
                    string original = exif.DateTimeOriginal;
                    if (!string.IsNullOrEmpty(original) && DateTime.TryParse(original, out DateTime dt))
                    {
                        exif.DateTimeOriginal = dt.AddHours(1).ToString("yyyy:MM:dd HH:mm:ss");
                    }
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
 * 1. When you need to correct camera time‑zone errors in JPEG photos before publishing them to an online gallery.
 * 2. When you want to synchronize photo timestamps with server logs by shifting the EXIF DateTimeOriginal by one hour.
 * 3. When daylight‑saving time changes require adjusting sunrise or sunset metadata stored in JPEG EXIF data.
 * 4. When a digital asset management system must align timestamps of images captured in different time zones.
 * 5. When preparing images for legal evidence and you must ensure the recorded capture time reflects the correct hour.
 */
