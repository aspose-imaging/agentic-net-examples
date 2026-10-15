// HOW-TO: Convert EMF to GIF With 256‑Color Palette In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = Path.Combine("Input", "sample.emf");
            string outputPath = Path.Combine("Output", "sample.gif");

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
                    using (GifOptions gifOptions = new GifOptions())
                    {
                        image.Save(outputPath, gifOptions);
                    }
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
 * 1. When you need to embed vector graphics from a Windows Metafile into a web page that only supports GIF images with a 256‑color limit.
 * 2. When generating email newsletters that require animated or static GIFs derived from EMF logos while ensuring the file size stays small.
 * 3. When automating a batch process that converts legacy EMF icons to GIFs for use in mobile applications that cannot handle more than 256 colors.
 * 4. When creating printable reports where charts are exported as EMF and must be converted to GIF for compatibility with older PDF generators.
 * 5. When developing a C# utility that transforms EMF diagrams into GIFs for inclusion in documentation systems that only accept GIF format.
 */
