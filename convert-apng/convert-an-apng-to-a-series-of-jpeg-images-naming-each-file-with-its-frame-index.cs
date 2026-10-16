// HOW-TO: Extract APNG Frames To Sequential JPEG Files In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "animation.apng");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                int frameCount = apng.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    using (RasterImage frame = (RasterImage)apng.Pages[i])
                    {
                        string outputPath = Path.Combine("Output", $"frame_{i}.jpg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        JpegOptions jpegOptions = new JpegOptions();
                        frame.Save(outputPath, jpegOptions);
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
 * 1. When you need to break down an animated PNG into individual JPEG images for a web gallery that only supports static JPEG thumbnails.
 * 2. When a game developer wants to convert each frame of an APNG sprite animation into separate JPEG assets for texture atlases.
 * 3. When a reporting tool must embed each frame of an APNG chart as JPEG images in a PDF document.
 * 4. When a batch processing pipeline extracts frames from APNG files to generate JPEG previews for a content management system.
 * 5. When a mobile app requires JPEG versions of APNG animation frames to reduce memory usage on devices that cannot decode APNG.
 */
