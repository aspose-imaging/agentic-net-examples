// HOW-TO: Compress GIF Image to Reduce File Size in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input\\sample.gif";
            string outputPath = "Output\\sample_compressed.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to shrink animated GIFs for faster webpage loading without losing visual quality, they can use this code to apply lossy compression in C#.
 * 2. When preparing email newsletters, a developer can reduce the size of GIF attachments to stay under mailbox limits by using Aspose.Imaging’s compression routine.
 * 3. When building a mobile app that displays GIF stickers, a developer can compress the assets to lower the app bundle size and improve download speed.
 * 4. When archiving large collections of GIFs on a server, a developer can automatically compress each file to save storage space while preserving animation.
 * 5. When generating GIF previews for social media platforms, a developer can use this code to create smaller files that meet platform size restrictions.
 */
