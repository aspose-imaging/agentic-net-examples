// HOW-TO: Resize Image to Fit 1024x1024 Box Using Nearest Neighbor in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                double scaleX = 1024.0 / originalWidth;
                double scaleY = 1024.0 / originalHeight;
                double scale = Math.Min(scaleX, scaleY);
                if (scale > 1.0) scale = 1.0; // Do not upscale

                int newWidth = (int)Math.Round(originalWidth * scale);
                int newHeight = (int)Math.Round(originalHeight * scale);

                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
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
 * 1. When you need to generate thumbnail previews for user‑uploaded photos while preserving aspect ratio and limiting size to 1024 × 1024 pixels.
 * 2. When a web service must downscale large JPEG or PNG files before storing them in a database to save storage space.
 * 3. When an e‑commerce platform wants to ensure product images fit within a fixed square container without distortion, using the fast NearestNeighbour algorithm.
 * 4. When a mobile app processes camera captures on the server and must prevent upscaling while resizing images to a maximum dimension of 1024 pixels.
 * 5. When a batch‑processing script needs to resize a mixed collection of image formats with Aspose.Imaging in C# while maintaining original proportions.
 */
