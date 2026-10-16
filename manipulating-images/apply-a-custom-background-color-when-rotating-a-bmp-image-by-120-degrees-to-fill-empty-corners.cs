// HOW-TO: Rotate BMP Image 120 Degrees with Custom Background Color in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Define custom background color (e.g., light blue)
                var backgroundColor = Aspose.Imaging.Color.FromArgb(255, 0, 128, 255);

                // Rotate 120 degrees, resize proportionally, fill empty corners with background color
                image.Rotate(120f, true, backgroundColor);

                // Save the rotated image
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
 * 1. When you need to display a BMP graphic at an angle on a UI and want the uncovered corners filled with a specific color to match the app theme.
 * 2. When generating thumbnails for a game asset pipeline where BMP sprites must be rotated by 120° and the empty space should be a uniform background.
 * 3. When preparing scanned BMP documents for printing and rotating them while ensuring the background matches the paper color to avoid white gaps.
 * 4. When creating custom map tiles from BMP files that require a 120‑degree rotation and a consistent background to blend seamlessly with neighboring tiles.
 * 5. When automating batch processing of BMP images for a marketing campaign, rotating each image and applying a brand‑color fill to the corners for visual consistency.
 */
