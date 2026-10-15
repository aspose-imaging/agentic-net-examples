// HOW-TO: Convert DjVu Document to PNG Pages in Parallel with C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.djvu";
            string outputFolder = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvuImage.PageCount;

                Parallel.ForEach(Enumerable.Range(0, pageCount), pageIndex =>
                {
                    string outputPath = Path.Combine(outputFolder, $"page_{pageIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions(pageIndex)
                    };

                    djvuImage.Save(outputPath, pngOptions);
                });
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
 * 1. When you need to extract every page of a multi‑page DjVu file as separate PNG images for web preview.
 * 2. When you want to speed up batch conversion of large DjVu documents by using multiple CPU cores in a C# application.
 * 3. When you are building an automated pipeline that processes scanned books stored as DjVu and stores each page as a lossless PNG for archival.
 * 4. When you must generate thumbnail images for each page of a DjVu file on a server without blocking other operations.
 * 5. When you are integrating Aspose.Imaging into a desktop tool that converts user‑uploaded DjVu files into PNG sequences for further editing.
 */
