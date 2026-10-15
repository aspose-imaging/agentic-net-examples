// HOW-TO: Create Multipage TIFF from Multiple PSD Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPsd1 = "psd1.psd";
            string inputPsd2 = "psd2.psd";
            string inputPsd3 = "psd3.psd";
            string outputTiff = "output/multipage.tif";

            if (!File.Exists(inputPsd1)) { Console.Error.WriteLine($"File not found: {inputPsd1}"); return; }
            if (!File.Exists(inputPsd2)) { Console.Error.WriteLine($"File not found: {inputPsd2}"); return; }
            if (!File.Exists(inputPsd3)) { Console.Error.WriteLine($"File not found: {inputPsd3}"); return; }

            int width, height;
            using (Image firstPsd = Image.Load(inputPsd1))
            {
                width = firstPsd.Width;
                height = firstPsd.Height;
            }

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiff));

            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                using (RasterImage psd1 = (RasterImage)Image.Load(inputPsd1))
                {
                    tiff.AddPage(psd1);
                }
                using (RasterImage psd2 = (RasterImage)Image.Load(inputPsd2))
                {
                    tiff.AddPage(psd2);
                }
                using (RasterImage psd3 = (RasterImage)Image.Load(inputPsd3))
                {
                    tiff.AddPage(psd3);
                }

                tiff.Save(outputTiff, tiffOptions);
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
 * 1. When you need to combine several Photoshop PSD files into a single multi‑page TIFF for archival or printing purposes.
 * 2. When generating a document where each page is a separate Photoshop design and must be delivered as one TIFF file.
 * 3. When automating batch conversion of PSD assets into a multi‑page TIFF for use in desktop publishing workflows.
 * 4. When creating a searchable PDF‑like image stack by first merging PSD files into a multi‑page TIFF before further processing.
 * 5. When integrating Photoshop output into a medical or engineering imaging system that requires multi‑page TIFF input.
 */
