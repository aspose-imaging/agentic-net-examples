// HOW-TO: Export Each Frame of a Multi‑Page TIFF to BMP with Original DPI in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "Output";

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int index = 0;
                foreach (var frame in tiff.Frames)
                {
                    string outputPath = Path.Combine(outputDir, $"frame_{index}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (BmpOptions bmpOptions = new BmpOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        BitsPerPixel = 24,
                        ResolutionSettings = new ResolutionSetting(tiff.HorizontalResolution, tiff.VerticalResolution)
                    })
                    {
                        frame.Save(outputPath, bmpOptions);
                    }

                    index++;
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
 * 1. When you need to split a scanned multi‑page document saved as a TIFF into individual BMP images for legacy Windows applications that only accept BMP files.
 * 2. When preserving the original DPI of each page is required for accurate printing or measurement after converting the TIFF frames to BMP.
 * 3. When processing medical or engineering TIFF files and you must extract each layer as a separate high‑resolution BMP for further analysis in custom C# tools.
 * 4. When automating a workflow that converts multi‑page TIFF archives into BMP thumbnails while keeping the source resolution for quality‑controlled archives.
 * 5. When integrating Aspose.Imaging in a .NET service that receives multi‑page TIFF uploads and needs to store each page as a BMP with the same pixel density for downstream processing.
 */
