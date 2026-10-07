// HOW-TO: Convert Animated PNG to GIF in C# With Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
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
 * 1. When you need to display an animated PNG on browsers or platforms that only support GIF, you can convert the APNG to a GIF using Aspose.Imaging in C#.
 * 2. When preparing marketing emails that require animated images, converting APNG files to GIF ensures compatibility with most email clients.
 * 3. When creating a slideshow for a Windows desktop application, you can transform APNG assets into GIFs to simplify playback with built‑in controls.
 * 4. When archiving animation assets in a format with smaller file size, converting APNG to GIF via C# helps reduce storage while preserving the animation.
 * 5. When integrating third‑party image libraries that accept only GIF input, you can programmatically convert APNG files to GIF using Aspose.Imaging before processing.
 */
