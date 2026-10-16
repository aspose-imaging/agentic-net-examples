// HOW-TO: Convert CMX Image to Progressive JPEG in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive
                };
                cmxImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to display legacy CorelDRAW CMX graphics on web pages that require fast, progressive JPEG loading.
 * 2. When migrating a batch of CMX files to a more widely supported JPEG format for mobile applications.
 * 3. When generating thumbnail previews of CMX drawings that should load incrementally in browsers.
 * 4. When integrating Aspose.Imaging into a document conversion service that outputs progressive JPEGs for a smoother user experience.
 * 5. When automating a workflow that converts CMX artwork to JPEG with progressive compression to reduce perceived load time.
 */
