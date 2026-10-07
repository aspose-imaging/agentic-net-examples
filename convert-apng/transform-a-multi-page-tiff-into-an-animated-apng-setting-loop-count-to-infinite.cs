// HOW-TO: Convert Multi‑Page TIFF to Infinite Loop Animated APNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\multi.tif";
            string outputPath = "Output\\animated.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    NumPlays = 0
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, tiff.Width, tiff.Height))
                {
                    apng.RemoveAllFrames();

                    foreach (TiffFrame frame in tiff.Frames)
                    {
                        Color[] pixels = tiff.LoadPixels(frame.Bounds);

                        using (PngOptions pngOpts = new PngOptions
                        {
                            Source = new FileCreateSource(Path.GetTempFileName(), false)
                        })
                        using (PngImage temp = (PngImage)Image.Create(pngOpts, frame.Width, frame.Height))
                        {
                            temp.SavePixels(new Rectangle(0, 0, frame.Width, frame.Height), pixels);
                            apng.AddFrame(temp);
                        }
                    }

                    apng.Save();
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
 * 1. When you need to display a multi‑page scanned document as a continuously looping animation on a website, you can convert the TIFF to an APNG using C# and Aspose.Imaging.
 * 2. When generating animated product previews from a series of TIFF frames for an e‑commerce app, this code creates an APNG that repeats indefinitely.
 * 3. When creating a looping banner or slideshow from high‑resolution TIFF assets for a digital signage system, the conversion to an APNG simplifies playback in browsers.
 * 4. When automating the conversion of medical imaging TIFF stacks into lightweight animated PNGs for quick review in a desktop application, the infinite loop ensures the sequence stays visible.
 * 5. When building a reporting tool that needs to embed an animated representation of multi‑page charts stored as TIFFs, this snippet produces an APNG that can be embedded in PDFs or HTML.
 */
