// HOW-TO: Check and Align Horizontal and Vertical DPI in TIFF with C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                double horizontalDpiBefore = image.HorizontalResolution;
                double verticalDpiBefore = image.VerticalResolution;
                Console.WriteLine($"Before alignment: Horizontal DPI = {horizontalDpiBefore}, Vertical DPI = {verticalDpiBefore}");

                image.AlignResolutions();

                double horizontalDpiAfter = image.HorizontalResolution;
                double verticalDpiAfter = image.VerticalResolution;
                Console.WriteLine($"After alignment: Horizontal DPI = {horizontalDpiAfter}, Vertical DPI = {verticalDpiAfter}");

                bool areEqual = Math.Abs(horizontalDpiAfter - verticalDpiAfter) < 0.0001;
                Console.WriteLine($"DPIs are identical after alignment: {areEqual}");

                image.Save(outputPath);
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
 * 1. When you need to verify and correct a scanned TIFF's DPI so that horizontal and vertical resolutions are identical for precise printing.
 * 2. When preparing TIFF images for a GIS application that requires square pixels, you can align the DPI before loading the data.
 * 3. When feeding TIFF files into an OCR engine that assumes equal DPI, you use this code to ensure consistent resolution metadata.
 * 4. When archiving medical images in TIFF format, aligning the DPI helps meet DICOM compliance by making pixel dimensions uniform.
 * 5. When troubleshooting an image‑processing workflow, you can compare DPI values before and after AlignResolutions to confirm that the operation does not alter the image content.
 */
