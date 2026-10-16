// HOW-TO: Embed and Verify Digital Signature in PNG with Password in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";
            string password = "abcd";

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

            using (RasterImage signedImage = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = signedImage.IsDigitalSigned(password);
                Console.WriteLine(isSigned ? "Signature verified." : "Signature not found.");
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
 * 1. When you need to protect a PNG logo from unauthorized modification by embedding a password‑protected digital signature before publishing it online.
 * 2. When a medical imaging system must ensure that diagnostic PNG scans have not been altered, you can embed and later verify a signature using Aspose.Imaging in C#.
 * 3. When a document management workflow requires proof of origin for PNG screenshots, you can add a four‑character password signature and check it during automated processing.
 * 4. When delivering product packaging artwork as PNG files, embedding a digital signature lets downstream partners verify authenticity without extra metadata files.
 * 5. When building a secure archival solution for PNG assets, you can embed a password‑based signature at save time and later confirm integrity during retrieval.
 */
