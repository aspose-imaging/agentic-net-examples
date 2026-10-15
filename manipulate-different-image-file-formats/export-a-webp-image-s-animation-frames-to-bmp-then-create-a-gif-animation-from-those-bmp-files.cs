// HOW-TO: Convert Animated WebP to GIF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputWebP = "input.webp";
            string outputGif = "output/output.gif";

            if (!File.Exists(inputWebP))
            {
                Console.Error.WriteLine($"File not found: {inputWebP}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputGif);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputWebP))
            {
                image.Save(outputGif, new GifOptions());
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
 * 1. When you need to display an animated WebP on platforms that only support GIF, you can convert it to a GIF using Aspose.Imaging in C#.
 * 2. When a web application must generate GIF previews of user‑uploaded animated WebP files, this code provides a simple server‑side conversion.
 * 3. When migrating legacy assets from WebP to GIF for email newsletters, the snippet automates the batch conversion in a .NET environment.
 * 4. When building a desktop tool that extracts animation frames from a WebP and saves them as a single GIF, this approach handles the format change without manual frame handling.
 * 5. When integrating image processing into a content‑management system that stores images as WebP but needs GIF output for social media sharing, the code performs the conversion programmatically.
 */
