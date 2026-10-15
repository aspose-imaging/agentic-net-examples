// HOW-TO: Crop PNG Image to Centered Square Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\cropped.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;
                int size = Math.Min(width, height);

                int leftShift = (width - size) / 2;
                int rightShift = width - size - leftShift;
                int topShift = (height - size) / 2;
                int bottomShift = height - size - topShift;

                image.Crop(leftShift, rightShift, topShift, bottomShift);
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
 * 1. When you need to generate square thumbnails from user‑uploaded PNG photos for a web gallery.
 * 2. When you must prepare profile pictures that are perfectly centered and square before saving them to a database.
 * 3. When you are creating assets for a mobile app that requires square PNG icons derived from larger images.
 * 4. When you need to standardize image dimensions for a machine‑learning model that expects square inputs.
 * 5. When you want to batch‑process product images to fit a consistent square layout on an e‑commerce site.
 */
