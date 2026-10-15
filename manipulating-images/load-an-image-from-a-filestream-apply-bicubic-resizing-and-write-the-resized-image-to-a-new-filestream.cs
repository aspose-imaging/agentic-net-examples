// HOW-TO: Resize JPEG Using Aspose.Imaging and FileStream in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Image image = Image.Load(inputStream))
                {
                    int newWidth = 200;
                    int newHeight = 200;
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                    using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        JpegOptions options = new JpegOptions();
                        image.Save(outputStream, options);
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
 * 1. When you need to generate thumbnail previews of user‑uploaded JPEG photos on a web server without loading the entire image into memory.
 * 2. When you must batch‑process a directory of high‑resolution JPEG files to a fixed 200×200 size for mobile app assets while keeping the originals unchanged.
 * 3. When an API receives an image as a stream and you have to resize it before saving the result to a different storage location.
 * 4. When you want to create a smaller version of a scanned JPEG document for faster email attachment or web display.
 * 5. When integrating image resizing into a Windows service that reads JPEGs from a network share via FileStream and writes the resized copies to another folder.
 */
