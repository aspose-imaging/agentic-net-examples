// HOW-TO: Rotate JPEG 90 Degrees And Save As New File Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
 * 1. When you need to automatically correct the orientation of JPEG photos taken in portrait mode before uploading them to a web gallery using Aspose.Imaging in C#.
 * 2. When a batch job must rotate scanned JPEG documents 90 degrees to match the required layout for printing and save the results to a designated folder.
 * 3. When an application generates thumbnails and must store the rotated JPEG as a separate file for archival purposes with minimal code.
 * 4. When integrating with a mobile app that sends images sideways and the server must rotate the JPEG to standard orientation using C# and Aspose.Imaging.
 * 5. When preparing product images for an e‑commerce site that requires all JPEGs to be consistently oriented and saved in a specific output directory.
 */
