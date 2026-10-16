// HOW-TO: Overlay Semi Transparent PNG Logo onto BMP Image in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string backgroundPath = "background.bmp";
            string logoPath = "logo.png";
            string outputPath = "output/output.bmp";

            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image bgImg = Aspose.Imaging.Image.Load(backgroundPath))
            using (Aspose.Imaging.Image logoImg = Aspose.Imaging.Image.Load(logoPath))
            {
                var background = (Aspose.Imaging.RasterImage)bgImg;
                var logo = (Aspose.Imaging.RasterImage)logoImg;

                int x = (background.Width - logo.Width) / 2;
                int y = (background.Height - logo.Height) / 2;

                background.Blend(new Aspose.Imaging.Point(x, y), logo, 127);

                var source = new FileCreateSource(outputPath, false);
                var options = new BmpOptions() { Source = source };
                background.Save(outputPath, options);
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
 * 1. When you need to brand product screenshots by placing a semi‑transparent PNG logo at the center of a BMP file using C# and Aspose.Imaging.
 * 2. When you want to generate watermarked BMP assets for a marketing campaign without altering the original image dimensions.
 * 3. When you are preparing a set of legacy BMP icons that require a consistent logo overlay for corporate identity.
 * 4. When you need to programmatically add a centered transparent logo to BMP backgrounds before uploading them to a digital asset management system.
 * 5. When you are automating the creation of branded BMP thumbnails for a Windows desktop application using Aspose.Imaging’s Blend method.
 */
