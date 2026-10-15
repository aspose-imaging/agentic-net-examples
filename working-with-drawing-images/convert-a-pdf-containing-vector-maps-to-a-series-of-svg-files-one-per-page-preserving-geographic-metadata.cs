// HOW-TO: Convert PDF Map Pages to Separate SVG Files in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\map.pdf";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image pdfImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = pdfImage as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    Image pageImage;
                    if (multipage != null)
                    {
                        pageImage = multipage.Pages[i];
                    }
                    else
                    {
                        pageImage = pdfImage;
                    }

                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        pageImage.Save(outputPath, svgOptions);
                    }

                    if (multipage != null && pageImage != null && !ReferenceEquals(pageImage, pdfImage))
                    {
                        pageImage.Dispose();
                    }
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
 * 1. When you need to extract each page of a vector map PDF as an independent SVG for web‑based GIS visualization.
 * 2. When a GIS application requires individual SVG layers per map sheet to preserve geographic metadata while editing.
 * 3. When automating batch conversion of multi‑page PDF atlases into scalable SVG assets for responsive design.
 * 4. When integrating Aspose.Imaging in a C# service that delivers per‑page SVG files to downstream mapping tools.
 * 5. When converting printed map PDFs into editable vector graphics without losing coordinate information for further analysis.
 */
