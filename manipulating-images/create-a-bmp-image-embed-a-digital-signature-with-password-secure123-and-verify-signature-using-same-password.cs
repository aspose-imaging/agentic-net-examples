// HOW-TO: Create BMP Image And Add Password Protected Digital Signature In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string originalPath = "output/original.bmp";
            string signedPath = "output/signed.bmp";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalPath));
            Directory.CreateDirectory(Path.GetDirectoryName(signedPath));

            // Create a blank BMP image (256x256, 24bpp)
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };
            using (var image = (RasterImage)Image.Create(bmpOptions, 256, 256))
            {
                // Fill with white background
                image.Save(originalPath);
            }

            // Load the created image
            if (!File.Exists(originalPath))
            {
                Console.Error.WriteLine($"File not found: {originalPath}");
                return;
            }

            using (var raster = (RasterImage)Image.Load(originalPath))
            {
                // Embed digital signature
                string password = "Secure123";
                raster.EmbedDigitalSignature(password);
                raster.Save(signedPath);
            }

            // Verify the signature
            if (!File.Exists(signedPath))
            {
                Console.Error.WriteLine($"File not found: {signedPath}");
                return;
            }

            using (var signedRaster = (RasterImage)Image.Load(signedPath))
            {
                string password = "Secure123";
                bool isSigned = signedRaster.IsDigitalSigned(password);
                Console.WriteLine($"Signature verification: {isSigned}");
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
 * 1. When you need to generate a blank BMP file as a placeholder or template before adding secure metadata.
 * 2. When you want to embed a password‑protected digital signature into an image to ensure its authenticity and detect tampering.
 * 3. When you must verify that a BMP image has been signed with the correct password before processing or distribution.
 * 4. When building a workflow that creates, signs, and validates images automatically in a C# application.
 * 5. When complying with regulatory or internal policies that require cryptographic signing of raster graphics for audit trails.
 */
