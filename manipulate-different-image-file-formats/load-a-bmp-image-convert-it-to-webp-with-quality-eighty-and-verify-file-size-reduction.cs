// HOW-TO: Convert BMP to WebP with Quality 80 and Check Size Reduction in C# (Aspose.Imaging for .NET)
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
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.bmp";
                string outputPath = "output/output.webp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new WebPOptions
                    {
                        Quality = 80
                    };
                    image.Save(outputPath, options);
                }

                long inputSize = new FileInfo(inputPath).Length;
                long outputSize = new FileInfo(outputPath).Length;

                if (outputSize < inputSize)
                {
                    Console.WriteLine($"Success: output file size {outputSize} bytes is smaller than input {inputSize} bytes.");
                }
                else
                {
                    Console.WriteLine($"Warning: output file size {outputSize} bytes is not smaller than input {inputSize} bytes.");
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
 * 1. When you need to shrink large BMP assets for faster web page loading by converting them to WebP with a specific quality setting.
 * 2. When you want to automate batch processing of legacy BMP files into modern WebP format while ensuring the new files are smaller than the originals.
 * 3. When you are building a C# application that must validate that image compression actually reduces file size before uploading to a CDN.
 * 4. When you need to create a server‑side service that receives BMP uploads, compresses them to WebP at 80% quality, and logs whether the compression succeeded.
 * 5. When you are optimizing mobile app resources by converting high‑resolution BMP icons to lightweight WebP images and confirming the size benefit programmatically.
 */
