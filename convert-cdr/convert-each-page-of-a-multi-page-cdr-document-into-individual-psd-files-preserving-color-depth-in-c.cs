// HOW-TO: Convert Multi‑Page CDR to Separate PSD Files in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.psd");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (PsdOptions options = new PsdOptions())
                        {
                            options.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));
                            image.Save(outputPath, options);
                        }
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "page_1.psd");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PsdOptions options = new PsdOptions())
                    {
                        image.Save(outputPath, options);
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
 * 1. When a design team needs to extract each page of a CorelDRAW (CDR) file as high‑color‑depth Photoshop (PSD) layers for further editing in Photoshop.
 * 2. When an automated workflow must batch‑process multi‑page CDR documents and generate individual PSD files for archival or publishing pipelines.
 * 3. When a web service receives CDR uploads and must split them into separate PSD images to display each page on a website without losing color information.
 * 4. When a conversion utility has to handle both single‑page and multi‑page CDR files, ensuring each page is saved as a standalone PSD using Aspose.Imaging in C#.
 * 5. When a developer integrates image conversion into a .NET application and needs to preserve the original color depth while exporting each CDR page to Photoshop format.
 */
