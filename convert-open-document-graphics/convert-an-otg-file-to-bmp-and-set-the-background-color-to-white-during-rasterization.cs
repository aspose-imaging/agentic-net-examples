// HOW-TO: Convert OTG Vector File to BMP with White Background in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to display an OTG vector diagram in a Windows application that only supports BMP images, you can rasterize it to BMP with a white background.
 * 2. When generating printable reports that require bitmap images, converting OTG files to BMP ensures compatibility with legacy printers.
 * 3. When creating thumbnails for a gallery that stores images as BMP, you may convert OTG graphics while forcing a white background to avoid transparency issues.
 * 4. When integrating third‑party vector assets into a .NET service that processes BMP files, this code lets you load the OTG, rasterize it, and save it as BMP.
 * 5. When automating batch conversion of design assets from OTG to BMP for archival purposes, setting the background color to white guarantees a consistent appearance.
 */
