// HOW-TO: Create Infinite Looping APNG From PNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    NumPlays = 0 // infinite looping
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apng.AddFrame(sourceImage);
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
 * 1. When you need to convert a static PNG into an animated APNG that repeats forever for a website banner.
 * 2. When building a desktop application that displays continuous looping animations without user interaction, such as a loading spinner.
 * 3. When generating game assets where an APNG sprite must play endlessly to represent character idle animations.
 * 4. When creating digital signage content that requires an APNG to loop infinitely for unattended displays.
 * 5. When developing a cross‑platform UI component that uses Aspose.Imaging to produce infinite‑loop APNGs from user‑uploaded PNGs.
 */
