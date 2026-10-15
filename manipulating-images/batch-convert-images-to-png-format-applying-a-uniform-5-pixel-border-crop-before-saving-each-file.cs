// HOW-TO: Batch Convert Images to PNG with 5 Pixel Border Crop in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input";
            string outputPath = "output";

            foreach (string filePath in Directory.GetFiles(inputPath))
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (Image image = Image.Load(filePath))
                {
                    int newWidth = image.Width - 10;
                    int newHeight = image.Height - 10;

                    if (newWidth <= 0 || newHeight <= 0)
                    {
                        Console.Error.WriteLine($"Image too small to crop: {filePath}");
                        continue;
                    }

                    var cropRect = new Aspose.Imaging.Rectangle(5, 5, newWidth, newHeight);
                    image.Crop(cropRect);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                    string outFile = Path.Combine(outputPath, fileNameWithoutExt + ".png");

                    Directory.CreateDirectory(Path.GetDirectoryName(outFile));

                    var pngOptions = new PngOptions();
                    image.Save(outFile, pngOptions);
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
 * 1. When you need to prepare a set of product photos for an e‑commerce site by removing a uniform border and saving them as lightweight PNG files.
 * 2. When a desktop application must automatically process scanned documents, trim a 5‑pixel margin, and store the results in PNG for consistent display.
 * 3. When a batch job has to convert legacy image assets to PNG while ensuring all images have the same cropped dimensions for a mobile app.
 * 4. When you want to generate thumbnail‑ready PNGs from a folder of mixed‑format images, cropping the edges to eliminate unwanted frames.
 * 5. When a server‑side service processes user‑uploaded pictures, strips a small border, and saves them in PNG to preserve transparency and reduce file size.
 */
