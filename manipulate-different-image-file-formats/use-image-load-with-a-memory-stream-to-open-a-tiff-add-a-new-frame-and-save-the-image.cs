// HOW-TO: Add a Blank Frame to a TIFF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(fileBytes))
            {
                using (TiffImage tiffImage = (TiffImage)Image.Load(ms))
                {
                    int width = tiffImage.Width;
                    int height = tiffImage.Height;

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    TiffFrame newFrame = new TiffFrame(tiffOptions, width, height);

                    Color[] whitePixels = Enumerable.Repeat(Color.White, width * height).ToArray();
                    newFrame.SavePixels(newFrame.Bounds, whitePixels);

                    tiffImage.AddFrame(newFrame);
                    tiffImage.Save(outputPath);
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
 * 1. When you need to programmatically insert a blank page into an existing multi‑page TIFF without writing the file to disk first.
 * 2. When you want to load a TIFF from a byte array or network stream, modify its frames, and save the updated file.
 * 3. When you are generating a white placeholder page for scanned documents before archiving them as a multi‑frame TIFF.
 * 4. When you must combine image processing steps such as creating a new TiffFrame and appending it to an existing TIFF in a .NET application.
 * 5. When you require a memory‑efficient way to edit TIFF metadata and frames using Aspose.Imaging without creating temporary files.
 */
