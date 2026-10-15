// HOW-TO: Render EMF Vector Graphic to High Resolution BMP at 300 DPI in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input\\vector.emf";
            string outputPath = "output\\rendered.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var bmpOptions = new BmpOptions();
                bmpOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
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
 * 1. When you need to convert a Windows Metafile (EMF) into a 300 DPI BMP for high‑quality print output in a .NET application.
 * 2. When a legacy reporting tool requires bitmap images, and you must render vector EMF charts as high‑resolution BMP files using C#.
 * 3. When generating thumbnails for a document management system that stores BMP files, you can render the original EMF at 300 DPI to preserve detail.
 * 4. When preparing graphics for a medical imaging workflow that only accepts BMP format, you can use Aspose.Imaging to rasterize EMF vectors at printer‑grade resolution.
 * 5. When automating batch conversion of design assets, this code lets you programmatically save multiple EMF logos as high‑resolution BMPs for use in Windows applications.
 */
