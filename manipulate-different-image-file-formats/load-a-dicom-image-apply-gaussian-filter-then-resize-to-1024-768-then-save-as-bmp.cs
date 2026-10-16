// HOW-TO: Convert DICOM to BMP with Gaussian Blur and Resize in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\input.dcm";
        string outputPath = "output\\output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

                raster.Resize(1024, 768);

                BmpOptions bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application needs to create thumbnail BMP previews of DICOM scans after applying a smoothing filter for faster web display.
 * 2. When a radiology workflow requires converting high‑resolution DICOM files to a standard BMP format while reducing noise and scaling them to 1024×768 for integration into legacy reporting tools.
 * 3. When a research project preprocesses DICOM images by blurring and resizing them before feeding the BMP files into a machine‑learning model that expects fixed‑size inputs.
 * 4. When a hospital’s PACS system must export patient scans as BMPs for compatibility with third‑party diagnostic software that cannot read DICOM directly.
 * 5. When a desktop utility needs to batch‑process DICOM images, apply a Gaussian blur to improve visual clarity, resize them for consistent UI layout, and save the results as BMP files.
 */
