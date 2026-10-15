// HOW-TO: Convert WebP Image to Animated GIF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When you need to display a WebP picture on legacy browsers that only support GIF, you can convert it with Aspose.Imaging in C#.
 * 2. When generating animated thumbnails for a web gallery that requires GIF format, you can load the original WebP and save it as GIF.
 * 3. When an email marketing system only accepts GIF attachments, you can transform user‑uploaded WebP files to GIF before sending.
 * 4. When a mobile app stores screenshots as WebP but the server‑side processing pipeline expects GIF, you can perform the conversion using Image.Load and Image.Save.
 * 5. When automating batch conversion of WebP assets to GIF for a game’s asset pipeline, this code provides a simple C# solution.
 */
