// HOW-TO: Embed and Verify Password Protected Digital Signature in Image C# (Aspose.Imaging for .NET)
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

namespace DigitalSignatureDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output.png";
                string password = "StrongPass123";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.EmbedDigitalSignature(password);
                    image.Save(outputPath);
                }

                using (RasterImage verifyImage = (RasterImage)Image.Load(outputPath))
                {
                    bool isSigned = verifyImage.IsDigitalSigned(password);
                    Console.WriteLine($"Signature verification: {isSigned}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to protect a JPEG photo with a password‑protected digital signature before sharing it as a PNG to ensure the recipient can verify its authenticity.
 * 2. When your application must embed a cryptographic signature into scanned documents so that later C# code can confirm they have not been altered.
 * 3. When regulatory compliance requires that images contain a verifiable digital signature using a strong password longer than four characters.
 * 4. When you want to add a tamper‑evident seal to product images in an e‑commerce platform and later programmatically validate the seal during order processing.
 * 5. When a forensic tool needs to embed and later check a password‑protected signature in evidence photos to maintain chain‑of‑custody integrity.
 */
