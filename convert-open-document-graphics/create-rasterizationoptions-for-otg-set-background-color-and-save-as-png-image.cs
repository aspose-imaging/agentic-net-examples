// HOW-TO: Convert OTG Vector Image to PNG with White Background in C# (Aspose.Imaging for .NET)
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

namespace OtgToPngConverter
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.otg";
            string outputPath = "output.png";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var rasterOptions = new OtgRasterizationOptions();
                    rasterOptions.BackgroundColor = Aspose.Imaging.Color.White;

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    image.Save(outputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display an OTG vector diagram on a web page that only supports raster PNG images, you can rasterize it with a white background using Aspose.Imaging in C#.
 * 2. When generating printable reports that embed OTG graphics, converting them to PNG ensures compatibility with PDF generators that require raster images.
 * 3. When automating a batch process that extracts vector assets from legacy OTG files and stores them as PNG thumbnails for a digital asset management system.
 * 4. When creating a mobile app that loads map overlays saved as OTG, converting them to PNG with a solid background avoids transparency issues on devices that don’t support vector formats.
 * 5. When integrating a document workflow that receives OTG files from designers, converting them to PNG with a predefined background color standardizes the visual appearance for downstream editors.
 */
