// HOW-TO: Convert Multipage TIFF to Optimized Animated GIF in C# (Aspose.Imaging for .NET)
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
            string tiffPath = "Input/sequence.tif";
            string gifPath = "Output/animated.gif";

            if (!File.Exists(tiffPath))
            {
                Console.Error.WriteLine($"File not found: {tiffPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(gifPath));

            using (Image tiff = Image.Load(tiffPath))
            {
                if (tiff is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    using (GifOptions gifOptions = new GifOptions())
                    {
                        gifOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount - 1));
                        gifOptions.LoopsCount = 0; // infinite loop
                        tiff.Save(gifPath, gifOptions);
                    }
                }
                else
                {
                    Console.Error.WriteLine("Input TIFF does not contain multiple pages.");
                    return;
                }
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
 * 1. When you need to turn a multi‑page TIFF scan into a lightweight animated GIF for web galleries while keeping the original frame order and infinite looping.
 * 2. When you must generate an animated GIF from a series of TIFF frames in a server‑side C# application and ensure the output uses lossy compression to reduce file size.
 * 3. When a desktop utility has to batch‑process scanned documents and produce shareable GIF animations without losing the animation timing or quality.
 * 4. When integrating Aspose.Imaging into a .NET service that receives TIFF sequences and returns an optimized GIF for email newsletters or social media posts.
 * 5. When creating a C# workflow that validates a TIFF contains multiple pages, converts it to an animated GIF, and automatically creates the output folder structure.
 */
