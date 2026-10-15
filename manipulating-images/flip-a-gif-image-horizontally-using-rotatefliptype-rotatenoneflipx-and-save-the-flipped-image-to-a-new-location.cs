// HOW-TO: Flip a GIF Horizontally Using Aspose.Imaging RotateFlip in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/input.gif";
            string outputPath = "output/output_flipped.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
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
 * 1. When you need to create a mirrored version of an animated GIF for a web banner without altering the original file.
 * 2. When a game developer wants to flip character sprites stored as GIFs to face the opposite direction at runtime.
 * 3. When a marketing tool generates personalized GIF ads and must horizontally reverse the image to match a user's layout preferences.
 * 4. When an e‑learning platform automatically adjusts GIF illustrations to align with right‑to‑left language reading direction.
 * 5. When a batch‑processing script must flip multiple GIF files before uploading them to a content delivery network.
 */
