// HOW-TO: Add JPEG Compressed Frame to Existing TIFF in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = tiff.Width;
                int height = tiff.Height;

                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.TiffJpegRgb);
                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

                Aspose.Imaging.Color[] whitePixels = Enumerable.Repeat(Aspose.Imaging.Color.White, width * height).ToArray();
                newFrame.SavePixels(new Aspose.Imaging.Rectangle(0, 0, width, height), whitePixels);

                tiff.AddFrame(newFrame);
                tiff.Save(outputPath);
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
 * 1. When you need to create a multi‑page TIFF by appending a blank JPEG‑compressed page to an existing document in a C# application.
 * 2. When you want to reduce the file size of a new TIFF page by using JPEG compression while preserving the original image dimensions.
 * 3. When a workflow requires programmatically adding a white background frame to a scanned TIFF and then saving the updated file on the server.
 * 4. When you must generate a TIFF file that contains both original pages and additional generated pages for archival or reporting purposes using Aspose.Imaging for .NET.
 * 5. When you need to automate the insertion of a new frame with custom metadata (e.g., comment tag) into a TIFF stack as part of a document‑processing pipeline.
 */
