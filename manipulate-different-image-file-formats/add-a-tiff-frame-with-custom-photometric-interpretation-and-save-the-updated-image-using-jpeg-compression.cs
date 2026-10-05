// HOW-TO: Add a New TIFF Frame with RGB Photometric and JPEG Compression in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
        string inputPath = "input.tif";
        string outputPath = "output\\output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int width = tiffImage.ActiveFrame.Width;
                int height = tiffImage.ActiveFrame.Height;

                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Jpeg;
                frameOptions.Photometric = TiffPhotometrics.Rgb;

                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);
                tiffImage.AddFrame(newFrame);

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When you need to append an extra page to an existing multi‑page TIFF while preserving color accuracy using RGB photometric interpretation.
 * 2. When you want to create a TIFF document that combines original images with a newly generated frame and store the whole file using JPEG compression to reduce file size.
 * 3. When a scanning application must add a blank or processed frame to a TIFF stack and ensure the output remains compatible with JPEG‑compressed TIFF viewers.
 * 4. When a medical imaging workflow requires inserting a diagnostic overlay as a separate TIFF frame with specific photometric settings and saving the result efficiently.
 * 5. When a web service generates multi‑page TIFF reports and needs to add a summary page with RGB colors while keeping the overall file size low by using JPEG compression.
 */
