// HOW-TO: Blend PNG Logo Onto JPEG Banner At Bottom Right With Alpha 192 In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string bannerPath = "input/banner.jpg";
            string logoPath = "input/logo.png";
            string outputPath = "output/result.jpg";

            if (!File.Exists(bannerPath))
            {
                Console.Error.WriteLine($"File not found: {bannerPath}");
                return;
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage banner = (RasterImage)Image.Load(bannerPath))
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                int x = banner.Width - logo.Width;
                int y = banner.Height - logo.Height;
                Point location = new Point(x, y);
                byte opacity = 192;

                banner.Blend(location, logo, opacity);

                JpegOptions jpegOptions = new JpegOptions()
                {
                    Source = new FileCreateSource(outputPath, false),
                    Quality = 90
                };
                banner.Save(outputPath, jpegOptions);
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
 * 1. When you need to add a semi‑transparent company logo to the corner of a promotional JPEG image for web publishing.
 * 2. When you want to programmatically watermark product photos with a PNG badge while preserving JPEG quality.
 * 3. When you must generate personalized banners that combine a background JPEG with a translucent overlay logo in an automated C# workflow.
 * 4. When you are creating email campaign graphics that require a PNG logo blended onto a JPEG header at a specific opacity.
 * 5. When you need to batch‑process marketing assets, placing a PNG icon on the bottom‑right of each JPEG and saving the result with a defined JPEG quality.
 */
