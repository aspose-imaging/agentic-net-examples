// HOW-TO: How To Crop, Resize And Digitally Sign A PNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "Output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Crop using a Rectangle
                Rectangle cropRect = new Rectangle(50, 50, 200, 200);
                image.Crop(cropRect);

                // Resize to 400x400
                image.Resize(400, 400, ResizeType.NearestNeighbourResample);

                // Embed digital signature with a valid password
                image.EmbedDigitalSignature("secure123");

                // Save the result as PNG
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, options);
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
 * 1. When you need to prepare a user‑uploaded PNG thumbnail by cropping a specific area, scaling it to 400 × 400 pixels, and securing it with a digital signature for tamper‑evidence.
 * 2. When generating product catalog images that must be uniformly sized, contain only the relevant portion of the original PNG, and be signed to verify authenticity before publishing online.
 * 3. When creating compliance‑ready documents where each embedded PNG must be cropped to a region of interest, resized to a standard dimension, and digitally signed to meet regulatory audit requirements.
 * 4. When building a C# web service that receives high‑resolution PNGs, extracts a logo via cropping, resizes it for UI display, and embeds a signature to ensure the image has not been altered during transmission.
 * 5. When automating batch processing of PNG assets for a mobile app, needing to cut out a defined rectangle, resize to the app’s required 400 × 400 size, and add a password‑protected digital signature for secure distribution.
 */
