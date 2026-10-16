// HOW-TO: Crop a 200x200 Area from a TIFF and Save to Memory Stream in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (MemoryStream inputStream = new MemoryStream())
            {
                fileStream.CopyTo(inputStream);
                inputStream.Position = 0;

                using (RasterImage image = (RasterImage)Image.Load(inputStream))
                {
                    Rectangle cropRect = new Rectangle(0, 0, 200, 200);
                    image.Crop(cropRect);

                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                        image.Save(outputStream, options);
                        Console.WriteLine($"Cropped image size in bytes: {outputStream.Length}");
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
 * 1. When you need to extract a specific region from a multi‑page TIFF for thumbnail generation in a web application.
 * 2. When you want to process a scanned document in memory without creating temporary files on disk.
 * 3. When you have to send a cropped portion of a large TIFF to another service via a byte array or stream.
 * 4. When you are building a PDF conversion pipeline that requires a 200 × 200 pixel image slice from the original TIFF.
 * 5. When you need to validate or display a small region of a high‑resolution TIFF in a Windows Forms or WPF viewer.
 */
