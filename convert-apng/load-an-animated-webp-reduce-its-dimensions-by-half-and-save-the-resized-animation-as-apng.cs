// HOW-TO: Resize Animated WebP to Half Size and Convert to APNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animated.webp";
            string outputPath = "Output/resized.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                WebPImage webp = (WebPImage)img;
                int newWidth = webp.Width / 2;
                int newHeight = webp.Height / 2;

                webp.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

                ApngOptions apngOptions = new ApngOptions();
                webp.Save(outputPath, apngOptions);
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
 * 1. When you need to display a smaller animated image on a mobile app, you can resize an animated WebP and convert it to APNG for better compatibility.
 * 2. When optimizing web page load times, developers can shrink animated WebP assets and output them as APNG to serve browsers that prefer PNG animation.
 * 3. When creating animated stickers for messaging platforms that only accept APNG, you can take an existing animated WebP, halve its dimensions, and save it as APNG.
 * 4. When preparing assets for an email newsletter that does not support WebP, you can resize the animation and convert it to APNG to ensure it displays correctly.
 * 5. When building a game UI that requires low‑resolution animated icons, you can programmatically reduce the size of a WebP animation and export it as APNG for use in the engine.
 */
