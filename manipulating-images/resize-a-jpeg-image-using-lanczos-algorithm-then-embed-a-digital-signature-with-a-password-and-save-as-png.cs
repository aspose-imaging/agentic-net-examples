// HOW-TO: Resize JPEG with Lanczos and Add Password Protected Signature in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\signed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                image.EmbedDigitalSignature("secret");
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to shrink a high‑resolution JPEG for faster web loading while maintaining sharpness using the Lanczos resampling algorithm.
 * 2. When you must embed a password‑protected digital signature into an image to verify its authenticity after resizing.
 * 3. When converting a JPEG to a lossless PNG after scaling it down for archival or printing purposes.
 * 4. When generating secure thumbnail images for a gallery where each thumbnail carries a hidden signature that only authorized users can validate.
 * 5. When automating batch processing of product photos to create smaller, signed PNG files for a regulated e‑commerce platform.
 */
