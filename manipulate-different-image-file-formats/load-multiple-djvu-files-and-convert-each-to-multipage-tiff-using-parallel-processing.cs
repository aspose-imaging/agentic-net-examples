// HOW-TO: Convert Multiple DjVu Files to Multipage TIFF in Parallel with C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = { "input1.djvu", "input2.djvu" };
            string[] outputPaths = { "output\\output1.tif", "output\\output2.tif" };

            Enumerable.Range(0, inputPaths.Length).AsParallel().ForAll(i =>
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();
                    djvu.Save(outputPath, tiffOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert scanned DjVu documents into searchable multipage TIFF files for archival while utilizing all CPU cores to speed up the process.
 * 2. When a document‑management system receives DjVu uploads and must store them as LZW‑compressed TIFFs for compatibility with downstream Windows applications.
 * 3. When you are building a server‑side service that processes multiple DjVu files concurrently to generate multipage TIFFs for printing or OCR pipelines.
 * 4. When you want to automate the conversion of a collection of DjVu ebooks into multipage TIFFs for e‑reader devices that only support TIFF format.
 * 5. When you must ensure each output TIFF is placed in a specific folder structure, creating missing directories automatically during parallel conversion of DjVu files.
 */
