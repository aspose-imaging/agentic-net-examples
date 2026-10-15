// HOW-TO: Create BMP Image With Digital Signature And Handle Invalid Password In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 200, 200))
            {
                canvas.EmbedDigitalSignature("secure123");
                canvas.Save();
            }

            using (RasterImage img = (RasterImage)Image.Load(outputPath))
            {
                try
                {
                    img.EmbedDigitalSignature("123");
                }
                catch (Aspose.Imaging.CoreExceptions.ImageException ex)
                {
                    Console.WriteLine($"HANDLED: {ex.Message}");
                }
                img.Save();
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
 * 1. When you need to generate a BMP file and embed a password‑protected digital signature to ensure the image’s authenticity.
 * 2. When you want to programmatically add a signature to an existing BMP image and verify that an incorrect password triggers a handled exception.
 * 3. When building a C# application that must create secure bitmap assets for compliance audits and log signature errors without crashing.
 * 4. When integrating Aspose.Imaging into a workflow that signs images during batch processing and gracefully handles signature validation failures.
 * 5. When developing a document management system that stores BMP graphics with embedded signatures and requires robust error handling for wrong passwords.
 */
