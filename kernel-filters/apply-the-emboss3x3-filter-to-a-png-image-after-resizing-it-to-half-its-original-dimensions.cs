// HOW-TO: Resize PNG to Half Size and Apply Emboss Filter in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (PngImage png = (PngImage)Image.Load(inputPath))
            {
                int newWidth = png.Width / 2;
                int newHeight = png.Height / 2;
                png.Resize(newWidth, newHeight);

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

                png.Filter(png.Bounds, filterOptions);
                png.Save(outputPath);
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
 * 1. When you need to generate smaller preview thumbnails of PNG graphics while adding a stylized emboss effect for a web gallery.
 * 2. When preparing product images for a mobile app, you may resize them to half their original dimensions and apply an emboss filter to enhance visual depth.
 * 3. When creating printable assets, you might reduce PNG file size for faster upload and use an emboss filter to give the image a subtle 3‑D appearance.
 * 4. When processing user‑uploaded PNGs on a server, you can automatically shrink them and apply an emboss effect before storing them in a content‑delivery network.
 * 5. When building a desktop photo‑editing tool in C#, you can use Aspose.Imaging to resize PNG files and apply the Emboss3x3 convolution filter as part of an image‑enhancement pipeline.
 */
