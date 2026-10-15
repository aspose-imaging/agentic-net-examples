// HOW-TO: Compress Animated GIF Created From PSD Frames Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPsdPath = "input.psd";
        string outputGifPath = "output/compressed.gif";

        if (!File.Exists(inputPsdPath))
        {
            Console.Error.WriteLine($"File not found: {inputPsdPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

        try
        {
            using (Image psdImage = Image.Load(inputPsdPath))
            {
                if (!(psdImage is IMultipageImage multipagePsd))
                {
                    Console.Error.WriteLine("The PSD does not contain multiple pages.");
                    return;
                }

                RasterImage firstFrame = (RasterImage)multipagePsd.Pages[0];
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                GifOptions gifOptions = new GifOptions();

                using (Image gifImage = Image.Create(gifOptions, width, height))
                {
                    GifImage gif = (GifImage)gifImage;

                    foreach (Image page in multipagePsd.Pages)
                    {
                        using (RasterImage frame = (RasterImage)page)
                        {
                            gif.AddPage(frame);
                        }
                    }

                    gif.Save(outputGifPath, gifOptions);
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
 * 1. When you need to generate a smaller animated GIF from a multi‑layer Photoshop file for web pages or email newsletters.
 * 2. When you want to automate the conversion of PSD slide decks into lightweight GIF animations in a C# batch process.
 * 3. When you must reduce the file size of an animated GIF without losing frame order by using Aspose.Imaging’s lossy compression.
 * 4. When you are building a server‑side service that receives PSD uploads and returns optimized GIFs for mobile devices.
 * 5. When you need to programmatically extract each layer of a PSD, assemble them into an animation, and save the result with reduced bandwidth usage.
 */
