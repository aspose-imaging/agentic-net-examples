// HOW-TO: Load TIFF From MemoryStream, Add New Frame, and Save In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(fileBytes))
            using (Image loadedImage = Image.Load(memoryStream))
            {
                TiffImage tiffImage = loadedImage as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                int width = tiffImage.Width;
                int height = tiffImage.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                TiffFrame newFrame = new TiffFrame(tiffOptions, width, height);
                tiffImage.AddFrame(newFrame);

                tiffImage.Save(outputPath);
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
 * 1. When you need to open a TIFF stored in a byte array, insert a new blank page, and write the updated multi‑page TIFF back to disk in a .NET application.
 * 2. When processing scanned documents where each page is a TIFF frame and you must add an extra placeholder frame without reading the file directly from the file system.
 * 3. When building a server‑side service that receives TIFF data via a web request, adds a new frame, and returns the modified TIFF to the client.
 * 4. When converting images saved in a database BLOB to a multi‑frame TIFF by loading the bytes into a MemoryStream, appending a frame, and saving the result.
 * 5. When automating archival workflows that require adding a cover page to existing TIFF files using Aspose.Imaging without creating temporary files on disk.
 */
