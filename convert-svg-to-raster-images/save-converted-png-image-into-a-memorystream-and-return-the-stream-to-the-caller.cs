// HOW-TO: Convert TIFF to PNG and Return MemoryStream in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.tif";
                string outputPath = "output\\converted.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (MemoryStream pngStream = ConvertToPngStream(inputPath))
                {
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        pngStream.Position = 0;
                        pngStream.CopyTo(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static MemoryStream ConvertToPngStream(string inputPath)
        {
            MemoryStream outputStream = new MemoryStream();
            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                image.Save(outputStream, options);
            }
            outputStream.Position = 0;
            return outputStream;
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application receives a multi‑page TIFF from a user and must convert it to a PNG for browser display without creating temporary files.
 * 2. When you need to send the converted PNG directly in an HTTP response or API payload by using a MemoryStream.
 * 3. When processing large batches of images on a server and you want to minimize disk I/O by keeping the PNG data in memory.
 * 4. When you have to embed the PNG into a PDF or Word document that accepts a stream as the image source.
 * 5. When implementing an image preview feature in a desktop or mobile app that loads the PNG from a MemoryStream for faster rendering.
 */
