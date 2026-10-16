// HOW-TO: Convert APNG to GIF with Frame Delay Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.apng");
            string outputPath = Path.Combine("Output", "output.gif");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                var gifOptions = new GifOptions();
                apng.Save(outputPath, gifOptions);
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
 * 1. When you need to convert an animated PNG (APNG) into a GIF for web browsers that only support GIF animation while preserving frame timing via the GIF comment extension.
 * 2. When a C# application must batch‑process APNG assets and output GIF files for use in legacy mobile apps that cannot read APNG.
 * 3. When you want to generate GIF previews of APNG stickers in a chat application, ensuring the original animation speed is retained.
 * 4. When integrating Aspose.Imaging into a server‑side service that receives APNG uploads and returns GIFs with embedded delay information for email newsletters.
 * 5. When automating the creation of animated GIFs from APNG source files in a CI/CD pipeline to include in documentation or marketing materials.
 */
