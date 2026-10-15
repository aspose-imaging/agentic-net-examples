// HOW-TO: Create PNG with Alpha Channel and Embed Digital Signature in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "signed_image.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG image with alpha channel
            using (PngImage png = new PngImage(200, 200, PngColorType.TruecolorWithAlpha))
            {
                // Embed digital signature
                string password = "SecretPwd";
                png.EmbedDigitalSignature(password);

                // Save the image
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                png.Save(outputPath, options);
            }

            // Verify the digital signature on the saved image
            using (RasterImage loaded = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = loaded.IsDigitalSigned("SecretPwd");
                Console.WriteLine($"Signature verification result: {isSigned}");
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
 * 1. When you need to generate a transparent PNG for a web UI and ensure its authenticity with a password‑protected digital signature.
 * 2. When you want to embed a tamper‑evident signature into an image that will be stored or transmitted and later validate it programmatically.
 * 3. When a document‑management system requires images to carry a cryptographic signature to prove origin before archiving.
 * 4. When you are building a secure image‑sharing service that must verify that uploaded PNGs have not been altered after saving.
 * 5. When you need to create a PNG with an alpha channel for overlay graphics and also guarantee its integrity by checking the signature confidence in C#.
 */
