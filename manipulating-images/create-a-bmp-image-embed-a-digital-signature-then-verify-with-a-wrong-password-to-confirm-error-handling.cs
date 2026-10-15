// HOW-TO: Create BMP Image, Add Digital Signature, Verify with Wrong Password in C# (Aspose.Imaging for .NET)
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
            // Hardcoded paths
            string inputPath = "original.bmp";
            string signedPath = "signed.bmp";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(signedPath) ?? ".");

            // Create a simple BMP image
            using (RasterImage bmp = (RasterImage)Image.Create(new BmpOptions { BitsPerPixel = 24 }, 256, 256))
            {
                // Optionally fill with a solid color (default is black)
                bmp.Save(inputPath);
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Embed digital signature with correct password
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.EmbedDigitalSignature("CorrectPassword");
                image.Save(signedPath);
            }

            // Verify signed image exists
            if (!File.Exists(signedPath))
            {
                Console.Error.WriteLine($"File not found: {signedPath}");
                return;
            }

            // Attempt verification with wrong password
            using (RasterImage signedImage = (RasterImage)Image.Load(signedPath))
            {
                bool isSigned = signedImage.IsDigitalSigned("WrongPassword");
                Console.WriteLine($"Verification with wrong password: {(isSigned ? "Signed" : "Not signed")}");
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
 * 1. When you need to programmatically generate a BMP file and protect it with a password‑protected digital signature.
 * 2. When you want to embed a digital signature into an image to guarantee its authenticity in a .NET application.
 * 3. When you must confirm that signature verification fails with an incorrect password to handle security errors gracefully.
 * 4. When you are building a workflow that creates, signs, and validates bitmap assets for compliance or audit purposes.
 * 5. When you need to demonstrate error handling for digital signature verification in image‑processing tutorials or unit tests.
 */
