// HOW-TO: Embed Digital Signature in Images Over Minimum Pixel Count with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.png";
            string password = "myPass";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (image.Width * image.Height < 16384)
                {
                    Console.Error.WriteLine("Image does not meet minimum pixel count requirement.");
                    return;
                }

                if (password == null || password.Length < 4)
                {
                    Console.Error.WriteLine("Password must be at least 4 characters long.");
                    return;
                }

                image.EmbedDigitalSignature(password);
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
 * 1. When you need to protect high‑resolution photos by adding a password‑protected digital signature only if they are large enough to meet a quality threshold.
 * 2. When a workflow requires converting JPEG files to PNG while embedding a digital signature for compliance, but skips small images that don't meet the pixel count.
 * 3. When you want to automate image security in a batch process, ensuring that only images larger than 16,384 pixels are signed with a user‑defined password.
 * 4. When integrating Aspose.Imaging into a C# application that must verify image size before applying a digital signature to meet regulatory standards.
 * 5. When building a document management system that stores signed PNGs and needs to reject undersized images to conserve storage and maintain integrity.
 */
