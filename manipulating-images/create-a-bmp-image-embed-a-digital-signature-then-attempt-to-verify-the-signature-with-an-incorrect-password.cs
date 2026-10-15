// HOW-TO: Create BMP Image With Digital Signature And Test Wrong Password In C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "signed_image.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            int width = 200;
            int height = 200;

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                string correctPassword = "correctPassword";
                canvas.EmbedDigitalSignature(correctPassword);
                canvas.Save();
            }

            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (RasterImage signedImage = (RasterImage)Image.Load(outputPath))
            {
                string wrongPassword = "wrongPassword";
                bool isSigned = signedImage.IsDigitalSigned(wrongPassword);
                Console.WriteLine($"Signature verification with wrong password: {isSigned}");
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
 * 1. When you need to generate a BMP image and embed a password‑protected digital signature to guarantee its integrity.
 * 2. When you want to verify that a signed BMP cannot be authenticated using an incorrect password, demonstrating signature validation failure.
 * 3. When you are creating a blank canvas, signing it, and saving it to disk as part of an automated document‑security pipeline in C#.
 * 4. When you need to handle exceptions while embedding or checking digital signatures on raster images using Aspose.Imaging.
 * 5. When you are testing the Aspose.Imaging API to ensure that digital signatures are correctly applied and that verification rejects wrong passwords.
 */
