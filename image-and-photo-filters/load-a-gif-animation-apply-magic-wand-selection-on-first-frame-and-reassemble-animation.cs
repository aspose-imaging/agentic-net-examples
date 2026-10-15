// HOW-TO: Apply Magic Wand Selection to First Frame of GIF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output\\output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Set active frame to the first frame
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];

                // Apply Magic Wand selection on the active frame
                RasterImage frame = (RasterImage)gif.ActiveFrame;
                MagicWandTool.Select(frame, new MagicWandSettings(10, 10))
                    .Apply();

                // Save the modified GIF animation
                GifOptions gifOptions = new GifOptions();
                gif.Save(outputPath, gifOptions);
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
 * 1. When you need to isolate a specific region in the first frame of an animated GIF for further editing or masking using Aspose.Imaging.
 * 2. When you want to programmatically remove the background from the initial frame of a GIF before adding text or graphics overlays in C#.
 * 3. When you are building a batch process that applies a magic wand selection to the first frame of multiple GIF files to prepare them for compositing.
 * 4. When you need to create a GIF where only the first frame has a selective effect while preserving the rest of the animation unchanged.
 * 5. When you are developing a web service that receives GIFs, selects a region in the first frame with a tolerance setting, and returns the modified animation.
 */
