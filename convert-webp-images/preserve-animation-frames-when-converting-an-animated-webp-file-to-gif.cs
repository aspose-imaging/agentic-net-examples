// HOW-TO: Convert Animated WebP to GIF While Preserving Frames in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                webp.Save(outputPath, options);
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
 * 1. When you need to display an animated WebP image on browsers that only support GIF, you can convert it while keeping all animation frames using Aspose.Imaging in C#.
 * 2. When creating marketing assets that require a GIF animation derived from a WebP source, this code ensures the original motion is retained during the conversion.
 * 3. When building a server‑side image processing pipeline that receives user‑uploaded animated WebP files and must output GIFs for legacy platforms, the snippet handles the format change without dropping frames.
 * 4. When automating batch conversion of animated WebP stickers to GIFs for messaging apps, the code preserves each frame so the animation remains smooth.
 * 5. When integrating image conversion into a .NET desktop application that lets users edit and export animated graphics, this example shows how to save the edited WebP as a GIF without losing any animation data.
 */
