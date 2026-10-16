// HOW-TO: Convert PNG Image to JPEG with Quality Setting in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversionDemo
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output/output.jpg";

            try
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image using Aspose.Imaging
                // The 'using' statement guarantees proper disposal of the image object
                using var image = Image.Load(inputPath);

                // Prepare JPEG save options (you can customize quality, etc.)
                var jpegOptions = new JpegOptions
                {
                    // Example: set compression quality (0-100)
                    Quality = 90
                };

                // Save the image in JPEG format to the specified output path
                image.Save(outputPath, jpegOptions);
            }
            catch (Exception ex)
            {
                // Any unexpected errors are reported without crashing the application
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce file size of PNG assets by converting them to JPEG for faster web page loading.
 * 2. When a batch process must generate JPEG thumbnails from PNG source images for email attachments.
 * 3. When an application requires saving user‑uploaded PNG pictures as JPEG with a specific compression quality for storage constraints.
 * 4. When migrating a legacy system that only supports JPEG, you can programmatically convert existing PNG files using Aspose.Imaging in C#.
 * 5. When preparing images for print or PDF generation that demand JPEG format with controlled quality, this code automates the conversion.
 */
