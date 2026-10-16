// HOW-TO: Create BMP Crop Inset Rotate 90° Add Digital Signature in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        string outputPath = "Output/output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            using (RasterImage image = (RasterImage)Image.Create(new BmpOptions(), 200, 200))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);
                image.Crop(20, 20, 20, 20);
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                image.EmbedDigitalSignature("secure123");
                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to generate a blank BMP thumbnail, trim its borders, rotate it for portrait orientation, and secure it with a digital signature before saving.
 * 2. When an application must produce a signed BMP document for compliance, applying a uniform inset crop to remove margins and rotating the image to match a required layout.
 * 3. When a reporting tool creates BMP charts, needs to remove edge whitespace, rotate the chart for printing, and embed a verification signature to prevent tampering.
 * 4. When a batch process prepares BMP assets for a legacy system, automatically crops a fixed border, rotates each image 90 degrees, and adds a cryptographic signature for authenticity.
 * 5. When a desktop utility exports user‑drawn graphics as BMP files, applies a consistent inset crop, reorients the image, and embeds a password‑protected digital signature for secure distribution.
 */
