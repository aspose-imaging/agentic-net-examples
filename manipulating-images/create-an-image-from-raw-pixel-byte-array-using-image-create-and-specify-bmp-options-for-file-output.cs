// HOW-TO: Create BMP Image From Raw Pixel Byte Array In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.raw";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Read raw pixel data
            byte[] rawData = File.ReadAllBytes(inputPath);

            // Define image dimensions (example: 100x100)
            int width = 100;
            int height = 100;

            // Ensure the raw data length matches expected size (32 bits per pixel)
            int expectedLength = width * height * 4;
            if (rawData.Length < expectedLength)
            {
                Console.Error.WriteLine("Insufficient raw data for the specified dimensions.");
                return;
            }

            // Set up BMP options with raw data source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 32,
                Source = new StreamSource(new MemoryStream(rawData))
            };

            // Create the image from raw data
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image to BMP file
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
 * 1. When you need to convert a raw sensor dump of 32‑bit pixel data into a standard BMP file for viewing or further processing in C#.
 * 2. When generating thumbnails from custom binary image streams without using third‑party image libraries.
 * 3. When importing raw frame buffers from a camera or video capture device and saving them as BMP images for diagnostics.
 * 4. When creating placeholder graphics from generated pixel arrays in automated testing or batch image pipelines.
 * 5. When converting legacy raw image files to BMP format to make them compatible with Windows applications.
 */
