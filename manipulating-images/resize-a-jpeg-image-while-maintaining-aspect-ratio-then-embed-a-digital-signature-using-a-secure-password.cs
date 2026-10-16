// HOW-TO: Resize JPEG and Embed Password Protected Digital Signature in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";
            string password = "StrongPassword123";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                int maxWidth = 800;
                int maxHeight = 800;

                double ratioX = (double)maxWidth / image.Width;
                double ratioY = (double)maxHeight / image.Height;
                double ratio = Math.Min(ratioX, ratioY);

                int newWidth = image.Width;
                int newHeight = image.Height;

                if (ratio < 1.0)
                {
                    newWidth = (int)(image.Width * ratio);
                    newHeight = (int)(image.Height * ratio);
                }

                image.Resize(newWidth, newHeight);

                if (image is RasterImage rasterImage)
                {
                    if (rasterImage.Width >= 8 && rasterImage.Height >= 8 && rasterImage.Width * rasterImage.Height >= 16384)
                    {
                        rasterImage.EmbedDigitalSignature(password);
                    }
                    else
                    {
                        Console.Error.WriteLine("Image does not meet minimum size requirements for digital signature.");
                    }
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a RasterImage; cannot embed digital signature.");
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
 * 1. When you need to generate smaller web‑ready JPEG thumbnails while ensuring the image can be authenticated later with a password‑protected digital signature.
 * 2. When an e‑commerce platform must compress product photos to a maximum of 800 × 800 pixels and embed a secure signature to prevent unauthorized image manipulation.
 * 3. When a document management system stores scanned JPEGs and requires both size reduction for storage efficiency and a tamper‑evident signature that only authorized users can verify.
 * 4. When a mobile app uploads user‑taken photos to a server, you must resize them to meet API limits and embed a password‑protected signature to guarantee the source’s integrity.
 * 5. When a legal firm archives evidence images, they need to resize large JPEGs for faster retrieval and embed a digital signature with a strong password to maintain chain‑of‑custody compliance.
 */
