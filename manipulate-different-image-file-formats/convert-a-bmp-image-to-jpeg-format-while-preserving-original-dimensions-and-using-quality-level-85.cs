// HOW-TO: Convert BMP to JPEG with Quality 85 in C# (Aspose.Imaging for .NET)
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

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.bmp";
                string outputPath = "output/output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };
                    image.Save(outputPath, jpegOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce file size of legacy BMP assets for web delivery while keeping the original dimensions, you can use this C# code with Aspose.Imaging to save them as JPEG at quality 85.
 * 2. When an automated batch process must convert scanned BMP documents to compressed JPEGs for archival storage, the example shows how to load each image and specify a quality level in C#.
 * 3. When a desktop application requires users to export edited BMP graphics as JPEGs with consistent visual quality, the code demonstrates the necessary steps using Aspose.Imaging in .NET.
 * 4. When integrating image conversion into a server‑side service that receives BMP uploads and returns JPEG responses, this snippet provides the C# implementation for preserving dimensions and setting compression quality.
 * 5. When migrating a legacy system that stores product photos as BMP files to a modern format, the example helps developers programmatically convert those images to JPEG with a controlled quality setting in C#.
 */
