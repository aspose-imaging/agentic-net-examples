// HOW-TO: Extract Each Page from Multi‑Page SVG and Save as Separate EMF Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";

            using (Image image = Image.Load(inputPath))
            {
                Directory.CreateDirectory(outputDirectory);

                int pageCount = 1;
                if (image is IMultipageImage multipage)
                {
                    pageCount = multipage.PageCount;
                }

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.emf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    EmfOptions emfOptions = new EmfOptions();

                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    emfOptions.VectorRasterizationOptions = vectorOptions;

                    emfOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i));

                    image.Save(outputPath, emfOptions);
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
 * 1. When you need to convert each layer of a multi‑page SVG diagram into individual EMF files for high‑quality vector printing.
 * 2. When generating separate vector assets from a multi‑page SVG to embed in Microsoft Office documents using C#.
 * 3. When automating the extraction of SVG pages for use in CAD or GIS applications that require EMF format.
 * 4. When creating per‑page vector graphics for a reporting system that outputs charts as EMF for scalable PDFs.
 * 5. When processing batch SVG files on a server to produce individual EMF files for downstream vector‑based workflows.
 */
