// HOW-TO: Set JPEG Compression to Baseline and Verify Compatibility in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

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
                    CompressionType = JpegCompressionMode.Baseline
                };
                image.Save(outputPath, jpegOptions);
            }

            // Verify that the saved image uses Baseline compression
            using (Image savedImage = Image.Load(outputPath))
            {
                var jpegImage = savedImage as JpegImage;
                if (jpegImage != null && jpegImage.JpegOptions != null && jpegImage.JpegOptions.CompressionType == JpegCompressionMode.Baseline)
                {
                    Console.WriteLine("Compression type set to Baseline. Compatible with older viewers.");
                }
                else
                {
                    Console.WriteLine("Compression type verification failed.");
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
 * 1. When you need to guarantee that JPEG images open correctly in legacy browsers or older image viewers, you set the compression mode to Baseline.
 * 2. When preparing product photos for email newsletters that must display on all email clients, you convert JPEGs to Baseline compression.
 * 3. When archiving scanned documents as JPEG files for long‑term storage, you use Baseline compression to ensure future compatibility.
 * 4. When generating thumbnails for a mobile app that must work on devices with limited JPEG decoder support, you enforce Baseline compression.
 * 5. When validating a batch of images before uploading to a content management system that rejects progressive JPEGs, you programmatically set and verify Baseline compression.
 */
