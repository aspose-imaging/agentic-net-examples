// HOW-TO: Rotate BMP Image 180 Degrees, Add Digital Signature, Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.png";
            string password = "Secret123";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                image.EmbedDigitalSignature(password);
                PngOptions options = new PngOptions();
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
 * 1. When you need to flip a scanned BMP document upside‑down, protect it with a password‑based digital signature, and deliver it as a lossless PNG for web publishing.
 * 2. When an archival system requires converting legacy BMP assets to PNG while ensuring the image orientation is corrected and the file is cryptographically signed for integrity verification.
 * 3. When a medical imaging workflow must rotate patient scans, embed a secure signature to meet compliance, and store the result in a widely supported PNG format.
 * 4. When a batch process needs to re‑orient product photos, add a tamper‑evident signature, and output PNG files for inclusion in an e‑commerce catalog.
 * 5. When a desktop application must programmatically rotate a BMP logo, sign it with a secret key, and save it as PNG for use in reports or presentations.
 */
